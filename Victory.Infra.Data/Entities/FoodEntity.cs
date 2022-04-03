﻿namespace Victory.Infra.Data.Entities;

public class FoodEntity
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double CostInUSD { get; set; }
    public string ImagePath { get; set; }
    public FoodType Type { get; set; }
}