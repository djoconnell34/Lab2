using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Assignment
    {
        public string AssignName;
        public float grade;

        Assignment() { }

        public Assignment(string AssignName, float grade)
        {
            this.AssignName = AssignName;
            this.grade = grade;
        }

        public static void allAssigns()
        {
            Console.Clear();
            if (Program.tempStudent.stdAssignments.Count == 0)
            {
                Console.WriteLine($"{Program.tempStudent.name} has no Assignments, Enter B to add Assignments");
            }
            else
                Console.WriteLine($"{Program.tempStudent.name}'s grades:");
            {
                foreach (var x in Program.tempStudent.stdAssignments)
                {
                    Console.WriteLine($"- {x.AssignName}: {x.grade}");
                }
            }
            Console.WriteLine();
        }
        public static void newAssign()
        {
            Console.Clear();
            Console.Write("What is the Assignment Name: ");
            string tempAssign2 = Console.ReadLine();
            Program.tempStudent.stdAssignments.Add(new Assignment(tempAssign2, 0));
            Console.WriteLine($"{tempAssign2} has been added to {Program.tempStudent.name}\n");

            Program.tempStudent.studentAvg = Student.stdAvg(Program.tempStudent.name); //Give each student an Average Grade
        }
        public static void editAssign()
        {
            Console.Clear();

            while (true)
            {
                if (Program.tempStudent.stdAssignments.Count != 0)
                {
                    Console.Write("What Assignment Name do you want to change the Grade of: ");
                    string tempName3 = Console.ReadLine();

                    while (true)
                    {
                        if (Program.tempStudent.stdAssignments.Any(x => x.AssignName == tempName3) == true)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"{tempName3} is not in this Student's Assignments, please pick from below: ");
                            foreach (var x in Program.tempStudent.stdAssignments)
                            {
                                Console.WriteLine("- " + x.AssignName);

                            }
                            Console.Write("Which Assignment do you want to Edit: ");
                            tempName3 = Console.ReadLine();
                        }
                    }

                    Console.Write($"What grade did the student recieve on {tempName3}: ");
                    float tempGrade3 = float.Parse(Console.ReadLine());

                    while (true)
                    {
                        if (tempGrade3 > -1 && tempGrade3 < 101)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nThe grade you entered is either above 100 or below 0. Please Enter between these values");
                            Console.Write($"What grade did the student recieve on {tempName3}: ");
                            tempGrade3 = float.Parse(Console.ReadLine());
                        }
                    }
                    Program.tempAssignment = Program.tempStudent.stdAssignments.FirstOrDefault(x => x.AssignName == tempName3);
                    Program.tempAssignment.grade = tempGrade3;
                    Console.WriteLine($"{Program.tempAssignment.AssignName} now has a grade of {Program.tempAssignment.grade}\n");
                    Program.tempStudent.studentAvg = Student.stdAvg(Program.tempStudent.name);
                    break;
                }
                else
                {
                    Console.Write("There are no Assigmnets to Edit, press any key to add a Student and Then Edit him/her");
                    String anyKey = Console.ReadLine();
                    newAssign();
                }
                
            }
            



        }
        public static void delAssign()
        {
            Console.Clear();
            Console.Write("What Assignment do you want to Delete: ");
            string tempName4 = Console.ReadLine();

            while (true)
            {
                if (Program.tempStudent.stdAssignments.Any(x => x.AssignName == tempName4) == true)
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"{tempName4} is not in {Program.tempStudent.name}'s assignment list\n");
                    Console.WriteLine("What Assignment do you want to Delete from below: ");
                    foreach (var x in Program.tempStudent.stdAssignments)
                    {
                        Console.WriteLine("- " + x.AssignName);
                    }
                    Console.Write("Which Assignment: ");
                    tempName4 = Console.ReadLine();
                }
            }
            
            Program.tempStudent.stdAssignments.RemoveAll(x => x.AssignName == tempName4);
            Console.WriteLine($"{tempName4} was deleted\n");
        }

        
    }
}
