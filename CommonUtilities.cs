using DBSchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBSchoolManagementSystem
{
    public class CommonUtilities
    {
        public static string DepartmentName { get;  set; }
        public static string CourseName { get;  set; }
        public static string FullName { get;  set; }

        public static SelectList GetEmployeeTypeDD()
        {
            using (SchoolManagement db = new SchoolManagement())
            {
                List<SelectListItem> ddlist = new List<SelectListItem>();
                var collection = db.Database.SqlQuery<SelectListModelFunctionClass>(@"select TypeId as Id, TypeName as Title from EmployeeType").ToList();
                
                ddlist.Add(new SelectListItem { Text = "--Select--", Value = "0" });
                foreach (var item in collection)
                {

                    ddlist.Add(new SelectListItem { Text = item.Title, Value = item.Id.ToString() });
                }

                return new SelectList(ddlist.ToList(), "Value", "Text");
            }

        }
        public static SelectList GetCourseTypeDD()
        {
            using (SchoolManagement db = new SchoolManagement())
            {
                List<SelectListItem> ddlist = new List<SelectListItem>();
                var collection = db.Database.SqlQuery<SelectListModelFunctionClass>(@"select TypeId as Id, TypeName as Title from CourseType").ToList();

                ddlist.Add(new SelectListItem { Text = "--Select--", Value = "0" });
                foreach (var item in collection)
                {

                    ddlist.Add(new SelectListItem { Text = item.Title, Value = item.Id.ToString() });
                }

                return new SelectList(ddlist.ToList(), "Value", "Text");
            }

        }
        public static SelectList GetUserTypeDD()
        {
            using (SchoolManagement db = new SchoolManagement())
            {
                List<SelectListItem> ddlist = new List<SelectListItem>();
                var collection = db.Database.SqlQuery<SelectListModelFunctionClass>(@"select UserId as Id, UserName as Title from UserType").ToList();

                ddlist.Add(new SelectListItem { Text = "--Select--", Value = "0" });
                foreach (var item in collection)
                {

                    ddlist.Add(new SelectListItem { Text = item.Title, Value = item.Id.ToString() });
                }

                return new SelectList(ddlist.ToList(), "Value", "Text");
            }

        }
        public static SelectList GetCourseTypeDefaultDD()
        {
            using (SchoolManagement db = new SchoolManagement())
            {
                List<SelectListItem> ddlist = new List<SelectListItem>();
                ddlist.Add(new SelectListItem { Text = "--Select--", Value = "0" });
                return new SelectList(ddlist.ToList(), "Value", "Text");
            }

        }
        public static SelectList GetDepartmentDD()
        {
           using (SchoolManagement db = new SchoolManagement())
          {
           List<SelectListItem> ddlist = new List<SelectListItem>();
           var collection = db.Database.SqlQuery<SelectListModelFunctionClass>(@"select DepartmentId as Id, DepartmenttName as Title from Department").ToList();

           ddlist.Add(new SelectListItem { Text = "--Select--", Value = "0" });
           foreach (var item in collection)
                {

                 ddlist.Add(new SelectListItem { Text = item.Title, Value = item.Id.ToString() });
                }

               return new SelectList(ddlist.ToList(), "Value", "Text");
           }

        }
        public static SelectList GetCourseDD()
        {
            using (SchoolManagement db = new SchoolManagement())
            {
                List<SelectListItem> ddlist = new List<SelectListItem>();
                var collection = db.Database.SqlQuery<SelectListModelFunctionClass>(@"select Courseid as Id, CourseName as Title from Course").ToList();

                ddlist.Add(new SelectListItem { Text = "--Select--", Value = "0" });
                foreach (var item in collection)
                {

                    ddlist.Add(new SelectListItem { Text = item.Title, Value = item.Id.ToString() });
                }

                return new SelectList(ddlist.ToList(), "Value", "Text");
            }

        }

        public static string GetTypeNameFromEmployeeId(int? id)
        {
            string TypeName=string.Empty;
            using (SchoolManagement db = new SchoolManagement())
            {
                try
                {
                    TypeName = db.Database.SqlQuery<string>(@"select TypeName from EmployeeType where TypeId='" +id+ "'").FirstOrDefault();
                    

                }
                catch(Exception)
                {
                    return string.Empty;
                }
                
            }
            return TypeName;
        }

        public static string GetTypeNameFromCourseId(int? id)
        {
            string TypeName = string.Empty;
            using (SchoolManagement db = new SchoolManagement())
            {
                try
                {
                    TypeName = db.Database.SqlQuery<string>(@"select TypeName from CourseType where TypeId='" + id + "'").FirstOrDefault();


                }
                catch (Exception)
                {
                    return string.Empty;
                }

            }
            return TypeName;
        }






        public static string GetDepartmentNameFromDepartmentId(int? id)
        {
            string TypeName = string.Empty;
            using (SchoolManagement db = new SchoolManagement())
            {
                try
                {
                    DepartmentName = db.Database.SqlQuery<string>(@"select DepartmenttName from Department where DepartmentId='" + id + "'").FirstOrDefault();
                    


                }
                catch (Exception)
                {
                    return string.Empty;
                }

            }
            return DepartmentName;
        }
        public static string GetCourseNameFromCourseId(int? id)
        {
            string TypeName = string.Empty;
            using (SchoolManagement db = new SchoolManagement())
            {
                try
                {
                    CourseName = db.Database.SqlQuery<string>(@"select CourseName from Course where Courseid='" + id + "'").FirstOrDefault();



                }
                catch (Exception)
                {
                    return string.Empty;
                }

            }
            return CourseName;
        }
        public static SelectList GetStudentDD()
        {
            using (SchoolManagement db = new SchoolManagement())
            {
                List<SelectListItem> ddlist = new List<SelectListItem>();
                var collection = db.Database.SqlQuery<SelectListModelFunctionClass>(@"select StudentId as Id, FullName as Title from Student").ToList();

                ddlist.Add(new SelectListItem { Text = "--Select--", Value = "0" });
                foreach (var item in collection)
                {

                    ddlist.Add(new SelectListItem { Text = item.Title, Value = item.Id.ToString() });
                }

                return new SelectList(ddlist.ToList(), "Value", "Text");
            }

        }
        public static SelectList GetSubjectDD()
        {
            using (SchoolManagement db = new SchoolManagement())
            {
                List<SelectListItem> ddlist = new List<SelectListItem>();
                var collection = db.Database.SqlQuery<SelectListModelFunctionClass>(@"select SubjectId as Id, SubjectName as Title from Subject").ToList();

                ddlist.Add(new SelectListItem { Text = "--Select--", Value = "0" });
                foreach (var item in collection)
                {

                    ddlist.Add(new SelectListItem { Text = item.Title, Value = item.Id.ToString() });
                }

                return new SelectList(ddlist.ToList(), "Value", "Text");
            }

        }
        public static string GetSubjectNameFromSubjectId(int? id)
        {
            string SubjectName = string.Empty;
            using (SchoolManagement db = new SchoolManagement())
            {
                try
                {
                    CourseName = db.Database.SqlQuery<string>(@"select SubjectName from Subject where SubjectId='" + id + "'").FirstOrDefault();



                }
                catch (Exception)
                {
                    return string.Empty;
                }

            }
            return SubjectName;
        }




        //public static string GetSubjectStudentFromStudentId(int? id)
        //{
        //    string TypeName = string.Empty;
        //    using (SchoolManagement db = new SchoolManagement())
        //    {
        //        try
        //        {
        //            FullName = db.Database.SqlQuery<string>(@"select FullName from Student where StudentId='" + id + "'").FirstOrDefault();



        //        }
        //        catch (Exception)
        //        {
        //            return string.Empty;
        //        }

        //    }
        //    return Name;
        //}



        public class SelectListModelFunctionClass
        {
            public int Id { get; set; }

            public string Idstr { get; set; }
            public string Title { get; set; }

            public int Name { get; set; }
            public string ProvinceTitleNep { get; set; }
            public int BankId { get; set; }
        }

    }
}