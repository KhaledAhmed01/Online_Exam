//using Online_Exam.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using System.Collections.Generic;
//using System.Linq;

//namespace Online_Exam.Controllers
//{
//    public class ExamController : Controller
//    {
//        private readonly OnlineExammDbContext _context;

//        public ExamController(OnlineExammDbContext context)
//        {
//            _context = context;
//        }

//        public IActionResult Index()
//        {
//            List<Exam> exams = _context.Exams.ToList();
//            return View(exams);
//        }

//        [HttpGet]
//        public IActionResult Create()
//        {
//            // Get the current user's role
//            // var isAdministration = User.IsInRole("administration");

//            // Prepare a SelectList for dropdown if needed
//            // ViewBag.Users = new SelectList(_context.Users, "U_Email", "U_Email");

//            // Pass a flag to the view indicating whether the email should be displayed as text
//            //ViewBag.DisplayEmailAsText = isAdministration;

//            return View(Exam());
//        }

//        [HttpPost]
//        public IActionResult Create(Exam exam)
//        {
//            // Check if the Adminstration_Email exists in the Users table
//            var userExists = _context.Users.Any(u => u.U_Email == exam.Adminstration_Email);

//            if (!userExists)
//            {
//                ModelState.AddModelError("Adminstration_Email", "Email not found. Please sign up.");
//            }

//            if (ModelState.IsValid)
//            {
//                _context.Exams.Add(exam);
//                _context.SaveChanges();

//                // Redirect to Index only when email is found
//                return RedirectToAction("Index");
//            }

//            // Repopulate the user dropdown
//            //ViewBag.Users = new SelectList(_context.Users, "U_Email", "U_Email");

//            // Pass the flag to the view
//            //ViewBag.DisplayEmailAsText = User.IsInRole("administration");

//            return View(exam);
//        }


//        [HttpGet]
//        public IActionResult Edit(int id)
//        {
//            Exam exam = _context.Exams.Find(id);

//            // Get the current user's role
//            var isAdministration = User.IsInRole("administration");

//            // Prepare a SelectList for dropdown if needed
//            ViewBag.UserList = new SelectList(_context.Users, "U_Email", "U_Email");

//            // Pass a flag to the view indicating whether the email should be displayed as text
//            ViewBag.DisplayEmailAsText = isAdministration;

//            return View(exam);
//        }

//        [HttpPost]
//        public IActionResult Edit(Exam exam)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Exams.Update(exam);
//                _context.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            // Repopulate the user dropdown
//            ViewBag.UserList = new SelectList(_context.Users, "U_Email", "U_Email");

//            // Pass the flag to the view
//            ViewBag.DisplayEmailAsText = User.IsInRole("administration");

//            return View(exam);
//        }

//        [HttpGet]
//        public IActionResult Delete(int id)
//        {
//            Exam exam = _context.Exams.Find(id);
//            return View(exam);
//        }

//        [HttpPost]
//        public IActionResult DeleteConfirmed(int id)
//        {
//            Exam exam = _context.Exams.Find(id);
//            _context.Exams.Remove(exam);
//            _context.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        private bool ExamExists(int id)
//        {
//            return _context.Exams.Any(e => e.Exam_id == id);
//        }
//    }
//}
