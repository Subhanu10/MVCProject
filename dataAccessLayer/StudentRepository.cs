using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace dataAccessLayer
{

    public interface IStudentRepository
    {
    
        void AddStudent(StudentInformation p);
        void UpdateStudent(StudentInformation details);
        void DeleteStudent(int id);
        StudentInformation GetStudentById(int id);
        List<StudentInformation>GetAllStudents();
        List<State> GetStates();
        List<Gender> GetGender();
        bool CheckDuplicate(int id, string email, string mobilenumber);
    }
   
    public class StudentRepository : IStudentRepository

    {
        public IConfiguration _Configuration;
        string connectionString = string.Empty;
        public StudentRepository(IConfiguration appsettings)
        {
            _Configuration = appsettings;
            connectionString = appsettings.GetSection("DbConnection").Value;
            var connect = appsettings.GetConnectionString("SqlServerConnection");
        }

        
        public List<StudentInformation>GetAllStudents()
        {
            try
            {
                List<StudentInformation> student = new List<StudentInformation>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    SqlCommand com = new SqlCommand("sp_GetAllStudent", connection);
                    com.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    SqlDataReader data = com.ExecuteReader();
                    while (data.Read())
                    {
                        student.Add(new StudentInformation
                        {
                            Id = Convert.ToInt32(data["Id"]),
                            Name = data["Name"].ToString(),
                            Email = data["Email"].ToString(),
                            MobileNumber = data["MobileNumber"].ToString(),
                            StateId = Convert.ToInt32(data["StateId"]),
                            StateName = data["StateName"].ToString(),
                            Gender = data["Gender"].ToString(),
                            DOB = Convert.ToDateTime(data["DOB"])
                        }) ;
                    }

                    return student;
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Gender> GetGender()
        {
            try
            {
                List<Gender> gender = new List<Gender>();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand com = new SqlCommand("sp_GetGender", connection);
                    connection.Open();

                    using (SqlDataReader dr = com.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            gender.Add(new Gender
                            {
                                GenderId = Convert.ToInt32(dr["GenderId"]),
                                GenderName = dr["GenderName"].ToString()

                            });

                        }
                    }
                    
                }
                return gender;
            }
            catch (SqlException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<State> GetStates()
        {
            try
            {
                List<State> states = new List<State>();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand com = new SqlCommand("sp_GetStates", connection);
                    connection.Open();

                    using (SqlDataReader dr = com.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            states.Add(new State
                            {
                                StateId = Convert.ToInt32(dr["StateId"]),
                                StateName = dr["StateName"].ToString()

                            });

                        }
                    }
                   
                }
                return states;
            }
            catch (SqlException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public StudentInformation GetStudentById(int id)
        {
            try
            {
                StudentInformation info = null;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    SqlCommand com = new SqlCommand("sp_GetStudentById", connection);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    SqlDataReader data = com.ExecuteReader();

                    while (data.Read())
                    {
                        info = new StudentInformation
                        {
                            Id = Convert.ToInt32(data["Id"]),
                            Name = data["Name"].ToString(),
                            Email = data["Email"].ToString(),
                            MobileNumber = data["MobileNumber"].ToString(),
                            StateId = Convert.ToInt32(data["StateId"]),
                            StateName = data["StateName"].ToString(),
                            Gender = data["Gender"].ToString(),
                            DOB = Convert.ToDateTime(data["DOB"])
                        };
                    }

                    return info;
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public void AddStudent(StudentInformation p)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {


                    SqlCommand com = new SqlCommand("sp_AddStudent", connection);
                    com.CommandType = CommandType.StoredProcedure;


                    com.Parameters.AddWithValue("@Name", p.Name);
                    com.Parameters.AddWithValue("@Email", p.Email);
                    com.Parameters.AddWithValue("@MobileNumber", p.MobileNumber);
                    com.Parameters.AddWithValue("@StateId", p.StateId);
                    com.Parameters.AddWithValue("@Gender", p.Gender);
                    com.Parameters.AddWithValue("@DOB", p.DOB);


                    connection.Open();
                    com.ExecuteNonQuery();


                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void UpdateStudent(StudentInformation details)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {


                    SqlCommand com = new SqlCommand("sp_UpdateStudent", connection);
                    com.CommandType = CommandType.StoredProcedure;

                    com.Parameters.AddWithValue("@Id", details.Id);
                    com.Parameters.AddWithValue("@Name", details.Name);
                    com.Parameters.AddWithValue("@Email", details.Email);
                    com.Parameters.AddWithValue("@MobileNumber", details.MobileNumber);
                    com.Parameters.AddWithValue("@StateId", details.StateId);
                    com.Parameters.AddWithValue("@Gender", details.Gender);
                    com.Parameters.AddWithValue("@DOB", details.DOB);


                    connection.Open();
                    com.ExecuteNonQuery();


                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void DeleteStudent(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {


                    SqlCommand com = new SqlCommand("sp_DeleteStudent", connection);
                    com.CommandType = CommandType.StoredProcedure;


                    com.Parameters.AddWithValue("@Id", id);



                    connection.Open();
                    com.ExecuteNonQuery();


                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public bool CheckDuplicate( int id, string email, string mobilenumber)
        {


            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                
                    SqlCommand com = new SqlCommand("CheckDuplicate", connection);
                    com.CommandType = CommandType.StoredProcedure;

                    com.Parameters.AddWithValue("@Id", id);
                    com.Parameters.AddWithValue("@Email", email);
                    com.Parameters.AddWithValue("@MobileNumber", mobilenumber);

                

                connection.Open();
                int result = Convert.ToInt32(com.ExecuteScalar());
                return result == 1;



            }
        }
    }
}