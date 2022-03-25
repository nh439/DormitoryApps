﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Hangfire;
using dormitoryApps.Server.Services.Job;

namespace dormitoryApps.Server
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Schedule
    {
        private readonly RequestDelegate _next;

        public Schedule(RequestDelegate next, IJobServices jobServices)
        {
            RecurringJob.AddOrUpdate(() => jobServices.Run(), Cron.Minutely);
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ScheduleExtensions
    {
        public static IApplicationBuilder UseSchedule(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Schedule>();
        }
    }
}