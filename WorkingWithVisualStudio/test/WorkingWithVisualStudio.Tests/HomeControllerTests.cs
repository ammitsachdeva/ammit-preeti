using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkingWithVisualStudio.Controllers;
using WorkingWithVisualStudio.Models;
using Xunit;

namespace WorkingWithVisualStudio.Tests
{
    public class HomeControllerTests
    {
        class ModelCompleteFakeRepository : IRepository
        {
            public IEnumerable<Product> Products { get; } = new Product[]
            {
                new Product {Name = "p1", Price = 275M },
                new Product {Name = "p2", Price =  48.95M },
                new Product {Name = "p3", Price = 19.50M },
                new Product {Name = "p3", Price = 34.95M }
             };
            public void AddProduct(Product p)
            {
                //do nothing -not required for test
            }
        }
        [Fact]
        public void IndexActionModelIsComplete()
        {
            //Arrange
            var controller = new HomeController();
            controller.Repository = new ModelCompleteFakeRepository();
            //Act
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;
            //Assert
            Assert.Equal(controller.Repository.Products,model,
                Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name
                && p1.Price == p2.Price));
        }
        class ModelCompleteFakeRepositoryPricesUnder50 : IRepository
        {
            public IEnumerable<Product> Products { get; } = new Product[]
            {
                new Product {Name = "p1", Price = 275M },
                new Product {Name = "p2", Price =  48.95M },
                new Product {Name = "p3", Price = 19.50M },
                new Product {Name = "p3", Price = 34.95M }
             };
            public void AddProduct(Product p)
            {
                //do nothing -not required for test
            }
        }
        [Fact]
        public void IndexActionModelIsCompletePricesUnder50()
        {
            //Arrange
            var controller = new HomeController();
            controller.Repository = new ModelCompleteFakeRepositoryPricesUnder50();
            //Act
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;
            //Assert
            Assert.Equal(controller.Repository.Products, model,
                Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name
                && p1.Price == p2.Price));
        }


    }
}
