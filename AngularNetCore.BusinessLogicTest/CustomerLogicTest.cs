﻿using AngularNetCore.BusinessLogic.Implementations;
using AngularNetCore.BusinessLogic.Interfaces;
using AngularNetCore.BusinessLogicTest.Mocked;
using AngularNetCore.Models;
using AngularNetCore.UnitOfWork;
using FluentAssertions;
using Xunit;

namespace AngularNetCore.BusinessLogicTest
{
    public class CustomerLogicTest
    {
        private readonly IUnitOfWork _unitMocked;
        private readonly ICustomerLogic _customerLogic;

        public CustomerLogicTest()
        {
            var unitMocked = new CustomerRepositoryMocked();
            _unitMocked = unitMocked.GetInstance();
            _customerLogic = new CustomerLogic(_unitMocked);
        }

        [Fact]
        public void GetById_Customer_Test()
        {
            var result = _customerLogic.GetById(1);
            result.Should().NotBeNull();
            result.Id.Should().BeGreaterThan(0);
        }

        [Fact(DisplayName = "[CustomerLogic] Insert")]
        public void Insert_Customer_Test()
        {
            var customer = new Customer
            {
                Id = 101,
                City = "Lima",
                Country = "Peru",
                FirstName = "Cesar",
                LastName = "Vallejo",
                Phone = "995765478"
            };

            var result = _customerLogic.Insert(customer);
            result.Should().Be(101);
        }

        [Fact(DisplayName = "[CustomerLogic] Update")]
        public void Update_Customer_Test()
        {
            var customer = new Customer
            {
                Id = 1,
                City = "Lima",
                Country = "Peru",
                FirstName = "Cesar",
                LastName = "Vallejo",
                Phone = "995765478"
            };

            var result = _customerLogic.Update(customer);
            var currentUser = _customerLogic.GetById(1);
            currentUser.Should().NotBeNull();
            currentUser.Id.Should().Be(customer.Id);
            currentUser.City.Should().Be(customer.City);
            currentUser.Country.Should().Be(customer.Country);
            currentUser.FirstName.Should().Be(customer.FirstName);
            currentUser.LastName.Should().Be(customer.LastName);
            currentUser.Phone.Should().Be(customer.Phone);
        }
    }
}
