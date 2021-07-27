using Extensions.Tests.Classes;
using System;
using System.Objects;
using Xunit;

namespace Extensions.Tests
{
    public class ObjectsExtensionTests
    {

        [Fact(DisplayName = "Testing Applying Properties From Object To Other Object")]
        public void TestingApplyingPropertiesFromObjectToOtherObject()
        {
            var userFrom = new User
            {
                Id = Guid.NewGuid(),
                Username = "user_from",
                Email = "user@from.com",
                Phone = "0800 000 1111"
            };

            var userTo = new User();
            userTo.SetProperties(userFrom);

            Assert.True(userFrom.Equals<User>(userTo));
        }
    }
}
