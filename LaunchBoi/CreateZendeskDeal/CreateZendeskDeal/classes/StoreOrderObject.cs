/// <summary>
///  PURPOSE  : The classes used for creating an backOrderObject
/// </summary>

namespace CreateZendeskDeal
{
  public class StoreOrderObject
  {
    public Orders[] orders { get; set; }
    public int total { get; set; }
    public int page { get; set; }
    public int pages { get; set; }
  }

  public class Orders
  {
    public int orderId { get; set; }
    public string orderNumber { get; set; }
    public string orderKey { get; set; }
    public string orderDate { get; set; }
    public string createDate { get; set; }
    public string modifyDate { get; set; }
    public object paymentDate { get; set; }
    public object shipByDate { get; set; }
    public string orderStatus { get; set; }
    public int? customerId { get; set; }
    public string customerUsername { get; set; }
    public string customerEmail { get; set; }
    public Billto billTo { get; set; }
    public Shipto shipTo { get; set; }
    public Items[] items { get; set; }
    public float orderTotal { get; set; }
    public float amountPaid { get; set; }
    public float taxAmount { get; set; }
    public float shippingAmount { get; set; }
    public string customerNotes { get; set; }
    public object internalNotes { get; set; }
    public bool gift { get; set; }
    public object giftMessage { get; set; }
    public object paymentMethod { get; set; }
    public object requestedShippingService { get; set; }
    public object carrierCode { get; set; }
    public object serviceCode { get; set; }
    public object packageCode { get; set; }
    public string confirmation { get; set; }
    public object shipDate { get; set; }
    public object holdUntilDate { get; set; }
    public Weight weight { get; set; }
    public object dimensions { get; set; }
    public Insuranceoptions insuranceOptions { get; set; }
    public Internationaloptions internationalOptions { get; set; }
    public Advancedoptions advancedOptions { get; set; }
    public int[] tagIds { get; set; }
    public object userId { get; set; }
    public bool externallyFulfilled { get; set; }
    public object externallyFulfilledBy { get; set; }
    public object labelMessages { get; set; }
  }

  public class Billto
  {
    public string name { get; set; }
    public object company { get; set; }
    public object street1 { get; set; }
    public object street2 { get; set; }
    public object street3 { get; set; }
    public object city { get; set; }
    public object state { get; set; }
    public object postalCode { get; set; }
    public object country { get; set; }
    public object phone { get; set; }
    public object residential { get; set; }
    public object addressVerified { get; set; }
  }

  public class Shipto
  {
    public string name { get; set; }
    public string company { get; set; }
    public string street1 { get; set; }
    public string street2 { get; set; }
    public object street3 { get; set; }
    public string city { get; set; }
    public string state { get; set; }
    public string postalCode { get; set; }
    public string country { get; set; }
    public object phone { get; set; }
    public bool residential { get; set; }
    public string addressVerified { get; set; }
  }

  public class Weight
  {
    public float value { get; set; }
    public string units { get; set; }
    public int WeightUnits { get; set; }
  }

  public class Insuranceoptions
  {
    public object provider { get; set; }
    public bool insureShipment { get; set; }
    public float insuredValue { get; set; }
  }

  public class Internationaloptions
  {
    public object contents { get; set; }
    public object customsItems { get; set; }
    public object nonDelivery { get; set; }
  }

  public class Advancedoptions
  {
    public int warehouseId { get; set; }
    public bool nonMachinable { get; set; }
    public bool saturdayDelivery { get; set; }
    public bool containsAlcohol { get; set; }
    public bool mergedOrSplit { get; set; }
    public object[] mergedIds { get; set; }
    public int? parentId { get; set; }
    public int storeId { get; set; }
    public object customField1 { get; set; }
    public object customField2 { get; set; }
    public object customField3 { get; set; }
    public object source { get; set; }
    public object billToParty { get; set; }
    public object billToAccount { get; set; }
    public object billToPostalCode { get; set; }
    public object billToCountryCode { get; set; }
    public object billToMyOtherAccount { get; set; }
  }

  public class Items
  {
    public int? orderItemId { get; set; }
    public object lineItemKey { get; set; }
    public string sku { get; set; }
    public string name { get; set; }
    public object imageUrl { get; set; }
    public Weight1 weight { get; set; }
    public int quantity { get; set; }
    public float unitPrice { get; set; }
    public object taxAmount { get; set; }
    public object shippingAmount { get; set; }
    public object warehouseLocation { get; set; }
    public object[] options { get; set; }
    public int? productId { get; set; }
    public object fulfillmentSku { get; set; }
    public bool adjustment { get; set; }
    public object upc { get; set; }
    public string createDate { get; set; }
    public string modifyDate { get; set; }
  }

  public class Weight1
  {
    public float value { get; set; }
    public string units { get; set; }
    public int WeightUnits { get; set; }
  }
}

