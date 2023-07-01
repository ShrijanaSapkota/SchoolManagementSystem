using DBSchoolManagementSystem.Controllers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace DBSchoolManagementSystem.Models
{
    public class SchoolManagement : DbContext
    {
        
        public DbSet<Student> Student { get; set; }
        public DbSet<Instructor> Instructor { get; set; }
        public DbSet<Course> Course{ get; set; }

        public DbSet<Department> Department { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<StudentSubject> StudentSubject{ get; set; }
        //public object StudentSubjectList { get;  set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)

        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        //public System.Data.Entity.DbSet<DBSchoolManagementSystem.Models.Subject> Subjects { get; set; }
        //public object SubjectStudent { get; internal set; }
    }
}