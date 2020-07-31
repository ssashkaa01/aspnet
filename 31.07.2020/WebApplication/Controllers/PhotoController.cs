using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Entities;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class PhotoController : Controller
    {
        DataContext dataContext = new DataContext();

        // GET: Photo
        public ActionResult Index()
        {
            IEnumerable<Photo> list = dataContext.Photos.ToList();
            
            var mapper = MyAutoMapperConfig.GetAutoMapper();
            // сопоставление
            var model = mapper.Map<List<PhotoVM>>(list);

            return View(model);

        }

        // GET: Photo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Photo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Photo/Create
        [HttpPost]
        public ActionResult Create(PhotoAddVM model)
        {
            if (model.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Оберіть фото!");
                return View(model);
            }

          
            if (ModelState.IsValid)
            {
                string fileName = Path.GetRandomFileName() + ".jpg";
                string serverPath = Server.MapPath("~/Uploading");
                string fileSave = Path.Combine(serverPath, fileName);
                model.ImageFile.SaveAs(fileSave);

                Photo photo = new Photo
                {
                    Name = model.Name,
                    Image = fileName,
                    CreateDate = DateTime.Now,
                    ModifyDate = DateTime.Now,
                    DeleteDate = DateTime.Now
                };
                dataContext.Photos.Add(photo);
                dataContext.SaveChanges();
               
                return RedirectToAction("Index");
            }
            return View(model);
        }
    

        // GET: Photo/Edit/5
        public ActionResult Edit(int id)
        {
            Photo item = dataContext.Photos.Find(id);
            
            var mapper = MyAutoMapperConfig.GetAutoMapper();
            // сопоставление
            var model = mapper.Map<PhotoAddVM>(item);


            return View(model);
        }

        // POST: Photo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PhotoAddVM model)
        {
            string fileName;

            Photo item = dataContext.Photos.Find(id);

            if (model.ImageFile != null)
            {
                 fileName = Path.GetRandomFileName() + ".jpg";
                string serverPath = Server.MapPath("~/Uploading");
                string fileSave = Path.Combine(serverPath, fileName);
                model.ImageFile.SaveAs(fileSave);
            }
            else
            {
                 fileName = item.Image;
            }

            item.Name = model.Name;
            item.ModifyDate = DateTime.Now;

            dataContext.SaveChanges();

            return RedirectToAction("Index");
           
        }

        // GET: Photo/Delete/5
        public ActionResult Delete(int id)
        {
            Photo item = dataContext.Photos.Find(id);
            if (item != null)
            {
                string serverPath = Server.MapPath("~/Uploading");
                string fileDelete = Path.Combine(serverPath, item.Image);

                if (System.IO.File.Exists(fileDelete))
                {
                    System.IO.File.Delete(fileDelete);
                }

                dataContext.Photos.Remove(item);
                dataContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // POST: Photo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            return RedirectToAction("Index");
        }
    }
}
