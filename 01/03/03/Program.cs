using System;
using System.Collections.Generic;
namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            FlowerStore flowerStore = new FlowerStore(); //ประกาศตัวแปร
            PrintNumberOfSelectFlower(flowerStore); //ปริ้น ดอกไม้ และเลือกดอกไม้
            Console.ReadLine(); 
        }
        static void PrintNumberOfSelectFlower(FlowerStore flowerStore)
        {
            string selectFlower;
            Console.WriteLine("Select number for buy flower :");
            foreach (string i in flowerStore.flowerList)
            {
                Console.Write((flowerStore.flowerList.IndexOf(i) + 1) + " ");
                Console.WriteLine(i);
            }
            selectFlower = Console.ReadLine();
            AddToCart(selectFlower, flowerStore);// เก็บค่าดอกไม้
            ExitorContinue(flowerStore); // ใส่ตระกร้า หรือ เลือกดอกไม้เพิ่ม
        }

        static void AddToCart(string selectFlower, FlowerStore flowerStore)
        {
            switch (selectFlower)
            {
                case "1"://เพิ่ม Rose
                    flowerStore.addToCart(flowerStore.flowerList[0]);
                    Console.WriteLine("Added " + flowerStore.flowerList[0]); 
                    break;
                case "2"://เพิ่ม Lotus
                    flowerStore.addToCart(flowerStore.flowerList[1]);
                    Console.WriteLine("Added " + flowerStore.flowerList[1]);
                    break;
                default:// พิมอย่างอื่นนอกจาก 1 , 2
                    Console.WriteLine("Not Added to cart. found select number of flower");
                    break;
            }
        }
        static void ExitorContinue(FlowerStore flowerStore)
        {
            Console.WriteLine("You can stop this progress ");
            Console.WriteLine("Type >> exit << for exit or press any key for continue");
            string decide = Console.ReadLine();
            if (decide == "exit") // ออกไป สรุป cart
            {
                Console.WriteLine("Current my cart");
                
                flowerStore.showCart();
            }
            else //ใส่ดอกไม้เพิ่ม
            {
                PrintNumberOfSelectFlower(flowerStore);
            }
        }
    }

    class FlowerStore //ส่วนร้านดอกไม้
    {
        public List<string> flowerList = new List<string>();
        List<string> cart = new List<string>();
        public FlowerStore()
        {
            flowerList.Add("Rose");
            flowerList.Add("Lotus");
        }
        public void addToCart(string name)
        {
            cart.Add(name);
        }

        public void showCart() //รวมของในตระกร้า
        {
            if (cart.Count == 0)
            {
                Console.WriteLine("Cart is empty");
            }
            else
            {
                Console.Write("My Cart :");
                foreach (string i in cart)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
