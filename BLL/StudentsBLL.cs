﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial_EntityFrameWorkCore.DAL;
using Tutorial_EntityFrameWorkCore.Models;

namespace Tutorial_EntityFrameWorkCore.BLL
{
    class StudentsBLL
    {
        public static List<Students> StudentsByName(string name)
        {
            var context = new SchoolContext();
            var students = context.Students
                            .Where(s => s.FirstName == name)
                            .ToList();

            return students;
        }

        public static Students FirstStudentsByName(string name)
        {
            var context = new SchoolContext();
            var student = context.Students
                            .Where(s => s.FirstName == name)
                            .Include(s => s.Grade)
                            .FirstOrDefault();

            return student;
        }

        public static Students FirstStudentsByNameRawQuery(string name)
        {
            var context = new SchoolContext();
            var student = context.Students
                            .FromSqlRaw($"SELECT * FROM Students WHERE FirstName = '{name}'")
                            .Include(s => s.Grade)
                            .FirstOrDefault();

            return student;
        }
    }
}
