using System;
using System.Collections.Generic;

namespace Sample_GraphQL.Infrastructure.DBContext;

public partial class UserToken
{
    public int TokenId { get; set; }

    public string TokenKey { get; set; } = null!;

    public string UserKey { get; set; } = null!;

    public string TokenType { get; set; } = null!;

    public string TokenHash { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public DateTime DateUpdated { get; set; }

    public string IsArchived { get; set; } = null!;

    public bool? IsActive { get; set; }
}
