using Microsoft.AspNetCore.Mvc;
using restapi.Models;

namespace restapi.Controllers;

[Route("api/animals")]
[ApiController]

public class AnimalController : ControllerBase
{

    private static readonly List<Animal> _animals = new()
    {
        new Animal { Id = 1, Name = "Nina", Category = "Cat", FurColor = "Brown", Weight = 10 },
        new Animal { Id = 2, Name = "Ozzy", Category = "Dog", FurColor = "White", Weight = 20 },
        new Animal { Id = 3, Name = "Maciek", Category = "Dog", FurColor = "Black", Weight = 40.5 }
    };
    
    
    
    
    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok(_animals);
    }

    
    
    
    [HttpGet("{id:int}")]
    public IActionResult GetAnimal(int id)
    {
        var animal = _animals.FirstOrDefault(a => a.Id == id);
        if (animal == null)
        {
            return NotFound($"There is no animal with id: {id}");
        }

        return Ok(animal);
    }

    
    
    [HttpPost]
    public IActionResult CreateAnimal(Animal animal)
    {
        _animals.Add(animal);
        return StatusCode(StatusCodes.Status201Created);
    }


    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(int id, Animal animal)
    {
        var animalToEdit = _animals.FirstOrDefault(a => a.Id == id);
        if (animalToEdit == null)
        {
            return NotFound($"There is no animal with id: {id}");
        }

        _animals.Remove(animalToEdit);
        _animals.Add(animal);
        return NoContent();
    }



    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        var animalToDelete = _animals.FirstOrDefault(a => a.Id == id);
        if (animalToDelete == null)
        {
            return NotFound($"There is no animal with id: {id}");
        }

        _animals.Remove(animalToDelete);
        return NoContent();
    }
    
    
    
    
}