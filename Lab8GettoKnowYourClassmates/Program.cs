using System;
using System.Linq;

namespace Lab8GettoKnowYourClassmates
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Which character would you like to learn more about?");

            string[] students = { "Arya", "John Snow", "Sansa" };

            bool continueLoop = true;
            while (continueLoop == true)
            {
                ListOutStringArray(students);
                StudentInfo(InputIsString(students, GetUserInput($"Enter a Name or a number (1-{students.Length}):")));

                continueLoop = YesOrNo();
            }
        }

        //lists out info based on selection int
        public static void StudentInfo(int number)
        {
            string[] cities = { "Bravos", "The Wall", "King's Landing" };
            string[] language = { "Java", "Old Tongue", "Valyrian" };
            string[] zip = { "12345", "48225", "88885" };
            string[] phoneNum = { "321-123-6543", "888-555-9966", "420-420-4200" };

            Console.WriteLine("");
            Console.WriteLine(string.Format("{0, -17}:{1, 17}", "Location", cities[number]));
            Console.WriteLine(string.Format("{0, -17}:{1, 17}", "Class Language", language[number]));
            Console.WriteLine(string.Format("{0, -17}:{1, 17}", "Zipcode", zip[number]));
            Console.WriteLine(string.Format("{0, -17}:{1, 17}", "Phone Number", phoneNum[number]));
        }

        //takes in user input
        public static string GetUserInput(string message)
        {
            Console.Write(message + " ");
            string input = Console.ReadLine();
            return input;
        }

        //continue while loop
        public static bool YesOrNo()
        {
            string userContinue = "";
            while (userContinue != "y" && userContinue != "n")
            {
                Console.Write("\nWould you like to pick another student? (y/n): ");
                userContinue = Console.ReadLine().ToLower();

                if (userContinue == "n")
                {
                    Console.WriteLine("Okay!!");
                    return false;
                }
            }
            return true;
        }

        //if any string in inputarray matches, return an int based on that. else, go to int input method
        public static int InputIsString(string[] name, string pick)
        {
            if (name.Contains(pick))
            {
                return Array.IndexOf(name, pick);
            }
            else
            {
                return InputIsInt(name, pick);
            }
        }

        //if string input is valid, return int
        public static int InputIsInt(string[] name, string pick)
        {
            try
            {
                int intPick = int.Parse(pick) - 1;
                string tryExceptionT = name[intPick];
                return intPick;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Input out of range");
                return InputIsString(name, GetUserInput("Try again"));
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid name");
                return InputIsString(name, GetUserInput("Try again"));
            }
        }

        //list out everything in the array
        public static void ListOutStringArray(string[] array)
        {
            Console.WriteLine("");
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(string.Format("{0, -11}:{1, 3}", array[i], i + 1));
            }
        }
    }
}
