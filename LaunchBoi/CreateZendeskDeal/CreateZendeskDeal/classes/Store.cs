/// <summary>
/// Simples Structure to keep a list of stores that will each contain a list of items associate with them.
/// </summary>

namespace CreateZendeskDeal
{
  class Store
  {
    public StoreOrderObject Orders { get; set; }
    public int storeId { get; set; }
    public string storeName { get; set; }
    public int contactId { get; set; }

    public Store(int passed_id, string store_name, int contact_id)
    {
      storeName = store_name;
      storeId = passed_id;
      contactId = contact_id;
    }
  }
}
