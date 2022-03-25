﻿global using API.Features.Bookings.Commands;
global using API.Features.Bookings.Queries;
global using API.Features.Foods.Commands;
global using API.Features.Foods.Queries;
global using API.Features.Messages.Commands;
global using API.Features.Messages.Queries;
global using API.Features.Subscribers.Commands;
global using API.Features.Subscribers.Queries;
global using API.Features.Users.Commands;
global using API.Features.Users.Queries;
global using API.Services.Abstract.Authorization;
global using API.Services.Abstract.Bookings;
global using API.Services.Abstract.Cache;
global using API.Services.Abstract.Foods;
global using API.Services.Abstract.Messages;
global using API.Services.Abstract.Subscribers;
global using API.Services.Abstract.Users;
global using MediatR;
global using Microsoft.Extensions.Caching.Memory;
global using Microsoft.IdentityModel.Tokens;
global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using System.Text;
global using VictoryRestaurant.Entities;
global using VictoryRestaurant.Enums.Food;