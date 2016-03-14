using System;
using System.Collections.Generic;
using NUnit.Framework;
namespace MiniForms.Unittest
{
    [TestFixture]
    public class TestCase
    {
        [Test]
        public void EnumerableTest()
        {
            // begin
            var items = GetItems();
            Console.WriteLine("Items loaded");
            foreach (var item in items)
            {
                Console.WriteLine("Read: " + item);
            }
        }
        public IEnumerable<string> GetItems()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Added Item " + i);
                foreach (var s in GetItems2())
                {
                    yield return s;
                }
                yield return "Item 1: " + i;
            }
        }
        public IEnumerable<string> GetItems2()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Added Item 2 " + i);
                yield return "Item 2: " + i;
            }
        }
    }
}