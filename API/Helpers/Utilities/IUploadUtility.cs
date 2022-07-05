namespace API.Helpers.Utilities
{
    public interface IUploadUtility
    {
        Task<string> UploadAsync(IFormFile file, string subfolder = "upload", string rawFileName = null);
        Task<string> UploadAsync(string file, string subfolder = "upload", string rawFileName = null);
    }

    public class UploadUtility : IUploadUtility
    {
        private string webRootPath;

        public UploadUtility()
        {
            webRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        }

        /// <summary>
        /// Upload a file to server folder.
        /// </summary>
        /// <param name="file">Uploaded file.</param>
        /// <param name="subfolder">Subfolder. Default: "upload"</param>
        /// <param name="rawFileName">Raw file name. Default: uploaded file name.</param>
        /// <returns>File name.</returns>
        public async Task<string> UploadAsync(IFormFile file, string subfolder = "upload", string rawFileName = null)
        {
            if (file == null)
                return null;

            var folderPath = Path.Combine(webRootPath, subfolder);
            var fileName = file.FileName;
            var extension = Path.GetExtension(file.FileName);

            if (string.IsNullOrEmpty(extension))
                return null;

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            if (!string.IsNullOrEmpty(rawFileName))
                fileName = $"{rawFileName}{extension}";

            var filePath = Path.Combine(folderPath, fileName);

            if (File.Exists(filePath))
                File.Delete(filePath);

            try
            {
                using (FileStream fs = File.Create(filePath))
                {
                    await file.CopyToAsync(fs);
                    await fs.FlushAsync();
                }

                return fileName;
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Upload a base64 string file to server folder.
        /// </summary>
        /// <param name="file">Uploaded file.</param>
        /// <param name="subfolder">Subfolder. Default: "upload"</param>
        /// <param name="rawFileName">Raw file name. Default: uploaded file name.</param>
        /// <returns>File name.</returns>
        public async Task<string> UploadAsync(string file, string subfolder = "upload", string rawFileName = null)
        {
            if (string.IsNullOrEmpty(file))
                return null;

            var folderPath = Path.Combine(webRootPath, subfolder);
            var extension = $".{file.Split(';')[0].Split('/')[1]}";

            if (string.IsNullOrEmpty(extension))
                return null;

            var fileName = $"{Guid.NewGuid().ToString()}{extension}";

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            if (!string.IsNullOrEmpty(rawFileName))
                fileName = $"{rawFileName}{extension}";

            var filePath = Path.Combine(folderPath, fileName);

            if (File.Exists(filePath))
                File.Delete(filePath);

            var base64String = file.Substring(file.IndexOf(',') + 1);
            var fileData = Convert.FromBase64String(base64String);

            try
            {
                await File.WriteAllBytesAsync(filePath, fileData);
                return fileName;
            }
            catch (System.Exception)
            {
                return null;
            }
        }
    }
}