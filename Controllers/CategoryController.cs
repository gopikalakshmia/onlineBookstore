using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using onlineBookstore.Data;
using onlineBookstore.Models;

namespace onlineBookstore.Controllers;

public class CategoryController : Controller
{
    //private readonly ILogger<HomeController> _logger;

   // public HomeController(ILogger<HomeController> logger)
    // {
    //     _logger = logger;
    // }
    private ApplicationDbContext _db;
    public CategoryController(ApplicationDbContext db){
        _db=db;
    }

    public IActionResult Index()
    {
       List<Category> categoriesList=_db.Categories.ToList();
        return View(categoriesList);
    }
//category/create
    public IActionResult Create(){
        return View();
    }
//Form submission
    [HttpPost]
    public IActionResult Create(Category obj){
        if(ModelState.IsValid){
            _db.Categories.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
