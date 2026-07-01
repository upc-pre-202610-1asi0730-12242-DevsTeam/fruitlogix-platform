using DevelopersTeam.Fruitlogix.Platform.Shared.Domain.Model.Entities;

namespace DevelopersTeam.Fruitlogix.Platform.Iam.Domain.Model.Aggregates;

public partial class User : IAuditableEntity
{
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}