using System;
using System.Collections.Generic;
using System.Data;
using WebPractice_ADO.DataAccess;
using WebPractice_ADO.Models;

namespace WebPractice_ADO.DataAcess
{
    public class ProductDAO
    {
        private static List<Product> ConvertToListProduct(DataTable dt)
        {
            List<Product> students = new List<Product>();
            foreach (DataRow dr in dt.Rows)
            {
                students.Add(new Product(
                    Convert.ToInt32(dr[0]),
                    dr[1].ToString(),
                    Convert.ToInt32(dr[2]),
                    Convert.ToInt32(dr[3]),
                    dr[4].ToString(),
                    new Category(Convert.ToInt32(dr[5]))
                    ));
            }
            return students;
        }

        private static List<Category> ConvertToListCat(DataTable dt)
        {

            List<Category> cat = new List<Category>();
            foreach (DataRow dr in dt.Rows)
            {
                cat.Add(new Category(
                Convert.ToInt32(dr[0]),
                dr[1].ToString()));
            }

            return cat;
        }


        public static List<Product> GetAllProduct()
        {
            string sql = "select * from Products";
            DataTable dt = DAO.GetDataBySql(sql, null);
            //dt -> List<Student>
            return ConvertToListProduct(dt);
        }

        public static List<Category> GetAllCat()
        {
            string sql = "select * from Major";
            DataTable dt = DAO.GetDataBySql(sql, null);
            return ConvertToListCat(dt);
        }


        public static List<Product> GetStudentsByCatid(string major)
        {
            string sql = "select * from Students where major = @major";
            SqlParameter[] parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@major", SqlDbType.VarChar);
            parameter[0].Value = major;
            DataTable dt = DAO.GetDataBySql(sql, parameter);
            return ConvertToListStudent(dt);
        }

        public static int checkExistStudent(int id)
        {
            string sql = "select count(*) from Students where id = @id";
            SqlParameter[] parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@id", SqlDbType.VarChar);
            parameter[0].Value = id;
            return Convert.ToInt32(DAO.GetDataBySql(sql, parameter).Rows[0][0].ToString());
        }

        public static int insertStudent(Student student)
        {
            string sql = "insert into  Students values (@id, @name, @gender, @dob, @major, @active, @scholarship)";
            SqlParameter[] parameter = new SqlParameter[7];
            parameter[0] = new SqlParameter("@id", SqlDbType.Int);
            parameter[0].Value = student.Id;
            parameter[1] = new SqlParameter("@name", SqlDbType.VarChar);
            parameter[1].Value = student.Name;
            parameter[2] = new SqlParameter("@gender", SqlDbType.Bit);
            parameter[2].Value = student.Gender.Equals("Male") ? 0 : 1;
            parameter[3] = new SqlParameter("@dob", SqlDbType.Date);
            parameter[3].Value = student.DOB;
            parameter[4] = new SqlParameter("@major", SqlDbType.VarChar);
            parameter[4].Value = student.Major.Code;
            parameter[5] = new SqlParameter("@active", SqlDbType.Bit);
            parameter[5].Value = student.Active ? 1 : 0;
            parameter[6] = new SqlParameter("@scholarship", SqlDbType.Int);
            parameter[6].Value = student.Scholarship;
            return DAO.ExecuteSql(sql, parameter);
        }
        public static int deleteStudent(int id)
        {
            string sql = "delete from Students where id = @id";
            SqlParameter[] parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@id", SqlDbType.Int);
            parameter[0].Value = id;
            return DAO.ExecuteSql(sql, parameter);
        }

        public static int editStudent(Student student)
        {
            string sql = "update Students set name = @name, gender = @gender, dob = @dob, major = @major, active = @active, scholarship = @scholarship where id = @id";
            SqlParameter[] parameter = new SqlParameter[7];
            parameter[0] = new SqlParameter("@name", SqlDbType.VarChar);
            parameter[0].Value = student.Name;
            parameter[1] = new SqlParameter("@gender", SqlDbType.Bit);
            parameter[1].Value = student.Gender.Equals("Male") ? 0 : 1;
            parameter[2] = new SqlParameter("@dob", SqlDbType.Date);
            parameter[2].Value = student.DOB;
            parameter[3] = new SqlParameter("@major", SqlDbType.VarChar);
            parameter[3].Value = student.Major.Code;
            parameter[4] = new SqlParameter("@active", SqlDbType.Bit);
            parameter[4].Value = student.Active ? 1 : 0;
            parameter[5] = new SqlParameter("@scholarship", SqlDbType.Int);
            parameter[5].Value = student.Scholarship;
            parameter[6] = new SqlParameter("@id", SqlDbType.Int);
            parameter[6].Value = student.Id;
            return DAO.ExecuteSql(sql, parameter);
        }
    }
}
