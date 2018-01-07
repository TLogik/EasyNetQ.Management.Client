﻿// ReSharper disable InconsistentNaming

using EasyNetQ.Management.Client.Model;
using NUnit.Framework;
using System;
using FluentAssertions;

namespace EasyNetQ.Management.Client.Tests.Model
{
    [TestFixture(Category = "Unit")]
    public class ExchangeInfoTests
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void Should_be_able_to_get_name()
        {
            const string expectedName = "the_name";
            var exchangeInfo = new ExchangeInfo(expectedName, "direct");
            exchangeInfo.GetName().ShouldEqual(expectedName);
        }

        [Test]
        public void Should_throw_if_we_try_to_create_an_exchange_with_an_unknown_type()
        {
            Action act = () => new ExchangeInfo("management_api_test_exchange", "some_bullshit_exchange_type");
            act.ShouldThrow<EasyNetQManagementException>();

        }
    }
}

// ReSharper restore InconsistentNaming