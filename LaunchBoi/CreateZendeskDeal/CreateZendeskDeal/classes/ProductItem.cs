using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateZendeskDeal.classes
{
  class ProductItem
  {
    public int quantity { get; set; }
    public Item item { get; set; }

    public ProductItem(Item passed_item, int passed_quant)
    {
      item = passed_item; quantity = passed_quant;
    }


  }
}
