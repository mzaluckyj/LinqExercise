﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            var sum = numbers.Sum();
            Console.WriteLine(sum);
            //TODO: Print the Average of numbers

            var avg = numbers.Average();
            Console.WriteLine(avg);
            //TODO: Order numbers in ascending order and print to the console
            var asc = numbers.OrderBy(x => x);
            Console.WriteLine("--Ascending--");
            foreach(var num in asc) Console.WriteLine(num);
            //TODO: Order numbers in decsending order and print to the console
            var decsending = numbers.OrderByDescending(x => x);
            Console.WriteLine("--Decsending--");
            foreach(var num in decsending) Console.WriteLine(num);

            //TODO: Print to the console only the numbers greater than 6
            Console.WriteLine("--sevenup--");
            var sevenUp = numbers.Where(i => i >6);
            foreach(var z in sevenUp) Console.WriteLine(z);
            //TODO: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("--4asc--");
            foreach(var num in asc.Take(4))
            { Console.WriteLine(num); }
            //TODO: Change the value at index 4 to your age, then print the numbers in decsending order
            Console.WriteLine("--age--");
            numbers[4] = 30;
            foreach(var item in numbers.OrderByDescending(num => num))
            { Console.WriteLine(item); }
            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            var filtered = employees.Where(person => person.FirstName.StartsWith("C") || person.FirstName.StartsWith("S"))
                .OrderBy(person => person.FirstName);
            Console.WriteLine("names with C or S");
            foreach (var employee in filtered) { Console.WriteLine(employee.FullName); }

            
           //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
           Console.WriteLine("--26--");
            var twentySix = employees.Where(person => person.Age > 26)
                .OrderBy(emp => emp.Age).ThenBy(emp => emp.FirstName);

            foreach (var employee in twentySix) { Console.WriteLine($"{employee.Age} {employee.FullName}"); }
            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35.
            var sumYOE = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);
            Console.WriteLine("--YOE--");
            Console.WriteLine($"Total YOE: {sumYOE.Sum(x => x.YearsOfExperience)}");
            Console.WriteLine($"Avg Yoe {sumYOE.Average(x => x.YearsOfExperience)}");
            //TODO: Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("New", "Guy", 30, 10)).ToList();

            Console.WriteLine("----");
            foreach (var item in employees) 
            {
                Console.WriteLine(item.FullName);
            }    
            
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
