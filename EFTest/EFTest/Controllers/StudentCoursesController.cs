using EFTest.Interfaces;
using EFTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EFTest.Controllers
{
    public class StudentCoursesController : Controller
    {
        private readonly IStudentCoursesRepository _studentCoursesRepository;
        public StudentCoursesController(IStudentCoursesRepository studentCoursesRepository)
        {
            _studentCoursesRepository = studentCoursesRepository;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _studentCoursesRepository.GetAll();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Models.StudentCourses studentCourses)
        {
            if (ModelState.IsValid)
            {
                await _studentCoursesRepository.Create(studentCourses);
                return RedirectToAction("Index");
            }
            return View(studentCourses);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            var studentCourses = await _studentCoursesRepository.GetById(id.Value);
            if (studentCourses == null)
            {
                return NotFound();
            }
            return View(studentCourses);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, Models.StudentCourses studentCourses)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            if (id.Value != studentCourses.StudentId)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                await _studentCoursesRepository.Update(studentCourses);
                return RedirectToAction("Index");
            }
            return View(studentCourses);
        }

        public IActionResult Privacy()
        { 
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var course = await _studentCoursesRepository.GetById(id);
            if (course == null)
            {
                return NotFound();
            }

            await _studentCoursesRepository.Delete(course);
            return RedirectToAction("Index");
        }
    }
}
