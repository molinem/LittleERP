using ERP.Dominio.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Dominio
{
    class Product
    {
        //------------------------------------Attributes----------------------------------
        private int idProduct { get; set; }
        private String name { get; set; }
        private int refComposition { get; set; }
        private int refSizes { get; set; }
        private double price{ get; set; }
        private int amount { get; set; }

        private static ManagerProduct g;

        //------------------------------------Constructors--------------------------------
        public Product(int idProduct, String name, int refComposition, int refSizes, double price, int amount)
        {
            this.idProduct = idProduct;
            this.name = name;
            this.refComposition = refComposition;
            this.refSizes = refSizes;
            this.price = price;
            this.amount = amount;
        }

        public Product(String name, int refComposition, int refSizes, double price, int amount)
        {
            this.name = name;
            this.refComposition = refComposition;
            this.refSizes = refSizes;
            this.price = price;
            this.amount = amount;
        }

        public Product(int idProduct,String name, double price, int amount)
        {
            this.idProduct = idProduct;
            this.name = name;
            this.price = price;
            this.amount = amount;
        }

        public static ManagerProduct manager()
        {
            if (g == null)
                g = new ManagerProduct();

            return g;
        }

        //-----------------------------------Getters-----------------------------------
        public int getIdProduct()
        {
            return idProduct;
        }

        public String getName()
        {
            return name;
        }

        public int getRefComposition()
        {
            return refComposition;
        }

        public int getRefSize()
        {
            return refSizes;
        }

        public double getPrice()
        {
            return price;
        }


        public int getAmount()
        {
            return amount;
        }

        //-----------------------------------Setters-----------------------------------
        public void setIdProduct(int idProduct)
        {
            this.idProduct = idProduct;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public void setRefComposition(int refComposition)
        {
            this.refComposition = refComposition;
        }

        public void setRefSize(int refSize)
        {
            this.refSizes = refSize;
        }

        public void setPrice(float price)
        {
            this.price = price;
        }

        public void setAmount(int amount)
        {
            this.amount = amount;
        }

        //-----------------------------------Methods-----------------------------------
        public void readAll()
        {
            g.readAllProducts();
        }

        public void search()
        {
            g.readProduct(this);
        }

        public void modify()
        {
            g.modifyProduct(this);
        }

    }
}
