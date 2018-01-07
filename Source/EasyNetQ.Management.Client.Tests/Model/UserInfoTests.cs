// ReSharper disable InconsistentNaming

using System;
using EasyNetQ.Management.Client.Model;
using NUnit.Framework;
using FluentAssertions;

namespace EasyNetQ.Management.Client.Tests.Model
{
    [TestFixture(Category = "Unit")]
    public class UserInfoTests
    {
        private UserInfo userInfo;
        private const string userName = "mike";
        private const string password = "topSecret";

        [SetUp]
        public void SetUp()
        {
            userInfo = new UserInfo(userName, password);
        }

        [Test]
        public void Should_have_correct_name_and_password()
        {
            userInfo.GetName().ShouldEqual(userName);
            userInfo.Password.ShouldEqual(password);
        }

        [Test]
        public void Should_be_able_to_add_tags()
        {
            userInfo.AddTag("administrator").AddTag("management");
            userInfo.Tags.ShouldEqual("administrator,management");
        }

        [Test]
        public void Should_not_be_able_to_add_the_same_tag_twice()
        {
            Action act = () => userInfo.AddTag("management").AddTag("management");
            act.ShouldThrow<ArgumentException>();
        }

        [Test]
        public void Should_not_be_able_to_add_incorrect_tags()
        { 
            Action act = () => userInfo.AddTag("blah");
            act.ShouldThrow<ArgumentException>();
        }

        [Test]
        public void Should_have_a_default_tag_of_empty_string()
        {
            userInfo.Tags.ShouldEqual("");
        }
    }
}

// ReSharper restore InconsistentNaming