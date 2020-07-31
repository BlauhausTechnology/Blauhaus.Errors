using System;
using System.Collections.Generic;
using Blauhaus.Errors.Tests.Tests._Base;
using NUnit.Framework;

namespace Blauhaus.Errors.Tests.Tests.ErrorTests
{
    public class EqualityTests
    {
        [Test]
        public void WHEN_values_are_the_same_SHOULD_return_TRUE()
        {
            foreach (var equalObjectPair in GetEqualObjects())
            {
                var item1 = equalObjectPair.Item1;
                var item2 = equalObjectPair.Item2;

                Assert.AreEqual(item1, item2);
                Assert.That(item1 == item2, Is.True);
                Assert.That(item1 != item2, Is.False);
                Assert.That(item1.GetHashCode(), Is.EqualTo(item2.GetHashCode()));
                Assert.That(item1.Equals(item2), Is.True);
            }
        }
        
        
        [Test]
        public void WHEN_values_are_not_the_same_SHOULD_return_FALSE()
        {
            foreach (var unequalObjectPair in GetUnequalObjects())
            {
                var item1 = unequalObjectPair.Item1;
                var item2 = unequalObjectPair.Item2;

                Assert.AreNotEqual(item1, item2);
                Assert.That(item1 != item2, Is.True);
                Assert.That(item1 == item2, Is.False);
                Assert.That(item1.GetHashCode(), Is.Not.EqualTo(item2.GetHashCode()));
                Assert.That(item1.Equals(item2), Is.False);
            }
        }

        protected static IEnumerable<Tuple<Error, Error>> GetEqualObjects()
        {
            return new List<Tuple<Error, Error>>
            {
                new Tuple<Error, Error>(TestErrors.TestErrorOne, TestErrors.TestErrorOne),
                new Tuple<Error, Error>(TestErrors.TestErrorThree("three"), TestErrors.TestErrorThree("three")),
                new Tuple<Error, Error>(TestErrors.TestErrorThree("four"), TestErrors.TestErrorThree("three")),
                new Tuple<Error, Error>(TestErrors.TestErrorThree("three"), TestErrors.TestErrorThree("four")),
            };
        }

        protected static IEnumerable<Tuple<Error, Error>> GetUnequalObjects()
        {
            return new List<Tuple<Error, Error>>
            {
                new Tuple<Error, Error>(TestErrors.TestErrorOne, TestErrors.TestErrorTwo),
                new Tuple<Error, Error>(TestErrors.TestErrorTwo, TestErrors.TestErrorOne),
                new Tuple<Error, Error>(TestErrors.TestErrorTwo, TestErrors.TestErrorThree("3")),
            };
        }
    }
}