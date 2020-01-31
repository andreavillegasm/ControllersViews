using System;
using System.Collections.Generic;
using System.Data;
//required for SqlParameter class
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetGrooming.Data;
using PetGrooming.Models;
using System.Diagnostics;

namespace PetGrooming.Controllers
{
    public class SpeciesController : Controller
    {
        private PetGroomingContext db = new PetGroomingContext();
        // GET: Species
        public ActionResult Index()
        {
            return View();
        }

        //TODO: Each line should be a separate method in this class
        // List
        public ActionResult List()
        {
            //what data do we need?
            List<Species> myspecies = db.Species.SqlQuery("Select * from species").ToList();

            return View(myspecies);
        }

        // Show
        /*
        public ActionResult Show(int id)
        {

        }
        */
        // Add
        public ActionResult Add()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Add(string SpeciesName)
        {
            string query = "insert into species (Name) values (@SpeciesName)";
            SqlParameter param = new SqlParameter(@SpeciesName, SpeciesName);

            return RedirectToAction("List");
        }

        // Update
        public ActionResult Update(int id)
        {
            //We need the species name
            string query = "select * from species where SpeciesID = @ id";
            SqlParameter param = new SqlParameter("@id", id);

            Species selectedspecies = db.Species.SqlQuery(query, param).FirstOrDefault();

            return View(selectedspecies);
        }
        // [HttpPost] Update
        [HttpPost]
        public ActionResult Update(int id, string SpeciesName)
        {
            string query = "update species set Name=@SpeciesName where SpeciesID=@id";
            SqlParameter[] sqlparams = new SqlParameter[2];
            sqlparams[0] =  new SqlParameter("@SpeciesName", SpeciesName);
            sqlparams[1] = new SqlParameter("@id", id);


            return RedirectToAction("List");
        }

        // (optional) delete
        public ActionResult Delete(int id)
        {
            string query = "delete from species where SpeciesID=@id";
            SqlParameter sqlparam = new SqlParameter("id", id);
            db.Database.ExecuteSqlCommand(query, sqlparam);

            return RedirectToAction("List");
        }
    }
}