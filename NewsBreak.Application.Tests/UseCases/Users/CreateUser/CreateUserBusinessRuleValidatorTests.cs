using AutoMapper;
using CleanArchitecture.Mediator;
using FluentValidation.Results;
using Moq;
using NewsBreak.Application.Infrastructure.Validation;
using NewsBreak.Application.Services.Persistence;
using NewsBreak.Application.UseCases.Users.CreateUser;
using NewsBreak.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsBreak.Application.Tests.UseCases.Users.CreateUser
{

    public class CreateUserBusinessRuleValidatorTests
    {

        #region Fields

        private readonly Mock<IMapper> m_MockMapper = new();
        private readonly Mock<IPersistenceContext> m_MockDbContext = new();

        private readonly User m_User;
        private readonly CreateUserInputPort m_InputPort;
        private readonly IUseCaseBusinessRuleValidator<CreateUserInputPort, ValidatorResult> m_Validator;

        #endregion Fields

        #region Constructors

        //public CreateUserBusinessRuleValidator()
        //{
        //    this.m_InputPort = new()
        //    {
        //        Email = "new@email.com"
        //    };
        //
        //
        //    this.m_Validator = new(this.m_MockDbContext);
        //}

        #endregion Constructors

        #region Methods



        #endregion Methods

    }

}
