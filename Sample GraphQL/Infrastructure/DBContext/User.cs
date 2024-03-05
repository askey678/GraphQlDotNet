using System;
using System.Collections.Generic;

namespace Sample_GraphQL.Infrastructure.DBContext;

public partial class User
{
    public int UserId { get; set; }

    public string UserKey { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? About { get; set; }

    public bool IsArchived { get; set; }

    public bool? IsActive { get; set; }

    public DateTime DateUpdated { get; set; }

    public DateTime DateCreated { get; set; }
}
