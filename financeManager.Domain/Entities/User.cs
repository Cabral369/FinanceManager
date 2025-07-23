namespace financeManager.Domain.Entities;

public class User : BaseEntity, IAutoGenerate
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public int MyProperty { get; set; }
}