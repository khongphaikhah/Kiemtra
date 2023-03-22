using EfAPI.Data;
using EfAPI.Repository.Interface;
using Entity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace EfAPI.Repository
{
    public class ImageRepository : Repository<Images>, IImageRepository
    {
        public ImageRepository(AppDb context) : base(context)
        {
        }

        public string DoiFileAnhSangChuoi(IFormFile file)
        {
            try
            {
                string logoString = string.Empty;

                if (file != null && file.Length != 0)
                {
                    string extension = Path.GetExtension(file.FileName).ToLower();
                    if (extension != ".png" && extension != ".bmp" && extension != ".jpg" && extension != ".jpeg")
                    {
                        throw new Exception();
                    }

                    logoString = ParseToString(file.OpenReadStream());
                }

                return logoString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DoiNhieuFileAnhSangChuoi(IList<IFormFile> files)
        {
            try
            {
                string logoString = string.Empty;
                var file = files[0];
                if (file != null && file.Length != 0)
                {
                    string extension = Path.GetExtension(file.FileName).ToLower();
                    if (extension != ".png" && extension != ".bmp" && extension != ".jpg" && extension != ".jpeg")
                    {
                        throw new Exception();
                    }

                    logoString = ParseToString(file.OpenReadStream());
                }

                return logoString;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public string ParseToString(Stream data)
        {
            Image image = Image.FromStream(data, true, true);
            // Compute thumbnail size.
            Image thumbnail = image.GetThumbnailImage(image.Width, image.Height, null, IntPtr.Zero);
            MemoryStream memoryStream = new MemoryStream();
            thumbnail.Save(memoryStream, ImageFormat.Jpeg);
            Byte[] bytes = new Byte[memoryStream.Length];
            memoryStream.Position = 0;
            memoryStream.Read(bytes, 0, (int)bytes.Length);

            return Convert.ToBase64String(bytes, 0, bytes.Length);
        }
    }
}
