namespace api.Helpers
{
    public class FilesHelper
    {
        private IWebHostEnvironment _hostingEnvironment;

        public FilesHelper(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public async Task<string> UploadFileAsync(IFormFile file)
        {
            //generate unique filename
            string fileName = Guid.NewGuid().ToString() + ".pdf";

            //upload file to server
            string folderPath = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads");
            string filePath = Path.Combine(folderPath, fileName);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return fileName;
        }
    }
}
