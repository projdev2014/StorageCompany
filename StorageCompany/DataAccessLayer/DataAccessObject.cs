using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using StorageCompany.Models.StoredProcedure.StorageCompany.DataAccessLayer;

namespace StorageCompany.DataAccessLayer
{
    
    public class DataAccessObject
    {
        SqlConnection myConnection;
        SqlCommand myCommand;
        SqlDataReader myDataReader;

        public DataAccessObject()
        {
            myConnection = ConnectionSql.getConnection();
        }

        private DataSet fill(String storeProc, String table)
        {
            DataSet myDataSet = new DataSet();
            SqlDataAdapter myDataAdapter;
            try
            {
                if (myConnection.State.ToString() == "Closed")
                {
                    myConnection.Open();
                }
            }
            catch (SqlException exp)
            {
                throw new Exception(" Erreur lors de la connexion à la base de donnée !", exp);
            }
            myCommand = myConnection.CreateCommand();
            myCommand.Connection = myConnection;
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = storeProc;

            myDataAdapter = new SqlDataAdapter(myCommand);
            myDataAdapter.Fill(myDataSet, table);

            myConnection.Close();
            return myDataSet;
        }

        // getListOrder
        public DataSet fillListOrder(String table = "Table")
        {
            String query = "getListOrder";
            DataSet dataSet = fill(query, table);
            return dataSet;
        }

        public List<ListOrder> getListOrder()
        {
            DataSet ds = fillListOrder();
            List<ListOrder> list = new List<ListOrder>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new ListOrder
                {
                    id = int.Parse(dr[0].ToString()),
                    type = dr[1].ToString(),
                    senderName = dr[2].ToString(),
                    recipientName = dr[3].ToString(),
                    dateAsked = DateTime.Parse(dr[4].ToString()),
                    dateEstimated = DateTime.Parse(dr[5].ToString()),
                    dateDone = DateTime.Parse(dr[6].ToString())
                });
            }
            return list;
        }

    }
    
}