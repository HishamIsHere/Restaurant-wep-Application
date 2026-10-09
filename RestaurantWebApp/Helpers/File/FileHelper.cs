namespace WebAppTemplate.Helpers.File
{
    public class FileHelper :IFileHelper
    {
        IWebHostEnvironment _webHostEnvironment;

        public FileHelper(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public string SaveImage(IFormFile? file, string folderName, string? oldImageName = null)
        {
            if (file == null || file.Length == 0)
            {
                return oldImageName ?? string.Empty;
            }
            try
            {
                if (!string.IsNullOrEmpty(oldImageName))
                {
                    var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName, oldImageName);
                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Delete(oldFilePath);
                    }
                }

                var targetFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName);
                if (!Directory.Exists(targetFolder))
                {
                    Directory.CreateDirectory(targetFolder);
                }
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var fullPath = Path.Combine(targetFolder, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                return fileName;
            }
            catch
            {
                return "Error";
            }
        }
        public string SaveDoc(IFormFile? file, string folderName, string? oldImageName = null)
        {
            return SaveImage(file, folderName, oldImageName);
        }
    }
}
