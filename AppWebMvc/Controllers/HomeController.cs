using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AppWebMvc.Models;
using AppWebMvc.Helper;
using System.Net.Http;
using Newtonsoft.Json;

namespace AppWebMvc.Controllers
{
    public class HomeController : Controller
    {
        StudentApi _api = new StudentApi();

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public async Task<IActionResult> Index()
        {
            List<StudentData> students = new List<StudentData>();
            HttpClient client = _api.Initial();

            HttpResponseMessage res = await client.GetAsync("api/student");

            if(res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                students = JsonConvert.DeserializeObject<List<StudentData>>(result);
            }

            return View(students);
        }

        public async Task<IActionResult> Details(int Id)
        {
            var student = new StudentData();
            HttpClient client = _api.Initial();

            HttpResponseMessage res = await client.GetAsync($"api/student/{Id}");

            if(res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                student = JsonConvert.DeserializeObject<StudentData>(result);
            }

            return View(student);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentData student)
        {

            HttpClient client = _api.Initial();

            var posTask = client.PostAsJsonAsync<StudentData>("api/student", student);
            posTask.Wait();

            var result = posTask.Result;
            if(result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var student = new StudentData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.DeleteAsync($"api/student/{Id}");

            return RedirectToAction("Index");
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
    }
}
