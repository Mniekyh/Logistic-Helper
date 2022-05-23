using LogisticHelper.Models;
using LogisticHelper.Repository;
using LogisticHelper.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogisticHelper.Controllers
{
    public class UzytkownikController : Controller
    {
      
        // GET: UzytkownikController
        private readonly IUnitOfWork _unitOfWork;
        public UzytkownikController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        // GET: BookCoverController

        public IActionResult Index()
        {
           
            IEnumerable<Uzytkownik> objUzytkownikList = _unitOfWork.Uzytkownik.GetAll();
            return View(objUzytkownikList);
        }
        // GET: UzytkownikController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UzytkownikController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Uzytkownik obj)
        {
            /*Some errors for fun*/
            if (obj.NAZWISKO == obj.IMIE)
            {
                ModelState.AddModelError("IdenticalNameToCustomName", "Rodzina bardzo kogoś nie kocha");


            }
            if (obj.IMIE == null)
            {
                ModelState.AddModelError("name", "Nazwa nie może być pusta! :/");
            }

            /*if everything correct, create row and go to index*/
            if (ModelState.IsValid)
            {
                _unitOfWork.Uzytkownik.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Uzytkownik created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET: UzytkownikController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UzytkownikController/Edit/5
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

        // GET: UzytkownikController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UzytkownikController/Delete/5
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
