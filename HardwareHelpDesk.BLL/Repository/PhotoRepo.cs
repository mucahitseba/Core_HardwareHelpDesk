using HardwareHelpDesk.BLL.Helpers;
using HardwareHelpDesk.BLL.Repository.Abstracts;
using HardwareHelpDesk.DAL;
using HardwareHelpDesk.MODELS.Entities;
using HardwareHelpDesk.MODELS.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HardwareHelpDesk.BLL.Repository
{
    public class PhotoRepo : RepoBase<Photo, int>, IRepoPhoto<Photo, int>
    {
        private readonly MyContext _DbContext;
        private readonly IHostingEnvironment _hostingEnvironment;

        public PhotoRepo(MyContext DbContext, IHostingEnvironment hostingEnvironment) : base(DbContext)
        {
            _DbContext = DbContext;
            _hostingEnvironment = hostingEnvironment;
        }

        public void AddPhotos(FaultProfileViewModel model)
        {
            if (model.FaultViewModel != null && model.UserProfileViewModel == null)
            {
                if (model.FaultViewModel.PostedFileFault.Count > 0)
                {
                    model.FaultViewModel.PostedFileFault.ForEach(async file =>
                    {
                        if (file == null || file.Length <= 0)
                        {
                            var filepath2 = Path.Combine("/img/image-not-available.jpg");

                            using (var fileStream = new FileStream(filepath2, FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                            }
                            Insert(new Photo()
                            {
                                FaultId = model.FaultViewModel.FaultID,
                                Path = "/img/image-not-available.jpg"
                            });

                            return;
                        }

                        var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                        var extName = Path.GetExtension(file.FileName);
                        fileName = StringHelper.UrlFormatConverter(fileName);
                        fileName += StringHelper.GetCode();
                        var webpath = _hostingEnvironment.WebRootPath;
                        var directorypath = Path.Combine(webpath, "Uploads");
                        var filePath = Path.Combine(directorypath, fileName + extName);

                        if (!Directory.Exists(directorypath))
                        {
                            Directory.CreateDirectory(directorypath);
                        }

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }
                        Insert(new Photo()
                        {
                            FaultId = model.FaultViewModel.FaultID,
                            Path = "/Uploads/" + fileName + extName
                        });

                    });
                } 
            }

            else if (model.FaultViewModel == null && model.UserProfileViewModel != null)
            {
                var formFile = model.UserProfileViewModel.PostedFile;
                var filePath2 = Path.Combine("/img/image-not-available.jpg");
                if (formFile.Length <= 0)
                {
                    using (var stream = new FileStream(filePath2, FileMode.Create))
                    {
                        formFile.CopyTo(stream);
                    }
                    Insert(new Photo()
                    {
                        UserId = model.UserProfileViewModel.Id,
                        Path = "/img/image-not-available.jpg"
                    });

                    return;
                }

                var fileName = Path.GetFileNameWithoutExtension(formFile.FileName);
                var extName = Path.GetExtension(formFile.FileName);
                fileName = StringHelper.UrlFormatConverter(fileName);
                fileName += StringHelper.GetCode();
                var webpath = _hostingEnvironment.WebRootPath;
                var directorypath = Path.Combine(webpath, "Uploads");
                var filePath = Path.Combine(directorypath, fileName + extName);

                if (!Directory.Exists(directorypath))
                {
                    Directory.CreateDirectory(directorypath);
                }

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    formFile.CopyTo(fileStream);
                }
                Insert(new Photo()
                {
                    FaultId = model.FaultViewModel.FaultID,
                    Path = "/Uploads/" + fileName + extName
                });
            }
        }
    }
}
