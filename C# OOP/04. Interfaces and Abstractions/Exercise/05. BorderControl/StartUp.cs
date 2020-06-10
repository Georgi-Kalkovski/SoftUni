namespace BorderControl
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main()
        {
            
            List<Check> checks = new List<Check>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command
                    .Split();

                if (tokens.Length == 3)
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string id = tokens[2];

                    Check check = new Check(name, age, id);

                    checks.Add(check);
                }

                else if (tokens.Length == 2)
                {
                    string model = tokens[0];
                    string id = tokens[1];

                    Check check = new Check(model, id);

                    checks.Add(check);
                }
            }

            string fakeId = Console.ReadLine();

            foreach (var check in checks)
            {
                if (check.Id.EndsWith(fakeId))
                {
                    Console.WriteLine(check.Id);
                }
            }
        }
    }
}
