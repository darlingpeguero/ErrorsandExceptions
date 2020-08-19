using System;


namespace EX3APart2_ErrorsandExceptions_DarlingP08012020
//Class:          ERAU ISTA220 Programming Fundamentals
//Student:        Darling Peguero
//Instructor:     Christine E Lee, Instructor
//Date:           07/9/2020
//                07/25/2020

/****************************************************************************************
 Homework Assignment: EX 3A - C# - Errors and Exceptions

Revision: This exercise builds on Exercise 1, Mathematical Formulas. You may have noticed 
that some inputs do not work, and that sometimes users make errors in inputs. In this exercise, 
we will address some of these issues.

Revision Date: 8/1/2020 
                -Modified my code so that my exception handling logic applies to inputs 
                generally for all formulas, rather than individual try/catch blocks for each formula.
                -Modify my program to add a finally block
                -Modify your code (by writing checked/unchecked statements) to protect against numeric overflow errors.

Revised Date: 

Reference:https://github.com/Dbrauch8/Math-Assignment-with-Averages/blob/master/Ex2A_testScores/Program.cs

****************************************************************************************/
{
    class Program
    {
        static void Main()
        {

            Console.WriteLine("\n\n");
            Console.Write("WELCOME! Please enter your name: "); ;
            string name = Console.ReadLine();
            Console.WriteLine($"Hello {name}! What Would you like to do today?");
            Console.WriteLine("***************************************************");

            bool displayMenu = true;
            while (displayMenu == true)
            {
                displayMenu = MainMenu();
            }
        }


        private static bool MainMenu()
        {
            //Added the try catch to the menu
            Console.WriteLine("\n");
            Console.WriteLine("     Please Type1, if you would like to find the circumference and area of a circle.");
            Console.WriteLine("     Please Type2, if you would like to find the Volume of a hemisphere.");
            Console.WriteLine("     Please Type3, if you would like to find the area of a triangle.");
            Console.WriteLine("     Please Type4, if you would like to Calculate root of Quadratic Equation.");
            Console.WriteLine("     Please Type5, if you would like to Exit");
            string input = Console.ReadLine();
            try
            {
                if (input == "1")
                {
                    Console.WriteLine("Great, you have Selected to find the circumference and area of a circle.");
                    Circumference();
                    return true;
                }
                else if (input == "2")
                {
                    Console.WriteLine("Awesome, you have selected to find the volume of a hemisphere.");
                    Volume();
                    return true;
                }
                else if (input == "3")
                {
                    Console.WriteLine("Perfect, you have selected to find the area of a triangle.");
                    Triangle();
                    return true;
                }
                else if (input == "4")
                {
                    Console.WriteLine("Cool, you would like to Calculate root of Quadratic Equation.");
                    Quadratic();
                    return true;
                }
                else if (input == "5")
                {
                    Exit();
                    return false;
                }
                else
                {
                    Console.WriteLine($"{input} is and invalid input, please try again!");
                    return true;
                }
            }
            catch (FormatException)
            {
                Console.Write("Invalid input, your input has to be a number, Please try again: ");
                return true;
            }
            catch (OverflowException oEx)
            {
                Console.WriteLine(oEx.Message);
                return true;
            }
            finally
            {
                Console.WriteLine("This program has finally terminated");
            }


        }
        static void Exit()
        {
            Console.Clear();
            Console.WriteLine("Are you sure?");
            Console.WriteLine("Y or N?");
            string result = Console.ReadLine();

            if (result == "Y")
            {
                Console.Clear();
                Console.WriteLine("Thank you! Goodbye!");
            }
            else if (result == "y")
            {
                Console.Clear();
                Console.WriteLine("Thank you! Goodbye!");
            }
            else if (result == "N")
            {
                MainMenu();
            }
            else if (result == "n")
            {
                MainMenu();
            }
        }




        static void Circumference()
        {
            /***********************************
              Circumference and Area
            ***********************************/
            // removed the try catch
            double radius = ' ';
            double area;
            double circumference;

            while (radius >= 0)
            {
                Console.Write("Please Enter the radius:  ");
                radius = double.Parse(Console.ReadLine());
                if (radius <= 0)
                {
                    Console.Write("You have entered a number that is equal to or less than 0, Please try again. ");
                    radius = double.Parse(Console.ReadLine());
                }

                area = checked(Math.PI * radius * radius);
                circumference = checked(2 * Math.PI * radius);
                Console.WriteLine($"If the radius is {radius} then the area is {area} and the circumference is {circumference}");
                break;
            }
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadLine();
            MainMenu();
        }

        static void Volume()
        {
            /***********************************
              volume of a hamisphere
            ***********************************/
            // removed the try catch
            double radius = ' ';
            double volume;

            while (radius >= 0)
            {

                Console.Write("Enter an integer for the radius: ");
                radius = double.Parse(Console.ReadLine());
                if (radius <= 0)
                {
                    Console.Write("You have entered a number that is equal to or less than 0, Please try again. ");
                    radius = double.Parse(Console.ReadLine());

                }

                volume = checked(((4.0 / 3) * Math.PI * radius * radius * radius) / 2);
                Console.WriteLine("The volume is {0}", volume);
                break;
            }
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadLine();
            MainMenu();
        }


        static void Triangle()
        {
            /***********************************
              Area of a Triangle
            ***********************************/
            // removed the try catch
            double area;
            double a = ' ';
            double b = ' ';
            double c = ' ';

            while ((a >= 0) && (b >= 0) && (c >= 0))
            {
                Console.Write("Enter the length of side a: ");
                a = double.Parse(Console.ReadLine());
                Console.Write("Enter the length of side b: ");
                b = double.Parse(Console.ReadLine());
                Console.Write("Enter the length of side c: ");
                c = double.Parse(Console.ReadLine());

                double p = (a + b + c) / 2;
                area = checked(Math.Sqrt(p * (p - a) * (p - b) * (p - c)));
                Console.WriteLine("The area is {0}", area);
                break;
            }
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadLine();
            MainMenu();
        }




        static void Quadratic()
        {
            /***********************************
              Quadratic formula
            ***********************************/
            double a;
            double b;
            double c;

            double d, x1, x2;
            Console.WriteLine("Calculate root of Quadratic Equation :");


            Console.Write("Input the value of a : ");
            a = double.Parse(Console.ReadLine());
            Console.Write("Input the value of b : ");
            b = double.Parse(Console.ReadLine());
            Console.Write("Input the value of c : ");
            c = double.Parse(Console.ReadLine());




            d = checked(b * b - 4 * a * c);
            if (d == 0)
            {
                Console.Write("Both roots are equal.");
                x1 = checked(-b / (2.0 * a));
                x2 = x1;
                Console.Write("First  Root Root1= {0}", x1);
                Console.Write("Second Root Root2= {0}", x2);
            }
            else if (d > 0)
            {
                Console.WriteLine("Both roots are real and diff-2 ");

                x1 = checked(-b + Math.Sqrt(d)) / (2 * a);
                x2 = checked(-b - Math.Sqrt(d)) / (2 * a);

                Console.Write("First  Root Root1= {0} ", x1);
                Console.Write("Second Root root2= {0} ", x2);
            }
            else
                Console.Write("Root are imaginary Solution. ");
            Console.ReadLine();
            MainMenu();
        }
    }
}
