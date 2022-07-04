﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieLibrary.DtoModels;
using MovieLibrary.Entities;

namespace MovieLibrary.Services
{
    public interface IAccountService
    {
        void RegisterUser(RegisterUserDto dto);
        string LoginUser(LoginUserDto loginDto);
    }

    public class AccountService : IAccountService
    {
        private readonly MovieDbContext dbContext;
        private readonly IPasswordHasher<User> passwordHasher;
        private readonly AuthenticationSettings authSettings;

        public AccountService(MovieDbContext dbContext, IPasswordHasher<User> passwordHasher, AuthenticationSettings authSettings)
        {
            this.dbContext = dbContext;
            this.passwordHasher = passwordHasher;
            this.authSettings = authSettings;
        }

        public void RegisterUser(RegisterUserDto dto)
        {
            var newUser = new User()
            {
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                DateOfBirth = dto.DateOfBirth,
                RoleId = dto.RoleId,
            };

            var hashedPassword = passwordHasher.HashPassword(newUser, dto.Password);
            newUser.PasswordHash = hashedPassword;

            dbContext.Users.Add(newUser);
            dbContext.SaveChanges();
        }

        public string LoginUser(LoginUserDto loginDto)
        {
            var user = dbContext.Users
                .Include(x => x.Role)
                .FirstOrDefault(x => x.Email == loginDto.Email);

            if(user is null)
                return null;

            var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginDto.Password);
            if(result == PasswordVerificationResult.Failed)
            {
                return null;
            }

            //Dodawanie claimów

        }
    }
}