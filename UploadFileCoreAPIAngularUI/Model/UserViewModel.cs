using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UploadFileCoreAPIAngularUI.Model
{
    public class UserViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Family { get; set; }
    }
}
