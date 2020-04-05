using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoLibrary.Models
{
    public class ShoppingCart
    {
        public delegate void MentionDiscount(decimal subTotal);

        public List<Product> Items { get; set; } = new List<Product>();

        public decimal GenerateTotal(MentionDiscount mentionDiscount,
            Func<List<Product>,decimal,decimal> calculateDiscountedTotal,
            Action<string> tellUserWeAreDiscounting)
        {
            decimal subTotal = Items.Sum(x => x.Price);

            mentionDiscount(subTotal);

            tellUserWeAreDiscounting("We are appying your discount.");

            return calculateDiscountedTotal(Items, subTotal);
        }
    }
}
