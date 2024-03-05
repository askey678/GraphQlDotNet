using System;
using System.Collections.Generic;

namespace Sample_GraphQL.Infrastructure.DBContext;

public partial class UserRole
{
    public int UserRoleId { get; set; }

    public string UserRoleKey { get; set; } = null!;

    public string UserKey { get; set; } = null!;

    public string RoleKey { get; set; } = null!;

    public bool IsArchived { get; set; }

    public bool? IsActive { get; set; }

    public DateTime DateUpdated { get; set; }

    public DateTime DateCreated { get; set; }
}
