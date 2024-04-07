//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using nhom8_TourDuLich.Models;
//using nhom8_TourDuLich.ViewModels;

//namespace nhom8_TourDuLich.Controllers
//{
//    public class Information_Controller : Controller
//    {
//        private List<InformationCustomer> _customer;
//        private readonly _63tinhThanhContext _context;

//        public Information_Controller(_63tinhThanhContext context)
//        {
//            _context = context;
//        }

//        public async Task<IActionResult> Index()
//        {
//            var INavigationBar_Controller = await _context.NavigationBars.Where(m => m.Hide == false).OrderBy(m => m.Order).ToListAsync();
//            var Information_Controller = await _context.Users.FirstOrDefaultAsync();
//            var viewModel = new Information_ViewModel
//            {
//                NavigationBarList = INavigationBar_Controller,
//                InformationCustomerList = Information_Controller
//            };
//            return View(viewModel);
//        }

//        public async Task<IActionResult> _NavigationBar()
//        {
//            return PartialView();
//        }

//        // GET: Information_Controller/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: Information_Controller/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(IFormCollection collection)
//        {
//            try
//            {
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: Information_Controller/Edit/5
//        public async Task<ActionResult> Edit(string id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }
//            InformationCustomer cus = _customer.Find(s => s.IdCustomer == id);
//            if (cus == null)
//            {
//                return NotFound();
//            }
//            return View(cus);
//        }

//        // POST: Information_Controller/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<ActionResult> Edit(InformationCustomer info)
//        {
//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    var edit = _customer.Find(m => m.IdCustomer == info.IdCustomer);
//                    edit.FullName = info.IdCustomer;
//                    edit.DateOfBirth = info.DateOfBirth;
//                    edit.Gender = info.Gender;
//                    edit.PhoneNumber = info.PhoneNumber;
//                    edit.Email = info.Email;
//                    return View("Edit", _customer);
//                }
//                catch (Exception ex)
//                {
//                    return NotFound();
//                }
//            }
//            else
//            {
//                ModelState.AddModelError("", "Vui lòng nhập đúng định dạng!");
//                return View(info);
//            }
//        }

//        // GET: Information_Controller/Delete/5
//        public ActionResult Delete(int id)
//        {
//            return View();
//        }

//        // POST: Information_Controller/Delete/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Delete(int id, IFormCollection collection)
//        {
//            try
//            {
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }
//    }
//}
