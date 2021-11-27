using AzureWebApp.Models;
using AzureWebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureWebApp
{
    public class CourseController : Controller
    {
        private readonly CourseService _courseService;
        private readonly IConfiguration _configuration;
        public CourseController(CourseService courseService, IConfiguration configuration)
        {
            _courseService = courseService;
            _configuration = configuration;
        }

        // GET: CourseController
        public ActionResult Index()
        {
            IEnumerable<Course> courses = _courseService.GetCourses(_configuration.GetConnectionString("SQLConnection"));
            return View(courses);
        }

    }
}
