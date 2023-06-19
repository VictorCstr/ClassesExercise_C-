using System;
using System.Globalization;
using TerceiraParte.Entities;
using TerceiraParte.Entities.Enums;

namespace TerceiraParte // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Console.Write("Enter department's name: ");
            string department = Console.ReadLine()!;

            System.Console.WriteLine("Enter worker Data:");
            System.Console.Write("Name: ");
            string name = Console.ReadLine()!;

            System.Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine()!);

            System.Console.Write("Base Salary: ");
            double salary = Double.Parse(Console.ReadLine()!);

            Department dept = new(department);
            Worker worker = new(name, level, salary, dept);

            System.Console.WriteLine("How many contracts to this worker? ");
            int contracts = int.Parse(Console.ReadLine()!);

            for (int i = 0; i < contracts; i++)
            {
                System.Console.WriteLine($"Enter {i + 1} contract data:");
                System.Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine()!);

                System.Console.Write("Value per hour: ");
                double value = Double.Parse(Console.ReadLine()!);

                System.Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine()!);

                HourContract contract = new(date, value, hours);
                worker.AddContract(contract);
            }

            System.Console.Write("Enter month and year to calculate income(MM / YYYY): ");
            string dateToCalculate = Console.ReadLine()!;
            int month = int.Parse(dateToCalculate.Split('/')[0]);
            int year = int.Parse(dateToCalculate.Split('/')[1]);

            System.Console.WriteLine(department);
            System.Console.WriteLine(worker.Name);
            System.Console.WriteLine(worker.Income(year, month));



        }
    }
}

