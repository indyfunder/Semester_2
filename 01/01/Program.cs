using System;
using System.Collections.Generic;
using System.Text; 
enum Menu
{
    PlayGame = 1,
    Exit
}
namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            Menuscreen();
            InputMenu();          
            ShowHangManGame();
        }
        static void Menuscreen() //หน้าต่างเมนู
        {
            Console.WriteLine("Welcome to Hangman Game");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("1.Play game");
            Console.WriteLine("2.Exit");
        }
        static void InputMenu() //การเลือก เล่นเกม หรือ ออก
        {
            Console.Write("Please Select Menu: ");
            Menu menu = (Menu)(int.Parse(Console.ReadLine()));

            PresentMenu(menu);
        }
        static void PresentMenu(Menu menu) //ถ้าเลือก เล่นเกม หรือ ออก
        {
            if (menu == Menu.PlayGame)
            {
                ShowHangManGame();//เข้า โปรแกรมเกม
            }
            else
            {
                Environment.Exit(0); // จบโปรแกรม
            }
        }
        static void ShowHangManGame()
        {
            Console.Clear(); // เคลียร์ข้อความเก่า
            HeadGameMenu();

            Random random = new Random((int)DateTime.Now.Ticks);                  //การสุ่มคำศัพท์
            string[] WordsList = { "tennis", "football", "badminton" };
            string wordHangman = WordsList[random.Next(0, WordsList.Length)];  //แปลงคำเป็นarray

            StringBuilder PrintUnderscore = new StringBuilder(wordHangman.Length); 
            for (int i = 0; i < wordHangman.Length; i++)  //การแปลง ตัวอักษรเป็น _
            {
                PrintUnderscore.Append('_');
            }
            int Count_ = wordHangman.Length; //จำนวณ _ ในครั้งแรก
            List<char> CorrectAlphabet = new List<char>();   //เก็บตัวอัษร ไว้ในลิส
            List<char> IncorrectAlphabet = new List<char>();

            int lives = 6, CorrectLetter = 0, IncorrectLetter = 0;


            bool won = false; //เงื่อนไขเข้าลูป
            char inputAlphabet;
            CountUnderscore(Count_); //พิม _ ครั้งแรก
            while (!won && lives != 0 )
            {
                Console.WriteLine("\nInput letter alphabet: ");               
                inputAlphabet = char.Parse(Console.ReadLine()); //รับค่าผู้ใช้ ตอนเล่นเกม
                
                if (wordHangman.Contains(inputAlphabet))//เงื่อนไขเข้าลูป
                {
                    CorrectAlphabet.Add(inputAlphabet);
                    Console.Clear();
                    Console.WriteLine("Play Game Hangman");
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("Incorrect Score: {0}", IncorrectLetter);

                    for (int i = 0; i < wordHangman.Length; i++) //ถ้าตัวอักษรที่ตอบมา มีตัวสะกดถูกอยู่ในคำศัพท์
                    {
                        if (wordHangman[i] == inputAlphabet)
                        {
                            PrintUnderscore[i] = wordHangman[i];
                            CorrectLetter++;
                        }
                    }
                    if (CorrectLetter == wordHangman.Length)
                    {
                        resultwin(); //แสดงผลชนะเหม                 
                    }                                                              
                }
                else
                {
                    IncorrectAlphabet.Add(inputAlphabet); //ถ้าตอบผิด
                    Console.Clear();
                    Console.WriteLine("Play Game Hangman");
                    Console.WriteLine("----------------------------------------");
                    IncorrectLetter++; // บวกแต้มที่ ตอบผิด
                    Console.WriteLine("Incorrect Score: {0}", IncorrectLetter);//แต้มที่ตอบผิด
                    lives--;                
                    if (lives == 0) //ถ้าตอบผิดเกิน 6 ครั้ง
                    {
                        resultlose(); //แสดงผล แพ้เกม
                    }
                }
                Console.WriteLine(PrintUnderscore.ToString());// แสดง _ ตัวที่ถูก เป็นอักษร 
            }        

        }
        
        static void HeadGameMenu() 
        {
            Console.WriteLine("Play Game Hangman");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Incorrect Score: 0");
        }
        
        static void resultwin() //ฟังชั่นชนะเกม
        {         
            Console.WriteLine("You win!!");
            Console.ReadLine();
            Environment.Exit(0);
        }
        static void resultlose()//ฟังชั่นแพ้เกม
        {
            Console.WriteLine("Game Over");
            Console.ReadLine();
            Environment.Exit(0);
        }

        static void CountUnderscore(int Count_) //ฟังชั่นพิม _ ตามจำนวณตัวอักษร
        {
            for (int i = 0; i < Count_; i++)
                Console.Write("_");
        }
    }
}