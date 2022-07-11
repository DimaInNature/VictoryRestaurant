﻿global using MediatR;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.ResponseCompression;
global using Microsoft.Extensions.Caching.Memory;
global using Microsoft.Extensions.DependencyInjection.Extensions;
global using System.IO.Compression;
global using System.Reflection;
global using Victory.Application.Web.Cache.Bookings;
global using Victory.Application.Web.Cache.Foods;
global using Victory.Application.Web.Cache.Messages;
global using Victory.Application.Web.Cache.Subscribers;
global using Victory.Application.Web.Cache.Tables;
global using Victory.Application.Web.Cache.Users;
global using Victory.Application.Web.Data.Bookings;
global using Victory.Application.Web.Data.ContactMessages;
global using Victory.Application.Web.Data.Foods;
global using Victory.Application.Web.Data.MailSubscribers;
global using Victory.Application.Web.Data.Tables;
global using Victory.Application.Web.Data.Users;
global using Victory.Domain.Enums.View.Options;
global using Victory.Domain.Features.Consumers.Bookings;
global using Victory.Domain.Features.Consumers.ContactMessages;
global using Victory.Domain.Features.Consumers.Foods;
global using Victory.Domain.Features.Consumers.MailSubscribers;
global using Victory.Domain.Features.Consumers.Tables;
global using Victory.Domain.Interfaces.Clients.Cache;
global using Victory.Domain.Interfaces.Clients.Data.Bookings;
global using Victory.Domain.Interfaces.Clients.Data.ContactMessages;
global using Victory.Domain.Interfaces.Clients.Data.Foods;
global using Victory.Domain.Interfaces.Clients.Data.MailSubscribers;
global using Victory.Domain.Interfaces.Clients.Data.Tables;
global using Victory.Domain.Interfaces.Clients.Data.Users;
global using Victory.Domain.Models;
global using Victory.Infra.Configuration.Services.Features;
global using Victory.Persistence.Repositories.Clients.Bookings;
global using Victory.Persistence.Repositories.Clients.ContactMessages;
global using Victory.Persistence.Repositories.Clients.Foods;
global using Victory.Persistence.Repositories.Clients.MailSubscribers;
global using Victory.Persistence.Repositories.Clients.Tables;
global using Victory.Persistence.Repositories.Clients.Users;
global using Victory.Presentation.Web.Configurations;
global using Victory.Presentation.Web.Configurations.MediatR;
global using Victory.Presentation.Web.Configurations.MediatR.Profiles;