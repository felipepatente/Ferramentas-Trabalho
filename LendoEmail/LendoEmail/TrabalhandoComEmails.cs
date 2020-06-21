using Microsoft.Exchange.WebServices.Data;
using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace LendoEmail
{
    public class TrabalhandoComEmails
    {
        private ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2013_SP1);
        private string emailOrigem = "felipepatente2020@outlook.com";

        public TrabalhandoComEmails()
        {            
            service.Credentials = new WebCredentials(emailOrigem, "46692201!@ASDFasdf");
            service.AutodiscoverUrl(emailOrigem);
        }

        public void EnviarEmail()
        {
            try
            {
                EmailMessage message = new EmailMessage(service);
                message.From = emailOrigem;
                message.Subject = "Teste";
                message.Body = "<b>Corpo do e-mail<b/>";
                message.Body.BodyType = BodyType.HTML;
                message.ToRecipients.Add("felipepatente2016@gmail.com");
                Thread.Sleep(5000);
                message.Send();
                Console.WriteLine("Enviado com sucesso");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void FazendoLeituraEmail()
        {
            

            if (service != null)
            {
                FindItemsResults<Item> result = service.FindItems(WellKnownFolderName.Inbox, new ItemView(100));

                foreach (var item in result)
                {
                    EmailMessage message = EmailMessage.Bind(service, item.Id);

                    //Só leio e-mails, se eles ainda não estiverem lidos
                    if (!message.IsRead)
                    {
                        string body = message.Body.Text;                        
                        //string from = message.From.Id.ToString();
                        string subject = message.Subject.ToString();
                        Console.WriteLine(subject);
                    }

                    //MoverEmailInbox(service, message);
                }                
            }
        }

        public void ExcluirEmail(EmailMessage mail)
        {
            try
            {
                DeleteMode delete = DeleteMode.MoveToDeletedItems;
                mail.Delete(delete);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void MoverEmailRoot(ExchangeService service, EmailMessage mail)
        {
            try
            {
                Folder rootfolder = Folder.Bind(service, WellKnownFolderName.MsgFolderRoot);
                rootfolder.Load();
                Folder foundFolder = rootfolder.FindFolders(new FolderView(100)).FirstOrDefault(x => x.DisplayName == "Rascunhos");

                if (foundFolder == default(Folder))
                {
                    throw new DirectoryNotFoundException(string.Format("Não foi possível encontrar a pasta {0}.", "Rascunhos"));
                }

                mail.Move(foundFolder.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void MoverEmailInbox(ExchangeService service, EmailMessage mail)
        {
            try
            {                
                Folder rootfolder = Folder.Bind(service, WellKnownFolderName.Inbox);
                rootfolder.Load();
                Folder foundFolder = rootfolder.FindFolders(new FolderView(100)).FirstOrDefault(x => x.DisplayName == "BRT");
                
                if (foundFolder == default(Folder))
                {
                    throw new DirectoryNotFoundException(string.Format("Não foi possível encontrar a pasta {0}.", "BRT"));
                }

                mail.Move(foundFolder.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public FolderId GetFolderId(string caixaEmail)
        {
            try
            {
                Mailbox mailbox = new Mailbox(caixaEmail);
                return new FolderId(WellKnownFolderName.Inbox, mailbox);
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
