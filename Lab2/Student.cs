using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Student
    {
        public string name;
        public List<Assignment> stdAssignments;
        public double studentAvg;


        Student() { }
        public Student(string name)
        {
            this.name = name;
            stdAssignments = new List<Assignment>();
            this.studentAvg = studentAvg;
            }

        //public static void addAssign(Assignment assignment)
        //{
        //    stdAssignments.Add(assignment);
        //}

        public static void showStds() //Will print all of the students within the selected Class
        {
            Console.Clear();
            if (Program.tempClass.studentList.Count == 0) //See if there are any students in the list
            {
                Console.WriteLine("No students added, Enter B to add students");
            }
            else
            {
                foreach (var x in Program.tempClass.studentList)
                {
                    Console.WriteLine($"Student Name: {x.name}\nNumber of Assignments: {x.stdAssignments.Count} , Average Grade: {x.studentAvg} \n"); //put grade
                }
            }
            Console.WriteLine();
        }
        public static void addStd()
        {
            Console.Clear();
            Console.Write("Enter the Student's Name: ");
            var tempStdName = Console.ReadLine();
            Program.tempClass.studentList.Add(new Student(tempStdName));
            Console.WriteLine($"{tempStdName} was added to {Program.tempClass.className} Class\n");
        }
        public static void editStd()
        {
            Console.Clear();
            Console.Write("Which Student do you want to Edit: ");
            string editStd = Console.ReadLine();
            while (true)
            {
                if (Program.tempClass.studentList.Any(x => x.name == editStd) == true)
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"{editStd} is not in this Class, please pick from below: ");
                    foreach (var x in Program.tempClass.studentList)
                    {
                        Console.WriteLine("- " + x.name);
                    }
                    Console.Write("Which Student do you want to Edit: ");
                    editStd = Console.ReadLine();
                }
            }
            Program.tempStudent = Program.tempClass.studentList.FirstOrDefault(x => x.name == editStd); //Make a Student Object for the student you want to edit/Add Assignments

        }
        public static void compareStd()
        {
            Console.Clear();
            Console.Write("Who is the first student: ");
            var firstName = Console.ReadLine();
            
            while (true)
            {
                if (Program.tempClass.studentList.Any(x => x.name == firstName) == true)
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine($"{firstName} is not in {Program.tempClass.className}, Please pick a Student from Below");
                    foreach (var x in Program.tempClass.studentList)
                    {
                        Console.WriteLine("- " + x.name);
                    }
                }
                Console.Write("Who is the first student: ");
                firstName = Console.ReadLine();
            }
            Console.Write("Who is the second student: ");
            string secName = Console.ReadLine();
            while (true)
            {
                if (Program.tempClass.studentList.Any(x => x.name == secName) == true)
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine($"{secName} is not in {Program.tempClass.className}");
                    foreach (var x in Program.tempClass.studentList)
                    {
                        Console.WriteLine("- " + x.name);
                    }
                }
                Console.Write("Who is the first student: ");
                secName = Console.ReadLine();
            }

            Console.Clear();

            var avg1 = 0;
            Program.tempStudent = Program.tempClass.studentList.FirstOrDefault(x => x.name == firstName);
            double std1avg = stdAvg(firstName);

            Console.WriteLine($"{firstName}'s Assignments with Grades, with a Class avg of: {std1avg}");
            foreach (var x in Program.tempStudent.stdAssignments)
            {
                Console.WriteLine($"- Assignment Name: {x.AssignName}, Assignment Grade: {x.grade}");
            }
            Console.WriteLine();

            Program.tempStudent = Program.tempClass.studentList.FirstOrDefault(x => x.name == secName);
            double std2avg = stdAvg(secName);
            {
                Console.WriteLine($"{secName}'s Assignments with Grades, with a Class avg of: {std2avg}");
                foreach (var x in Program.tempStudent.stdAssignments)
                {
                    Console.WriteLine($"- Assignment Name: {x.AssignName}, Assignment Grade: {x.grade}");
                }
            }
            Console.WriteLine();

        }


        public static void topStd()
        {
            Console.Clear();
            Student student = Program.tempClass.studentList.Aggregate((x1, x2) => x1.studentAvg > x2.studentAvg ? x1 : x2);
            Console.WriteLine($"The Student with the highest Average Grade of {student.studentAvg}% is: {student.name}\n");
        }
        public static void lowStd()
        {
            Console.Clear();
            Student student = Program.tempClass.studentList.Aggregate((x1, x2) => x1.studentAvg < x2.studentAvg ? x1 : x2);
            Console.WriteLine($"The Student with the lowest Average Grade of {student.studentAvg}% is: {student.name}\n");
        }

        public static void avgClass()
        {
            Console.Clear();
            double classAvg = Program.tempClass.studentList.Sum(x => x.studentAvg);
            classAvg = classAvg / Program.tempClass.studentList.Count;
            Console.WriteLine($"{Program.tempClass.className}'s Average is {classAvg}%\n");
        }


        public static void delStd()
        {
            Console.Clear();
            int counter = 0;
            while (counter == 0)
            {
                Console.Write("Which Student do you want to delete from " + Program.tempClass.className + "?");
                string delStd = (Console.ReadLine());
                if (Program.tempClass.studentList.Count == 0)
                {
                    Console.WriteLine("There are no Students to delete\n");
                    break;
                }
                else
                {
                    try
                    {
                        if (Program.tempClass.studentList.Any(x => x.name == delStd) == false) //see if the inputed class name is in the list (only can delete classes that exist)
                        {
                            throw new Exception();
                        }
                        else
                        {
                            Program.tempClass.studentList.RemoveAll(x => x.name == delStd); //delete the Class that matches the name in the list
                            Console.WriteLine($"{delStd} was deleted\n");
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("The Student you entered is not in the List, please choose from below");
                        foreach (var x in Program.tempClass.studentList)
                        {
                            Console.WriteLine("- " + x.name + "\n");
                        }
                    }
                }
                counter = 0;
            }
        }
        public static double stdAvg(string stdname)
        {
            int counter = 0;
            float total = 0;
            float avg = 0;
            Program.tempStudent = Program.tempClass.studentList.FirstOrDefault(x => x.name == stdname);
            for (int i = 0; i < Program.tempStudent.stdAssignments.Count; i++)
            {
                float x = Program.tempStudent.stdAssignments[i].grade;
                total = total + x;
                counter++;
            }
            avg = total / counter;
            Program.tempStudent.studentAvg = Math.Round(avg, 2);
            return avg;
        }
    }
}
