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
        static void buildPlayground(Dictionary<string, List<int>> dict, int num)
        {
            Random rand = new Random();
            for (int i = 0; i < num; i++)
            {
                List<int> stuGrades = new List<int> { rand.Next(60, 101), rand.Next(60, 101), rand.Next(60, 101) };
                string stuName = "Student " + (i + 1);
                dict.Add(stuName, stuGrades);
            }
        }
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> playground = new Dictionary<string, List<int>>();
            bool exit = false;
            while (!exit)
            {
                displayMenu();
                int menuSelection = getUserOption();
                Console.WriteLine("\n"+ menuSelection);
                switch(menuSelection)
                {
                    case 1:
                        Console.Write("How many students do you have? : ");
                        int numStu = Convert.ToInt32(Console.ReadLine());
                        buildPlayground(playground, numStu);
                        break;
                    case 2:
                        //displayAll();
                        break;
                    case 3:
                        //displayStudent(studentName);
                        break;
                    case 4:
                        //displayTopStudent();
                        break;
                    case 5:
                        //addStudent(student);
                        break;
                    case 6:
                        //changeStudentGrade(studentName, testNum, newGrade);
                        break;
                    case 7:
                        exit = false;
                        break;
                }
                Console.ReadKey();
            }
        }
    }
}
