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
//Create Form submission
    [HttpPost]
    public IActionResult Create(Category obj){
        if(ModelState.IsValid){
            _db.Categories.Add(obj);
            _db.SaveChanges();
            TempData["success"]="The category Added Successfully";
            return RedirectToAction("Index");
        }
        else
        return View();
    }
//Edit
public IActionResult Edit (int? Id){
    if(Id==null && Id==0){
        return NotFound();
    }
    Category? editCategoryVal = _db.Categories.FirstOrDefault(item => item.Id == Id);
    if (editCategoryVal == null)
    {
        return NotFound();
    }
    return View(editCategoryVal);
}
//Submit Edit
    [HttpPost]
    public IActionResult Edit(Category obj){
        if(ModelState.IsValid){
            _db.Categories.Update(obj);
            _db.SaveChanges();
               TempData["success"]="The category Edited Successfully";
            return RedirectToAction("Index");
        }
        else
        return View();
    }

//Delete
public IActionResult Delete(int? Id){
        if (Id == null && Id == 0)
        {
        return NotFound();
    }
    Category? deleteCategoryVal = _db.Categories.FirstOrDefault(item => item.Id == Id);
    if (deleteCategoryVal == null)
    {
        return NotFound();
    }
    return View(deleteCategoryVal);
}
//Submit Delete
    [HttpPost,ActionName("Delete")]
    public IActionResult DeletePost(Category obj){
     
            _db.Categories.Remove(obj);
            _db.SaveChanges();
               TempData["success"]="The category Removed Successfully";
            return RedirectToAction("Index");
       
        
    }





    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
