using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CRUDelicious.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    
    private MyContext _context;


    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;


    }

    [HttpGet]
    [Route("")]
    public IActionResult Index()
    {
        List<Dishe> ListaDishes = _context.Dishes.ToList();
        return View("Index", ListaDishes);
    }

    [HttpGet]
    [Route("formulario/dish")]
    public IActionResult FormularioDish(){
        return View("FormularioDish");
    }

    [HttpPost]
    [Route("nuevo/dish")]
    public IActionResult AgregarDish(Dishe dish){
        // Me puedes ayudar aca, nose que estoy haciendo mal pero al rellenar el formulario y añadir , se queda en la misma pagina y no redirecciona al index
        if(!ModelState.IsValid){ 
            foreach(var ModelStateEntry in ModelState.Values)
            {
                foreach(var error in ModelStateEntry.Errors){
                    Console.WriteLine("Error: " + error.ErrorMessage);
                }
            }
        }
        if(ModelState.IsValid){

            _context.Dishes.Add(dish);
            _context.SaveChanges();
            return RedirectToAction("Index"); 
            }
    
        return View("FormularioDish");

        }

    [HttpGet]
    [Route("volver/index")]
    public IActionResult VolverIndex(){
        return RedirectToAction("Index");
    }

    [HttpGet]
    [Route("dish/edit/{id_dish}")]
    public IActionResult FormularioEditarDish(int id_dish){

        Dishe? dish = _context.Dishes.FirstOrDefault(i => i.Id == id_dish);
        return View("FormularioEditarDish", dish);  
    }
    [HttpGet]
    [Route("edit/{id_dish}")]
    public IActionResult EditarDish(int id_dish){
        Dishe? dish = _context.Dishes.FirstOrDefault(edit => edit.Id == id_dish);
        return View("EditarDish", dish);
    }

    [HttpPost]
    [Route("actualiza/dish/{id_dish}")]

    public IActionResult ActualizaDish(Dishe dish, int id_dish){
        Dishe? dishPrevia = _context.Dishes.FirstOrDefault(i => i.Id == id_dish);
        if(ModelState.IsValid){
            

            dishPrevia.Name = dish.Name;
            dishPrevia.Chef = dish.Chef;
            dishPrevia.Calories = dish.Calories;
            dishPrevia.Tastiness = dish.Tastiness;
            dishPrevia.Description = dish.Description;
            //dishPrevia.Fecha_Actualizacion = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction ("Index");
        }   
        return View("EditarDish", dishPrevia);


    }

    [HttpPost]
    [Route("elimina/dish/{id_dish}")]
    public IActionResult EliminaDish(int id_dish){
        Dishe? dish = _context.Dishes.FirstOrDefault(i => i.Id == id_dish);
        _context.Dishes.Remove(dish);
        _context.SaveChanges();
        return RedirectToAction("Index");

    }



    /*public IActionResult Privacy()
    {
        return View();
    }
    */
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
