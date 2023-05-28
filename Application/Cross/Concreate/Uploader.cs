using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Application.Cross.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

//using Word = Microsoft.Office.Interop.Word;
//using Microsoft.Office.Interop.Word;

namespace Application.Cross.Concreate
{
    public class Uploader : IUploader
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ILogger<Uploader> _logger;
        private readonly IConfiguration _configuration;

        private readonly string _mainPath;
        public Uploader(ILogger<Uploader> logger, IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {
            _logger = logger;
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;

            _mainPath = _configuration.GetSection("File:SavePath").Value;
        }

        public async Task<string> UploadGeneralsFile(IFormFile file, string userId = null)
        {
            string extraPath = _configuration.GetSection("File:General").Value;
            var fullFileName = await UploadFile(file,
                _hostingEnvironment.ContentRootPath + _configuration.GetSection("File:SavePath").Value,
                extraPath);

            return fullFileName;

        }
        public async Task<string> UploadUserPrimaryInfoDocumnetsFile(IFormFile file, string userId = null)
        {
            string extraPath = _configuration.GetSection("File:UserPrimaryInfoDocumnetsImage").Value;
            var fullFileName = await UploadFile(file,
                _hostingEnvironment.ContentRootPath + _configuration.GetSection("File:SavePath").Value,
                extraPath);

            return fullFileName;

        }
        public async Task<string> UploadFile(IFormFile file, string path, string extraPath, string userId = null)
        {
            var fileFullPath = "!bad path!";
            try
            {
                //var firstpath = path + _configuration.GetSection("File:SavePath").Value;
                var extension = Path.GetExtension(file.FileName);
                var fileName = "";
                if (string.IsNullOrEmpty(userId))
                    fileName = Guid.NewGuid() + extension;
                else
                    fileName = userId + "_" + Guid.NewGuid() + extension;
                var tempPath = Path.Combine(path, extraPath);
                fileFullPath = Path.Combine(tempPath, fileName);
                if (!Directory.Exists(Path.Combine(path, extraPath)))
                {
                    Directory.CreateDirectory(Path.Combine(path, extraPath));
                }
                switch (extension)
                {
                    case ".jpg":
                        var imageResized = await ResizeImage(file);
                        imageResized.Save(fileFullPath);
                        break;

                    default:
                        using (var stream = System.IO.File.Create(fileFullPath))
                        {
                            await file.CopyToAsync(stream);
                        };
                        break;
                }
                return fileName;
            }
            catch (Exception)
            {
                throw new Exception($"File Upload not working Correctly in path : {fileFullPath} ");
            }
        }

        public async Task<string> UploadProductionProductFile(IFormFile file)
        {
            var fileFullPath = "!bad path!";
            try
            {
                var extraPath = _configuration.GetSection("File:FactoryProductionProduct").Value;
                var fullFileName = await UploadFile(file,
                    _hostingEnvironment.ContentRootPath + _mainPath,
                    extraPath);
                return fullFileName;
            }
            catch (Exception)
            {
                throw new Exception($"File Upload not working Correctly in path : {fileFullPath} ");
            }
        }

        private Task<Image> ResizeImage(IFormFile file)
        {
            var image = SixLabors.ImageSharp.Image.Load(file.OpenReadStream());
            var imageH = image.Height;
            var imageW = image.Width;
            var maxH = int.Parse(_configuration.GetSection("File:MaxWidth").Value);
            var maxW = int.Parse(_configuration.GetSection("File:MaxHeight").Value);
            while (imageH > maxH && imageW > maxW)
            {
                imageH = imageH * 3 / 4;
                imageW = imageW * 3 / 4;
            }
            image.Mutate(x => x.Resize(imageW, imageH));
            return Task.FromResult(image);
        }
    }
}