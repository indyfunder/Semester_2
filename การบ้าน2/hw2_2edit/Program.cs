using System;
using System.Collections.Generic;
enum Menu
{
    Student = 1,
    Teacher
}
enum Day
{
    day_17_Oct = 1,
    day_18_Oct,
    day_19_Oct
}
enum Time
{
    a = 1,
    b,c
}

namespace hw2_2edit
{
    class Program
    {
        static RegistrationInformation List;
        static void Main(string[] args)
        {
            PreparePerson();
            PrintMenuScreen();
            PrintDayScreen();
        }
        static void PreparePerson()
        {
            Program.List = new RegistrationInformation();
        }
        static void ShowGetListPersonScreen()
        {
            Console.Clear();
            Program.List.FetchPersonList();
        }
        static void PrintMenuScreen()
        {
            Console.Clear();
            Header Header = new Header();
            Header.PrintHeader();
            ListMenu listMenu = new ListMenu();
            listMenu.PrintListMenu();
            Console.Write("Please Select Menu: ");
            Menu menu = (Menu)(int.Parse(Console.ReadLine()));

            PresentMenu(menu);
        }
        static void PresentMenu(Menu menu)
        {
            if (menu == Menu.Student)
            {
                ShowInputRegisterStudentScreen();
            }
            else if (menu == Menu.Teacher)
            {
                ShowInputRegisterTeacherScreen();
            }
            else
            {
                PrintTryAgain();
                PrintMenuScreen();
            }
        }
        static void ShowInputRegisterStudentScreen()
        {
            Console.Clear();
            HeaderRegisterStudent headerRegisterStudent = new HeaderRegisterStudent();
            headerRegisterStudent.PrintHeaderRegisterStudent();

            InputForStudentFromKeyboard();
        }
        static void ShowInputRegisterTeacherScreen()
        {
            Console.Clear();
            HeaderRegisterTeacher headerRegisterTeacher = new HeaderRegisterTeacher();
            headerRegisterTeacher.PrintHeaderRegisterTeacher();

            InputForTeacherFromKeyboard();
        }
        static void InputForStudentFromKeyboard()
        {
            Console.Clear();
            HeaderRegisterStudent headerRegisterStudent = new HeaderRegisterStudent();
            headerRegisterStudent.PrintHeaderRegisterStudent();

            Student student = CreateNewStudent();
            Program.List.AddNewPerson(student);
        }
        static void InputForTeacherFromKeyboard()
        {
            Console.Clear();
            HeaderRegisterTeacher headerRegisterTeacher = new HeaderRegisterTeacher();
            headerRegisterTeacher.PrintHeaderRegisterTeacher();

            Teacher teacher = CreateNewTeacher();
            Program.List.AddNewPerson(teacher);
        }

        static Student CreateNewStudent()
        {
            return new Student(InputName(), InputSurname(), InputAge(), InputIDCardNumber(),
                 InputPhoneNumber(), InputEmail(), InputStudentID());
        }
        static Teacher CreateNewTeacher()
        {
            return new Teacher(InputName(), InputSurname(), InputAge(), InputIDCardNumber(),
                InputPhoneNumber(), InputEmail(), InputPosition());
        }
        static string InputName()
        {
            Console.Write("Name: ");
            return Console.ReadLine();
        }
        static string InputSurname()
        {
            Console.Write("Surname: ");
            return Console.ReadLine();
        }
        static string InputAge()
        {
            Console.Write("Age: ");
            return Console.ReadLine();
        }
        static string InputIDCardNumber()
        {
            Console.Write("ID Card Number: ");
            return Console.ReadLine();
        }
        static string InputStudentID()
        {
            Console.Write("Student ID: ");
            return Console.ReadLine();
        }
        static string InputPhoneNumber()
        {
            Console.Write("Phone Number: ");
            return Console.ReadLine();
        }
        static string InputEmail()
        {
            Console.Write("Email: ");
            return Console.ReadLine();
        }
        static string InputPosition()
        {
            Console.Write("Position: ");
            return Console.ReadLine();
        }
        static void PrintDayScreen()
        {
            Console.Clear();
            PrintDay();
            ListDay DayList = new ListDay();
            DayList.PrintDayList();

            Console.Write("Choose Day :");
            Day day = (Day)(int.Parse(Console.ReadLine()));

            PresentDay(day);
        }
        static void PresentDay(Day day)
        {
            if (day == Day.day_17_Oct || day == Day.day_18_Oct || day == Day.day_19_Oct)
            {
                PrintTimeScreen();
            }
            else
            {
                PrintTryAgain();
                PrintDayScreen();
            }
        }
        static void PrintTimeScreen()
        {
            Console.Clear();
            PrintTime();
            ListTime TimeList = new ListTime();
            TimeList.PrintTimeList();

            Console.Write("Choose Timecap : ");
            Time time = (Time)(int.Parse(Console.ReadLine()));

            PresentTime(time);
        }
        static void PresentTime(Time time)
        {
            if (time == Time.a || time == Time.b || time == Time.c )
            {
                ShowGetListPersonScreen();
            }
            else
            {
                PrintTryAgain();
                PrintTimeScreen();
            }

        }
        static void PrintDay()
        {
            Console.WriteLine("***** Day *****");
        }
        static void PrintTime()
        {
            Console.WriteLine("***** Time *****");
        }
        static void PrintTryAgain()
        {
            Console.Clear();
            Console.WriteLine("Incorrect Please try again");
        }
    }
        class Header
        {
            public void PrintHeader()
            {
                string PrintHeader = "The School Exhibition 2021 \n >Booking System\n >17 - 19 October\n--------------------------";
                Console.WriteLine(PrintHeader);
            }
        }
        class ListMenu
        {
            public void PrintListMenu()
            {
                string PrintListMenu = "1. Student. \n2. Teacher.";
                Console.WriteLine(PrintListMenu);
            }
        }
        class ListDay
        {
            public void PrintDayList()
            {
                string PrintDayList = "1. 17 October\n2. 18 October\n3. 19 October";
                Console.WriteLine(PrintDayList);
            }
        }
        class ListTime
        {
            public void PrintTimeList()
            {
                string PrintTimeList = "1. 13:00 - 14:30\n2. 15:00 - 16:30\n3. 17:00 - 18:30";
                Console.WriteLine(PrintTimeList);
            }
        }
        class HeaderRegisterStudent
        {
            public void PrintHeaderRegisterStudent()
            {
                string PrintHeaderRegisterStudent = "***** Register Student.*****";
                Console.WriteLine(PrintHeaderRegisterStudent);
            }
        }
        class HeaderRegisterTeacher
        {
            public void PrintHeaderRegisterTeacher()
            {
                string PrintHeaderRegisterTeacher = "*****Register Teacher.*****";
                Console.WriteLine(PrintHeaderRegisterTeacher);
            }
        }         
        class RegistrationInformation
        {
            private List<Person> personList;
            public RegistrationInformation()
            {
                this.personList = new List<Person>();
            }
            public void AddNewPerson(Person person)
            {
                this.personList.Add(person);
            }

            public void FetchPersonList()
            {
                Console.WriteLine("Registering was done");
                Console.WriteLine("--------------------");
                foreach (Person person in this.personList)
                {
                    if (person is Student)
                    {
                        Console.WriteLine("Name: {0} \nSurname: {1} \nType: Student \nID Card Number: {2}  \n See you soon XD", person.GetName(), person.GetSurName(), person.GetIDCardNumber());
                        Console.ReadLine();
                    }
                    else if (person is Teacher)
                    {
                        Console.WriteLine("Name: {0} \nSurname: {1} \nType: Teacher \nID Card Number: {2}  \n See you soon XD", person.GetName(), person.GetSurName(), person.GetIDCardNumber());
                        Console.ReadLine();
                    }
                }
            }
        }
        class Person
        {
            protected string name;
            protected string surname;
            protected string age;
            protected string idCardNumber;
            protected string phonenumber;
            protected string email;
            public Person(string name, string surname, string age, string idCardNumber,
                string phonenumber, string email)
            {
                this.name = name;
                this.surname = surname;
                this.age = age;
                this.idCardNumber = idCardNumber;
                this.phonenumber = phonenumber;
                this.email = email;
            }
            public string GetName()
            {
                return this.name;
            }
            public string GetSurName()
            {
                return this.surname;
            }
            public string GetIDCardNumber()
            {
                return this.idCardNumber;
            }
        }
        class Student : Person
        {
            protected string studentID;
            public Student(string name, string surname, string age, string idCardNumber,
                string studentID, string phonenumber, string email) : base(name, surname, age, idCardNumber, phonenumber, email)
            {

                this.studentID = studentID;

            }
            public string GetStudentID()
            {
                return this.studentID;
            }
        }
        class Teacher : Person
        {
            protected string position;
            public Teacher(string name, string surname, string age, string idCardNumber,
                string position, string phonenumber, string email) : base(name, surname, age, idCardNumber, phonenumber, email)
            {

                this.position = position;

            }
            public string GetPosition()
            {
                return this.position;
            }
        }   
}