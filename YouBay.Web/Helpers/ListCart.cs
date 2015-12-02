
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YouBay.Domain.Entities;

namespace MVCYoubay2.Helpers
{
    public class ListCart
    {

        public List<Item> Items { get; private set; }

        public static readonly ListCart Instance;

        static ListCart()
        {

            if (HttpContext.Current.Session["MyVirtualCart"] == null)
            {

                Instance = new ListCart();
                Instance.Items = new List<Item>();
                HttpContext.Current.Session["MyVirtualCart"] = Instance;

            }
            else
                Instance = (ListCart)HttpContext.Current.Session["MyVirtualCart"];
        }

        protected ListCart() { }

        public void AddItem(Product prod)
        {

            Boolean iswhat = false;
            // Create a new item to add to the cart


            foreach (Item a in Items)
            {
                if (a.Prod.productId == prod.productId)
                {
                    a.Quantity++;
                    iswhat = true;
                    return;
                }
            }
            if (iswhat == false)
            {

                Item newItem = new Item(prod);
                newItem.Quantity = 1;
                Items.Add(newItem);
            }


        }

        public void setToNUll()
        {
            HttpContext.Current.Session["MyVirtualCart"] = null;
        }
        public void SetLessOneItem(Product produit)
        {

            foreach (Item a in Items)
            {
                if (a.Prod.productId == produit.productId)
                {
                    if (a.Quantity <= 0)
                    {
                        RemoveItem(a.Prod);
                        return;
                    }
                    else
                    {
                        a.Quantity--;
                        return;
                    }

                }
            }

        }

        public void SetItemQuantity(Product Product, int quantity)
        {

            if (quantity == 0)
            {
                RemoveItem(Product);
                return;
            }

            foreach (Item a in Items)
            {
                if (a.Prod.productId == Product.productId)
                {
                    a.Quantity = quantity;
                    return;
                }
            }

        }



        public void RemoveItem(Product Product)
        {

            Item t = null;

            foreach (Item a in Items)
            {

                if (a.Prod.productId == Product.productId)
                {
                    t = a;
                }
            }

            if (t != null)
            {
                Items.Remove(t);
            }

        }


        public float GetSubTotal()
        {
            float? subTotal = 0;
            foreach (Item i in Items)
                subTotal += i.TotalPrice;
            return (float)subTotal;
        }
    }
}