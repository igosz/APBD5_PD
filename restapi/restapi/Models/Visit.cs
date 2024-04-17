namespace restapi.Models;

public class Visit
{
    public int Id { get; set; }
    public string VisitDate { get; set; }
    public int AnimalId { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}