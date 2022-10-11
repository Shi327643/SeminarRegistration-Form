using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCCoreWebApp.Models;
using System.Diagnostics;

namespace MVCCoreWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
        
            return View();
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
        [Route("[controller]/[action]/{id?}")]
        public IActionResult GreetDay(string id)
        {
            ViewBag.msg = "Welcome :" + id;
            return View("greet");  
        }
        [Route("home/AddNumbers/{num1}/{num2?}")]
        [Route("home/sum/{num1:int:range(1,50)}/{num2:int}")]
        public IActionResult AddNumbers(int num1, int num2)
        {
            int result = num1 + num2;
            ViewBag.Result = "Sum is :" + result;
            return View();  
        }


        public IActionResult EmployeeForm()
        {
            Employee employee = new Employee();
            return View(employee);
        }

        public IActionResult DisplayEmployeeForm(Employee employee)
        {
            if (ModelState.IsValid)
            {
                return View(employee);

            }
            else
            {
                return View("EmployeeForm",employee);
            }
        }

        public IActionResult CookieDemo()
        {
            return View();
        }
        public IActionResult WriteCookie(string setting, string settingValue, bool isPersistent)
        {
            if (isPersistent)
            {
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Append(setting, settingValue, options);
            }
            else
            {
                Response.Cookies.Append(setting, settingValue);

            }
            ViewBag.Message = "Cookie written successfully";
            return View("CookieDemo");
        }

        public IActionResult ReadCookies()
        {
            ViewBag.FontName = Request.Cookies["fontname"];
            ViewBag.FontSize = Request.Cookies["fontsize"];
            ViewBag.Color = Request.Cookies["color"];
            if (string.IsNullOrEmpty(ViewBag.FontName))
            {
                ViewBag.FontName = "Arial";
            }
            if (string.IsNullOrEmpty(ViewBag.FontSize))
            {
                ViewBag.FontSize = "22px";
            }
            if (string.IsNullOrEmpty(ViewBag.Color))
            {
                ViewBag.Color = "Blue";
            }
            return View();
        }
        public IActionResult WelcomePage()
        {
            return View();
        }
        public IActionResult SeminarRegistration()
        {
            Seminar seminarObj = new Seminar();
            List<SelectListItem> ConfirmationList = new List<SelectListItem>()
            {
                new SelectListItem { Text = "Yes, I will Attend", Value = true.ToString() },
                new SelectListItem { Text = "No, I Won't be able to attend", Value = false.ToString()}

            };
           
            ViewBag.List = ConfirmationList;
            return View();

        }
        public IActionResult SuccessfullForm(Seminar u)
        {
            if (ModelState.IsValid)
            {

                if (u.Confirmation == true)
                {
                    ViewBag.msg = "Thank You" + " " + u.Name;
                    ViewBag.msg1 = "It's great that You are Comming";
                }
                else
                {
                    ViewBag.msg = "Thank You" + " " + u.Name;
                    ViewBag.msg1 = "Sorry to hear that You can't make it, but thanks for letting us know";
                }
            }
            return View(u);




        }
    }
}