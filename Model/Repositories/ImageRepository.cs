using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LazZiya.ImageResize;

namespace Model.Repositories
{
    public class ImageRepository : IImageRepository
    {
        public byte[] MakeFindPreview(string path)
        {
            try
            {
                byte[] byteImage;
                FileStream fileStream = new FileStream(path, FileMode.Open);
                Image image = Image.FromStream(fileStream);
                MemoryStream memoryStream = new MemoryStream();
                image.ScaleAndCrop(40, 40).Save(memoryStream, image.RawFormat); //save to memory stream
                byteImage = memoryStream.ToArray();
                memoryStream.Dispose();
                fileStream.Dispose();
                return byteImage;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public byte[] MakeFindImage(string path)
        {
            byte[] byteImage;
            FileStream fileStream = new FileStream(path, FileMode.Open);
            Image image = Image.FromStream(fileStream);
            MemoryStream memoryStream = new MemoryStream();
            image.ScaleAndCrop(600, 600, TargetSpot.Center).Save(memoryStream, image.RawFormat); //save to memory stream
            byteImage = memoryStream.ToArray();

            memoryStream.Dispose();
            fileStream.Dispose();

            return byteImage;
        }
    }
}
