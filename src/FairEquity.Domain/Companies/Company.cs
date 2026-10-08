namespace FairEquity.Domain.Companies;

public sealed class Company
{
    public const int NameMaxLength = 200;

    public Guid Id { get; private set; }
    public string Name { get; private set; } = null!;
    public DateTimeOffset CreatedAt { get; private set; }

    private Company() { }

    public static Company Create(string name, DateTimeOffset createdAt) => new()
    {
        Id = Guid.CreateVersion7(createdAt),
        Name = name.Trim(),
        CreatedAt = createdAt,
    };
}
