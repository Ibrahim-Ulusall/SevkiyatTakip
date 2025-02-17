﻿using Sevkiyat.Takip.Application.Models.Auths;
using Sevkiyat.Takip.Application.Services;
using Sevkiyat.Takip.Application.Utilities.Security.Hashing;
using Sevkiyat.Takip.Application.Utilities.Security.JWT;
using Sevkiyat.Takip.Application.Validators.Auths;
using Sevkiyat.Takip.Core.Aspects.Security;
using Sevkiyat.Takip.Core.Aspects.Validation;
using Sevkiyat.Takip.Core.Models.Auths;
using Sevkiyat.Takip.Core.Utilities.Helpers;
using Sevkiyat.Takip.Core.Utilities.Results;
using Sevkiyat.Takip.Domain.Entities;

namespace Sevkiyat.Takip.Persistance.Services;
public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenHelper _tokenHelper;
    private readonly Helper _helper;
    public AuthService(IUserRepository userRepository, ITokenHelper tokenHelper, Helper helper)
    {
        _userRepository = userRepository;
        _tokenHelper = tokenHelper;
        _helper = helper;
    }

    [ValidationAspect(typeof(LoginValidator), Priority = 2)]
    public async Task<LoginResultModel> Login(LoginModel login)
    {
        LoginResultModel result = new();
        User? user = await _userRepository.GetAsync(i => i.Email == login.Email);

        if (user == null)
        {
            result.Success = false;
            result.Message = "User not found.";
            return result;
        }


        bool passwordVerified = HashingHelper.VerifyPassword(login.Password, user.PasswordHash, user.PasswordSalt);

        if (passwordVerified)
        {
            var claims = await _userRepository.GetUserClaims(user.Id);
            result.Success = true;
            result.Message = "Login Successed";
            result.UserId = user.Id;
            result.AccessToken = _tokenHelper.CreateToken(user, claims);
            return result;
        }

        result.Success = false;
        result.Message = "Password Incorrect";
        return result;
    }

    [SecurityAspect("admin", Priority = 1)]
    [ValidationAspect(typeof(RegisterValidator))]
    public async Task<IResult> Register(RegisterModel register)
    {
        bool userExists = await _userRepository.AnyAsync(i => i.Email.ToLower() == register.Email.ToLower());
        if (userExists)
            return new ErrorResult(message: "User already exists");


        string? photo = null;

        if (register.Photo != null)
        {
            var result = await _helper.UploadImage(register.Photo);
            if (!result.Success)
                return result;
            photo = result.Data;
        }


        HashingHelper.CreatePasswordHash(register.Password, out byte[] passwordHash, out byte[] passwordSalt);

        User user = new()
        {
            FirstName = register.FirstName,
            LastName = register.LastName,
            Email = register.Email,
            Status = true,
            Photo = photo,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        };

        await _userRepository.AddAsync(user);

        return new SuccessResult(message: "User created");

    }
}
