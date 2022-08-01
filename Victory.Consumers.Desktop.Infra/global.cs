﻿global using MediatR;
global using Microsoft.Extensions.DependencyInjection;
global using System;
global using System.Collections.Generic;
global using System.Reflection;
global using Victory.Consumers.Desktop.Application.Services.Authorizations.JWT;
global using Victory.Consumers.Desktop.Application.Services.Bookings;
global using Victory.Consumers.Desktop.Application.Services.ContactMessages;
global using Victory.Consumers.Desktop.Application.Services.Foods;
global using Victory.Consumers.Desktop.Application.Services.FoodTypes;
global using Victory.Consumers.Desktop.Application.Services.Integrations.CloudinaryImages;
global using Victory.Consumers.Desktop.Application.Services.Integrations.SMTP;
global using Victory.Consumers.Desktop.Application.Services.MailSubscribers;
global using Victory.Consumers.Desktop.Application.Services.Sessions;
global using Victory.Consumers.Desktop.Application.Services.Tables;
global using Victory.Consumers.Desktop.Application.Services.UserRoles;
global using Victory.Consumers.Desktop.Application.Services.Users;
global using Victory.Consumers.Desktop.Domain.Commands.Authorizations;
global using Victory.Consumers.Desktop.Domain.Commands.Bookings;
global using Victory.Consumers.Desktop.Domain.Commands.ContactMessages;
global using Victory.Consumers.Desktop.Domain.Commands.Foods;
global using Victory.Consumers.Desktop.Domain.Commands.Integrations.CloudinaryImages;
global using Victory.Consumers.Desktop.Domain.Commands.Integrations.SMTP;
global using Victory.Consumers.Desktop.Domain.Commands.MailSubscribers;
global using Victory.Consumers.Desktop.Domain.Commands.Tables;
global using Victory.Consumers.Desktop.Domain.Commands.Users;
global using Victory.Consumers.Desktop.Domain.Configurations;
global using Victory.Consumers.Desktop.Domain.Core.Models;
global using Victory.Consumers.Desktop.Domain.Core.MVVM.ViewModels;
global using Victory.Consumers.Desktop.Domain.Interfaces.Bookings;
global using Victory.Consumers.Desktop.Domain.Interfaces.ContactMessages;
global using Victory.Consumers.Desktop.Domain.Interfaces.Foods;
global using Victory.Consumers.Desktop.Domain.Interfaces.FoodTypes;
global using Victory.Consumers.Desktop.Domain.Interfaces.MailSubscribers;
global using Victory.Consumers.Desktop.Domain.Interfaces.Tables;
global using Victory.Consumers.Desktop.Domain.Interfaces.UserRoles;
global using Victory.Consumers.Desktop.Domain.Interfaces.Users;
global using Victory.Consumers.Desktop.Domain.Queries.Bookings;
global using Victory.Consumers.Desktop.Domain.Queries.ContactMessages;
global using Victory.Consumers.Desktop.Domain.Queries.Foods;
global using Victory.Consumers.Desktop.Domain.Queries.FoodTypes;
global using Victory.Consumers.Desktop.Domain.Queries.MailSubscribers;
global using Victory.Consumers.Desktop.Domain.Queries.Tables;
global using Victory.Consumers.Desktop.Domain.Queries.UserRoles;
global using Victory.Consumers.Desktop.Domain.Queries.Users;
global using Victory.Consumers.Desktop.Infra.IoC.MediatR.Profiles;