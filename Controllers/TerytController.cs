using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ServiceModel;

namespace LogisticHelper.Controllers
{
    public class TerytController : Controller
    {
        // GET: TerytController
        public ActionResult Index()
        {
            serviceteryt.TerytWs1Client client = new serviceteryt.TerytWs1Client();


            client.ClientCredentials.UserName.UserName = "Mariusz.Sobota";
            client.ClientCredentials.UserName.Password = "so6QT8ahG";
            var result = client.CzyZalogowanyAsync();

           var cos =  client.PobierzListeMiejscowosciWGminieAsync( "slaskie", "gliwicki","gieraltowice",DateTime.Now);
                return View(cos);



        }

        // GET: TerytController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TerytController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TerytController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TerytController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TerytController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TerytController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TerytController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
