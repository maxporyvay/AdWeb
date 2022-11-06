﻿using AdWeb.AppServices.User.Repositories;
using AdWeb.Contracts.User;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AdWeb.AppServices.User.Services
{
    /// <inheritdoc />
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IClaimsAccessor _claimsAccessor;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <inheritdoc />
        public async Task<Domain.User> GetCurrent(CancellationToken cancellation)
        {
            var claims = await _claimsAccessor.GetClaims(cancellation);

            var id = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }

            //var user = await 

            return null; 
        }

        /// <inheritdoc />
        public async Task<string> Login(string login, string password, CancellationToken cancellation)
        {
            var existingUser = await _userRepository.FindWhere(user => user.Login == login, cancellation);
            if (existingUser == null)
            {
                throw new Exception("Пользователь не найден");
            }

            if (!existingUser.Password.Equals(password))
            {
                throw new Exception("Нет прав.");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, existingUser.Id.ToString()),
                new Claim(ClaimTypes.Name, existingUser.Login)
            };

            var secretKey = "breadbreadbreadbreadbreadbreadbreadbreadbread"; //TODO

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(1),
                    notBefore: DateTime.UtcNow,
                    signingCredentials: new SigningCredentials(
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                            SecurityAlgorithms.HmacSha256
                        )
                );

            var result = new JwtSecurityTokenHandler().WriteToken(token);

            return result;
        }

        /// <inheritdoc />
        public async Task<Guid> Register(string login, string password, CancellationToken cancellation)
        {
            var user = new Domain.User
            {
                Login = login,
                Name = login,
                Password = password,
                CreationTime = DateTime.UtcNow
            };

            var existingUser = await _userRepository.FindWhere(user => user.Login == login, cancellation);
            if (existingUser != null)
            {
                throw new Exception($"Пользователь с логином {login} уже зарегистрирован!");
            }

            await _userRepository.AddAsync(user);

            return user.Id;
        }
    }
}
