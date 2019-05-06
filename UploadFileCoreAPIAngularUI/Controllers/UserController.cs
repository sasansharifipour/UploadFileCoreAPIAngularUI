using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UploadFileCoreAPIAngularUI.Model;

namespace UploadFileCoreAPIAngularUI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        private IHostingEnvironment _hostingEnvironment;

        public UserController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [AllowAnonymous]
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Post(string data, IFormFile file)
        {
            UserViewModel model = Newtonsoft.Json
                .JsonConvert.DeserializeObject<UserViewModel>(data);

            

            bool validate = TryValidateModel(model);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (file.Length <= 0)
                return BadRequest(ModelState);

            User user = new User() { Name = model.Name, Family = model.Family, Image = file };

            string folderName = "Upload";
            string webRootPath = _hostingEnvironment.WebRootPath;
            string newPath = Path.Combine(webRootPath, folderName);

            string fileName = user.Name + "_" + user.Family + Path.GetExtension(user.Image.FileName);
            string fullPath = Path.Combine(newPath, fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            string Data_Created = "You Successfully Upload The Data!!!";

            return Ok(Json(Data_Created));
        }

    }
}