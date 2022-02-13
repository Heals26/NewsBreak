using MediatR;
using Microsoft.EntityFrameworkCore;
using NewsBreak.Application.Services.Data;
using NewsBreak.Application.Services.Security.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace NewsBreak.Application.UseCases.OAuth.CreateOAuthFromLogin
{

    public class CreateOAuthFromLoginInteractor : IRequestHandler<CreateOAuthFromLoginRequest, CreateOAuthFromLoginResponse>
    {

        #region Fields

        private readonly IAuthenticationContainer m_AuthenticationContainer;
        private readonly IAuthenticationService m_AuthenticationService;
        private readonly IBreakDBContext m_DbContext;

        #endregion Fields

        #region Constructors

        public CreateOAuthFromLoginInteractor(IAuthenticationContainer authenticationContainer, IAuthenticationService authenticationService, IBreakDBContext breakDBContext)
        {
            this.m_AuthenticationContainer = authenticationContainer;
            this.m_AuthenticationService = authenticationService;
            this.m_DbContext = breakDBContext;
        }

        #endregion Constructors

        #region Handle Implementation

        public async Task<CreateOAuthFromLoginResponse> Handle(CreateOAuthFromLoginRequest request, CancellationToken cancellationToken)
        {
            // https://medium.com/@mmoshikoo/jwt-authentication-using-c-54e0c71f21b0
            var _ClientApplication = await this.m_DbContext.ClientApplications
                .AsNoTracking()
                .Include(c => c.ClientApplicationScopes)
                    .ThenInclude(cas => cas.Scope)
                .Where(ca => ca.Name == request.ClientID && ca.Secret == request.ClientSecret)
                .SingleOrDefaultAsync()
                    ?? throw new AuthenticationException();

            var _Account = await this.m_DbContext.Accounts
                .Include(a => a.Claims)
                .SingleOrDefaultAsync(a => a.Email == request.Username)
                    ?? throw new AuthenticationException();

            _Account.Password.VerifyHash(request.Password);

            var _Claims = this.m_AuthenticationService.CalculateClaims(_Account.Claims);

            this.m_AuthenticationContainer.Claims = _Claims;
            var _Token = this.m_AuthenticationService.GenerateToken(this.m_AuthenticationContainer);

            return new CreateOAuthFromLoginResponse();
        }

        #endregion Handle Implementation

    }

}
