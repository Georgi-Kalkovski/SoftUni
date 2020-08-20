﻿namespace P03._Database_After.Contracts
{
    using System.Collections.Generic;

    public interface ICourseData
    {
        IEnumerable<int> CourseIds();

        IEnumerable<string> CourseNames();

        IEnumerable<string> Search(string substring);

        string GetCourseById(int id);
    }
}
