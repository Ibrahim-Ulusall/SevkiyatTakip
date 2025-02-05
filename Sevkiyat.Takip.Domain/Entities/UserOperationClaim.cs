﻿using Sevkiyat.Takip.Core.Entities;

namespace Sevkiyat.Takip.Domain.Entities;
public class UserOperationClaim : BaseEntity<Guid>
{
    public Guid UserId { get; set; }
    public Guid OperationClaimId { get; set; }
    public User? User { get; set; }
    public OperationClaim? OperationClaim { get; set; }
}