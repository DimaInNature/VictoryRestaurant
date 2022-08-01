﻿namespace Victory.Microservices.FoodService.Domain.Commands.Foods;

public sealed record class CreateFoodCommand : IRequest
{
    public FoodEntity? Food { get; }

    public CreateFoodCommand(FoodEntity entity) => Food = entity;

    public CreateFoodCommand() { }
}