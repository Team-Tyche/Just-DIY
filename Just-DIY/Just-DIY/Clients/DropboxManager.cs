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
                var backupContent = new StringBuilder();
                var sb = new StringBuilder();
                foreach (var row in data)
                {
                    foreach (var property in row.GetType().GetProperties())
                    {
                        if (!property.ToString().StartsWith("System.Collections.Generic"))
                        {
                            sb.Append(property.GetValue(row) + ",");
                        }
                    }

                    backupContent.Append(sb.ToString().TrimEnd(',') + Environment.NewLine);
                    sb.Clear();
                }
                await Upload(dropBoxClient, "/JustDIY", typeof(T).Name + "_backup_" + DateTime.Now + ".csv", backupContent.ToString());
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