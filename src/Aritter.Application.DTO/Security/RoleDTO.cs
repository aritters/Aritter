using System.Collections.Generic;

namespace Aritter.Application.DTO.Security
{
	public class RoleDTO : DTO
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public virtual ICollection<UserDTO> Users { get; set; }
		public virtual ICollection<AuthorizationDTO> Authorizations { get; set; }
	}
}
