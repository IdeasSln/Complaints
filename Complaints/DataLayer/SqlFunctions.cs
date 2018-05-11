using Complaints.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Complaints.DataLayer
{
    public static class SqlFunctions
    {
        private static string strCRMARConnectionString = ConfigurationManager.ConnectionStrings["ComplaintsContext"].ConnectionString;
        public static List<Complaint> GetComplaints(int? Complaint_Id = null)
        {
            SqlConnection conn = new SqlConnection(strCRMARConnectionString);
            List<Complaint> listComplaints = new List<Complaint>();
            try
            {
                listComplaints.Add(new Complaint
                {
                    Complainant = new Person
                    {
                        AKA = "aka",
                        City = "city",
                        DOB = DateTime.Now,
                        First_Name = "firstname",
                        Last_Name = "lastname",
                        Gender = new Gender() { Description = "Male", Id = 1 },
                        Zip = "zuo",
                        Home_Number = "home number",
                        Id = 1,
                        Street = "street",
                        State = "state",
                        Other_Number = "other number",
                        Middle_Name = "middle name",
                        Mobile_Number = "mobile number"
                    },
                    Id = 1,
                    Narrative = "this is narative",
                    Report_Written_By = new Safety_Officer() { Id = 1, UserName = "asdfsaas" },
                    Disposition = new Disposition() { Id = 1, Description = "close" },
                    Report_Reviewed_By = new Safety_Officer() { Id = 1, UserName = "asdfsaas" },
                    Report_Date = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt"),
                    Incident = new Incident() { Description = "asfas", Id = 1 },
                    Incident_Location = new Incident_Location() { Description = "desc_loc", Id = 1 },
                    Incident_Occurance_Date = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt"),
                    Equipment = null,
                    Person_Of_Interest = null
                });


               // conn.Open();

                //string strQuery = "SELECT Record_ID,GENERIC,MEDFORM, DOSE,ROUTE,FREQ,START_DATE,STOP_DATE,Create_Date,UserCreateID,Indication,Special_Instructions,Frequency_Times,Discontinue "
                //    + "FROM MAR_ORDER "
                //    + "WHERE CASE_NO=@CASE_NO AND DISC_DATE IS NULL AND STOP_DATE >=@StopClause";

                //SqlCommand cmd = new SqlCommand(strQuery, conn);
                //SqlDataReader reader = null;

                //cmd.Parameters.AddWithValue("@CASE_NO", CaseNumb);
                //cmd.Parameters.AddWithValue("@StopClause", DateTime.Now.AddDays(-3));
                //reader = cmd.ExecuteReader();

                //while (reader.Read())
                //{
                //    Hashtable htPrescription = new Hashtable();
                //    htPrescription["GENERIC"] = reader["GENERIC"];
                //    htPrescription["MEDFORM"] = reader["MEDFORM"];
                //    htPrescription["DOSE"] = reader["DOSE"];
                //    htPrescription["ROUTE"] = reader["ROUTE"];
                //    htPrescription["FREQ"] = reader["FREQ"];
                //    htPrescription["STARTDATE"] = Convert.ToDateTime(reader["START_DATE"]).ToShortDateString();
                //    htPrescription["STOPDATE"] = Convert.ToDateTime(reader["STOP_DATE"]).ToShortDateString();
                //    htPrescription["Indication"] = reader["Indication"];
                //    htPrescription["UserCreateID"] = reader["UserCreateID"];
                //    htPrescription["CreateDate"] = Convert.ToDateTime(reader["Create_Date"]).ToShortDateString();
                //    htPrescription["SpecialInstructions"] = reader["Special_Instructions"];
                //    htPrescription["RecordID"] = reader["Record_ID"];
                //    htPrescription["FrequencyTimes"] = reader["Frequency_Times"];
                //    htPrescription["Discontinue"] = reader["Discontinue"];

                //    alPrescriptions.Add(htPrescription);
                //}
            }
            catch (Exception eX)
            {
                Console.Write(eX.InnerException);
            }
            finally
            {
                //conn.Close();
            }

            return listComplaints;
        }
        public static List<ViewModel_DropDownGrid> GetTableValues(string TableName)
        {
            List<ViewModel_DropDownGrid> list_ViewModel_DropDownGrid = new List<ViewModel_DropDownGrid>();
            using (SqlConnection connection = new SqlConnection(strCRMARConnectionString))
            {
                connection.Open();

                //string strQuery =
                //    string.Format(@"SELECT ID, DESCRIPTION,ACTIVE
                //     FROM INCIDENT_{0} ", TableName);

                string strQuery =
                   string.Format(@"SELECT Id, Description,Active from {0} ",TableName);

                SqlCommand cmd = new SqlCommand(strQuery, connection);
                SqlDataReader reader = null;

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ViewModel_DropDownGrid viewModel = new ViewModel_DropDownGrid()
                    {
                        TableId = Convert.ToInt32(reader["Id"]),
                        Description = reader["Description"].ToString(),
                        Active = Convert.ToBoolean(reader["Active"])
                    };

                    list_ViewModel_DropDownGrid.Add(viewModel);
                }
            }

            return list_ViewModel_DropDownGrid;
        }

        public static void InsertTableValues(string TableName, ViewModel_DropDownGrid Griddata)
        {
            List<ViewModel_DropDownGrid> list_ViewModel_DropDownGrid = new List<ViewModel_DropDownGrid>();
            using (SqlConnection connection = new SqlConnection(strCRMARConnectionString))
            {
                connection.Open();

                string strQuery =
                    string.Format(@"INSERT INTO {0} (Description,Active) VALUES(@param_Description,@param_Active)", TableName);

                SqlCommand cmd = new SqlCommand(strQuery, connection);
                cmd.Parameters.AddWithValue("@param_Description", Griddata.Description);
                cmd.Parameters.AddWithValue("@param_Active", Griddata.Active);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdateTableValues(string TableName, ViewModel_DropDownGrid Griddata)
        {
            List<ViewModel_DropDownGrid> list_ViewModel_DropDownGrid = new List<ViewModel_DropDownGrid>();
            using (SqlConnection connection = new SqlConnection(strCRMARConnectionString))
            {
                connection.Open();

                string strQuery =
                    string.Format(@"INSERT INTO {0} (Description,Active) VALUES(@param_Description,@param_Active)", TableName);

                SqlCommand cmd = new SqlCommand(strQuery, connection);
                cmd.Parameters.AddWithValue("@param_Description", Griddata.Description);
                cmd.Parameters.AddWithValue("@param_Active", Griddata.Active);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
        }
    }
}