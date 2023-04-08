using Microsoft.AspNetCore.Http;
using RentalCar.Core.Utilities.Results.Abstract;
using RentalCar.Core.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static IResult Add(IFormFile file)
        {

            //Cheks the file exists or not.
            var fileExist = CheckFileExists(file);
            if (!fileExist.Success)
            {
                return new ErrorResult(fileExist.Message);
            }


            //Gets's the extension and checks whether it's valid or not.
            var type = Path.GetExtension(file.FileName);
            var typeValid = CheckFileTypeValid(type);

            //If not Valid throws error
            if (!typeValid.Success)
            {
                return new ErrorResult(typeValid.Message);
            }



            //Creates directory!
            (string newPath, string path2) result = SaveFile(file);
            try
            {
                //Creates temporary file on disk and returns full path of that file.
                var sourcePath = Path.GetTempFileName();

                if (file.Length > 0)
                {
                    using (var stream = new FileStream(sourcePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }

                //Moves specified filed to the new Location
                File.Move(sourcePath, result.newPath);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }

            return new SuccessResult(Path.Combine(result.path2));
            
        }



        public static IResult Update(IFormFile file, string sourcePath)
        {
            var fileExist = CheckFileExists(file);
            if (!fileExist.Success)
            {
                return new ErrorResult(fileExist.Message);
            }

            var type = Path.GetExtension(file.FileName);
            var typeValid = CheckFileTypeValid(type);
            if (!typeValid.Success)
            {
                return new ErrorResult(typeValid.Message);
            }


            var result = SaveFile(file);

            try
            {
                if (sourcePath.Length > 0)
                {
                    using (var stream = new FileStream(result.newPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                File.Delete(sourcePath);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }
            return new SuccessResult(result.Path2);
        }


        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }



        private static (string newPath, string Path2) SaveFile(IFormFile file)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileExtension = fileInfo.Extension.ToLower();

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //guidName.jpg
            string newFileName = Guid.NewGuid().ToString("D") + fileExtension;
            //wwwroot//Images///guidName.jpg
            string newPath = Path.Combine(path, newFileName);
            //guidName.extension
            string path2 = Path.Combine(newFileName);


            return (newPath, path2);
        }


        private static IResult CheckFileExists(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult("File Does Not Exist!");
        }




        private static IResult CheckFileTypeValid(string type)
        {
            if (type == ".jpeg" || type == ".png" || type == ".JPG" || type == ".jpg" || type == ".JPEG" || type == ".PNG")
            {
                return new SuccessResult();
            }
            return new ErrorResult("File Type Is Wrong! It Has To Be ('.jpeg', '.png' or '.jpg')");

        }
        private static void DeleteOldImageFile(string directory)
        {
            var fullDirectory = Environment.CurrentDirectory + "\\wwwroot" + directory;
            if (File.Exists(fullDirectory))
            {
                File.Delete(fullDirectory);
            }
        }
    }
}

