using Microsoft.AspNetCore.Http;
using System;
using System.Drawing;
using System.IO;

namespace Bussiness.Servicios
{

    public class ServicioImagenToBase64
    {
        public static string PlaceHolder = "/images/placeholder.svg";
        public static string ConvertToBase64(Stream file, int w = 256)
        {
            if (file.Length > 0)
            {
                var ms = new MemoryStream();
                file.CopyTo(ms);

                ms = ResizeImage(ms, w);

                var fileBytes = ms.ToArray();
                return "data:image;base64," + Convert.ToBase64String(fileBytes);
            }
            else
            {
                return PlaceHolder;
            }
        }

        public static MemoryStream ResizeImage(MemoryStream ms, int w)
        {
            Image img = Image.FromStream(ms);
            int h = Convert.ToInt32(w * img.Height / img.Width);
            Image imgN = img.GetThumbnailImage(w, h, null, IntPtr.Zero);
            MemoryStream res = new MemoryStream();
            imgN.Save(res, img.RawFormat);
            return res;
        }


    }
}
