using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using System.Text;

public class Example

{
    public static void Main(string[] args)

    {
        string input = Console.ReadLine();
        var users = new Dictionary<string, string>();

        while (input != "Lumpawaroo")
        {
            if (input.Contains('|'))
            {
                string[] splt = input.Split('|').Select(s => s.Trim()).ToArray();

                if (!users.ContainsKey(splt[1]))
                {
                    users.Add(splt[1], splt[0]);
                }
            }
			
            else
            {
                string[] splt = input.Split("->".ToCharArray()).Select(s => s.Trim()).ToArray();
				
                if (users.ContainsKey(splt[0]))
                {
                    users[splt[0]] = splt[2];
                    Console.WriteLine($"{splt[0]} joins the {splt[2]} side!");
                }
				
                else
                {
                    users.Add(splt[0], splt[2]);
                    Console.WriteLine($"{splt[0]} joins the {splt[2]} side!");

                }
            }
			
            input = Console.ReadLine();
        }

        foreach (var side in users.GroupBy(x => x.Value).OrderByDescending(t => t.Count()).ThenBy(a => a.Key))
        {
            Console.WriteLine($"Side: { side.Key}, Members: {side.Count()} ");

            foreach (var user in side.OrderBy(d => d.Key))
            {
                Console.WriteLine($"! {user.Key}");
            }
        }
    }
}