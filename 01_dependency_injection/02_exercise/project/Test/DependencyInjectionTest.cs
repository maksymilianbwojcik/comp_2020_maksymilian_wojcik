using System;
using Xunit;
using Microsoft.Extensions.DependencyInjection;

namespace Test
{
    internal interface IFoo
    {
        int Test();
    }

    internal class Foo : IFoo
    {
        public int Test()
        {
            return 7;
        }
    }

    internal class Bar
    {
        private readonly IFoo _foo;

        public Bar(IFoo foo)
        {
            _foo = foo;
        }

        public int Test()
        {
            return _foo.Test();
        }
    }

    public class DependencyInjectionTest
    {
        [Fact]
        public void HasSomeTypesForTesting()
        {
            var foo = new Foo();
            var bar = new Bar(foo);
            Assert.Equal(7, bar.Test());
        }

        // TODO: Add tests...

        [Fact]
        public void BarUsingCollectionAndProvider()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IFoo, Foo>();
            serviceCollection.AddScoped<Bar>();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var bar = serviceProvider.GetService<Bar>();
            Assert.Equal(7, bar.Test());
        }

        [Fact]
        public void AddTransient()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<IFoo, Foo>();
            serviceCollection.AddTransient<Bar>();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var bar1 = serviceProvider.GetService<Bar>();
            var bar2 = serviceProvider.GetService<Bar>();
            
            Assert.NotEqual(bar1, bar2);
            
            using IServiceScope serviceScope = serviceProvider.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;
            
            bar1 = provider.GetService<Bar>();
            Assert.NotEqual(bar1, bar2);
        }

        [Fact]
        public void AddScoped()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IFoo, Foo>();
            serviceCollection.AddScoped<Bar>();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var bar1 = serviceProvider.GetService<Bar>();
            var bar2 = serviceProvider.GetService<Bar>();
            
            Assert.Equal(bar1, bar2);

            using IServiceScope serviceScope = serviceProvider.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;
            
            bar1 = provider.GetService<Bar>();
            Assert.NotEqual(bar1, bar2);
        }

        [Fact]
        public void AddSingleton()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IFoo, Foo>();
            serviceCollection.AddSingleton<Bar>();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var bar1 = serviceProvider.GetService<Bar>();
            var bar2 = serviceProvider.GetService<Bar>();
            
            Assert.Equal(bar1, bar2);
            
            using IServiceScope serviceScope = serviceProvider.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;
            
            bar1 = provider.GetService<Bar>();
            Assert.Equal(bar1, bar2);
        }
    }
}