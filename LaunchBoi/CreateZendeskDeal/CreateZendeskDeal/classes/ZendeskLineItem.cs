namespace CreateZendeskDeal.classes
{
  public class ZendeskLineItem
  {


    public LineItemData data { get; set; }
    public LineItemMeta meta { get; set; }


    public ZendeskLineItem()
    {
      data = new LineItemData();
      meta = new LineItemMeta();
    }
  }

  public class LineItemData
  {
    public int product_id { get; set; }
    public string value { get; set; }
    public string currency { get; set; }
    public string variation { get; set; }
    public int quantity { get; set; }
  }

  public class LineItemMeta
  {
    public string type { get; set; }
  }
}

