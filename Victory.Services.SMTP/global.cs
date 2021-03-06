global using MediatR;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.OpenApi.Models;
global using System.Reflection;
global using Victory.Application.SMTP.Data;
global using Victory.Application.SMTP.Messages;
global using Victory.Domain.Features.Consumers.MailSubscribers;
global using Victory.Domain.Interfaces.Consumers.Data.MailSubscribers;
global using Victory.Domain.Models;
global using Victory.Infra.Configuration.Services.Features;
global using Victory.Persistence.Repositories.Consumers.MailSubscribers;
global using Victory.Services.SMTP.Configurations;
global using Victory.Services.SMTP.Configurations.MediatR;
global using Victory.Services.SMTP.Configurations.MediatR.Profiles;