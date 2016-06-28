﻿using Aritter.Domain.SecurityModule.Aggregates.UserAgg;
using Aritter.Domain.Seedwork;

namespace Aritter.Domain.SecurityModule.Aggregates.PermissionAgg
{
    public class UserRole : Entity
	{
		public int UserId { get; set; }
		public int RoleId { get; set; }
		public virtual User User { get; set; }
		public virtual Role Role { get; set; }
	}
}
