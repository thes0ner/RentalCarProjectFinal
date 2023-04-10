using Microsoft.AspNetCore.Http;
using RentalCar.Core.Utilities.Results.Abstract;
using RentalCar.Core.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.Core.Utilities.Helpers.FileHelper
{
    public class FileHelperManager : IFileHelper
    {
        public void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public string Update(IFormFile file, string filePath, string root)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            return Upload(file, root);
        }

        public string Upload(IFormFile file, string root)
        {
            if (file.Length > 0)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                string extension = Path.GetExtension(file.FileName);
                string guid = Guid.NewGuid().ToString();
                string filePath = guid + extension;

                using (FileStream fileStream = File.Create(root + filePath))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                    return filePath;
                }
            }
            return null;
        }
    }
}

#region MyRegion

//private static IResult CheckFileExists(IFormFile file)
//{
//    if (file != null && file.Length > 0)
//    {
//        return new SuccessResult();
//    }
//    return new ErrorResult("File Does Not Exist!");
//}




//private static IResult CheckFileTypeValid(string type)
//{
//    if (type == ".jpeg" || type == ".png" || type == ".JPG" || type == ".jpg" || type == ".JPEG" || type == ".PNG")
//    {
//        return new SuccessResult();
//    }
//    return new ErrorResult("File Type Is Wrong! It Has To Be ('.jpeg', '.png' or '.jpg')");

//}
//private static void DeleteOldImageFile(string directory)
//{
//    var fullDirectory = Environment.CurrentDirectory + "\\wwwroot" + directory;
//    if (File.Exists(fullDirectory))
//    {
//        File.Delete(fullDirectory);
//    }
//}
#endregion