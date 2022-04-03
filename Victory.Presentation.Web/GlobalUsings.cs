﻿global using MediatR;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.ResponseCompression;
global using Microsoft.Extensions.Caching.Memory;
global using Microsoft.Extensions.DependencyInjection.Extensions;
global using System.IO.Compression;
global using System.Reflection;
global using Victory.Application.Features.Bookings;
global using Victory.Application.Features.Foods;
global using Victory.Application.Features.Messages;
global using Victory.Application.Features.Subscribers;
global using Victory.Application.Web.Interfaces;
global using Victory.Application.Web.Services;
global using Victory.Domain.Models;
global using Victory.Infra.Core.Enums;
global using Victory.Infra.Core.Enums.View.Options;
global using Victory.Presentation.Web.Configurations;
global using Victory.Presentation.Web.Configurations.MediatR;
global using Victory.Presentation.Web.Configurations.MediatR.Profiles;