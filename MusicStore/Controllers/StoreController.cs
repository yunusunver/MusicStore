using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class StoreController : Controller
    {
        MusicStoreEntities storeDb = new MusicStoreEntities();
        // GET: Store
        public ActionResult Index()
        {
            var genreList = storeDb.Genres.ToList();
            return View(genreList);
        }
        public ActionResult Browse(string genre)
        {
            var genreModel = storeDb.Genres.Include("Albums").Single(x=>x.Name==genre);
            return View(genreModel);
        }

        public ActionResult Details(int id)
        {
            var album = storeDb.Albums.Find(id);
            return View(album);
        }
    }
}