﻿namespace Victory.Consumers.Desktop.Domain.Core.Models;

public class FoodType : IAggregationModel
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
}