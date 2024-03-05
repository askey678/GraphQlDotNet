using System;
using System.Collections.Generic;

namespace Sample_GraphQL.Infrastructure.DBContext;

public partial class Role
{
    public int RoleId { get; set; }

    public string RoleKey { get; set; } = null!;

    public string RoleName { get; set; } = null!;

    public bool IsArchived { get; set; }

    public bool? IsActive { get; set; }

    public DateTime DateUpdated { get; set; }

    public DateTime DateCreated { get; set; }
}
