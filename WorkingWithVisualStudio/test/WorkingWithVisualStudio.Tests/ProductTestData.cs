using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using WorkingWithVisualStudio.Models;

namespace WorkingWithVisualStudio.Tests
{
    public class ProductTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { GetPricesUnder50() };
            yield return new object[] { GetPricesOver50 };

        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        private IEnumerable<Product> GetPricesUnder50()
        {
            decimal[] prices = new decimal[] { 275, 49.95M, 19.50M, 24.95M };
            for (int i = 0; i < prices.Length; i++)
            {
                yield return new Product { Name = $"P{i + 1}", Price = prices[i] };
            }
        }
        private Product[] GetPricesOver50 => new Product[]
        {
            new Product {Name = "p1" , Price = 5 },
            new Product {Name = "p2" , Price = 48.95M },
            new Product {Name = "p3" , Price = 19.50M },
            new Product {Name = "p4" , Price = 24.95M } };

        }
    }
    
