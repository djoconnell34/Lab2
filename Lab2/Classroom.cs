using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Classroom
    {
        public string className;
        public List<Student> studentList;
        Classroom() { }
        public Classroom(string className)
        {
            this.className = className;
            studentList = new List<Student>();
        }

        public static void showClasses() //Show all classes input by user
        {
            Console.Clear();
            Console.WriteLine("School Syllabus:");
            if (Program.classes.Count == 0) //See if there are any classes in the list
            {
                Console.WriteLine("There are no classes, enter B to add one.\n");
            }
            else
            {
                foreach (var x in Program.classes) //Shows all classes
                {
                    Console.WriteLine("- " + x.className);
                }
            }
            Console.WriteLine();
        }
        public static void addClass() //Lets the user add a Class
        {
            Console.Clear();
            int check = 0;
            string tempName = " ";
            while (check == 0)
            {
                try
                {
                    Console.Write("Enter the Class Name: ");
                    tempName = Console.ReadLine();
                    if (tempName.Any(x => !char.IsLetter(x)))
                    {
                        throw new Exception();
                    }
                    if (Program.classes.Any(x => x.className == tempName) == true) //see if the inputed class name is already in the list (only can add new class names)
                    {
                        throw new Exception();
                    }
                    check = 1;
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Only can use letters for a Class Name\n");
                }
            }
            Program.classes.Add(new Classroom(tempName));
            Console.WriteLine($"{tempName} was added!\n");
        }

        public static void delClass() //Lets the User Delete a Class
        {
            Console.Clear();
            int counter = 0;
            while (counter == 0)
            {
                Console.Write("Which Class do you want to Delete: ");
                string delClass1 = (Console.ReadLine());
                if (Program.classes.Count == 0)
                {
                    Console.WriteLine("There are no classes to delete\n");
                    break;
                }
                else
                {
                    try
                    {
                        if (Program.classes.Any(x => x.className == delClass1) == false) //see if the inputed class name is in the list (only can delete classes that exist)
                        {
                            throw new Exception();
                        }
                        else
                        {
                            Program.classes.RemoveAll(x => x.className == delClass1); //delete the Class that matches the name in the list
                            Console.WriteLine($"{delClass1} was deleted\n");
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.Write("\nThe Class you entered is not in the List, do you still want to Delete a Class (Y / N): ");
                        char userInput = Convert.ToChar(Console.ReadLine());
                        if (userInput == 'N')
                        {
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Choose from the following Syllabus: ");
                            foreach (var x in Program.classes)
                            {
                                Console.WriteLine("- " + x.className);
                            }
                        }

                    }
                }
            }
        }
        public static void pickClass() //Lets the User Delete a Class
        {
            Console.Clear();
            int counter = 0;
            Console.WriteLine("Which Class do you want to Edit?");
            foreach (var x in Program.classes)
            {
                Console.WriteLine("- " + x.className);
            }
            Console.Write("Which Class Information do you want to see: \n");
            string className2 = Console.ReadLine();
            while (counter == 0)
            {
                    try
                    {
                        if (Program.classes.Any(x => x.className == className2))
                        {
                            break;
                        }
                        else throw new Exception();
                    }
                    catch (Exception ex)
                    {
                        Console.Clear();
                        Console.WriteLine("Please only Select from the following Classes:");
                        foreach (var x in Program.classes)
                        {
                            Console.WriteLine("- " + x.className);
                        }
                        Console.Write("Which Class Information do you want to see: \n");
                        className2 = Console.ReadLine();

                }
            }
            Program.tempClass = Program.classes.FirstOrDefault(x => x.className == className2);//Create an Object of the School Class(ie Math) that you will add students and Assignments
        }
    }

}
