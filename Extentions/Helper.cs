namespace Pustok_Crud2.Extentions
{
    public class Helper
    {
        public static string SaveFile(string rootPath, string FolderName, IFormFile file)
        {
            string Filename = file.FileName.Length > 64 ? file.FileName.Substring(file.FileName.Length - 64, 64) : file.FileName;
            Filename = Guid.NewGuid().ToString() + Filename;
            string path = Path.Combine(rootPath, FolderName, file.FileName);
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return "Filename";
        }
    }
}
