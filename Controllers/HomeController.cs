 
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using crud.Models;

using Microsoft.EntityFrameworkCore;


namespace crud.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context { get; set; }

        // here we can "inject" our context service into the constructor
        public HomeController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("")]

        public IActionResult Index()
        {
            List<Dish> AllDishes = _context.Dishes.ToList();

            return View(AllDishes);
        }


        [HttpGet("/new")]
        public IActionResult New()
        {
            return View();
        }

        //dish creation
        [HttpPost("CreateDish")]//post need post to make data post 
        public IActionResult CreateDish(Dish dish)
        {

            _context.Add(dish);//add but then you have to save kind of like git add and commit 
            _context.SaveChanges();
            System.Console.WriteLine(dish.Name);
            System.Console.WriteLine(dish.Tastyness);
            System.Console.WriteLine(dish.Calories);
            System.Console.WriteLine(dish.Chef);
            return RedirectToAction("Index");//returns to the page after creation 
        }
        [HttpGet("delDish/{Id}")]
        public IActionResult delDish(int Id)
        {
            Dish RetrievedDish = _context.Dishes.FirstOrDefault(item => item.DishId == Id);
            _context.Dishes.Remove(RetrievedDish);
            _context.SaveChanges();
            System.Console.WriteLine(RetrievedDish.Name);
            System.Console.WriteLine(RetrievedDish.Tastyness);
            System.Console.WriteLine(RetrievedDish.Calories);
            System.Console.WriteLine(RetrievedDish.Chef);
            return RedirectToAction("Index");//returns to the page after creation 

        }

        [HttpGet("edit/{Id}")]
        public IActionResult editHelper(int Id)
        {
            Dish myDish = _context.Dishes.FirstOrDefault(dish => dish.DishId == Id);
            return View("Edit",myDish);
        }

        [HttpPost("update/{Id}")]
        public IActionResult editDishes(int Id, Dish myDish)
        {
            Dish RetrievedDish = _context.Dishes.FirstOrDefault(item => item.DishId == Id);
            RetrievedDish.Name = myDish.Name;
            RetrievedDish.Calories = myDish.Calories;
            RetrievedDish.Chef = myDish.Chef;
            RetrievedDish.Tastyness = myDish.Tastyness;
            RetrievedDish.UpdatedAt = DateTime.Now;  
            _context.SaveChanges();
            return RedirectToAction("Index");


        }

        [HttpGet("dish/{Id}")]
        public IActionResult Display(int Id)
        {
            Dish RetrievedDish = _context.Dishes.FirstOrDefault(item => item.DishId == Id);
            return View("Dish", RetrievedDish);


        }


    }
}