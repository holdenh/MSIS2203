﻿using System;
using System.Collections.Generic;

/**
 *      Holden Halferty
 *      Week 12 Attendance 4/2/2020
 *      
 *      Create a small DBMS that makes use of methods to create a Dictionary of students
 *          and display some information about the students.
 */

namespace InClassExerciseII_Mod8_Wk12
{
    class Program
    {


        /* Function that is called that display different use options. */
        static void displayMenu()
        {
            Console.Clear();
            Console.WriteLine("1) Build the playground.");
            Console.WriteLine("2) Display all students.");
            Console.WriteLine("3) Display one student.");
            Console.WriteLine("4) Display the top student.");
            Console.WriteLine("5) Add a student.");
            Console.WriteLine("6) Change student grade.");
            Console.WriteLine("7) Exit.");
        }

        /* Function that will take input from the user based on the Menu options. */
        static int getUserOption()
        {
            Console.Write("Please choose from one of the menu options (1-7): ");
            /* Catch user entries that may be strings, and handle input out of range. */
            try
            {
                int output = Convert.ToInt32(Console.ReadLine());
                if (output < 1 || output > 7)
                {
                    displayMenu();
                    return getUserOption();
                }
                return output;
            } catch (Exception e)
            {
                displayMenu();
                return getUserOption();
            }
        }

        /* Function that takes a dictionary and a given number, and creates/returns a playground with that amount of students having 3 grades a piece. */
        static void buildPlayground(Dictionary<string, List<double>> dict, int num)
        {
            for (int i = 0; i < num; i++)
            {
                addStudent(dict);
            }
        }

        /* Function that is used to display all the studetns of a given dictionary. */
        static void displayAll(Dictionary<string, List<double>> students)
        {
            foreach (KeyValuePair<String, List<double>> stuReport in students)
            {
                Console.WriteLine("Student: {0}\n\tExam 1: {1}%\tExam 2: {2}%\tExam 3: {3}%\n\tStudent AVG: {4}%", stuReport.Key, stuReport.Value[0], stuReport.Value[1], stuReport.Value[2], stuReport.Value[3]);
            }
        }
        /* function that searches for a given student in the dictionary. */
        static bool searchFor(Dictionary<string, List<double>> students, string stuName)
        {
            bool found = false;
            foreach (KeyValuePair<string, List<double>> stuReport in students)
            {
                if (stuReport.Key.ToLower().Equals(stuName.ToLower()))
                {
                    found = true;
                }
            }
            if (found == false)
            {
                Console.WriteLine("{0} not found on the playground.", stuName);
            }
            return found;
        }
        /* Function that is used to display a specific of a given dictionary. The name of a student will be pass in. */
        static void displayStudent(Dictionary<string, List<double>> students, string stuName)
        {
            if (searchFor(students, stuName))
            {
                Console.WriteLine("Student: {0}\n\tExam 1: {1}%\tExam 2: {2}%\tExam 3: {3}%\n\tStudent AVG: {4}%", stuName, students[stuName][0], students[stuName][1], students[stuName][2], students[stuName][3]);
            }
        }

        /* Function that is used to display a specific of a given dictionary. The name of a student will be pass in. */
        static void displayTopStudent(Dictionary<string, List<double>> students)
        {
            KeyValuePair<string, List<double>> topStu = new KeyValuePair<string, List<double>>("", new List<double> { 0.0, 0.0, 0.0, 0.0 });
            foreach (KeyValuePair<string, List<double>> stuReport in students)
            {
                if (stuReport.Value[3] > topStu.Value[3])
                {
                    topStu = stuReport;
                }
            }
            Console.WriteLine("\nStudent with the highest average of test scores is : \n");
            displayStudent(students, topStu.Key);
        }

        /* Function that will add a single student to the passed in dictionary with name incremented, and 3 random test grades. */
        static void addStudent(Dictionary<string, List<double>> students)
        {
            Random rand = new Random();

            List<double> stuGrades = new List<double> { (double)rand.Next(60, 101), (double)rand.Next(60, 101), (double)rand.Next(60, 101) };
            double totalPoints = 0;
            double stuAvg = 0.0;
            foreach (int grade in stuGrades)
            {
                totalPoints += grade;
            }
            stuAvg = Math.Round(totalPoints / stuGrades.Count, 2);
            stuGrades.Add(stuAvg);
            string stuName = "student " + (students.Count + 1);
            students.Add(stuName, stuGrades);
        }

        /* function that will take a given student name, and change a one of their test grades.*/
        static void changeStudentGrade(Dictionary<string, List<double>> students, string stuName, int testNum, double newGrade)
        {
            double totalPoints = 0.0;
            double stuAvg = 0.0;
            students[stuName][testNum - 1] = newGrade;
            for(int i = 0; i < students[stuName].Count-1; i++)
            {
                totalPoints += students[stuName][i];
            }
            stuAvg = Math.Round(totalPoints / (students[stuName].Count - 1), 2);
            students[stuName][(students[stuName].Count - 1)] = stuAvg;
        }
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> playground = new Dictionary<string, List<double>>();
            bool exit = false;
            while (!exit)
            {
                displayMenu();
                int menuSelection = getUserOption();
                switch(menuSelection)
                {
                    case 1:
                        Console.Write("How many students do you have? : ");
                        int numStu = Convert.ToInt32(Console.ReadLine());
                        buildPlayground(playground, numStu);
                        Console.WriteLine("Playground of {0} students created", numStu);
                        Console.Write("\nPress any key to continue.");
                        Console.ReadKey();
                        break;
                    case 2:
                        displayAll(playground);
                        Console.Write("\nPress any key to continue.");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Write("What is the students name? : ");
                        string studentName = Console.ReadLine();
                        displayStudent(playground, studentName);
                        Console.Write("\nPress any key to continue.");
                        Console.ReadKey();
                        break;
                    case 4:
                        displayTopStudent(playground);
                        Console.Write("\nPress any key to continue.");
                        Console.ReadKey();
                        break;
                    case 5:
                        addStudent(playground);
                        Console.WriteLine("A single student was added.");
                        displayAll(playground);
                        Console.Write("\nPress any key to continue.");
                        Console.ReadKey();
                        break;
                    case 6:
                        Console.Write("Student's name : ");
                        studentName = Console.ReadLine();
                        if (searchFor(playground, studentName))
                        {
                            Console.WriteLine("{0}'s current grades\n", studentName);
                            displayStudent(playground, studentName);
                            Console.Write("\nExam Number to Change : ");
                            int testNum = Convert.ToInt32(Console.ReadLine());
                            Console.Write("\nNew Test Grade :");
                            double newGrade = Convert.ToDouble(Console.ReadLine());
                            changeStudentGrade(playground, studentName, testNum, newGrade);
                            Console.WriteLine("\n{0}'s grades after the change to Exam 3 \n",studentName);
                            displayStudent(playground, studentName);
                            Console.Write("\nPress any key to continue.");
                            Console.ReadKey();
                            break;
                        }
                        break;
                    case 7:
                        exit = true;
                        break;
                }
            }
        }
    }
}
