using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Program
    {
        public static List<Classroom> classes = new List<Classroom>();
        public static Classroom tempClass;
        public static List<Student> studentList;
        public static Student tempStudent;
        public static List<Assignment> stdAssignments;
        public static Assignment tempAssignment;
        static void Main(string[] args)
        {
            {
                int quit = 0;
                Console.WriteLine("Welcome to the Academy");
                
                while (quit == 0)
                {
                    
                    Console.WriteLine("What Action would you like to Take?");
                    Console.WriteLine("A:  See all Classes\nB:  Add a Class\nC:  Delete a Class\nD:  Class Information\nQ:  Exit the App");
                    string action3 = Console.ReadLine();
                    //See if user entered the right input - A,B,C,D,Q
                    int action3b = 0;
                    while (action3b == 0)
                    {
                        
                            if (action3 == "A" || action3 == "B" || action3 == "C" || action3 == "D" || action3 == "Q" && action3.Length == 1)
                            {
                            break;

                            }
                            else
                            {
                            Console.Clear();
                            Console.WriteLine("Please only choose from the following:");
                            Console.WriteLine("A:  See all Classes\nB:  Add a Class\nC:  Delete a Class\nD:  Class Information\nQ:  Exit the App");
                            action3 = Console.ReadLine();
                        }

                    }

                    //switch to what user info he/she wants
                    switch (action3)
                    {
                        case "A":
                            Classroom.showClasses(); //Method in Classroom Class that prints each Class
                            break;
                        case "B":
                            Classroom.addClass(); //Method in Classroom Class that lets user add a Class (only with letters)
                            break;
                        case "C":
                            Classroom.delClass(); //Method in Classroom Class that lets user delete a Class
                            break;
                        case "D":
                            {
                                Classroom.pickClass();
                               
                                int counter2 = 0;

                                
                                Console.Clear();
                                Console.Write($"Welcome to the {tempClass.className} Class App");
                                while (counter2 == 0)
                                {
                                    Console.WriteLine("What Action would you like to Take?");
                                    Console.WriteLine("A:  See All Grades\nB:  Add a Student\nC:  Enter the Student's Info \nD:  Compare two studentes" +
                                   "\nE:  Show the top Grade\nF:  Show the bottom Grade\nG;  Calculate Avg of the Class\nH:  Remove a Student\nQ:  Back to Main Menu");
                                    string action = Console.ReadLine();
                                    
                                    int counter2a = 0;
                                    while (counter2a == 0)//Make sure user enters correct 
                                    {
                                        if (action == "A" || action == "B" || action == "C" || action == "D" || action == "E" || action == "F" || 
                                        action == "G" || action == "H" || action == "Q" && action.Length == 1)
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("A:  See All Grades\nB:  Add a Student\nC:  Enter the Student's Info \nD:  Compare two studentes" +
                                            "\nE:  Show the top Grade\nF:  Show the bottom Grade\nG:  Calculate Avg of the Class\nH:  Remove a Student\nQ:  Back to Main Menu");
                                            action = Console.ReadLine();

                                        }
                                    }

                                    switch (action)
                                    {
                                        case "A":
                                            Student.showStds(); //Method in Student Class that will show all students within the selected Class
                                            break;
                                        case "B":
                                            Student.addStd(); //Method in Student Class that will add a student
                                            break;

                                        case "C":
                                            Student.editStd();
                                            int counter3 = 0;
                                            while (counter3 == 0)
                                            {
                                                Console.WriteLine("A:  See All Grades\nB:  Add an Assignment\nC:  Add an Assignment Grade\nD:  Remove a Assignment " +
                                                "\nQ:  Back to Main Menu ");
                                                string action2 = Console.ReadLine();
                                                //See if user entered the right input A,B,C,D,Q
                                                while (true)
                                                {
                                                    if (action2 == "A" || action2 == "B" || action2 == "C" || action2 == "D" || action2 == "Q" 
                                                        || action2.Length == 1)
                                                    {
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Please only Chose from the Following:");
                                                        Console.WriteLine("A:  See All Grades\nB:  Add an Assignment\nC:  Add an Assignment Grade\nD:  Remove a Assignment " +
                                                       "\nQ:  Back to Main Menu ");
                                                        action2 = Console.ReadLine();
                                                        
                                                    }
                                                }
                                                switch (action2)
                                                {
                                                    case "A":
                                                        Assignment.allAssigns();
                                                        break;
                                                    case "B":
                                                        Assignment.newAssign();
                                                        break;
                                                    case "C":
                                                        Assignment.editAssign();
                                                        break;
                                                    case "D":
                                                       Assignment.delAssign();
                                                        break;
                                                    case "Q":
                                                        Console.Clear();
                                                        counter3 = 1;
                                                        break;
                                                }
                                            }
                                            break;

                                        case "D":
                                            Student.compareStd();
                                            break;
                                        case "E":
                                        Student.topStd();
                                        break;
                                        case "F":
                                        Student.lowStd();
                                        break;
                                        case "G":
                                        Student.avgClass();
                                        break;
                                        case "H":
                                        Student.delStd();
                                        break;
                                        case "Q":
                                            Console.Clear();
                                            counter2 = 1;
                                            break;
                                    }


                                }
                                break;
                            }
                        case "Q":
                            quit = 1;
                            break;
                    }
                }
            }
        }
    }
}
