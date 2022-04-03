﻿namespace Victory.Application.Features.Foods;

public sealed record class CreateFoodCommand : IRequest
{
    public Food? Food { get; }

    public CreateFoodCommand(Food entity) => Food = entity;

    public CreateFoodCommand() { }
}