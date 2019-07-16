/// 
/// PROGRAMMER    : JONAS SMITH
/// Purpose       : This application will take a look at shipstation and based on the store that the order come from
///                    then it will create a deal with this information.
/// DOCUMENTATION : https://shipstation.docs.apiary.io/#reference/products/list-products/list-stores
///                 https://developers.getbase.com/docs/rest/articles/oauth2/introduction
///                 https://helloworks.zendesk.com/hc/en-us/articles/360012556832-API-Request-Examples-in-C-NET - restSharp
///                 

using System;
using RestSharp;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using CreateZendeskDeal.classes;
using System.Collections.Generic;

namespace CreateZendeskDeal
{
  class Program
  {
    public static ShipStationProducts      ShipStationProductCatalog = new ShipStationProducts();
    public static List<CreatedZendeskDeal> CreatedZendeskDealsList   = new List<CreatedZendeskDeal>();
    public static List<Item>               ZenProductCatalog         = new List<Item>();
    public static string                   path                      = AppDomain.CurrentDomain.BaseDirectory + "CreatedZendeskDeals.json";

    const int HSWID = 704464;
    const int RitID = 675351;
    const int FTSID = 752594;
    const int CBD6ID = 294182;

    // This can be hardcoded as it will not change unless I want it to for now.
    // creates storeList used to determine the storeID, StoreName, and ContactId
    public static List<Store> storeList = new List<Store>() { 
              new Store( HSWID, "HS WholeSale",    235377398 ), 
              new Store( RitID, "Ritual",          235377418 ),
              new Store( FTSID, "420 Beast",       240092783 ),
              // new Store( CBDID, "CBD Retail Club", 000000000 ),
     };

    static void Main()
    {
      ZenProductCatalog         = ReturnAllProductsFromZendesk();
      ShipStationProductCatalog = ReturnAllProductsFromShipStationAsync();

      CreateProductsInZendeskIfNewFromShipStation();

      if (CreateProductsInZendeskIfNewFromShipStation())
        ZenProductCatalog = ReturnAllProductsFromZendesk();

      LoadZendeskDealsCreated();
      LoadShipstationOrdersIntoStoreListAsync(storeList);

      // itereate through each store and its values
      for (int storeIndex = 0; storeIndex < storeList.Count; storeIndex++)
        // foreach order associate with a store check if a deal needs to be made.
        for (int orderIndex = 0; orderIndex < storeList[storeIndex].Orders.total; orderIndex++) {
          // Checks the shipstation order Id to determine if it correspondes to any shipstation orderID that has already been processed.
          bool _doesExist = CreatedZendeskDealsList.Any(item => item.ssOrder.orderId == storeList[storeIndex].Orders.orders[orderIndex].orderId);

          if (_doesExist == false) {
            ZendeskDeal Deal              = CreateNewZendeskDeal(storeList[storeIndex].Orders.orders[orderIndex], storeIndex);
            ZendeskOrderToAdd Order       = GetZendeskOrder(Deal.data.id);
            List<ProductItem> productList = ConvertShipstationItemsToZendeskProducts(storeList[storeIndex].Orders.orders[orderIndex].items);
            bool _isAddAllItems           = AddAllShipStationItemsToZendeskOrder(productList, Order.data.id);
            if (_isAddAllItems) {
              CreatedZendeskDealsList.Add(new CreatedZendeskDeal(Order, Deal, storeList[storeIndex].Orders.orders[orderIndex]));
              Console.WriteLine("{0} - Created new Zendesk deal {1}", DateTime.Now.ToString(), Deal.data.id);
            }
          }
        }

      SaveCreatedZendeskDealsToJson();
    }

    /// <summary>
    /// Saves the current CreatedZendeskDeals to a local .json file
    /// </summary>
    public static void SaveCreatedZendeskDealsToJson()
    {
      var json = JsonConvert.SerializeObject(CreatedZendeskDealsList);
      File.WriteAllText(path, json);
    }

    /// <summary>
    /// Loads all current CreatedZendeskDeals from a local .json file
    /// </summary>
    public static void LoadZendeskDealsCreated()
    {

      if (File.Exists(path)) {
        string jsonString       = File.ReadAllText(path);
        CreatedZendeskDealsList = JsonConvert.DeserializeObject<List<CreatedZendeskDeal>>(jsonString);
      }
      else
        CreatedZendeskDealsList = new List<CreatedZendeskDeal>();
    }

    /// <summary>
    /// Loops through all items in the passed list in order to add the products to the zendesk order associated through order.id
    /// </summary>
    /// <param name="productLists"></param>
    /// <param name="order"></param>
    /// <returns></returns>
    public static bool AddAllShipStationItemsToZendeskOrder( List<ProductItem> productLists , int orderId)
    {
      int count = 0;

      try {

        for (int i = 0; i < productLists.Count; i++) {
          ZendeskLineItem lineItem  =  new ZendeskLineItem();
          lineItem.data.product_id  =  productLists[i].item.data.id;
          lineItem.data.value       =  productLists[i].item.data.prices[0].amount;
          lineItem.data.currency    =  productLists[i].item.data.prices[0].currency;
          lineItem.data.variation   =  "0.00";
          lineItem.data.quantity    =  productLists[i].quantity;
          lineItem.meta.type        =  "line_item";
          var client                = new RestClient() { BaseUrl = new Uri("https://api.getbase.com/v2/") };
          var request = new RestRequest(string.Format("https://api.getbase.com/v2/orders/{0}/line_items", orderId), Method.POST)
                                       { RequestFormat = DataFormat.Json, JsonSerializer = new RestSharpJsonNetSerializer()};

          request.AddHeader("Accept", "application/json")
                 .AddHeader("Content-Type", " application/json")
                 .AddHeader("Authorization", "Bearer 569ff471e1fb35bdb0f86e0a521e456ae5d45912947ce1c9514946e2446a3bf0");

          request.AddJsonBody(lineItem);

          var response = client.Execute(request);

          // if the response does not contain error
          if (!response.Content.Contains("Error"))
            count++;
        }

        // all items were added properly
        if (count == productLists.Count)
          return true;

      }
      catch (Exception)
      {
        throw;
      }

      return false;
    }


    /// <summary>
    /// Converts shipsation items to zendesk products and returns a list
    /// </summary>
    /// <param name="items"></param>
    /// <returns></returns>
    public static List<ProductItem> ConvertShipstationItemsToZendeskProducts(Items[] items)
    {

      List< ProductItem > itemList = new List<ProductItem>();

      // for each product in the list for this order
      for(int i = 0; i < items.Length; i++) {
        
        // return the first skud item that respresents the sku from the product list
        Item skuItem  = ZenProductCatalog.FirstOrDefault(item => item.data.sku == items[i].sku);
        if(skuItem != null)  {
          // add it to a list that we will return
          itemList.Add(new ProductItem( skuItem, items[i].quantity ));
        }
      }

      // return the list 
      return itemList;
    }

    /// <summary>
    /// Returns the zendesk order associated with the Deal_Id that is passed.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static ZendeskOrderToAdd GetZendeskOrder(int id)
    {

      ZendeskOrderToAdd order;

      var client             = new RestClient();
      client.BaseUrl         = new Uri("https://api.getbase.com/v2/");
      var request            = new RestRequest("https://api.getbase.com/v2/orders", Method.GET) { RequestFormat = DataFormat.Json };
      request.JsonSerializer = new RestSharpJsonNetSerializer();
      request.AddHeader("Accept", "application/json")
             .AddHeader("Authorization", "Bearer 569ff471e1fb35bdb0f86e0a521e456ae5d45912947ce1c9514946e2446a3bf0")
             .AddParameter("deal_id", id);

      var respose = client.Execute(request);
      order       = JsonConvert.DeserializeObject<ZendeskOrderToAdd>(respose.Content);

      if (order.data == null)
        order = JsonConvert.DeserializeObject<ZendeskOrderToAdd> ( CreateZendeskOrder(id) );

      return order;
    }

    /// <summary>
    /// Creates a Zendesk Order if an order is not associated with it.
    /// </summary>
    /// <param name="deal_id"></param>
    /// <returns></returns>
    public static string CreateZendeskOrder(int deal_id)
    {
      var client               = new RestClient();
      client.BaseUrl           = new Uri("https://api.getbase.com/v2/");
      AddZendeskOrder zenOrder = new AddZendeskOrder();

      zenOrder.data.deal_id    = deal_id;
      zenOrder.data.discount   = 0;
      zenOrder.meta.type       = "order";

      var request = new RestRequest("https://api.getbase.com/v2/orders", Method.POST) { RequestFormat = DataFormat.Json };

      request.JsonSerializer = new RestSharpJsonNetSerializer();

      request.AddHeader("Accept", "application/json")
             .AddHeader("Content-Type", "application/json")
             .AddHeader("Authorization", "Bearer 569ff471e1fb35bdb0f86e0a521e456ae5d45912947ce1c9514946e2446a3bf0")
             .AddJsonBody(zenOrder);

      var response = client.Execute(request);

      return response.Content;
    }

    /// <summary>
    /// Creates new ZendeskProduct with the ShipStationProduct object passed.
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    public static Item CreateNewZendeskProduct(SSProduct product)
    {
      ZendeskNewProduct newProduct = new ZendeskNewProduct();

      newProduct.data.name           = product.name;
      newProduct.data.sku            = product.sku;
      newProduct.data.description    = "product " + product.name;
      newProduct.data.active         = product.active;
      newProduct.data.prices         = new NewProductPrice[] { new NewProductPrice(product.price.ToString(), "USD") };
      newProduct.data.cost           =  product.price.ToString();
      newProduct.data.cost_currency  = "USD";
      newProduct.data.max_discount   = 10;
      newProduct.meta.type           = "product";


      var client  = new RestClient() { BaseUrl = new Uri("https://api.getbase.com/v2/") };
      var request = new RestRequest("https://api.getbase.com/v2/products", Method.POST) { RequestFormat = DataFormat.Json };
      request.JsonSerializer = new RestSharpJsonNetSerializer();

      request.AddHeader("Accept",        "application/json")
             .AddHeader("Content-Type",  "application/json")
             .AddHeader("Authorization", "Bearer 569ff471e1fb35bdb0f86e0a521e456ae5d45912947ce1c9514946e2446a3bf0");
      request.AddJsonBody(newProduct);

      var respose = client.Execute(request);

      return JsonConvert.DeserializeObject<Item>(respose.Content);
    }


    /// <summary>
    /// Foreach item in the shipstationProductCatalog, if the shipstationProductCatalog does not match to a sku we create a new product in zendesk.
    /// </summary>
    /// <returns></returns>
    public static bool CreateProductsInZendeskIfNewFromShipStation()
    {
      bool _reloadZenProductCatalog = false;

      for (int index = 0; index < ShipStationProductCatalog.products.Length; index++) {

        bool _doesExist = ZenProductCatalog.Any(item => item.data.sku == ShipStationProductCatalog.products[index].sku);

        if (!_doesExist) {
          CreateNewZendeskProduct(ShipStationProductCatalog.products[index]);
          _reloadZenProductCatalog = true;
        }
      }

      return _reloadZenProductCatalog;

    }


    /// <summary>
    /// Foreach store that is passed into storelist we fetch the orders that correspond in shipstation
    /// </summary>
    /// <param name="storeList"></param>
    /// <returns></returns>
    public static void LoadShipstationOrdersIntoStoreListAsync( List<Store> storeList )
    {
      // foreach store create a list of the orders associate with it. 
      for (int index = 0; index < storeList.Count; index++) {

        // retreive all shipstation orders from associated store
        storeList[index].Orders = GetShipStationOrdersForStore(storeList[index].storeId);
      }
    }


    /// <summary>
    /// Creates a new zendesk deal with the passedOrder and the storeIndex for the storelist array and return .json format with exit code
    /// </summary>
    /// <param name="passedOrder"></param>
    /// <param name="storeIndex"></param>
    /// <returns></returns>
    public static ZendeskDeal CreateNewZendeskDeal(Orders passedOrder, int storeIndex)
    {
      AddZendeskDeal zenDeal     = new AddZendeskDeal();
      int            wonStageId  = 8471402;

      zenDeal.data.hot                   = false;
      string[] tagArray                  = { "important" };
      zenDeal.data.name                  = storeList[storeIndex].storeName + 
                                            " - " + passedOrder.orderNumber;
      zenDeal.meta.type                  = "deal";
      zenDeal.data.tags                  = tagArray;
      zenDeal.data.value                 = passedOrder.orderTotal.ToString();
      zenDeal.data.stage_id              = wonStageId;
      zenDeal.data.contact_id            = storeList[storeIndex].contactId;
      zenDeal.data.custom_fields.website = "No store link";

      var client               = new RestClient() { BaseUrl = new Uri("https://api.getbase.com/v2/") };
      var request              = new RestRequest("https://api.getbase.com/v2/deals", Method.POST) { RequestFormat = DataFormat.Json};
      request.JsonSerializer   = new RestSharpJsonNetSerializer();

      request.AddHeader("Accept", "application/json")
             .AddHeader("Content-Type", " application/json")
             .AddHeader("Authorization", "Bearer 569ff471e1fb35bdb0f86e0a521e456ae5d45912947ce1c9514946e2446a3bf0");
      request.AddJsonBody(zenDeal);

      var respose = client.Execute(request);

      return JsonConvert.DeserializeObject<ZendeskDeal>(respose.Content);
    }

    static StoreOrderObject GetShipStationOrdersForStore(int storeId)
    {
      var client = new RestClient() { BaseUrl = new Uri("https://ssapi.shipstation.com/") };
      var request = new RestRequest(string.Format("https://ssapi.shipstation.com/orders?storeId={0}&createDateStart={1}", storeId, DateTime.Now.ToShortDateString()), Method.GET) { RequestFormat = DataFormat.Json };
      request.JsonSerializer = new RestSharpJsonNetSerializer();

      request.AddHeader("Accept", "application/json")
             .AddHeader("Authorization", "Basic MDJjMGJmY2Y2MjA3NDk1NzgyNmFjYmY3MTE4MzZmOWU6N2JiYmU3Y2UzZDQzNDMxZWFlZjMwNDdlNjQ1MTg1NmY=");

      var response = client.Execute(request);

      return JsonConvert.DeserializeObject<StoreOrderObject>(response.Content);
    }


    /// <summary>
    /// Returns all products from Zendesk 
    /// </summary>
    /// <returns></returns>
    public static List<Item> ReturnAllProductsFromZendesk()
    {
      List<Item> productList  = new List<Item>();
      bool        iterate     = true;
      int         numPerPage  = 100;
      int         pageCount   = 1;

      do {
        Products productQuerry = GetZendeskProducts(pageCount, numPerPage);
        for (int i = 0; i < productQuerry.items.Length; i++)
          productList.Add(productQuerry.items[i]);
        if (productQuerry.items.Length != numPerPage)
          iterate = false;
        pageCount++; } while (iterate);

      return productList;
    }


    /// <summary>
    /// Gets the maximum amount of orders from Zendesk in .json format
    /// </summary>
    /// <param name="page_number"></param>
    /// <param name="number_per_page"></param>
    /// <returns></returns>
    public static Products GetZendeskProducts(int page_number, int number_per_page)
    {
      var client     = new RestClient();
      client.BaseUrl = new Uri("https://api.getbase.com/v2");
      var request    = new RestRequest("https://api.getbase.com/v2/products", Method.GET)
                        .AddParameter("page", page_number)
                        .AddParameter("per_page", number_per_page)
                        .AddHeader("Accept", "application/json")
                        .AddHeader("Authorization", "Bearer 569ff471e1fb35bdb0f86e0a521e456ae5d45912947ce1c9514946e2446a3bf0");

      var response = client.Execute(request);

      return JsonConvert.DeserializeObject<Products>(response.Content);
    }

    static ShipStationProducts ReturnAllProductsFromShipStationAsync()
    {
      var client             = new RestClient() { BaseUrl = new Uri("https://ssapi.shipstation.com/") };
      var request            = new RestRequest("https://ssapi.shipstation.com/products", Method.GET) { RequestFormat = DataFormat.Json };
      request.JsonSerializer = new RestSharpJsonNetSerializer();

      request.AddHeader("Accept", "application/json")
             .AddHeader("Authorization", "Basic MDJjMGJmY2Y2MjA3NDk1NzgyNmFjYmY3MTE4MzZmOWU6N2JiYmU3Y2UzZDQzNDMxZWFlZjMwNDdlNjQ1MTg1NmY=");

      var respose = client.Execute(request);

      return JsonConvert.DeserializeObject<ShipStationProducts>(respose.Content);
    }
  }
}
