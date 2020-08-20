namespace PlayersAndMonsters.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    using Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(ICommandInterpreter commandInterpreter, IReader reader, IWriter writer)
        {
            this.commandInterpreter = commandInterpreter;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            var sb = new StringBuilder();

            while (true)
            {
                string[] inputArgs = this.reader.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (inputArgs[0] == "Exit")
                {
                    break;
                }

                try
                {
                    string result = this.commandInterpreter.Read(inputArgs);
                    this.writer.WriteLine(result);
                    sb.AppendLine(result);
                }
                catch (TargetInvocationException ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                    sb.AppendLine(ex.InnerException.Message);
                }
            }
        }
    }
}
