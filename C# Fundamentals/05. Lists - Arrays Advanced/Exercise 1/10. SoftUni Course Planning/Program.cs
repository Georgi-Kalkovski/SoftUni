using System;
using System.Collections.Generic;
using System.Linq;


namespace CoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lessons = Console.ReadLine().Split(", ").ToList();

            string input = Console.ReadLine();

            while (input != "course start")
            {
                string[] data = input.Split(':');

                string command = data[0];

                if (command == "Add")
                {
                    string title = data[1];

                    if (lessons.Contains(title) == false)
                    {
                        lessons.Add(title);
                    }
                }
				
                else if (command == "Insert")
                {
                    string title = data[1];
                    int index = int.Parse(data[2]);

                    if (lessons.Contains(title) == false)
                    {
                        if (index >= 0 && index < lessons.Count)
                        {
                            lessons.Insert(index, title);
                        }
                    }
                }
                else if (command == "Remove")
                {
                    string title = data[1];

                    if (lessons.Contains(title))
                    {
                        int index = lessons.IndexOf(title);

                        if (index + 1 < lessons.Count)
                        {
                            if (lessons[index + 1] == $"{title}-Exercise")
                            {
                                lessons.RemoveRange(index, 2);
                            }
							
                            else
                            {
                                lessons.Remove(title);
                            }
                        }
						
                        else
                        {
                            lessons.Remove(title);
                        }
                    }
                }
				
                else if (command == "Swap")
                {
                    string firstTitle = data[1];
                    string secondTitle = data[2];

                    if (lessons.Contains(firstTitle) && lessons.Contains(secondTitle))
                    {
                        int firstTitleIndex = lessons.IndexOf(firstTitle);
                        int secondTitleIndex = lessons.IndexOf(secondTitle);

                        lessons[firstTitleIndex] = secondTitle;
                        lessons[secondTitleIndex] = firstTitle;

                        if (firstTitleIndex + 1 < lessons.Count && secondTitleIndex + 1 < lessons.Count)
                        {
                            if (lessons[firstTitleIndex + 1] == $"{firstTitle}-Exercise" && lessons[secondTitleIndex + 1] == $"{secondTitle}-Exercise")
                            {
                                string temp = lessons[secondTitleIndex + 1];
                                lessons[secondTitleIndex + 1] = lessons[firstTitleIndex + 1];
                                lessons[firstTitleIndex + 1] = temp;
                            }
							
                            else if (lessons[firstTitleIndex + 1] == $"{firstTitle}-Exercise")
                            {
                                lessons.Insert(secondTitleIndex + 1, lessons[firstTitleIndex + 1]);

                                if (secondTitleIndex > firstTitleIndex)
                                {
                                    lessons.RemoveAt(firstTitleIndex + 1);
                                }
								
                                else if (secondTitleIndex < firstTitleIndex)
                                {
                                    lessons.RemoveAt(firstTitleIndex + 2);
                                }

                            }
							
                            else if (lessons[secondTitleIndex + 1] == $"{secondTitle}-Exercise")
                            {
                                lessons.Insert(firstTitleIndex + 1, lessons[secondTitleIndex + 1]);

                                if (firstTitleIndex < secondTitleIndex)
                                {
                                    lessons.RemoveAt(secondTitleIndex + 2);
                                }
								
                                else if (firstTitleIndex > secondTitleIndex)
                                {
                                    lessons.RemoveAt(secondTitleIndex + 1);
                                }
                            }
                        }
						
                        else if (firstTitleIndex + 1 < lessons.Count)
                        {
                            if (lessons[firstTitleIndex + 1] == $"{firstTitle}-Exercise")
                            {
                                lessons.Insert(secondTitleIndex + 1, lessons[firstTitleIndex + 1]);

                                if (secondTitleIndex > firstTitleIndex)
                                {
                                    lessons.RemoveAt(firstTitleIndex + 1);
                                }
								
                                else if (secondTitleIndex < firstTitleIndex)
                                {
                                    lessons.RemoveAt(firstTitleIndex + 2);
                                }
                            }
                        }
						
                        else if (secondTitleIndex + 1 < lessons.Count)
                        {
                            if (lessons[secondTitleIndex + 1] == $"{secondTitle}-Exercise")
                            {
                                lessons.Insert(firstTitleIndex + 1, lessons[secondTitleIndex + 1]);

                                if (firstTitleIndex < secondTitleIndex)
                                {
                                    lessons.RemoveAt(secondTitleIndex + 2);
                                }
								
                                else if (firstTitleIndex > secondTitleIndex)
                                {
                                    lessons.RemoveAt(secondTitleIndex + 1);
                                }
                            }
                        }
                    }
                }
				
                else if (command == "Exercise")
                {
                    string title = data[1];

                    if (lessons.Contains(title))
                    {
                        int index = lessons.IndexOf(title);

                        if (index + 1 < lessons.Count)
                        {
                            if (lessons[index + 1] != $"{title}-Exercise")
                            {
                                lessons.Insert(index + 1, $"{title}-Exercise");
                            }
                        }
						
                        else
                        {
                            lessons.Add($"{title}-Exercise");
                        }
                    }
					
                    else
                    {
                        lessons.Add(title);
                        lessons.Add($"{title}-Exercise");
                    }
                }

                input = Console.ReadLine();
            }

            for (int index = 0; index < lessons.Count; index++)
            {
                Console.WriteLine($"{index + 1}.{lessons[index]}");
            }
        }
    }
}