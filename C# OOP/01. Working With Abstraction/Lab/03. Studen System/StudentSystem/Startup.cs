namespace StudentSystem
{
    class Startup
    {
        static void Main()
        {
            StudentSystem studentSystem = new StudentSystem();

            while (true)
            {
                studentSystem.StudentInfo();
            }
        }
    }
}
