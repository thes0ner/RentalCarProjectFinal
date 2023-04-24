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
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            //Benzersiz isimde 0 baytlık geçiçi bir dosya oluşturup, bu doysanın adresini sourcePath değişkenine atmış oluyoruz
            var sourcePath = Path.GetTempFileName(); 
            
            //Burada Ekleyeceğimiz dosyanın uzunluğunu bayt ile hesaplıyoruz ve Gerçekten dosya gelmiş mi gelmemiş mi diye kontrol yapıyoruz.
            if (file.Length > 0) 
            {
                using (var stream = new FileStream(sourcePath, FileMode.Create)) // Filestream sınıfı bizim dosya okuma,yazma,atlama işlemlerini yapıyor. FileMode.Create Dosya oluşturuyor veya varsa üzerine yazıyor.
                {
                    //Dosyamızı sourcePath'teki oluşturduğumuz dosya üzerine yazıyoruz.
                    file.CopyTo(stream); 
                }
            }
            
            //Dosyamızın adını fileInfo değişkenine aktardık. FileInfo sınıfı Dosya yolu işlemleri için kullanılan sınıftır.
            FileInfo fileInfo = new FileInfo(file.FileName); 
            
            //Dosya adını ve uzantısını fileExtension değişkenine aktardık. 
            string fileExtension = fileInfo.Extension; 
            
            //Guid.NewGuid().ToString() ifadesi bize eşsiz, benzersiz bir isim oluşturdu ve stringe çevirdi.
            var path = Guid.NewGuid().ToString() + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Year + fileExtension;

            //Burda yeni bir dizin oluşturduk.
            var result = NewPath(path); 

            //Dosyamızı yeni oluşturğumuz dizine aktardık.
            File.Move(sourcePath, result); 
            return path;
        }

        public static void Delete(string path)
        {
            File.Delete(path);
        }

        public static string Update(string oldPath, IFormFile file)
        {
            Delete(oldPath);
            return Add(file);
        }

        private static string NewPath(string file)
        {
            string path = Environment.CurrentDirectory + @"\wwwroot\Uploads\Images";

            string result = $@"{path}\{file}";
            return result;
        }
    }
}
