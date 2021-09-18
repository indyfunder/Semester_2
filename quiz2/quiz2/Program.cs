using System;

namespace quiz2
{
    class Program
    {
        static void Main(string[] args)
        {
            int NumRose, NumSunflower;
            Console.Write("Input total Rose :");
            NumRose = int.Parse(Console.ReadLine());
            Console.Write("Input total Sunflower :");
            NumSunflower = int.Parse(Console.ReadLine());
            PrintRose();
            PrintSunflower();

        }
        static void PrintRose()
        {
            int id,Number;
            string name, description, height, Circumference;

            id = int.Parse(Console.ReadLine());
            Console.Write("ID:{0}", id);
            name = Console.ReadLine();
            Console.Write("Plant name:{0}", name);
            description = Console.ReadLine();
            Console.Write("Plant description:{0}", description);
            Number = int.Parse(Console.ReadLine());
            Console.Write("Amount:{0}", Number);
            height = Console.ReadLine();
            Console.Write("Height:{0}",height);
            Circumference = Console.ReadLine();
            Console.Write("Circumference:{0}", Circumference);

        }
        static void PrintSunflower()
        {
            int id, Number;
            string name, description, height, Circumference;

            id = int.Parse(Console.ReadLine());
            Console.Write("ID:{0}", id);
            name = Console.ReadLine();
            Console.Write("Plant name:{0}", name);
            description = Console.ReadLine();
            Console.Write("Plant description:{0}", description);
            Number = int.Parse(Console.ReadLine());
            Console.Write("Amount:{0}", Number);
            height = Console.ReadLine();
            Console.Write("Height:{0}", height);
            Circumference = Console.ReadLine();
            Console.Write("Circumference:{0}", Circumference);
        }

        class Rose
        {
            public string NameRose;
            private int totalRose = 0;
            public void TotalRose(int NumRose)
            {
                this.totalRose = this.totalRose + NumRose;
            }

            public int GetTotalRose()
            {
                return this.totalRose;
            }
        }
        class Sunflower
        {
            public string NameSunflower;
            private int totalSunflower = 0;
            public void TotalRose(int NumSunflower)
            {
                this.totalSunflower = this.totalSunflower + NumSunflower;
            }

            public int GetTotalRose()
            {
                return this.totalSunflower;
            }
        }
    }
}
