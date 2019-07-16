using System;


public class ShipStationOrder
{
  public int orderId { get; set; }
  public string orderNumber { get; set; }
  public string orderKey { get; set; }
  public DateTime orderDate { get; set; }
  public DateTime createDate { get; set; }
  public DateTime modifyDate { get; set; }
  public DateTime paymentDate { get; set; }
  public DateTime shipByDate { get; set; }
  public string orderStatus { get; set; }
  public int customerId { get; set; }
  public string customerUsername { get; set; }
  public string customerEmail { get; set; }
  public Billto billTo { get; set; }
  public Shipto shipTo { get; set; }
  public ShipStationOrderItem[] items { get; set; }
  public float orderTotal { get; set; }
  public float amountPaid { get; set; }
  public int taxAmount { get; set; }
  public int shippingAmount { get; set; }
  public string customerNotes { get; set; }
  public string internalNotes { get; set; }
  public bool gift { get; set; }
  public string giftMessage { get; set; }
  public string paymentMethod { get; set; }
  public string requestedShippingService { get; set; }
  public string carrierCode { get; set; }
  public string serviceCode { get; set; }
  public string packageCode { get; set; }
  public string confirmation { get; set; }
  public string shipDate { get; set; }
  public object holdUntilDate { get; set; }
  public Weight weight { get; set; }
  public Dimensions dimensions { get; set; }
  public Insuranceoptions insuranceOptions { get; set; }
  public Internationaloptions internationalOptions { get; set; }
  public Advancedoptions advancedOptions { get; set; }
  public object tagIds { get; set; }
  public object userId { get; set; }
  public bool externallyFulfilled { get; set; }
  public object externallyFulfilledBy { get; set; }
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
  public string phone { get; set; }
  public bool residential { get; set; }
  public string addressVerified { get; set; }
}

public class Weight
{
  public int value { get; set; }
  public string units { get; set; }
}

public class Dimensions
{
  public string units { get; set; }
  public int length { get; set; }
  public int width { get; set; }
  public int height { get; set; }
}

public class Insuranceoptions
{
  public string provider { get; set; }
  public bool insureShipment { get; set; }
  public int insuredValue { get; set; }
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
  public object parentId { get; set; }
  public int storeId { get; set; }
  public string customField1 { get; set; }
  public string customField2 { get; set; }
  public string customField3 { get; set; }
  public string source { get; set; }
  public object billToParty { get; set; }
  public object billToAccount { get; set; }
  public object billToPostalCode { get; set; }
  public object billToCountryCode { get; set; }
}

public class ShipStationOrderItem
{
  public int orderItemId { get; set; }
  public string lineItemKey { get; set; }
  public string sku { get; set; }
  public string name { get; set; }
  public object imageUrl { get; set; }
  public Weight1 weight { get; set; }
  public int quantity { get; set; }
  public float unitPrice { get; set; }
  public object taxAmount { get; set; }
  public object shippingAmount { get; set; }
  public string warehouseLocation { get; set; }
  public Option[] options { get; set; }
  public int? productId { get; set; }
  public object fulfillmentSku { get; set; }
  public bool adjustment { get; set; }
  public object upc { get; set; }
  public DateTime createDate { get; set; }
  public DateTime modifyDate { get; set; }
}

public class Weight1
{
  public int value { get; set; }
  public string units { get; set; }
}

public class Option
{
  public string name { get; set; }
  public string value { get; set; }
}
