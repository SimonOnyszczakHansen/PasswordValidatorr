using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordValidatorr
{
    internal class Program
    {
        static string password;
        static void Main(string[] args)
        {
            Program.GUI();
            Console.ReadLine();
        }
        static void controller()
        {
            //Checks the password requirements
            Program.Modellayer();
            Program.UpperLowercase(password);
            Program.PasswordLength(password);
            Program.NumberCheck(password);
            Program.SpecialChar(password);
            
        }
        static void Modellayer()
        {
            password = Console.ReadLine();
        }
        static bool UpperLowercase(string password)
        {
            //Checks if the password contains upper and lower case letters
            if (password.Any(char.IsUpper) && password.Any(char.IsLower))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        static bool PasswordLength(string password)
        {
            //Checks if the password is too long or short
            if (password.Length > 11 && password.Length < 65)
            {
                return true;
            }
            {
                return false;
            }
        }
        static bool NumberCheck(string password)
        {
            //Checks if the password contains numbers
            foreach (char c in password)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }
            return false;
        }
        static bool SpecialChar(string password)
        {
            //Checks for special characters
            return password.Any( ch => !char.IsLetterOrDigit(ch));
        }
        static bool Same4Times(string password)
        {
            //Checks if the user entered the same digits in a row
            for (int i = 0; i < password.Length-3; i++)
            {
                if(password[i] == password[i + 1] && password[i + 1] == password[i + 2] && password[i + 2] == password[i + 3])
                {
                    return true;
                }
            }
            return false;
        }
        static bool NumbersConsecutively(string password)
        {
            //checks if the user enter consecutive numbers like 5, 6, 7, 8, 9
            char[] arr = password.ToArray();
            int[] ints = new int[arr.Length];
            int count = 0;

            foreach (char ch in arr)
            {
                if (char.IsDigit(ch))
                {
                    ints[count] = arr[count];
                }
                else
                {
                    ints[count] = -2;
                }
                count++;
            }
            for (int i = 0; i< ints.Length-3; i++)
            {
                if (ints[i] + 1 == ints[i + 1] && ints[i + 1] + 1 == ints[i + 2] && ints[i + 2] + 1 == ints[i + 3])
                {
                    return true;
                }
            }
            return false;
        }
        static void GUI()
        {
            //graphical user interface
            Console.WriteLine("Indtast password");
            Program.controller();
            //Gives error message if the user didnt enter upper and lowercase letters
            if (!UpperLowercase(password))
            {
                Console.WriteLine("Passwordet skal have mix af både store og små bogstaver");
                Program.GUI();                
            }
            //Gives error message if the password has the incorrect length
            else if (!PasswordLength(password))
            {
                Console.WriteLine("Passwordet skal være minimum 12 tegn og max. 64");
                Program.GUI();
            }
            //Gives error message if the password don't have a mix of numbers and letters
            else if (!NumberCheck(password))
            {
                Console.WriteLine("Passwordet skal have et mix af tegn og tal");
                Program.GUI();
            }
            //Gives error message if the password does not contain special characters
            else if (!SpecialChar(password))
            {
                Console.WriteLine("Passwordet skal indeholde minimum et specialtegn");
                Program.GUI();
            }
            else
            {
                //Tells the user the password is not strong enough and sends them back to retype it
                if (Same4Times(password) && NumbersConsecutively(password))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Passwordet er ikke stærkt nok");
                    Program.GUI();
                }
                //Tells the user the password is ok, but is seen as weak
                else if(Same4Times(password) || NumbersConsecutively(password))
                {
                    Console.ForegroundColor= ConsoleColor.Yellow;
                    Console.WriteLine("Passwordet er OK, men betragtes som svagt");
                }
                //If the password is good!
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Passwordet er OK");
                }
            }
        }
    }
}
