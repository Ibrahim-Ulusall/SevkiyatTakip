﻿namespace Sevkiyat.Takip.Application.Utilities.Security.JWT;
public class AccessToken
{
    public string Token { get; set; } = null!;
    public DateTime Expiration { get; set; }
}
