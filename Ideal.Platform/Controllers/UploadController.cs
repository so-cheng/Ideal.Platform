using Ideal.Platform.Authorization;
using Ideal.Platform.Common.Config;
using Ideal.Platform.Common.Snowflake;
using Microsoft.AspNetCore.Mvc;

namespace Ideal.Platform.Controllers
{
    public class UploadController : Controller
    {
        [NoAuthentiction]
        public IActionResult FileUpload(IFormFile file)
        {
            string fileName = file.FileName.Split(".")[0] + "_" + SnowFlakeUse.GetSnowflakeID()+"."+file.FileName.Split(".")[1];
            string save = Directory.GetCurrentDirectory() + "//wwwroot//HeadImg//" + fileName;
            using (FileStream fs = new FileStream(save, FileMode.Create))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
            string path ="http://"+ HttpContext.Request.Host + $"/HeadImg/{fileName}";
            object obj = new
            {
                code= 200,
                fileName = fileName,
                msg = "上传成功！",
                src= path,
                path = $"/HeadImg/{fileName}"
            };
            return Json(obj);
        }
    }
}
