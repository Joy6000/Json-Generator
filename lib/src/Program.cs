using System;
using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace JsonGen
{
    public class json
    {
        public string name, version, path, run, nameOfFile;


        public json(string n, string v, string p, string r, string nof)
        {
            name = n;
            version = v;
            path = p;
            run = r;
            nameOfFile = nof;
        }

        internal class Program
        {

            static void Main(string[] args)
            {

                Console.Write("Name of Project: ");
                string n = Console.ReadLine();
                Console.Write("New Version: ");
                string v = Console.ReadLine();
                Console.Write("Path of Project: ");
                string p = Console.ReadLine();
                Console.Write("Run Command Name: ");
                string r = Console.ReadLine();
                Console.Write("Name of JSON File to be Created: ");
                string nof = Console.ReadLine();

                json data = new json(n, v, p, r, nof);

                string toPrint = JsonConvert.SerializeObject(data, Formatting.Indented);

                Boolean result = nof.Contains(".json");

                string append = "";

                if(!result)
                {
                    append = ".json";
                } else
                {
                    append = "";
                }

                string path = @"PUT PATH HERE" + nof + append;

                using (FileStream fs = File.Create(path));

                using StreamWriter file = new(path);

                Console.WriteLine("Data here: \n" + toPrint);

                file.WriteLineAsync(toPrint);

                Console.WriteLine("Successfully created file {0}!", nof);
            }
        }
    }
}