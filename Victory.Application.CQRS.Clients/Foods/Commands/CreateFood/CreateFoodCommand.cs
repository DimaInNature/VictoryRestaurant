﻿namespace Victory.Application.CQRS.Clients.Foods;

public sealed record class CreateFoodCommand
    : BaseAuthorizedFeature, IRequest
{
    public Food? Food { get; }

    public CreateFoodCommand(Food entity, string token) =>
        (Food, Token) = (entity, token);

    public CreateFoodCommand() { }
}