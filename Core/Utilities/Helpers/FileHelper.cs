using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            var result = newPath(file);
            try
            {
                var tempPath = Path.GetTempFileName(); //Geçiçi yol
                if (file.Length > 0)
                {
                    using (var fileStream = new FileStream(tempPath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);

                    }
                    File.Move(tempPath, result.newPath);
                }
            }
            catch (Exception exception)
            {

                return exception.Message;
            }
           
            //var fileNewPath = newPath(file);
            
            return result.Path2;

        }

        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception)
            {

                return new ErrorResult();
            }


            return new SuccessResult();
        }

        public static string Update(string tempPath, IFormFile file)
        {
            var result = newPath(file);

            try
            {
                if (tempPath.Length > 0)
                {
                    using (FileStream fileStream = new FileStream(result.newPath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                   
                }
                File.Delete(tempPath);
            }
            catch (Exception exception)
            {

                return exception.Message;
            }
            
            
            return result.Path2;
        }

        //public static string CreateNewFilePath(IFormFile file)
        //{
        //    FileInfo fileInfo = new FileInfo(file.FileName);
        //    var fileExtension = fileInfo.Extension;

        //    var currentLocation = Environment.CurrentDirectory + @"\CarImages\";
        //    var path = Guid.NewGuid().ToString() + fileExtension;
        //    return currentLocation + path;
        //}

        public static (string newPath, string Path2) newPath(IFormFile file)
        {
            FileInfo ff = new FileInfo(file.FileName);
            string fileExtension = ff.Extension;
            //Extension : myfile.txt dosyasındaki txt kısmıdır yani dosya uzantısı

            var newPath = Guid.NewGuid().ToString() + fileExtension;
            //Guid.NewGuid() metodu ile yeni bir GUID oluşturulur

            string path = Environment.CurrentDirectory + @"\wwwroot\uploads";
            //Environment.CurrentDirectory : uygulamanın çalıştığı aktif klasör yolu

            string result = $@"{path}\{newPath}";

            return (result, $"\\uploads\\{newPath}");
        }
    }
}
