using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.IO.Pipes;
using TaskSystemServer.Dtos.Profile;
using TaskSystemServer.Extentions;
using TaskSystemServer.Interfaces;
using TaskSystemServer.Models;
using static System.Net.WebRequestMethods;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskSystemServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        public  static IWebHostEnvironment _webHostEnvironment;
        public readonly  IProfileRepository _memberprofileRepo;

        public ProfileController(IWebHostEnvironment webHostEnvironment, IProfileRepository memberprofileRepo)
        {
            _webHostEnvironment = webHostEnvironment;
            _memberprofileRepo = memberprofileRepo;   
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromForm] UploudProfile profile)
        {
            try
            {
                if(profile.files.Length >0)
                {
                    int memberId = int.Parse(User.GetMemberId());
                    string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    string newFileName = $"{memberId}{Path.GetExtension(profile.files.FileName)}";
                    string fullPath = Path.Combine(path, newFileName);

                    var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fullPath);


                    //delete the old profile if it exists
                    foreach (var file in Directory.GetFiles(Path.GetDirectoryName(fullPath)))
                    {

                        //Console.WriteLine("*******************************");
                        //Console.WriteLine(Path.GetFileNameWithoutExtension(file));
                        //Console.WriteLine("*******************************");

                        if (int.Parse(Path.GetFileNameWithoutExtension(file)) == memberId) {  
                            System.IO.File.Delete(file);
                            var delete = await _memberprofileRepo.DeleteAsync(memberId);
                            break; 
                        }

                    }


                        using (FileStream fileStream = System.IO.File.Create(fullPath))
                    {
                        profile.files.CopyTo(fileStream);
                        fileStream.Flush();

                        Memberprofile memberProfile = new Memberprofile
                        {
                            MemberId = int.Parse(User.GetMemberId()),
                            ProfileUrl = fullPath
                        };



                        var mp = await _memberprofileRepo.CreateAsync(memberProfile);
                        return Ok("Profile Added");
                    }
                }
                else
                {
                    return BadRequest("Profile failed to be added");
                }
            }catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetProfile()
        {
            int memberId = int.Parse(User.GetMemberId());
            var url = await _memberprofileRepo.GetByIdAsync(memberId);

            if (url!=null && System.IO.File.Exists(url.ProfileUrl))
            {
                var image = System.IO.File.OpenRead(url.ProfileUrl);

                //string contentType = GetContentType(url.ProfileUrl); // Implement this method to determine content type
                //return File(fileStream, contentType);

                return File(image, $"image/{Path.GetExtension(url.ProfileUrl).ToLowerInvariant()}");
            }

            return NotFound("No profile");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            int memberId = int.Parse(User.GetMemberId());
            var profile = await _memberprofileRepo.DeleteAsync(memberId);
            if (profile == null)
            {
                return NotFound("No Profile");
            }

            return NoContent();
        }

        //private string GetContentType(string filePath)
        //{
        //    // Example: Determine content type based on file extension
        //    string contentType;
        //    switch (Path.GetExtension(filePath).ToLowerInvariant())
        //    {
        //        case ".jpg":
        //        case ".jpeg":
        //            contentType = "image/jpeg";
        //            break;
        //        case ".png":
        //            contentType = "image/png";
        //            break;
        //        default:
        //            contentType = "application/octet-stream"; // Generic content type
        //            break;
        //    }
        //    return contentType;
        //}
    }
}
