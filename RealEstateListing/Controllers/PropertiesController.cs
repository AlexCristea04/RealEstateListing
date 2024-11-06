using Microsoft.AspNetCore.Mvc;
using RealEstateListing.Models;

namespace RealEstateListing.Controllers;

public class PropertiesController : Controller
{
    private static readonly List<Property> Properties = new()
    {
        new Property { Id = 1, Address = "123 Main St", Description = "Cozy 2-bedroom apartment", Price = 250000, AgentId = 1 },
        new Property { Id = 2, Address = "456 Oak Ave", Description = "Spacious 4-bedroom house", Price = 500000, AgentId = 2 }
    };

    private static readonly List<Agent> Agents = new()
    {
        new Agent { Id = 1, Name = "John Doe", PhoneNumber = "123-456-7890", Email = "johndoe@example.com" },
        new Agent { Id = 2, Name = "Jane Smith", PhoneNumber = "098-765-4321", Email = "janesmith@example.com" }
    };

    public IActionResult Details(int id)
    {
        var property = Properties.FirstOrDefault(p => p.Id == id);
        if (property == null)
        {
            return NotFound("Property not found.");
        }

        var agent = Agents.FirstOrDefault(a => a.Id == property.AgentId);
        if (agent == null)
        {
            return NotFound("Agent not found.");
        }

        var viewModel = new PropertyDetailsViewModel
        {
            PropertyAddress = property.Address,
            PropertyDescription = property.Description,
            PropertyPrice = property.Price,
            AgentName = agent.Name,
            AgentContact = $"{agent.PhoneNumber} | {agent.Email}"
        };

        return View(viewModel);
    }
}
