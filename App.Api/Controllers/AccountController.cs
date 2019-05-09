using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using App.Api.Security;
using App.Domain.Commands;
using App.Domain.Commands.UserCommands;
using App.Domain.Entities;
using App.Domain.Repositories;
using Flunt.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace App.Api.Controllers
{
    public class AccountController : Controller
    {
        private readonly ICustomerRepository _repository;
        private readonly TokenOptions _tokenOptions;
        private Customer _customer;
        private readonly JsonSerializerSettings _serializerSettings;
        public AccountController(ICustomerRepository repository,IOptions<TokenOptions> jwtOptions)
        {
            _repository = repository;
            _tokenOptions = jwtOptions.Value;
            ThrowIfInvalidOptions(_tokenOptions);
            _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("v1/autenticar")]
        public async Task<IActionResult> Post([FromForm] AuthenticateUserCommand command)
        {
            if(command == null)
                return null;

            var identity = await  GetClaims(command);
            if(identity == null)
                return null;

            var claims = new []
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, command.UserName),
                new Claim(JwtRegisteredClaimNames.NameId, command.UserName),
                new Claim(JwtRegisteredClaimNames.Email, command.UserName),
                new Claim(JwtRegisteredClaimNames.Sub, command.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, await _tokenOptions.JtiGenerator()),
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_tokenOptions.IssuedAt).ToString(), ClaimValueTypes.Integer64),
                identity.FindFirst("Apptest")
            };

            var jwt = new JwtSecurityToken(
                issuer : _tokenOptions.Issuer,
                audience : _tokenOptions.Audience,
                claims: claims.AsEnumerable(),
                notBefore : _tokenOptions.NotBefore,
                expires : _tokenOptions.Expiration,
                signingCredentials : _tokenOptions.SigningCredentials);

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                token = encodedJwt,
                expires_in = (int)_tokenOptions.ValidFor.TotalSeconds,
                users = new
                {
                    id = _customer.Id,
                    name = _customer.Name.ToString(),
                    email = _customer.Email.Address
                }
            };

            var json = JsonConvert.SerializeObject(response, _serializerSettings);
            return new OkObjectResult(json);
        }

        private static long ToUnixEpochDate(DateTime date)
            =>(long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970,1,1,0,0,0, TimeSpan.Zero))
                    .TotalSeconds);

        private static void ThrowIfInvalidOptions(TokenOptions options)
        {
            if(options == null ) throw new ArgumentNullException(nameof(options));

            if(options.ValidFor <= TimeSpan.Zero)
                throw new ArgumentException("O período deve ser maio que zero",
                                            nameof(TokenOptions.ValidFor));

            if(options.SigningCredentials == null)
                throw new ArgumentNullException(nameof(TokenOptions.SigningCredentials));

            if(options.JtiGenerator == null)
                throw new ArgumentNullException(nameof(TokenOptions.JtiGenerator));
        }

        private Task<ClaimsIdentity> GetClaims(AuthenticateUserCommand command)
        {
            var customer = _repository.Get(command.UserName);

            if(User == null)
                return Task.FromResult<ClaimsIdentity>(null);

            if(!customer.User.Authenticate(command.UserName,command.Password))
                return Task.FromResult<ClaimsIdentity>(null);

            _customer = customer;
            return Task.FromResult(new ClaimsIdentity(
                new GenericIdentity(customer.User.UserName,"Token"),
                new []{
                    new Claim("Apptest","User"),
                    new Claim("Apptest","Admin")
                }
            ));
        }

    }
}