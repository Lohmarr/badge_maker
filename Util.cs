using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using SkiaSharp;

namespace badge_maker
{
    public class Util
    {
        // Enter Employee info and return updated List
        static public List<Employee> GetEmployees()
        {
            List<Employee> employees = new();

            while (true)
            {
                Console.WriteLine("Please enter a first name: ");
                Console.WriteLine("(Leave empty to exit)");

                string firstName = Console.ReadLine() ?? "";

                if (firstName == "")
                {
                    break;
                }
                Console.WriteLine("Please enter a last name: ");

                string lastName = Console.ReadLine() ?? "";

                Console.WriteLine("Please enter Employee's ID: ");

                int id = Int32.Parse(Console.ReadLine() ?? "");

                Console.WriteLine("Please enter Employee's Photo URL: ");

                string photoUrl = Console.ReadLine() ?? "";

                Employee currentEmployee = new(firstName, lastName, id, photoUrl);
                employees.Add(currentEmployee);
            }

            return employees;
        }

        // Print List of employees
        static public void PrintEmployees(List<Employee> employees)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                Console.WriteLine(employees[i].GetAll());
            }
        }

        // Create directory and csv with employee info
        static public void MakeCSV(List<Employee> employees)
        {

            if (!Directory.Exists("data"))
            {
                Directory.CreateDirectory("data");
            }

            using StreamWriter file = new("data/employees.csv");
            file.WriteLine("ID, Name, PhotoURL");

            for (int i = 0; i < employees.Count; i++)
            {
                file.WriteLine(employees[i].GetCSV());
            }
        }

        // Create badge for each employee
        async static public Task MakeBadges(List<Employee> employees)
        {
            int BADGE_WIDTH = 669;
            int BADGE_HEIGHT = 1044;

            
            using HttpClient client = new();

            foreach (Employee i in employees)
            {
                SKImage photo = SKImage.FromEncodedData(await client.GetStreamAsync(i.GetPhotoUrl()));
                SKImage background = SKImage.FromEncodedData(File.OpenRead("./badge.png"));

                SKData data = background.Encode();
                data.SaveTo(File.OpenWrite("./data/employeeBadge.png"));

                SKBitmap badge = new(BADGE_WIDTH, BADGE_HEIGHT);
                SKCanvas canvas = new(badge);

                canvas.DrawImage(background, new SKRect(0, 0, BADGE_WIDTH, BADGE_HEIGHT));
            }
        }
    }
}