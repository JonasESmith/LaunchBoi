using System;

public class ZendeskOrder
{
  public OrderItem[] items { get; set; }
  public OrderMeta meta { get; set; }
}

public class OrderMeta
{
  public int count { get; set; }
  public string type { get; set; }
  public OrderLinks links { get; set; }
}

public class OrderLinks
{
  public string self { get; set; }
}

public class OrderItem
{
  public OrderMeta1 meta { get; set; }
  public OrderData data { get; set; }
}

public class OrderMeta1
{
  public string type { get; set; }
}

public class OrderData
{
  public int id { get; set; }
  public int deal_id { get; set; }
  public DateTime updated_at { get; set; }
  public DateTime created_at { get; set; }
  public int discount { get; set; }
}
