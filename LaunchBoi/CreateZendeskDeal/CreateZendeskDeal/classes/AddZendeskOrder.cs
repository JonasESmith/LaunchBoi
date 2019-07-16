

namespace CreateZendeskDeal
{

  public class AddZendeskOrder
  {
    public AddZendeskOrder()
    {
      data = new AddZendeskData();
      meta = new AddZendeskMeta();
    }

    public AddZendeskData data { get; set; }
    public AddZendeskMeta meta { get; set; }
  }

  public class AddZendeskData
  {
    public int deal_id { get; set; }
    public int discount { get; set; }
  }

  public class AddZendeskMeta
  {
    public string type { get; set; }
  }

}
