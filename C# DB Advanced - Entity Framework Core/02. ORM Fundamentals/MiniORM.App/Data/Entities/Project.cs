﻿namespace MiniORM.App
{
    using MiniORM.App.Data.Entities;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<EmployeesProject> EmployeeProjects { get; }
    }
}
