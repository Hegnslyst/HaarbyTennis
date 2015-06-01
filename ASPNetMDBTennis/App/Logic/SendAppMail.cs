using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.IO;
using HaarbyTennis.Model;



namespace HaarbyTennis.App.Logic
{
   
    public class SendAppMail
    {
        private const string SOURCE = "SPOC.App.Logic.SendAppMail";

       
        /// <summary>
        ///Sender mail(s) til enten studerende eller eksamenskontores Team mail postkasser.
        /// </summary>                      
        /// <param name="mailListe">En liste med minimum 1 modtager mail-adresse</param>
        /// <param name="subject">string med emnefeltet til mail</param>
        /// <param name="content">string med selve tekstindholdet til mail</param>
        /// <param name="content">En liste med sti og filnavne på evt. vedhæftede filer</param>
        /// <returns>Kaster fejl som opsamles i kaldene metode</returns>
        public static bool SendMail(List<string> mailListe, string subject, string content, List<MailContact> attachments, out string errorMessage)
        {
            //CreateTestMessage2();
            errorMessage = "";
            bool result = true;
            int antalSendtMail = 0;
            //Gennemløb liste med mulige modtagere
            for (int i = 0; i < mailListe.Count; i++)
            {
                try
                {
                    string smtpServerName = ASPNetMDBTennis.Properties.Settings.Default.SmtpServer;
                    string fromEmailAddress = ASPNetMDBTennis.Properties.Settings.Default.MailSender;
                    string ccEmailAddress = ASPNetMDBTennis.Properties.Settings.Default.MailCC;
                    string bccEmailAddress = ASPNetMDBTennis.Properties.Settings.Default.MailBCC;

                    if (!string.IsNullOrWhiteSpace(smtpServerName) && !string.IsNullOrWhiteSpace(fromEmailAddress))
                    {
                        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                        System.Net.Mail.SmtpClient smtpServer = new System.Net.Mail.SmtpClient(smtpServerName, 587);
                        
                        //System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential("admin@haarbytennis.dk", "qzc76qhb");                      
                        System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential("admin@haarbytennis.dk", "qzc76qhb");                      
                        smtpServer.Credentials = SMTPUserInfo;
                        

                        mail.From = new System.Net.Mail.MailAddress(fromEmailAddress);
                        mail.To.Add(mailListe[i]);
                        if (!string.IsNullOrWhiteSpace(ccEmailAddress))
                        {
                            mail.CC.Add(ccEmailAddress);
                        }
                        if (!string.IsNullOrWhiteSpace(bccEmailAddress))
                        {
                            mail.Bcc.Add(bccEmailAddress);
                        }
                        mail.Subject = subject;
                        mail.Body = content;
                        

                        //Den studerende kan uploade et antal filer. Gennemløb listen med de uploadede fil-navne.     
                        //På Serveren ligger fil(erne) fra den studerende
                        for (int j = 0; j < attachments.Count; j++)
                        {
                            MailContact contact = attachments[j];

                           // convert string to stream
                            //byte[] byteArray = Encoding.UTF8.GetBytes(contact.Document);
                           
                            //MemoryStream stream = new MemoryStream(byteArray);
                            Stream stream =  new MemoryStream(contact.Document); 
                          
                            //Dette virker ok
                            //Attachment data = new Attachment(contact.FilePath + contact.DocNavn,  MediaTypeNames.Application.Octet);
                          

                            //Fil overføres men typen er forkert.
                            Attachment data = new Attachment(stream, contact.DocNavn);

                            // Add time stamp information for the file.
                            ContentDisposition disposition = data.ContentDisposition;
                            disposition.CreationDate = System.IO.File.GetCreationTime(contact.FilePath);
                            disposition.ModificationDate = System.IO.File.GetLastWriteTime(contact.FilePath);
                            disposition.ReadDate = System.IO.File.GetLastAccessTime(contact.FilePath);
                            //tilknyt den enkelte uploaded fil til e-mail meddelsen.                         
                            mail.Attachments.Add(data);
                        }
                        
                        smtpServer.Send(mail);
                        antalSendtMail++;
                    }
                }
                catch (Exception ex)
                {
                    LogStatus.LogUserError(LogStatus.eLogGruppe.Ukendt,"Antal " + antalSendtMail + " Fejl ved afsendelse af mail Liste: " + ex.Message, SOURCE + ".SendMail" );
                    result = false;
                }
            }
            return result;
        }


       
        /// <summary>
        ///Sender kvittering.
        /// </summary>                      
        /// <param name="mailListe">En liste med minimum 1 modtager mail-adresse</param>
        /// <param name="subject">string med emnefeltet til mail</param>
        /// <param name="content">string med selve tekstindholdet til mail</param>
         /// <returns>Kaster fejl som opsamles i kaldene metode</returns>
        public static bool SendMail(List<string> mailListe, string subject, string content, out string errorMessage)
        {
            errorMessage = "";
            bool result = true;
            //Gennemløb liste med mulige modtagere
            for (int i = 0; i < mailListe.Count; i++)
            {
                try
                {
                    string smtpServerName = ASPNetMDBTennis.Properties.Settings.Default.SmtpServer;
                    string fromEmailAddress = ASPNetMDBTennis.Properties.Settings.Default.MailSender;
                    string ccEmailAddress = ASPNetMDBTennis.Properties.Settings.Default.MailCC;
                    string bccEmailAddress = ASPNetMDBTennis.Properties.Settings.Default.MailBCC;

                    if (!string.IsNullOrWhiteSpace(smtpServerName) && !string.IsNullOrWhiteSpace(fromEmailAddress))
                    {
                        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                        System.Net.Mail.SmtpClient smtpServer = new System.Net.Mail.SmtpClient(smtpServerName, 587);

                        System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential("admin@haarbytennis.dk", "qzc76qhb");
                        smtpServer.Credentials = SMTPUserInfo;

                        mail.From = new System.Net.Mail.MailAddress(fromEmailAddress);
                        mail.To.Add(mailListe[i]);
                        if (!string.IsNullOrWhiteSpace(ccEmailAddress))
                        {
                            mail.CC.Add(ccEmailAddress);
                        }
                        if (!string.IsNullOrWhiteSpace(bccEmailAddress))
                        {
                            mail.Bcc.Add(bccEmailAddress);
                        }
                        mail.Subject = subject;
                        mail.Body = content;
                      
                        smtpServer.Send(mail);
                    }
                }
                catch (Exception ex)
                {
                    LogStatus.LogUserError(LogStatus.eLogGruppe.Ukendt, "Fejl ved afsendelse af mail kvittering: " + ex.Message, SOURCE + ".SendMail");
                    result = false;
                }
            }
            return result;
        }
       

       


    }
}