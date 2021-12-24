using BlazorInputFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_State_Services.Models
{
    public interface IUploadPhoto
    {
        Task Upload(IFileListEntry file);
    }
}
