using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using StorageCompany.Models.StoredProcedure;
using StorageCompany.Models;

namespace StorageCompany.DataAccessLayer
{

    public class DataAccessObject
    {
        SqlConnection myConnection;
        SqlCommand myCommand;
        //SqlDataReader myDataReader;

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

        // getListMovement
        public DataSet fillListMovement(String table = "Table")
        {
            String query = "getListMovement";
            DataSet dataSet = fill(query, table);
            return dataSet;
        }

        public List<ListMovement> getListMovement()
        {
            DataSet ds = fillListMovement();
            List<ListMovement> list = new List<ListMovement>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new ListMovement
                {
                    id = int.Parse(dr[0].ToString()),
                    type = dr[1].ToString(),
                    status = dr[2].ToString(),
                    product = dr[3].ToString(),
                    newStorage = dr[4].ToString(),
                    oldStorage = dr[5].ToString(),
                    dateDone = DateTime.Parse(dr[6].ToString()),
                    timeExpire = DateTime.Parse(dr[7].ToString())

                });
            }
            return list;
        }

        // getListStorageFree
        public DataSet fillListStorageFree(DateTime date, string table = "Table")
        {
            DataSet myDataSet = new DataSet();
            SqlDataAdapter myDataAdapter;
            String query = "getListStorageFree";
            myDataSet.Tables.Add(table);
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
            SqlCommand myCommand = new SqlCommand(query, myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.Add("@date", SqlDbType.DateTime, 20).Value = date;
            myDataAdapter = new SqlDataAdapter(myCommand);
            myDataAdapter.Fill(myDataSet, table);
            myConnection.Close();
            return myDataSet;
        }

        public List<Storage> getListEmptyStorage(DateTime date)
        {
            int? a;
            DataSet ds = fillListStorageFree(date);
            List<Storage> list = new List<Storage>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr[2].ToString() == null)
                {
                    a = null;
                }
                else
                {
                    a = int.Parse(dr[2].ToString());
                }
                list.Add(new Storage
                {
                    id = int.Parse(dr[0].ToString()),
                    storageTypeId = int.Parse(dr[1].ToString()),
                    storageParentId = a,
                    name = dr[3].ToString(),
                    usable = bool.Parse(dr[4].ToString())
                });
            }
            return list;
        }

        public List<Storage> subList(List<Storage> list, List<ItemIn> listItemIn)
        {
            List<Storage> newlist = new List<Storage>(list);
            if (listItemIn != null)
            {
                foreach (ItemIn i in listItemIn)
                {
                    foreach (Storage s in list)
                    {
                        if (s.id == i.storageId)
                        {
                            newlist.Remove(s);
                        }
                    }
                }
            }
            return newlist;
        }
    }

}