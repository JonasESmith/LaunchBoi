using System;

public class ZendeskDeal
{
  public Data data { get; set; }
  public Meta meta { get; set; }
}

public class ZenDealData
{
  public int id { get; set; }
  public int creator_id { get; set; }
  public int owner_id { get; set; }
  public string name { get; set; }
  public string value { get; set; }
  public string currency { get; set; }
  public bool hot { get; set; }
  public int stage_id { get; set; }
  public DateTime last_stage_change_at { get; set; }
  public int last_stage_change_by_id { get; set; }
  public DateTime last_activity_at { get; set; }
  public int source_id { get; set; }
  public object loss_reason_id { get; set; }
  public object unqualified_reason_id { get; set; }
  public string dropbox_email { get; set; }
  public int contact_id { get; set; }
  public int organization_id { get; set; }
  public object estimated_close_date { get; set; }
  public string[] tags { get; set; }
  public Custom_Fields custom_fields { get; set; }
  public DateTime created_at { get; set; }
  public DateTime updated_at { get; set; }
}

public class Custom_Fields
{
  public string website { get; set; }
}

public class ZenDealMeta
{
  public string type { get; set; }
}

