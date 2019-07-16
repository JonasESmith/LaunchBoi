
using CreateZendeskDeal.classes;

namespace CreateZendeskDeal
{
  /// this will create a basic item that will store the corresponding values for the created zendesk deals
  ///     When this is created it will need to have an associated deal, order, and a shipstatin order that
  ///     is passed and stored within a local json file that I can parse to do reports on.
  class CreatedZendeskDeal
  {

    public CreatedZendeskDeal(ZendeskOrderToAdd zen_Order, ZendeskDeal zen_Deal, Orders ss_Orders)
    {
      zenOrder  =  zen_Order;
      zenDeal   =  zen_Deal;
      ssOrder   =  ss_Orders;
    }

    // represents the zenorder that is associated with the shipstation order.
    public ZendeskOrderToAdd zenOrder { get; set; }
    // represents the zendeal that is associate with the shipstation order when created. 
    public ZendeskDeal zenDeal { get; set; }
    // represent the shipstation order 
    public  Orders ssOrder { get; set; }

  }
}
