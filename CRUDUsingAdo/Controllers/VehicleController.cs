using CRUDUsingAdo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDUsingAdo.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IConfiguration _configuration;
        private VehicleCRUD db;

        public VehicleController(IConfiguration configuration)
        {
            _configuration = configuration;
            db=new VehicleCRUD (_configuration);
        }


        // GET: VehicleController
        public ActionResult Index()
        {
            var list=db.GetVehicles();
            return View(list);
        }

        // GET: VehicleController/Details/5
        public ActionResult Details(int id)
        {
            var v=db.GetVehiclesById(id);
            return View(v);
        }

        // GET: VehicleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vehicle vehicle)
        {
            try
            {
                var result = db.AddVehicle(vehicle);
                if(result>0)
                return RedirectToAction(nameof(Index));
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: VehicleController/Edit/5
        public ActionResult Edit(int id)
        {
            var h = db.GetVehiclesById(id);
            return View(h);
        }

        // POST: VehicleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Vehicle vehicle)
        {
            try
            {
                var result = db.EditVehicle(vehicle);
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: VehicleController/Delete/5
        public ActionResult Delete(int id)
        {
            var h=db.GetVehiclesById(id);
            return View(h);
        }

        // POST: VehicleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                var result = db.DeleteVehicle(id);
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
