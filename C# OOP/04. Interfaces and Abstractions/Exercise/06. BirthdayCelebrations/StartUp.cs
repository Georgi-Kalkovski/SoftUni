namespace BirthdayCelebrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlTypes;
    using System.Globalization;

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

                string kind = tokens[0];

                if (kind == "Citizen")
                {
                    string name = tokens[1];
                    int age = int.Parse(tokens[2]);
                    string id = tokens[3];
                    DateTime dateTime = DateTime.ParseExact(tokens[4], "dd/MM/yyyy", null);

                    Check check = new Check(name, age, id,dateTime);

                    checks.Add(check);
                }

                else if (kind == "Pet")
                {
                    string name = tokens[1];
                    DateTime dateTime = DateTime.ParseExact(tokens[2], "dd/MM/yyyy", null);

                    Check check = new Check(name, dateTime);

                    checks.Add(check);
                }

                else if (kind == "Robot")
                {
                    string model = tokens[1];
                    string id = tokens[2];

                    Check check = new Check(model, id);

                    checks.Add(check);
                }
            }

            int year = int.Parse(Console.ReadLine());

            foreach (var check in checks)
            {
                if (check.Birthdate.Year.Equals(year))
                {
                    Console.WriteLine(FormatedDateString(check.Birthdate));
                }
            }
        }

        public static string FormatedDateString(DateTime birthdate)
        {
            if (birthdate == SqlDateTime.MinValue.Value)
                return string.Empty;
            else
                return birthdate.ToString("dd/MM/yyyy").Replace('.','/');
        }
    }
}
