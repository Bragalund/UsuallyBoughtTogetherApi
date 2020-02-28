using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using UsuallyBoughtTogetherApi.Entities;

namespace UsuallyBoughtTogetherApi.tests.TestUtils
{
    public static class ObjectCreator
    {
        private static readonly Fixture _fixture = new Fixture();
        
        public static List<int> CreateListOfInts()
        {
            return _fixture.CreateMany<int>().ToList();
        }

        public static IEnumerable<ProductEntryEntity> CreateListOfProductEntries()
        {
            return _fixture.CreateMany<ProductEntryEntity>().ToList();
        }
    }
}