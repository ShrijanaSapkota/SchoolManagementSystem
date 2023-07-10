using DBSchoolManagementSystem.Controllers;
using DBSchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace DBSchoolManagementSystem.Services
{
    public class StudentServices
    {
        public string InsertStudent(Student model)
        {
            using (SchoolManagement db = new SchoolManagement())
            {
                string ReturnMessage = string.Empty;

                var TypeNameParam = new SqlParameter { ParameterName = "@FullName", Value = model.FullName };
                var AddressParam = new SqlParameter { ParameterName = "@Address", Value = model.Address };
                var EmailParam = new SqlParameter { ParameterName = "@Email", Value = model.Email };
                var ContactnoParam = new SqlParameter { ParameterName = "@Contactno", Value = model.Contactno };
                var GenderParam = new SqlParameter { ParameterName = "@Gender", Value = model.Gender};
                var EnrollmentDateParam = new SqlParameter { ParameterName = "@EnrollmentDate", Value = model.EnrollmentDate };
                var TypeIdParam =new SqlParameter { ParameterName="@TypeId",Value = model.TypeId};
                var MessageParam = new SqlParameter
                {
                    ParameterName = "@Message",
                    DbType = DbType.String,
                    Size = 50,
                    Direction = ParameterDirection.Output
                };

                var PrimaryIdParam = new SqlParameter
                {
                    ParameterName = "@SID",
                    DbType = DbType.Int32,
                    Direction = ParameterDirection.Output
                };

                var result = db.Database.ExecuteSqlCommand("exec InsertStudent @FullName,@Address,@Email,@Contactno,@Gender,@EnrollmentDate,@Message OUT,@SID OUT", TypeNameParam,AddressParam,EmailParam,ContactnoParam,GenderParam,EnrollmentDateParam, TypeIdParam,MessageParam,PrimaryIdParam);
         
                int PKID = (int)PrimaryIdParam.Value;
                ReturnMessage = MessageParam.SqlValue.ToString();

                return ReturnMessage;
            }
        }

        public string UpdateStudent(Student model)
        {
            using (SchoolManagement db = new SchoolManagement())
            {
                string ReturnMessage = string.Empty;

                var StudentIdParam = new SqlParameter { ParameterName = "@StudentId", Value = model.StudentId };
                var TypeNameParam = new SqlParameter { ParameterName = "@FullName", Value = model.FullName };
                var AddressParam = new SqlParameter { ParameterName = "@Address", Value = model.Address };
                var EmailParam = new SqlParameter { ParameterName = "@Email", Value = model.Email };
                var ContactnoParam = new SqlParameter { ParameterName = "@Contactno", Value = model.Contactno };
                var GenderParam = new SqlParameter { ParameterName = "@Gender", Value = model.Gender };
                var EnrollmentDateParam = new SqlParameter { ParameterName = "@EnrollmentDate", Value = model.EnrollmentDate };
                var MessageParam = new SqlParameter
                {
                    ParameterName = "@Message",
                    DbType = DbType.String,
                    Size = 50,
                    Direction = ParameterDirection.Output
                };

                var result = db.Database.ExecuteSqlCommand("exec UpdateStudent @StudentId, @FullName, @Address, @Email, @Contactno, @Gender, @EnrollmentDate, @Message OUT",
                    StudentIdParam,TypeNameParam, AddressParam, EmailParam, ContactnoParam, GenderParam, EnrollmentDateParam, MessageParam);

                ReturnMessage = MessageParam.SqlValue.ToString();

                return ReturnMessage;
            }
        }
        public string DeleteStudent(int StudentId)
        {
            using (SchoolManagement db = new SchoolManagement())
            {
                string returnMessage = string.Empty;

                var studentIdParam = new SqlParameter { ParameterName = "@StudentId", Value = StudentId };
                var messageParam = new SqlParameter
                {
                    ParameterName = "@Message",
                    DbType = DbType.String,
                    Size = 50,
                    Direction = ParameterDirection.Output
                };

                var result = db.Database.ExecuteSqlCommand("exec DeleteStudent @StudentId, @Message OUT",
                     studentIdParam, messageParam);

                returnMessage = messageParam.SqlValue.ToString();

                return returnMessage;
            }
        }
        public List<StudentVm> GetStudentList()
        {
            using (SchoolManagement db = new SchoolManagement())
            {
                List<StudentVm> StudentList = new List<StudentVm>();

                StudentList = db.Database.SqlQuery<StudentVm>("exec ListStudent").ToList();

                return StudentList;
            } 
        }

        public List<AspNetRoles> GetAspNetRolesList()
        {
            using (SchoolManagement db = new SchoolManagement())
            {
                List<AspNetRoles> AspNetUserRolesList = new List<AspNetRoles>();

                AspNetUserRolesList = db.Database.SqlQuery<AspNetRoles>("exec ListUserRoles").ToList();

                return AspNetUserRolesList;
            }
        }

       public List<leaveNote>GetLeaveNoteList()
        {
            using (SchoolManagement  db= new SchoolManagement())
                    {
                List<leaveNote> leaveNotes = new List<leaveNote>();
                leaveNotes = db.Database.SqlQuery<leaveNote>("exec ListLeaveNote").ToList();
                return leaveNotes;
            }
           
        }


    }



}

   

