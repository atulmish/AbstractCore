using AbstractCore.DDD.Core;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace AbstractCore.DDD.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
            .AddMediatR(typeof(Ping))
            .BuildServiceProvider();

            var mediator = serviceProvider.GetService<IMediator>();
            var response = mediator.Send(new Ping()).Result;

            Console.WriteLine(response);

            Console.ReadKey();
        }
    }
}
