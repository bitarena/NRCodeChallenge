using NRCodeChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NRCodeChallenge.UnitTest.MockFactories
{
    public class ContributorFactory
    {
        public static Contributor CreateDefault()
        {
            var result = new Contributor
            {
                Username = "test",
            };

            return result;
        }

        public static IEnumerable<Contributor> CreateList(int size, string prefix = "hola")
        {
            var result = new List<Contributor>();
            for (var i= 0; i < size; i++)
            {
                result.Add(new Contributor
                {
                    Username = $"{prefix} {new Random().Next(0, 200)}",
                });
            }
            return result;
        }
    }
}
