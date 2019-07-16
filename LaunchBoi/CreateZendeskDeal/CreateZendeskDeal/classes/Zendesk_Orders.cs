using System;

public class Zendesk_Orders
{
  public ZenOrderItem[] items { get; set; }
  public ZenOrderMeta meta { get; set; }
}

public class ZenOrderMeta
{
  public string type { get; set; }
  public int count { get; set; }
  public ZenOrderLinks links { get; set; }
}

public class ZenOrderLinks
{
  public string self { get; set; }
}

public class ZenOrderItem
{
  public ZenOrderData data { get; set; }
  public ZenOrderMeta1 meta { get; set; }
}

public class ZenOrderData
{
  public int id { get; set; }
  public int deal_id { get; set; }
  public int discount { get; set; }
  public DateTime created_at { get; set; }
  public DateTime updated_at { get; set; }
}

public class ZenOrderMeta1
{
  public string type { get; set; }
}
