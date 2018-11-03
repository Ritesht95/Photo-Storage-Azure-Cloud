using System;
using System.IO;
using System.Linq;
using System.Web.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace CCPhotoUpload
{
    public partial class Default : System.Web.UI.Page
    {
        string ACName = WebConfigurationManager.AppSettings["acname"];
        string AccessKey = WebConfigurationManager.AppSettings["accesskey"];

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fileInput.HasFile)
            {
                var FolderPath = Server.MapPath("~/Images/");
                string Filename = Path.GetFileName(fileInput.FileName).Split('.')[0] + "_" + (DateTime.Now).ToString().Replace('-', '_').Replace(' ', '_').Replace(':', '_') + "." + fileInput.FileName.Split('.')[1];
                fileInput.SaveAs(FolderPath + Filename);
                string url="";

                try
                {
                    StorageCredentials creden = new StorageCredentials(ACName, AccessKey);
                    CloudStorageAccount acc = new CloudStorageAccount(creden, useHttps: true);
                    CloudBlobClient client = acc.CreateCloudBlobClient();
                    CloudBlobContainer cont = client.GetContainerReference(WebConfigurationManager.AppSettings["containername"]);
                    cont.CreateIfNotExists();
                    cont.SetPermissions(new BlobContainerPermissions{
                        PublicAccess = BlobContainerPublicAccessType.Blob

                    });
                    url += WebConfigurationManager.AppSettings["containerurl"];
                    url += Filename.Substring(0, Filename.LastIndexOf('.')) + ".jpg";
                     CloudBlockBlob cblob = cont.GetBlockBlobReference(Filename.Substring(0,Filename.LastIndexOf('.'))+".jpg");
                    using (Stream fileBlob = File.OpenRead(@FolderPath + Filename))
                    {
                        cblob.UploadFromStream(fileBlob);
                    }
                    SharedAccessBlobPolicy policy = new SharedAccessBlobPolicy();
                    policy.Permissions = SharedAccessBlobPermissions.Read;
                    policy.SharedAccessExpiryTime = DateTimeOffset.Parse("2019-12-12 12:00:00");
                    url += cblob.GetSharedAccessSignature(policy);

                }
                catch (Exception ex)

                {

                }

                var DC = new DataClassesDataContext();
                tblFile file = new tblFile();
                file.Title = txtFileName.Text;
                file.Filepath = url;
                file.Description = txtDecription.Text;
                file.Size = fileInput.PostedFile.ContentLength;
                file.Type = fileInput.FileName.Substring(fileInput.FileName.LastIndexOf('.') + 1).ToLower();
                DC.tblFiles.InsertOnSubmit(file);
                DC.SubmitChanges();

                var ImageID = (from ob in DC.tblFiles
                               orderby ob.ImageID descending
                               select ob.ImageID).First();
                var Keywords = txtKeywords.Text.Split(',');
                foreach (string keyword in Keywords)
                {
                    tblKeyword keywordObj = new tblKeyword();
                    keywordObj.Keyword = keyword.Trim();
                    keywordObj.ImageID = ImageID;
                    DC.tblKeywords.InsertOnSubmit(keywordObj);
                }
                DC.SubmitChanges();
            }
        }
    }
}