using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using HaarbyTennis.Model;
using HaarbyTennis.BLL;
using HaarbyTennis.App.Logic;
using HaarbyTennis.App;
using HaarbyTennis.AppState;
using HaarbyTennis.Utilities;
using OfficeOpenXml;

namespace ASPNetMDBTennis.Admin
{
    public partial class AdminMedlemmer : System.Web.UI.Page
    {
        List<Medlem> m_MedlemOplysninger_Liste;

        private const int VIEW_INDEX_LISTE = 0;
        private const int VIEW_INDEX_EDIT = 1;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                //TODO: HUSK at udkommentere.
                //Response.Redirect("/UI/Velkommen.aspx", true);
                
            }
            

            if (!IsPostBack)
            {

                SetupListForm();

            }

            this.ClearErrorMessage();

        }
        public ApplicationContext AppContext
        {
            get
            {
                ApplicationContext result = (ApplicationContext)Session["ApplicationContext"];
                if (result == null)
                {
                    result = new ApplicationContext();
                    Session["ApplicationContext"] = result;
                }
                return result;
            }
        }

        public AdmMedlemmerState State
        {
            get
            {
                AdmMedlemmerState state = (AdmMedlemmerState)Session["AdmMedlemmerState"];
                if (state == null)
                {
                    state = new AdmMedlemmerState();
                    Session["AdmMedlemmerState"] = state;
                }
                return state;
            }
        }

        #region Liste...

        private void SetupListForm()
        {
            if (!IsPostBack)
            {
                SetupSearchBox();
            }

            BindList();        
            ClearErrorMessage();
            mvMain.ActiveViewIndex = VIEW_INDEX_LISTE;
        }



        private void SetupSearchBox()
        {



            ddlSearchEfterMedlemstype.Items.Add(new ListItem("Fornavn", ""));
            ddlSearchEfterMedlemstype.Items.Add(new ListItem("Seniorer", "1"));
            ddlSearchEfterMedlemstype.Items.Add(new ListItem("Juniorer", "2"));
            ddlSearchEfterMedlemstype.Items.Add(new ListItem("Master 2014", "3"));
            ddlSearchEfterMedlemstype.Items.Add(new ListItem("Udmeldte medlemmer", "4"));
           
           
           


        }

        private void SetupEditBox()
        {


          


        }



        #endregion // Liste...


        private void BindList()
        {


            m_MedlemOplysninger_Liste = MedlemmerService.GetMedlemmer("ASC", ddlSearchEfterMedlemstype.SelectedValue);
            //Undersøg hvilke af de 6 dropdown bokse er valgt
            if (!string.IsNullOrWhiteSpace(ddlSearchEfterMedlemstype.SelectedValue))
            {


            }


            lvMain.DataSource = m_MedlemOplysninger_Liste;
        
            lvMain.DataBind();

            //todo: anvend state
            //this.State.CurrentItem = null;
         

            ClearErrorMessage();
        }

        #region Edit...
        private void SetupEditForm()
        {
            ClearErrorMessage();

            if (this.State.AppState == HaarbyTennis.App.FormState.Edit)
            {
                divNewUserFetch.Visible = false; //Oprette
                divUser.Visible = true; //Rette
                btnEditSave.Visible = true;
                btnEditBack.Visible = true;           
            
                divInfo.Visible = false;
                EditUserToPage();
            }
            else
                //Ret alle udsøgte elementer                
                if (this.State.AppState == HaarbyTennis.App.FormState.EditAll)
                {
                    divNewUserFetch.Visible = false; //Oprette
                    divUser.Visible = false; //Rette
                    btnEditSave.Visible = false;
                    btnEditBack.Visible = false;                  
                    EditUserToPage();
                }
                else if (this.State.AppState == HaarbyTennis.App.FormState.New)
                {
                    // Opsæt hvilke elementer der er synlige...
                    divNewUserFetch.Visible = true;
                    divUser.Visible = false;
                    btnEditSave.Visible = true;            
                    divInfo.Visible = false;
                    SetupEditBox();

                }
                else
                {
                    ShowErrorMessage("Ukendt visning valgt.");
                }
            mvMain.ActiveViewIndex = VIEW_INDEX_EDIT;
        }


        private void EditUserToPage()
        {
            //Hent et enkelt mail-adresse til editering
            if (this.State.AppState == HaarbyTennis.App.FormState.Edit)
            {
                Medlem medlem = this.State.Current_Medlem;
                txtEditId.Text = medlem.Id.ToString();
                txtEditFornavn.Text = medlem.Fornavn;
                txtEditEfternavn.Text = medlem.Efternavn;
                txtEditAdresse.Text = medlem.Adresse;
                txtEditPostnummer.Text = medlem.Postnummer;
                txtEditBynavn.Text = medlem.Bynavn;
                txtEditTlf_1.Text = medlem.Tlf_1;
                txtEditEmail.Text = medlem.Email;
                txtEditFoedselsdato.Text = medlem.Foedselsdato.ToString();
                txtEditKontingent.Text = medlem.Kontingent.ToString();
                txtEditMinitennis.Text = medlem.Minitennis.ToString();
                txtEditIndendoers.Text = medlem.Indendoers.ToString();
                txtEditRabat.Text = medlem.Rabat; 
                txtEditBoldkanon.Text = medlem.Boldkanon.ToString();
                if (medlem.JaTilNyheder)
                {
                    chkEditNewsMail.Checked = true;
                }
                else
                {
                    chkEditNewsMail.Checked = false;
                }

                if (medlem.Udmeldt)
                {
                    chkEditUdmeldt.Checked = true;
                }
                else
                {
                    chkEditUdmeldt.Checked = false;
                }
                txtEditMasterPeriode.Text = medlem.MasterPeriode.ToString();


                txtEditNoegle.Text = medlem.Noegle.ToString();
               
            }           



        }

        private bool SaveItem(out string errorMessage)
        {
            errorMessage = "";
            bool result = true;            
            try
            {
                if (this.State.AppState == HaarbyTennis.App.FormState.New)
                {

                    
                    this.State.Current_Medlem.Fornavn = txtCreateFornavn.Text;
                    this.State.Current_Medlem.Efternavn = txtCreateEfternavn.Text;

                    this.State.Current_Medlem.Adresse = txtCreateAdresse.Text;
                    this.State.Current_Medlem.Postnummer = txtCreatePostnummer.Text;
                    this.State.Current_Medlem.Bynavn = txtCreateBynavn.Text;
                    this.State.Current_Medlem.Tlf_1 = txtCreateTlf_1.Text;
                    this.State.Current_Medlem.Email = txtCreateEmail.Text;
                    if (!string.IsNullOrWhiteSpace(txtCreateFoedselsdato.Text))
                    {
                        this.State.Current_Medlem.Foedselsdato = Convert.ToDateTime(txtCreateFoedselsdato.Text);
                    }
                    if (!string.IsNullOrWhiteSpace(txtCreateKontingent.Text))
                    {
                        this.State.Current_Medlem.Kontingent = Convert.ToDecimal(txtCreateKontingent.Text);
                    }

                    if (!string.IsNullOrWhiteSpace(txtCreateNoegle.Text))
                    {
                        this.State.Current_Medlem.Noegle = Convert.ToDecimal(txtCreateNoegle.Text);
                    }

                    if (!string.IsNullOrWhiteSpace(txtCreateIndendoers.Text))
                    {
                        this.State.Current_Medlem.Indendoers = Convert.ToDecimal(txtCreateIndendoers.Text);
                    }
                    if (!string.IsNullOrWhiteSpace(txtCreateMinitennis.Text))
                    {
                        this.State.Current_Medlem.Minitennis = Convert.ToDecimal(txtCreateMinitennis.Text);
                    }
                   
                    this.State.Current_Medlem.Rabat = txtCreateRabat.Text;

                    if (!string.IsNullOrWhiteSpace(txtCreateBoldkanon.Text))
                    {
                        this.State.Current_Medlem.Boldkanon = Convert.ToDecimal(txtCreateBoldkanon.Text);
                    }
                  
                    if (chkCreateNewsMail.Checked)
                    {
                        this.State.Current_Medlem.JaTilNyheder = true;
                    }
                    else
                    {
                        this.State.Current_Medlem.JaTilNyheder = false;
                    }

                    this.State.Current_Medlem.OpdateretAfBruger = "Lasse";
                    result = MedlemmerService.InsertMedlem(this.State.Current_Medlem);

                }
                else if (this.State.AppState == HaarbyTennis.App.FormState.Edit)
                {
                    
                    this.State.Current_Medlem.Fornavn = txtEditFornavn.Text;
                    this.State.Current_Medlem.Efternavn = txtEditEfternavn.Text;
                    this.State.Current_Medlem.Adresse = txtEditAdresse.Text;
                    this.State.Current_Medlem.Postnummer =txtEditPostnummer.Text;
                    this.State.Current_Medlem.Bynavn = txtEditBynavn.Text;
                    this.State.Current_Medlem.Tlf_1 = txtEditTlf_1.Text;
                    this.State.Current_Medlem.Email = txtEditEmail.Text;
                    this.State.Current_Medlem.Foedselsdato = Convert.ToDateTime(txtEditFoedselsdato.Text);
                    this.State.Current_Medlem.Kontingent =  Convert.ToDecimal(txtEditKontingent.Text);
                    this.State.Current_Medlem.Noegle = Convert.ToDecimal(txtEditNoegle.Text);
                    this.State.Current_Medlem.Indendoers = Convert.ToDecimal(txtEditIndendoers.Text);
                    this.State.Current_Medlem.Minitennis = Convert.ToDecimal(txtEditMinitennis.Text);                    
                    this.State.Current_Medlem.Rabat = txtEditRabat.Text;
                    this.State.Current_Medlem.Boldkanon = Convert.ToDecimal(txtEditBoldkanon.Text);
                    if (chkEditNewsMail.Checked)
                    {
                        this.State.Current_Medlem.JaTilNyheder = true;
                    }
                    else
                    {
                        this.State.Current_Medlem.JaTilNyheder = false;
                    }

                    if (chkEditUdmeldt.Checked)
                    {
                        this.State.Current_Medlem.Udmeldt = true;
                    }
                    else
                    {
                        this.State.Current_Medlem.Udmeldt = false;
                    }
                    this.State.Current_Medlem.MasterPeriode = Convert.ToInt16(txtEditMasterPeriode.Text);

                    result = MedlemmerService.UpdateMedlem(this.State.Current_Medlem);
                }
               
                else
                {
                    result = false;
                    ShowErrorMessage("Ugyldig status ved gem.");
                }




            }
            catch (Exception ex)
            {
                result = false;
                ShowErrorMessage("Fejlbesked: " + ex.Message + (ex.InnerException == null ? "" : "<br/>Inner Exception: " + ex.InnerException.Message));

                errorMessage = "Fejlbesked: " + ex.Message;
                //Husk logning
                //LogStatus.LogUserError(LogStatus.eLogGruppe.StudentLogon, "Fejlbesked: " + ex.Message + " - Medlem: " + this.State.Current_Medlem.Id, Properties.Settings.Default.ApplicationName + ".SaveItem_TeamMailAdm", AppContext.CurrentUser.BrugerId);
                result = false;

            }
            return result;
        }
        #endregion // Edit...

        #region Events...

        protected void ddlSearchEfterMedlemstype_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetupListForm();
            //btnNew.Visible = false;
        }

        protected void btnSearchSearch_Click(object sender, EventArgs e)
        {
            SetupListForm();
            btnNew.Visible = false;

        
        }

        protected void btnSearchClear_Click(object sender, EventArgs e)
        {
            SetupSearchBox();          
            btnNew.Visible = true;
            divSeachCounterInfo.Visible = false;
            SetupListForm();
        }


        protected void btnNew_Click(object sender, EventArgs e)
        {

            this.State.AppState = HaarbyTennis.App.FormState.New;
            //this.State.CurrentRetning_Emne_Mail = new Core.DAL.Retning_Emne_Mail();   
            this.State.Current_Medlem = new Medlem();
            SetupEditForm();
        }

        protected void btnEditFetchUser_Click(object sender, EventArgs e)
        {
        }

        protected void btnEditBack_Click(object sender, EventArgs e)
        {
            SetupListForm();
        }

        protected void btnEditAllBack_Click(object sender, EventArgs e)
        {
           
            SetupListForm();
        }

        protected void btnEditSave_Click(object sender, EventArgs e)
        {
            string errorMessage = "";
            if (FeltValideringKraevetFelt(ref errorMessage))
            {
                //Undersøg om formatet er korrekt
                if (FeltValideringInputFormat(ref errorMessage))
                {
                    if (SaveItem(out errorMessage))
                    {
                        this.State.AppState = HaarbyTennis.App.FormState.List;
                        SetupListForm();
                    }
                    else
                    {
                        ShowErrorMessage(string.Format("Der er sket en fejl da data skulle gemmes.<br/>Beskrivelse: {0}", errorMessage));
                    }
                }
            }
            if (errorMessage != "")
            {
                ShowErrorMessage(errorMessage);
            }
        }


       

       

        protected void lvMain_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
           
            if (e.CommandName == "lbListItemEdit")
            {
                this.State.AppState = HaarbyTennis.App.FormState.Edit;
                int ItemId = Convert.ToInt32((e.CommandArgument));
                this.State.Current_Medlem = MedlemmerService.GetMedlemmerByID(ItemId);

                SetupEditForm();
            }

        }

        //TODO: Kan dette udelades?
        protected void lvMain_PreRender(object sender, EventArgs e)
        {
            BindList();
        }

       
        protected void ddOmraadelSelectedIndexChanged_Click(object sender, EventArgs e)
        {

           // LoadEmnerControl(ddlSearchEfterMedlemstype.SelectedValue);
            

        }

        
        protected void chkEditUdmeldt_CheckedChanged(object sender, EventArgs e)
        {
                        
        }
        protected void chkCreateNewsMail_CheckedChanged(object sender, EventArgs e)
        {
        }


        #endregion // Events...

        

        #region Fejlbeskeder...
        private void ClearErrorMessage()
        {
            divError.Visible = false;
            
        }


        private void ShowErrorMessage(string message)
        {
            divError.Visible = true;
            divError.InnerHtml = string.Format("<p><strong>Fejl</strong><br/>{0}</p>", message);
        }


        #endregion


        #region validering

        private bool FeltValideringInputFormat(ref string errorMessage)
        {
            errorMessage = "";
            //Validering af personlige oplysninger fra eksterne studenter.
            if (this.State.AppState == HaarbyTennis.App.FormState.New)
            {
                //Validering af create felterne
                if (!Shared.IsEmail(txtCreateEmail.Text))
                {
                    errorMessage = "Indtast en gyldig e-mail adresse";
                }
            }
            else
                if (this.State.AppState == HaarbyTennis.App.FormState.Edit)
                {
                    //Validering af Edit felterne
                    if (!Shared.IsEmail(txtEditEmail.Text))
                    {
                        errorMessage = "Indtast en gyldig e-mail adresse";
                    }
                }
                else
                    if (this.State.AppState == HaarbyTennis.App.FormState.EditAll)
                    {
                        //Validering af Edit felterne
                        if (!Shared.IsEmail(txtEditEmail.Text))
                        {
                            errorMessage = "Indtast en gyldig e-mail adresse";
                        }
                    }

            if (errorMessage != "")
                return false;
            else
                return true;

        }
        private bool FeltValideringKraevetFelt(ref string errorMessage)
        {

            if (this.State.AppState == HaarbyTennis.App.FormState.New)
            {
                //Validering af create felterne
                if (string.IsNullOrWhiteSpace(txtCreateFornavn.Text))
                {
                    errorMessage = "Feltet Fornavn må ikke være tomt.";
                }
                if (string.IsNullOrWhiteSpace(txtCreateEfternavn.Text))
                {
                    errorMessage = "Feltet Efternavn må ikke være tomt.";
                }
                if (string.IsNullOrWhiteSpace(txtCreateAdresse.Text))
                {
                    errorMessage = "Feltet adresse må ikke være tomt.";
                }
                if (string.IsNullOrWhiteSpace(txtCreatePostnummer.Text))
                {
                    errorMessage = "Feltet postnummer må ikke være tomt.";
                }
                if (string.IsNullOrWhiteSpace(txtCreateBynavn.Text))
                {
                    errorMessage = "Feltet Bynavn må ikke være tomt.";
                }
                if (string.IsNullOrWhiteSpace(txtCreateEmail.Text))
                {
                    errorMessage = "Feltet Email må ikke være tomt.";
                }

               
            }
            else
                if (this.State.AppState == HaarbyTennis.App.FormState.Edit)
                {
                    //Validering af editfelterne
                    if (string.IsNullOrWhiteSpace(txtEditFornavn.Text))
                    {
                        errorMessage = "Feltet  må ikke være tomt.";
                    }
                    if (string.IsNullOrWhiteSpace(txtEditEfternavn.Text))
                    {
                        errorMessage = "Feltet må ikke være tomt.";
                    }
                    if (string.IsNullOrWhiteSpace(txtEditAdresse.Text))
                    {
                        errorMessage = "Feltet må ikke være tomt.";
                    }
                    if (string.IsNullOrWhiteSpace(txtEditPostnummer.Text))
                    {
                        errorMessage = "Feltet må ikke være tomt.";
                    }
                    if (string.IsNullOrWhiteSpace(txtEditBynavn.Text))
                    {
                        errorMessage = "Feltet må ikke være tomt.";
                    }

                  

                    //der skal være foretaget valg i alle drop-down bokse

                }
               
            
            
            if (errorMessage != "")
                return false;
            else
                return true;
            
        }

        #endregion

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            ExcelPackage p = new ExcelPackage();
            
            string sheetName = "Tennismedlemmer";
            p.Workbook.Worksheets.Add(sheetName);
            ExcelWorksheet ws = p.Workbook.Worksheets[1];
            ws.Name = sheetName; //Setting Sheet's name
            
            //HtmlTable text1 = (HtmlTable)lvMain.FindControl("MedlemmerDataList");

            m_MedlemOplysninger_Liste = MedlemmerService.GetMedlemmer("ASC", "1");//Udsøg med Seniorer først

            p = OpenXMLConvertor.GetExcelListFromData(m_MedlemOplysninger_Liste); 

            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;  filename=lassesfilnavn.xlsx");
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.Charset = "";
            Response.ContentEncoding = System.Text.Encoding.Default;           
            Response.BinaryWrite(p.GetAsByteArray());
            Response.End();
          

        }

       
       
    }
}