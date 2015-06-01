using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HaarbyTennis.BLL;
using HaarbyTennis.Model;


namespace ASPNetMDBTennis.UI
{
    public partial class Nyheder : System.Web.UI.Page
    {
        List<NyhedOplysning> m_NyhederOplysninger_Liste;


        #region Tabel udgave
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    m_NyhederOplysninger_Liste = NyhederService.GetNyheder("DESC", 2010);


        //    foreach (NyhedOplysning nyhederOplysninger_Liste in m_NyhederOplysninger_Liste)
        //    {
        //        if (nyhederOplysninger_Liste.Dato.Year == 2014)
        //        { 
        //            TableRow raekkeData = new TableRow();
        //            TableCell CelleDato = new TableCell();
        //            TableCell CelleOverskrift = new TableCell();
        //            TableCell CelleOverTekst = new TableCell();
        //            TableCell TekstIndhold = new TableCell();

        //            CelleDato.Text = nyhederOplysninger_Liste.Dato.ToShortDateString();
        //            raekkeData.Cells.Add(CelleDato);

        //            CelleOverskrift.Text = nyhederOplysninger_Liste.OverSkrift;
        //            raekkeData.Cells.Add(CelleOverskrift);
        //            if (nyhederOplysninger_Liste.Tekst.Length > 40)
        //                CelleOverTekst.Text = nyhederOplysninger_Liste.Tekst.Substring(0, 40) + "...........";
        //            raekkeData.Cells.Add(CelleOverTekst);
                    

        //            //TekstIndhold = "<a href='"Nyheder.aspx?newsID="'"+"+ nyhederOplysninger_Liste.Id +"'" +"'>Læs mere</a>'";
        //            raekkeData.Cells.Add(TekstIndhold);


        //            // <td class="indhold"> 
			      
                   
        //            //</td>



        //            TableNyheder.Rows.Add(raekkeData);
        //        }


        //    }
        //    //ledeTekst.Font.Bold = false;


        //}
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();

        }
        private void BindData()
        {
            m_NyhederOplysninger_Liste = NyhederService.GetNyheder("DESC", 2014);         

            GridView1.DataSource = m_NyhederOplysninger_Liste;

            GridView1.DataBind();

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

            GridView1.EditIndex = e.NewEditIndex;

            BindData();

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

            GridView1.EditIndex = -1;

            BindData();

        }



        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if (((LinkButton)GridView1.Rows[0].Cells[0].Controls[0]).Text == "Insert")
            {
                //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["exam_moduleConnectionString"].ConnectionString);
                //SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "INSERT INTO quest_categories(cat_name) VALUES(@cat_name)"; cmd.Parameters.Add("@cat_name", SqlDbType.VarChar).Value = ((TextBox)GridView1.Rows[0].Cells[2].Controls[0]).Text;
                //cmd.Connection = con;

                //con.Open();

                //cmd.ExecuteNonQuery();

                //con.Close();

            }

            else
            {
                //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["exam_moduleConnectionString"].ConnectionString);
                //SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "UPDATE quest_categories SET cat_name=@cat_name WHERE cat_id=@cat_id";
                //cmd.Parameters.Add("@cat_name", SqlDbType.VarChar).Value = ((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
                //cmd.Parameters.Add("@cat_id", SqlDbType.Int).Value = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[1].Text);
                //cmd.Connection = con;

                //con.Open();

                //cmd.ExecuteNonQuery();

                //con.Close();



            }



            GridView1.EditIndex = -1;

            BindData();

        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["exam_moduleConnectionString"].ConnectionString);
            //SqlCommand cmd = new SqlCommand();
            long id = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[1].Text);
            NyhederService.DeleteNyhed(id);


            //BindData();

        }

        
        public void GridView1_SelectedIndexChanged(Object sender, EventArgs e)
        {
            // Get the currently selected row using the SelectedRow property.
            GridViewRow row = GridView1.SelectedRow;

            pop_up_label.Visible = true;
            pop_up_label.Text = row.Cells[3].Text;

            int id = Convert.ToInt32(row.Cells[1].Text);
            

            NyhedOplysning opl = new NyhedOplysning();
            opl = NyhederService.GetNyhedByID(id);
            pop_up_label.Text = opl.Tekst;

            //string url = "Popup.aspx";
            //string s = "window.open('" + url + "', 'popup_window', 'width=300,height=100,left=100,top=100,resizable=yes');";
            //ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
        }

     
    }
}