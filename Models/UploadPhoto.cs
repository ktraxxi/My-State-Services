using BlazorInputFile;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Project_State_Services.Models
{
    public class UploadPhoto : IUploadPhoto
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UploadPhoto(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task Upload(IFileListEntry file)
        {
            var path = Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot/user_avatars", file.Name);
            var memoryStream = new MemoryStream();
            await file.Data.CopyToAsync(memoryStream);

            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                memoryStream.WriteTo(fs);
            }
            
        }
    }
}
