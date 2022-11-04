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
            var defaultImagePath = Path.GetFullPath(@"..\Intranet.Application\Common\Image\Default.png");

            byte[] imageBytes;

            if (Image == null)
            {
                imageBytes = File.ReadAllBytes(defaultImagePath);
            }
            else
            {
                try
                {
                    using var dataStream = new MemoryStream();
                    await Image.CopyToAsync(dataStream);
                    imageBytes = dataStream.ToArray();
                }
                catch (Exception)
                {
                    throw new Exception("Something went wrong due to uploading image");
                }
            }
            return imageBytes;
        }
    }
}
