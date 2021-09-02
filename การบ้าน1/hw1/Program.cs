using System;
using System.Collections.Generic;

namespace hw1
{
    class Tshirt
    {
        public string size;
        public string color;
        public float price;
        public string image;

        public Tshirt(string valueSize, string valueColor, float valuePrice, string valueImage)
        {
            size = valueSize;
            color = valueColor;
            price = valuePrice;
            image = valueImage;
        }
    }
    class User
    {
        public string name;
        public string email;
        public ShoppingCart ShoppingCart;

        public User(string valueName, string valueEmail, ShoppingCart valueShoppingCart)
        {
            name = valueName;
            email = valueEmail;
            ShoppingCart = valueShoppingCart;
        }
    }
    class ShoppingCart
    {
        private List<Tshirt> orderTShirt;
        public float Total_cost = 0;
        public Address Address;

        public ShoppingCart(Address valueAddress)
        {
            Address = valueAddress;
            orderTShirt = new List<Tshirt>();
        }
        public void TotalCost()
        {
            foreach (Tshirt tshirt in orderTShirt)
            {
                Total_cost += tshirt.price;
            }
            Console.WriteLine("Total Cost: {0} Bath", Total_cost);
        }
        public void AddTSHIRT(Tshirt tshirt)
        {
            orderTShirt.Add(tshirt);
        }
    }
    class Address
    {
        public string street;
        public string city;
        public string zipCode;

        public Address(string valueStreet, string valueCity, string valueZipCode)
        {
            street = valueStreet;
            city = valueCity;
            zipCode = valueZipCode;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Tshirt> OrderTshirt = new List<Tshirt>();
            //
            Tshirt tshirt1 = new Tshirt("L", "Red", 500f, "00");
            Tshirt tshirt2 = new Tshirt("M", "Black", 750f, "01");
            Tshirt tshirt3 = new Tshirt("S", "Yellow", 625f, "02");
            //
            OrderTshirt.Add(tshirt1);
            OrderTshirt.Add(tshirt2);
            OrderTshirt.Add(tshirt3);
            //
            Address JameAddress = new Address("131/75 Phutthamonthon Road","Nakhon Pathom", "10180");
            //
            ShoppingCart ShopPingCart = new ShoppingCart(JameAddress);
            //
            User jame = new User("jame watson", "jame@gmail.com", ShopPingCart);
            //
            jame.ShoppingCart.AddTSHIRT(tshirt1);
            jame.ShoppingCart.AddTSHIRT(tshirt2);
            jame.ShoppingCart.AddTSHIRT(tshirt3);
            //
            foreach (Tshirt shoppingCart in OrderTshirt)
            {
                Console.WriteLine("Size: {0}", shoppingCart.size);
                Console.WriteLine("Color: {0}", shoppingCart.color);
                Console.WriteLine("Price: {0} bath", shoppingCart.price);
                Console.WriteLine("Image: {0}", shoppingCart.image);
                Console.Write("\n");
            }
            //
            Console.WriteLine("Name: {0}", jame.name);
            Console.WriteLine("Email: {0}", jame.email);
            Console.WriteLine("Address");
            Console.WriteLine("{0},{1},{2}",JameAddress.street, JameAddress.city, JameAddress.zipCode);
            Console.Write("\n");
            jame.ShoppingCart.TotalCost();
            Console.Write("\n");

            Console.ReadLine();
        }
       
    }
    
}
