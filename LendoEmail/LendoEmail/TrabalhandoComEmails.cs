using Microsoft.Exchange.WebServices.Data;
using System;
using System.IO;
using System.Linq;

namespace LendoEmail
{
    public class TrabalhandoComEmails
    {
        public void Processar()
        {
            ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2013_SP1);
            service.Credentials = new WebCredentials("felipepatente2020@outlook.com","46692201!@ASDFasdf");
            service.AutodiscoverUrl("felipepatente2020@outlook.com");

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
                    }

                    message.IsRead = true;

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
