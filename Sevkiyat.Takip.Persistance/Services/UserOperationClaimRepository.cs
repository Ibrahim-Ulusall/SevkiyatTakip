﻿using Sevkiyat.Takip.Application.Services;
using Sevkiyat.Takip.Core.Repositories;
using Sevkiyat.Takip.Domain.Entities;
using Sevkiyat.Takip.Persistance.Contexts;

namespace Sevkiyat.Takip.Persistance.Services;

public class UserOperationClaimRepository : EfRepositoryBase<Guid, UserOperationClaim, SevkiyatContext>
    , IUserOperationClaimRepository
{
    public UserOperationClaimRepository(SevkiyatContext context) : base(context)
    {
    }
}
