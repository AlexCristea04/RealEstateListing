﻿namespace RealEstateListing.Models;

public class Property
{
    public int Id { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int AgentId { get; set; }
}
