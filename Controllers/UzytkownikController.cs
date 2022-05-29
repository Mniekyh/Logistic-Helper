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
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var getUzytkownik = _unitOfWork.Uzytkownik.GetFirstOrDefault(u => u.ID == id);

            if (getUzytkownik == null)
            {
                return NotFound();
            }
            return View(getUzytkownik);
        }

        // POST: UzytkownikController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Uzytkownik entity)
        {
            if (entity.IMIE == null)
            {
                ModelState.AddModelError("NullName", "Name cannot be empty :(");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Uzytkownik.Update(entity);
                _unitOfWork.Save();
                TempData["success"] = "Uzytkownik got edited";
                return RedirectToAction("Index");
            }
            return View(entity);


        }

        // GET: UzytkownikController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var getUzytkownikToDelete = _unitOfWork.Uzytkownik.GetFirstOrDefault(u => u.ID == id);

            if (getUzytkownikToDelete == null)
                return NotFound();


            return View(getUzytkownikToDelete);
        }

        // POST: UzytkownikController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var obj = _unitOfWork.Uzytkownik.GetFirstOrDefault(u => u.ID == id); ;
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Uzytkownik.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Uzytkownik deleted successfully";

            return RedirectToAction("Index");
        }
    }
}
