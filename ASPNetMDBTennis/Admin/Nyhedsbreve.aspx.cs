using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using HaarbyTennis.App;
using HaarbyTennis.Model;
using HaarbyTennis.BLL;
using HaarbyTennis.App.Logic;


namespace ASPNetMDBTennis.Admin
{
    public partial class Nyhedsbreve : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {

                Response.Redirect("/UI/VelkommenVinter.aspx", true);

            }
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
        protected void btnSend_Click(object sender, EventArgs e)
        {
            string errorMessage = "";
            string errorCaption;
            //udvælg chekcboks som er afkrydset og sæt Primære studieretning.

             //Undersøg krævede felter
            if (FeltValideringKraevetFelt(ref errorMessage))
            {
           
                       
                //Send mail til TeamMailAdresser
                if (this.SendTeamMail(out errorMessage))
                {
                    if (this.SendMailKvittering(out errorMessage))
                    {
                                       
                    }
                    else
                    {
                        errorCaption = @"Fejl ved send af kvittering vedr. mailforsendelse";
                        ErrorMessage.ShowErrorPage(Response, AppContext, errorMessage, errorCaption);
                    }
                }
                else
                {
                    errorCaption = @"Fejl ved skrivning af mail tilpostkasse ";
                    ErrorMessage.ShowErrorPage(Response, AppContext, errorMessage, errorCaption);
                }


                if (this.AppContext.CurMailHandler.HenvendelseStatus == MailHandler.eHendvendelseStatus.Afsendt)
                {
                    //Hvis alt er gået godt, Send kvitterings-mail til Studerende
                    Response.Redirect("Kvittering.aspx");
                }
                else
                {
                    errorCaption = @"Fejl ved behandling af send af mail ";
                    ErrorMessage.ShowErrorPage(Response, AppContext, errorMessage, errorCaption);
                }
            }//end fejltjek af gui krævede felter
            if (errorMessage != "")
            {
                ShowErrorMessage(errorMessage);
            }
            
        }
    

        protected void btnFortryd_Click(object sender, EventArgs e)
        {
            this.ClearContact();
           
            Response.Redirect("Default.aspx");
            string sessionid = Session.SessionID;
        }

        /// <summary>
        /// Sletter uploadede filer i App_data.
        /// </summary>
        public void ClearContact()
        {

            //Sletning af uploadede filer ved fortrydelse og afslutning.
          
            System.Web.HttpContext.Current.Session.Abandon();

        }
        #region Send Mail

        /// <summary>
        ///Send mails til de forskellige Team mailbokse under Eksamenskontoret. 
        ///Mails findes i _appContext.CurMailSag.MailAdresser.
        ///Bemærk at der godt kan sendes mails til flere kontorer.
        /// </summary>                      
        /// <param name="errorMessage">Output med eventuel fejlbesked</param>
        /// <returns>Gik det godt?</returns>
        internal bool SendTeamMail(out string errorMessage)
        {

            errorMessage = "";
            bool result = true;
            try
            {

                string subject = txtEmne.Text;
                string content = txtHenvendelse.Text;
                List<MailContact> attachment;
               

                attachment = AppContext.CurMailHandler.VedHaeftning;

                //Hent maillisten fra DB
                List<Medlem> mailListe = MedlemmerService.GetMedlemmer("", "");

                foreach (Medlem medlemmer_Liste in mailListe)
                {
                    if (medlemmer_Liste.JaTilNyheder)
                    {
                        AppContext.CurMailHandler.MailAdresser.Add(medlemmer_Liste.Email);

                    }
                }
                if (SendAppMail.SendMail(AppContext.CurMailHandler.MailAdresser, subject, content, attachment, out errorMessage))
                {
                    this.AppContext.CurMailHandler.HenvendelseStatus = MailHandler.eHendvendelseStatus.Afsendt;


                    if (NyhederService.InsertNyhed(subject, content))
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
                else
                {

                    result = false;
                    //todo: husk at opdatere henvendelsestekst.
                }

            }
            catch (Exception ex)
            {
               
                errorMessage = "Fejlbesked: " + ex.Message;
                LogStatus.LogUserError(LogStatus.eLogGruppe.NyBruger, "Fejlbesked: " + ex.Message, Properties.Settings.Default.ApplicationName + ".SaveItem", "Administrator");
                
                result = false;
            }
            return result;

        }
        /// <summary>
        ///Send en svar/kvittering mail til den studerende.
        /// </summary>                      
        /// <param name="errorMessage">Output med eventuel fejlbesked</param>
        /// <returns>Gik det godt?</returns>
        internal bool SendMailKvittering(out string errorMessage)
        {

            errorMessage = "";
            bool result = true;
            try
            {
                string subject = "Email liste er afsendt.";
                
                string content = "Der er sendt til flg. mail-adresser: ";
                



                List<string> mailListe = new List<string>();
                
                mailListe.Add(Properties.Settings.Default.MailKvittering); //Tilføj admin@haarbytennis.dk som afsender
                
                //Alle modtagere af mails tilføjes kvitteringsmail.
                for (int i = 0; i < AppContext.CurMailHandler.MailAdresser.Count; i++)
                {

                    content = content + AppContext.CurMailHandler.MailAdresser[i].ToString() +  Environment.NewLine;      
                }
                
                if (!SendAppMail.SendMail(mailListe, subject, content, out errorMessage))
                {                   
                   
                    result = false;
                    //todo: husk at opdatere henvendelsestekst.
                }

            }
            catch (Exception ex)
            {
               
                errorMessage = "Fejlbesked: " + ex.Message;
                LogStatus.LogUserError(LogStatus.eLogGruppe.NyBruger, "Fejlbesked: " + ex.Message, Properties.Settings.Default.ApplicationName + ".SaveItem", "Administrator");
                result = false;
            }
            return result;

            //Felt i tabel med tekstindbold fra sendt mail.
        }
        #endregion
        protected void btnUploadFile_Click(object sender, EventArgs e)
        {
            string errorMessage = "";

            // Read the file and convert it to Byte Array            
            string filePath = fileUpload.PostedFile.FileName;
            //string beskrivelse = fileUploadBeskrivelse.Text.Trim();
            //if (string.IsNullOrWhiteSpace(beskrivelse))
            //{
            //    beskrivelse = Path.GetFileName(filePath);
            //}

            if (string.IsNullOrWhiteSpace(filePath))
            {
                errorMessage = "For at uploade en fil skal du vælge filen på din harddisk ved at klikke på Browse-knappen og trykke på Vedhæft.";
            }
            else
                //TODO: Tjek på max filesize ved upload
                if (AppContext.CurMailHandler.VedHaeftning.Count > 2) //todo: skal rettes ved idriftsættelse
                {
                    errorMessage = "Du kan max vedhæfte 4 filer til din mail";
                }
                else                
                {
                    string filename = Path.GetFileName(filePath);
                    string ext = Path.GetExtension(filename);
                    string contenttype = String.Empty;

                    //App.Controller.DokumentTypeController controller = new App.Controller.DokumentTypeController();
                    //Hent dokumenttypen som tillades at blive uploadet.
                    //var dokumentType = controller.GetDokumentType(ext);
                    DokumentType dokumentType = new DokumentType();
                    dokumentType.Extension = ext;

                    if (ext == ".pdf" || ext == ".doc" || ext == ".docx" || ext == ".jpg" || ext == ".rtf") 
                    {

                        string sessionId = this.Session.SessionID;
                        string pathToCreate = Server.MapPath("~/App_Data/Temporaryasfasdf/" + sessionId + "/");
                      
                        //Folder-løsning 1. Opret mappe som er entydigt i forhold til hver session(bruger)
                        //Tilknyt filnavn og sti, da senere skal anvendes i afsending af mail.
                        //TODO: samme metode til Create/Delete
                        Directory.CreateDirectory(pathToCreate);                                              
                        fileUpload.SaveAs(pathToCreate + "/" + filename);
                        
                        //Løsning 2: Gem filindhold i MailContact objektet til vedhæftning i SendMail
                        Byte[] bytes = fileUpload.FileBytes;
                        AppContext.CurMailHandler.AddDocumentToMailContact(bytes, filename, dokumentType, pathToCreate);
                        //TODO: Hent data til visning af ListView.
                        BindList();
                                       
                    }
                    else
                    {
                        errorMessage = "Du har vedhæftet en filtype der ikke er gyldig i systemet.";
                    }
            }

            if (errorMessage != "")
            {
                ShowErrorMessage(errorMessage);
            }

        }
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
        protected void lvMain_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "lbListItemDelete")
            {
                //int aftaleDokumenterId = Conv.CNInt(e.CommandArgument);

                //this.AppContext.StudAftale.Dokumenter.DeleteDocument(aftaleDokumenterId);
                //BindList();
            }
        }

      
        
        private void BindList()
        {
            //List<AftaleDokumenterViewModel> dokumentListe = this.AppContext.StudAftale.Dokumenter.GetDokumenterListeViewModel();
            //AppContext.CurMailHandler.VedHaeftning.Add(pathToCreate);

            lvMain.DataSource = AppContext.CurMailHandler.VedHaeftning;
            lvMain.DataBind();
        }

        private bool FeltValideringKraevetFelt(ref string errorMessage)
        {

            
            if (string.IsNullOrWhiteSpace(txtEmne.Text))
            {
                errorMessage = "Indtast mail emne";                   
            }
            if (string.IsNullOrWhiteSpace(txtHenvendelse.Text))
            {
                errorMessage = "Indtast mail tekst";                   
            }
            
            if (errorMessage != "")
            return false;
            else
            return true;
            
         }
    }
}