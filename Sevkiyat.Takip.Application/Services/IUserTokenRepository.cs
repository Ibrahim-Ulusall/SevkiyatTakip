﻿using Sevkiyat.Takip.Core.Repositories.Interfaces;
using Sevkiyat.Takip.Domain.Entities;

namespace Sevkiyat.Takip.Application.Services;

public interface IUserTokenRepository : IAsyncRepository<int,UserToken>, IRepository<int, UserToken>
{

}
