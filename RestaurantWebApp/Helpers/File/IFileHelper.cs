namespace WebAppTemplate.Helpers.File
{
    public interface IFileHelper
    {
        string SaveImage(IFormFile? file, string folderName, string? oldImageName = null);
        string SaveDoc(IFormFile? file, string folderName, string? oldImageName = null);
    }
}
