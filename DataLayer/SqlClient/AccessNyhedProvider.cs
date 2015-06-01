using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Web.Caching;
using System.Data.OleDb;
using HaarbyTennis.DAL;
using HaarbyTennis.Model;

namespace HaarbyTennis.DAL.SqlClient
{
    public class AccessNyhedProvider : PublicProvider
    {

        /// <summary>
        /// Retrieves all products
        /// </summary>
        public override List<HaarbyTennis.Model.NyhedOplysning> GetNyheder(string sortExpression, int aarstal)
        {

            using (OleDbConnection objConn = new OleDbConnection(this.ConnectionString))
            //using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                sortExpression = EnsureValidProductsSortExpression(sortExpression);

                string sqlStmt = string.Format("SELECT TOP 5 * FROM Nyheder ORDER BY DATO " + sortExpression );
                OleDbCommand objCommand = new OleDbCommand(sqlStmt, objConn);
                //SqlCommand cmd = new SqlCommand(sqlStmt, cn);
                //cn.Open();
                objConn.Open();
                //OleDbDataReader objDataReader;
                //objDataReader = objCommand.ExecuteReader();
                return GetNyhedCollectionFromReader(ExecuteReader(objCommand));
                //return GetNyhedCollectionFromReader(ExecuteReader(cmd));
            }
        }

        /// <summary>
        /// Returns the total number of products
        /// </summary>
        public override int GetNyhedCount()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("tbh_Public_GetNyhedCount", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                return (int)ExecuteScalar(cmd);
            }
        }

        /// <summary>
        /// Retrieves all products for the specified department
        /// </summary>
        public override List<HaarbyTennis.Model.NyhedOplysning> GetNyheder(int departmentID, string sortExpression, int pageIndex, int pageSize)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                sortExpression = EnsureValidProductsSortExpression(sortExpression);
                int lowerBound = pageIndex * pageSize + 1;
                int upperBound = (pageIndex + 1) * pageSize;
                string sql = string.Format(@"SELECT * FROM
(
   SELECT tbh_Products.ProductID, tbh_Products.AddedDate, tbh_Products.AddedBy, tbh_Products.DepartmentID, tbh_Products.Title, 
      tbh_Products.Description, tbh_Products.SKU, tbh_Products.UnitPrice, tbh_Products.DiscountPercentage, 
      tbh_Products.UnitsInStock, tbh_Products.SmallImageUrl, tbh_Products.FullImageUrl, tbh_Products.Votes, 
      tbh_Products.TotalRating, tbh_Departments.Title AS DepartmentTitle, 
      ROW_NUMBER() OVER (ORDER BY {0}) AS RowNum
   FROM tbh_Products INNER JOIN
      tbh_Departments ON tbh_Products.DepartmentID = tbh_Departments.DepartmentID
   WHERE tbh_Products.DepartmentID = {1}
) DepartmentProducts
   WHERE DepartmentProducts.RowNum BETWEEN {2} AND {3}
   ORDER BY RowNum ASC", sortExpression, departmentID, lowerBound, upperBound);
                SqlCommand cmd = new SqlCommand(sql, cn);
                cn.Open();
                return GetNyhedCollectionFromReader(ExecuteReader(cmd));
            }
        }


        /// <summary>
        /// Retrieves the product with the specified ID
        /// </summary>
        public override HaarbyTennis.Model.NyhedOplysning GetNyhedByID(int nyhedID)
        {
            using (OleDbConnection objConn = new OleDbConnection(this.ConnectionString))
            {


                string sqlStmt = string.Format("SELECT * FROM Nyheder where Id = " +  nyhedID );
                OleDbCommand objCommand = new OleDbCommand(sqlStmt, objConn);
                objConn.Open();
                
                IDataReader reader = ExecuteReader(objCommand, CommandBehavior.SingleRow);
                if (reader.Read())
                    return GetNyhedFromReader(reader);
                else
                    return null;
                //SqlCommand cmd = new SqlCommand("tbh_Public_GetNyhedByID", cn);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@NyhedID", SqlDbType.Int).Value = nyhedID;
                //cn.Open();
                //IDataReader reader = ExecuteReader(cmd, CommandBehavior.SingleRow);
                //if (reader.Read())
                //    return GetNyhedFromReader(reader);
                //else
                //    return null;
            }
        }



        /// <summary>
        /// Deletes a product
        /// </summary>
        public override bool DeleteNyhed(long nyhedID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("tbh_Public_DeleteNyhed", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@NyhedID", SqlDbType.Int).Value = nyhedID;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        /// <summary>
        ///// Inserts a new product
        ///// </summary>
        //public override int InsertNyhed(NyhedDetails nyhed)
        //{
        //    using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand("tbh_Public_InsertNyhed", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add("@dato", SqlDbType.DateTime).Value = nyhed.Dato;
        //        cmd.Parameters.Add("@overskrift", SqlDbType.NVarChar).Value = nyhed.OverSkrift;
        //        cmd.Parameters.Add("@tekst", SqlDbType.NVarChar).Value = nyhed.Tekst;
        //        cmd.Parameters.Add("@Billede_1", SqlDbType.NVarChar).Value = nyhed.Billede_1;
        //        cmd.Parameters.Add("@Billede_2", SqlDbType.NVarChar).Value = nyhed.Billede_2;
        //        cmd.Parameters.Add("@Redirect", SqlDbType.NVarChar).Value = nyhed.Redirect;
        //        cn.Open();
        //        int ret = ExecuteNonQuery(cmd);
        //        return (int)cmd.Parameters["@NyhedID"].Value;
        //    }
        //}

        /// <summary>
        /// Updates an product
        /// </summary>
        //public override bool UpdateNyhedStoredProc(NyhedDetails nyhed)
        //{
        //    using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand("tbh_Store_UpdateProduct", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add("@id", SqlDbType.Int).Value = nyhed.Id;
        //        cmd.Parameters.Add("@dato", SqlDbType.DateTime).Value = nyhed.Dato;
        //        cmd.Parameters.Add("@overskrift", SqlDbType.NVarChar).Value = nyhed.OverSkrift;
        //        cmd.Parameters.Add("@tekst", SqlDbType.NVarChar).Value = nyhed.Tekst;
        //        cmd.Parameters.Add("@Billede1", SqlDbType.NVarChar).Value = nyhed.Billede_1;
        //        cmd.Parameters.Add("@Billede2", SqlDbType.NVarChar).Value = nyhed.Billede_2;
        //        cmd.Parameters.Add("@Redirect", SqlDbType.NVarChar).Value = nyhed.Redirect;
        //        cn.Open();
        //        int ret = ExecuteNonQuery(cmd);
        //        return (ret == 1);
        //    }
        //}

        /// <summary>
        /// Indsætter et medlem
        /// </summary>
        public override bool InsertNyhed(NyhedOplysning nyhed)
        {
            using (OleDbConnection objConn = new OleDbConnection(this.ConnectionString))
            //using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                //query += "insert into tbnewsletters (title, text, name, created) values ('" + Title.Replace("'", "''") + "', '" + Text.Replace("'", "''") + "', '" + Name.Replace("'", "''") + "', '" + UKDateTimeFormat(Created) + "')";
                //string sqlStmt = string.Format("insert into Medlemsoplysninger (Efternavn, Fornavn, Adresse, Postnummer, Bynavn, Tlf_1, Email, Foedselsdato, Kontingent, Indendørs, Rabat, Boldkanon, JaTilNyheder) values ('" + 
                string sqlStmt = string.Format("insert into nyheder (dato, overskrift, tekst, billede1, billede2, Redirect, ImgWidth, ImgHight) values ('" +
                    nyhed.Dato + "', '" +
                    nyhed.OverSkrift + "', '" +
                    nyhed.Tekst + "', '" +
                    nyhed.Billede_1 + "', '" +
                    nyhed.Billede_2 + "', '" +
                    nyhed.Redirect + "', '" +
                    "" + "', '" +
                    "" +    
                    "' )");

                OleDbCommand objCommand = new OleDbCommand(sqlStmt, objConn);
                //SqlCommand cmd = new SqlCommand(sqlStmt, cn);
                //cn.Open();
                objConn.Open();
                int ret = objCommand.ExecuteNonQuery();
                return (ret == 1);


            }
        }


        /// <summary>
        /// Updates an product
        /// </summary>
        public override bool UpdateNyhed(NyhedOplysning nyhed)
        {

           
            using (OleDbConnection objConn = new OleDbConnection(this.ConnectionString))
            //using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                //query += "update tbnewsletters set title = '" + Title + "', text = '" + Text + "', name = '" + Name.Replace("'", "''") + "', created = '" + UKDateTimeFormat(Created) + "' where id = " + Id;
                string sqlStmt = string.Format("update Nyheder " +
                    " set dato = '" + nyhed.Dato +
                    "', overskrift = '" + nyhed.OverSkrift +
                    "', tekst = '" + nyhed.Tekst +
                    "' where id = " + nyhed.Id);

                OleDbCommand objCommand = new OleDbCommand(sqlStmt, objConn);
                //SqlCommand cmd = new SqlCommand(sqlStmt, cn);
                //cn.Open();
                objConn.Open();
                int ret = objCommand.ExecuteNonQuery();
                return (ret == 1);


            }
        }





    }
}
