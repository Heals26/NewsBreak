using FluentAssertions;
using Moq;
using NewsBreak.Application.Services.Data;
using NewsBreak.Application.Tests.Infrastructure.Database;
using NewsBreak.Application.UseCases.Accounts.CreateAccount;
using NewsBreak.Domain.Entities;
using NewsBreak.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NewsBreak.Application.Tests.UseCases.Accounts.CreateAccount
{

    public class CreateAccountInteractorTests : MockableDbContext
    {

        #region Setup
            
        public CreateAccountInteractorTests()
        {
            this.Setup();
        }

        #endregion Setup

        #region Handle Tests

        [Fact]
        public async Task Handle__CreateAccount__Succeeds()
        {
            // Arrange
            var _AccountToAdd = new CreateAccountRequest()
            {
                FirstName = "Mitch",
                LastName = "Healy",
                Email = "mitch_healy@outlook.com",
                Password = "lmao"
            };

            var _Interactor = new CreateAccountInteractor(this.MockedDbContext);

            // Act
            var _Actual = await _Interactor.Handle(_AccountToAdd, CancellationToken.None);

            // Assert
            _Actual.Should().BeOfType<CreateAccountResponse>().Which.AccountID.Should().Be(1);
        }

        #endregion Handle Tests

    }

}
