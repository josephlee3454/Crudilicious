using System.ComponentModel.DataAnnotations;
using System;
namespace crud.Models{
    public class Dish{
    
    [Key]
    public int DishId {get;set;}
    
    public string Name{get;set;}

    public string Chef {get;set;}

    public int Tastyness{get;set;}

    public int Calories{get;set;}

    public string Text{get;set;}

    public DateTime CreatedAt{get;set;}

    public DateTime UpdatedAt{get;set;}

    }
}