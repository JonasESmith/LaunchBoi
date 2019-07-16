using System;

public class Contacts
{
  public Contact_Items[] items { get; set; }
  public Contact_Meta meta { get; set; }
}

public class Contact_Meta
{
  public string type { get; set; }
  public int count { get; set; }
  public Contact_Links links { get; set; }
}

public class Contact_Links
{
  public string self { get; set; }
}

public class Contact_Items
{
  public Contact_Data data { get; set; }
  public Contact_Meta1 meta { get; set; }
}

public class Contact_Data
{
  public int id { get; set; }
  public int creator_id { get; set; }
  public int owner_id { get; set; }
  public bool is_organization { get; set; }
  public object contact_id { get; set; }
  public int parent_organization_id { get; set; }
  public string name { get; set; }
  public object first_name { get; set; }
  public object last_name { get; set; }
  public string customer_status { get; set; }
  public string prospect_status { get; set; }
  public object title { get; set; }
  public object description { get; set; }
  public string industry { get; set; }
  public string website { get; set; }
  public object email { get; set; }
  public object phone { get; set; }
  public object mobile { get; set; }
  public string fax { get; set; }
  public object twitter { get; set; }
  public object facebook { get; set; }
  public object linkedin { get; set; }
  public object skype { get; set; }
  public Address address { get; set; }
  public object billing_address { get; set; }
  public object shipping_address { get; set; }
  public string[] tags { get; set; }
  public Contact_Custom_Fields custom_fields { get; set; }
  public DateTime created_at { get; set; }
  public DateTime updated_at { get; set; }
}

public class Address
{
  public string line1 { get; set; }
  public string city { get; set; }
  public string postal_code { get; set; }
  public string state { get; set; }
  public string country { get; set; }
}

public class Contact_Custom_Fields
{
  public string known_via { get; set; }
}

public class Contact_Meta1
{
  public string type { get; set; }
}
