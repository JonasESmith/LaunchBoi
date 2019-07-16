using System;

/// <summary>
/// Gets the products from shipstation associated with our store
/// </summary>

namespace CreateZendeskDeal.classes
{

  public class ShipStationProducts
  {

    public SSProduct[] products { get; set; }
    public int total { get; set; }
    public int page { get; set; }
    public int pages { get; set; }
  }

  public class SSProduct
  {
    public object aliases { get; set; }
    public int productId { get; set; }
    public string sku { get; set; }
    public string name { get; set; }
    public double price { get; set; }
    public int? defaultCost { get; set; }
    public double? length { get; set; }
    public double? width { get; set; }
    public double? height { get; set; }
    public double? weightOz { get; set; }
    public object internalNotes { get; set; }
    public string fulfillmentSku { get; set; }
    public DateTime? createDate { get; set; }
    public DateTime? modifyDate { get; set; }
    public bool active { get; set; }
    public SSProductcategory productCategory { get; set; }
    public object productType { get; set; }
    public string warehouseLocation { get; set; }
    public string defaultCarrierCode { get; set; }
    public string defaultServiceCode { get; set; }
    public string defaultPackageCode { get; set; }
    public string defaultIntlCarrierCode { get; set; }
    public string defaultIntlServiceCode { get; set; }
    public string defaultIntlPackageCode { get; set; }
    public string defaultConfirmation { get; set; }
    public string defaultIntlConfirmation { get; set; }
    public string customsDescription { get; set; }
    public int? customsValue { get; set; }
    public string customsTariffNo { get; set; }
    public string customsCountryCode { get; set; }
    public object noCustoms { get; set; }
    public SSTag[] tags { get; set; }
  }

  public class SSProductcategory
  {
    public int categoryId { get; set; }
    public string name { get; set; }
  }

  public class SSTag
  {
    public int tagId { get; set; }
    public string name { get; set; }
  }
}



