using Microsoft.AspNetCore.Mvc;
using restapi.Models;
namespace restapi.Controllers;


[Route("api/visits")]
[ApiController]

public class VisistController : ControllerBase
{
    
    private static readonly List<Visit> _visits = new()
    {
        new Visit { Id = 1, AnimalId = 3, VisitDate = "01-01-2010", Description = "vaccination", Price = 100},
        new Visit { Id = 2, AnimalId = 3, VisitDate = "01-11-2019", Description = "regular examination", Price = 50},
        new Visit { Id = 3, AnimalId = 1, VisitDate = "10-07-2023", Description = "eye examination", Price = 200}
    };
    
    
    
    
    [HttpPost]
    public IActionResult CreateVisit(Visit visit)
    {
        _visits.Add(visit);
        return StatusCode(StatusCodes.Status201Created);
    }
    
    
    [HttpGet("{id:int}")]
    public IActionResult GetVisit(int id)
    {
        var _new_visits = new List<Visit>();
        foreach (var visit in _visits)
        {
            if (visit.AnimalId == id)
            {
                _new_visits.Add(visit);
            }
        }
        return Ok(_new_visits);
    }

}