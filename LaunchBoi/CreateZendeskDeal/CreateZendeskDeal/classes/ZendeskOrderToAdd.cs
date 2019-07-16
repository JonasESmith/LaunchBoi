using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Basic classes for the return information on a zendesk order
/// </summary>
namespace CreateZendeskDeal.classes
{

  public class ZendeskOrderToAdd
  {
    public Meta meta { get; set; }
    public Data data { get; set; }
  }

  public class Meta
  {
    public string type { get; set; }
  }

  public class Data
  {
    public int id { get; set; }
    public int deal_id { get; set; }
    public DateTime updated_at { get; set; }
    public DateTime created_at { get; set; }
    public int discount { get; set; }
  }
}
