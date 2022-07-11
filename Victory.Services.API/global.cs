﻿global using MediatR;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Caching.Memory;
global using Microsoft.Extensions.DependencyInjection.Extensions;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.OpenApi.Models;
global using StackExchange.Redis;
global using System.IdentityModel.Tokens.Jwt;
global using System.Reflection;
global using System.Security.Claims;
global using System.Text;
global using Victory.Application.API.Cache;
global using Victory.Application.API.Data.Bookings;
global using Victory.Application.API.Data.ContactMessages;
global using Victory.Application.API.Data.Foods;
global using Victory.Application.API.Data.FoodTypes;
global using Victory.Application.API.Data.MailSubscribers;
global using Victory.Application.API.Data.Tables;
global using Victory.Application.API.Data.UserRoles;
global using Victory.Application.API.Data.Users;
global using Victory.Domain.Authorization;
global using Victory.Domain.Features.API.Bookings;
global using Victory.Domain.Features.API.ContactMessages;
global using Victory.Domain.Features.API.Foods;
global using Victory.Domain.Features.API.FoodTypes;
global using Victory.Domain.Features.API.MailSubscribers;
global using Victory.Domain.Features.API.Tables;
global using Victory.Domain.Features.API.UserRoles;
global using Victory.Domain.Features.API.Users;
global using Victory.Domain.Interfaces.API.Cache;
global using Victory.Domain.Interfaces.API.Data.Bookings;
global using Victory.Domain.Interfaces.API.Data.ContactMessages;
global using Victory.Domain.Interfaces.API.Data.Foods;
global using Victory.Domain.Interfaces.API.Data.FoodTypes;
global using Victory.Domain.Interfaces.API.Data.MailSubscribers;
global using Victory.Domain.Interfaces.API.Data.Tables;
global using Victory.Domain.Interfaces.API.Data.UserRoles;
global using Victory.Domain.Interfaces.API.Data.Users;
global using Victory.Persistence.Databases;
global using Victory.Persistence.Entities;
global using Victory.Persistence.Repositories.API.Bookings;
global using Victory.Persistence.Repositories.API.ContactMessages;
global using Victory.Persistence.Repositories.API.Foods;
global using Victory.Persistence.Repositories.API.FoodTypes;
global using Victory.Persistence.Repositories.API.MailSubscribers;
global using Victory.Persistence.Repositories.API.Tables;
global using Victory.Persistence.Repositories.API.UserRoles;
global using Victory.Persistence.Repositories.API.Users;
global using Victory.Services.API.Configurations;
global using Victory.Services.API.Configurations.MediatR;
global using Victory.Services.API.Configurations.MediatR.Profiles;