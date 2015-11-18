namespace Just_DIY.Clients
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;
    using Dropbox.Api;
    using Dropbox.Api.Files;

    public class DropboxManager
    {
        public static async Task SaveBackup<T>(IList<T> data)
        {
            using (var dropBoxClient = new DropboxClient("zXamRugG1cUAAAAAAAAC-wCufBmVWCLSW3o8adzSnTXQeaxEtQcOJxe2rRakauXY"))
            {
                var backupContent = string.Join(Environment.NewLine, data);
                await Upload(dropBoxClient, "/JustDIY", typeof(T).Name + "_backup_" + DateTime.Now + ".csv", backupContent);
            }
        }

        private static async Task Upload(DropboxClient dbx, string folder, string file, string content)
        {
            using (var mem = new MemoryStream(Encoding.UTF8.GetBytes(content)))
            {
                await dbx.Files.UploadAsync(
                    folder + "/" + file,
                    WriteMode.Overwrite.Instance,
                    body: mem);
            }
        }
    }
}