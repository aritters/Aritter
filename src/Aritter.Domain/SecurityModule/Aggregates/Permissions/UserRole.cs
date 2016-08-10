using Aritter.Domain.SecurityModule.Aggregates.Modules;
using Aritter.Domain.SecurityModule.Aggregates.Users;
using Aritter.Domain.Seedwork;
using System.Collections.Generic;
using System.Linq;

namespace Aritter.Domain.SecurityModule.Aggregates.Permissions
{
    public class UserRole : Entity
    {
        public UserRole(Application application, string name)
            : this()
        {
            Application = application;
            ApplicationId = application.Id;

            Name = name;
        }

        public UserRole(Application application, string name, string description)
            : this(application, name)
        {
            Description = description;
        }

        private UserRole()
            : base()
        {
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public int ApplicationId { get; private set; }

        public virtual ICollection<Authorization> Authorizations { get; private set; } = new HashSet<Authorization>();
        public virtual ICollection<UserAssignment> UserAssignments { get; private set; } = new HashSet<UserAssignment>();
        public virtual Application Application { get; private set; }

        public void AddMember(UserAccount user)
        {
            if (UserAssignments.All(p => p != user))
            {
                var userAssignment = new UserAssignment(this, user);
                UserAssignments.Add(userAssignment);
            }
        }
    }
}