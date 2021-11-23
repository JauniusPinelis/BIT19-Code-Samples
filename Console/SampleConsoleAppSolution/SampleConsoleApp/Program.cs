using SampleConsoleApp;
using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var dog1 = new Dog();
            var dog2 = new Dog();

            dog1.Bark();
            dog2.Bark();

            Dog.StaticBark();


            var randomNumber = GetNumber();
            PrintInfo(randomNumber);
        }

        public static void PrintInfo(int info)
        {
            Console.WriteLine(info);
        }

        public static int GetNumber()
        {
            return 5*2;
        }
    }
}