using Extensions.Tests.Classes;
using System;
using System.Objects;
using Xunit;

namespace Extensions.Tests
{
    public class ComparerExtensionTests
    {
        [Fact(DisplayName = "Testing Equality Between Users Objects")]
        public void TestingEqualityBetweenUsersObjects()
        {
            var id = Guid.NewGuid();
            var user01 = new User
            {
                Id = id,
                Username = "user_zero_one",
                Email = "user01@email.com",
                Phone = "0800 010 1010"
            };

            var user01_repeated = new User
            {
                Id = id,
                Username = "user_zero_one",
                Email = "user01@email.com",
                Phone = "0800 010 1010"
            };

            Assert.True(user01.Equals<User>(user01_repeated));
        }

        [Fact(DisplayName = "Testing Difference Between Users Objects")]
        public void TestingDifferenceBetweenUsersObjects()
        {
            var user01 = new User
            {
                Id = Guid.NewGuid(),
                Username = "user_zero_one",
                Email = "user01@email.com",
                Phone = "0800 010 1010"
            };

            var user01_repeated = new User
            {
                Id = Guid.NewGuid(),
                Username = "user_zero_one",
                Email = "user01@email.com",
                Phone = "0800 010 1010"
            };

            Assert.False(user01.Equals<User>(user01_repeated));
        }

        [Fact(DisplayName = "Testing Equality Between Users Objects With Explicit Generic Comparer")]
        public void TestingEqualityBetweenUsersObjectsWithExplicitGenericComparer()
        {
            var id = Guid.NewGuid();
            var user01 = new User
            {
                Id = id,
                Username = "user_zero_one",
                Email = "user01@email.com",
                Phone = "0800 010 1010"
            };

            var user01_repeated = new User
            {
                Id = id,
                Username = "user_zero_one",
                Email = "user01@email.com",
                Phone = "0800 010 1010"
            };

            Assert.Equal(user01, user01_repeated, new GenericComparer<User>());
        }

        [Fact(DisplayName = "Testing Difference Between Users Objects With Explicit Generic Comparer")]
        public void TestingDifferenceBetweenUsersObjectsWithExplicitGenericComparer()
        {
            var user01 = new User
            {
                Id = Guid.NewGuid(),
                Username = "user_zero_one",
                Email = "user01@email.com",
                Phone = "0800 010 1010"
            };

            var user01_repeated = new User
            {
                Id = Guid.NewGuid(),
                Username = "user_zero_one",
                Email = "user01@email.com",
                Phone = "0800 010 1010"
            };

            Assert.NotEqual(user01, user01_repeated, new GenericComparer<User>());
        }
    }
}
