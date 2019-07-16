/// Simple Product class to make it easy to import products from zendesk when the application is ran.

using System;

public class Products
{
  public Item[] items { get; set; }
  public Meta meta { get; set; }
}

public class Meta
{
  public int count { get; set; }
  public string type { get; set; }
  public Links links { get; set; }
}

public class Links
{
  public string self { get; set; }
  public string next_page { get; set; }
}

public class Item
{
  public Meta1 meta { get; set; }
  public Data data { get; set; }
}

public class Meta1
{
  public string type { get; set; }
}

public class Data
{
  public int id { get; set; }
  public DateTime updated_at { get; set; }
  public DateTime created_at { get; set; }
  public bool active { get; set; }
  public string description { get; set; }
  public string name { get; set; }
  public string sku { get; set; }
  public Price[] prices { get; set; }
  public object max_discount { get; set; }
  public object max_markup { get; set; }
  public object cost { get; set; }
  public object cost_currency { get; set; }
}

public class Price
{
  public string currency { get; set; }
  public string amount { get; set; }
}
