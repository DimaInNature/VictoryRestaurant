﻿global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.ResponseCompression;
global using Microsoft.Extensions.Caching.Memory;
global using Microsoft.Extensions.DependencyInjection.Extensions;
global using Microsoft.IdentityModel.Tokens;
global using System.IO.Compression;
global using System.Text;
global using VictoryRestaurant.Domain;
global using VictoryRestaurant.Enums.Food;
global using VictoryRestaurant.Web.Services.Abstract.Foods;
global using Web.Enums.Views.Options;
global using Web.IoC.Injectors;
global using Web.Presentation.Configurations;
global using Web.Services.Abstract.Bookings;
global using Web.Services.Abstract.Messages;
global using Web.Services.Abstract.Subscribers;