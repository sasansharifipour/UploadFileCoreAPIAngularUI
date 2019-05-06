using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UploadFileCoreAPIAngularUI.Model
{
    public class User
    {
        public string Name { get; set; }

        public string Family { get; set; }

        public IFormFile Image { get; set; }
    }
}
