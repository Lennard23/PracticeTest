using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Program
{

    public class Person
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

    }
    public static void Main()
    {
        string filePath =
        @"C:\Users\Lennard\Desktop\Test\Question 2\Data.csv";
        List<Person> people = new List<Person>();
        //StreamReader reader = null;
        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            { 
            //    reader = new StreamReader(File.OpenRead(filePath));

                reader.ReadLine();  
            //List<string> listA = new List<string>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                string[] values = line.Split(',');
                    //foreach (var item in values)
                    //{
                    //    listA.Add(item);
                    //}
                    //foreach (var coloumn1 in listA)
                    //{
                    //    Console.WriteLine(coloumn1);
                    //}
                    if (values.Length >= 4)
                    {
                        Person person = new Person
                        {
                            Firstname = values[0],
                            Lastname = values[1],
                            Address = values[2],
                            PhoneNumber = values[3]
                        };
                        people.Add(person);
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("File doesn't exist");
        }
        Console.ReadLine();


        var nameFrequencies = people
            .GroupBy(p => p.Lastname)
            .Select(g => new  { Lastname = g.Key, Count = g.Count() })
            .OrderBy(x => x.Count)
            .ThenByDescending(x => x.Lastname);



        // Print the results to the console
        //foreach (var result in nameFrequencies)
        //{
        //    Console.WriteLine($"{result.Lastname}, {result.Count}");
        //}
        string outputFilePath = Path.Combine(Path.GetDirectoryName(filePath), "output.txt");
        using (StreamWriter writer = new StreamWriter(outputFilePath))
        {
            foreach (var result in nameFrequencies)
            {
                writer.WriteLine($"{result.Lastname}, {result.Count}");
            }
        }
    }
}

