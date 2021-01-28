using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class CartModel
    {
        private List<BookModel> items = new List<BookModel>();

        public void AddItem(BookModel model)
        {
            BookModel book = items
                .FirstOrDefault(x => x.Id == model.Id);

            if (book == null)
            {
                items.Add(model);
            }
        }

        public void RemoveItem(BookModel model)
        {
            items.RemoveAll(x => x.Id == model.Id);
        }

        public decimal ComputeTotalValue()
        {
            return items.Sum(x => x.Price);

        }
        public void Clear()
        {
            items.Clear();
        }

        //public IEnumerable<CartLine> Lines
        //{
        //    get { return lineCollection; }
        //}


    }
}