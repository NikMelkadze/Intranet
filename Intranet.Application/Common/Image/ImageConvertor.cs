using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intranet.Application.Common.Image
{
    public class ImageConvertor
    {
        public static async Task<byte[]> ImageToByteArr(IFormFile? Image, CancellationToken cancellationToken)
        {
            string defaultImagePath = Path.Combine(Directory.GetCurrentDirectory(), "Default.png");
            IFormFile defaultImage = null;
            byte[] imageBytes;

            using (var stream = new FileStream(defaultImagePath, FileMode.Create))
            {
                await defaultImage.CopyToAsync(stream, cancellationToken);
            }

            var Img = Image ?? defaultImage;
            try
            {
                using var dataStream = new MemoryStream();
                await Img.CopyToAsync(dataStream);
                imageBytes = dataStream.ToArray();
            }
            catch (Exception)
            {
                throw new Exception("Something went wrong due to uploading image");
            }
            return imageBytes;
        }
    }
}
