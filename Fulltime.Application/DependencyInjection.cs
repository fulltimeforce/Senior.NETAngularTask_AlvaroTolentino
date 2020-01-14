using Microsoft.Extensions.DependencyInjection;
using MediatR;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Fulltime.Application.Common.Behaviors;

namespace Fulltime.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            return services;

        }

    }
}
