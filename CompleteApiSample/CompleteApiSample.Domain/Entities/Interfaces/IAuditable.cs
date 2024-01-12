namespace CompleteApiSample.Domain.Entities.Interfaces
{
    public interface IAuditable
    {
        string UserName { get; set; }

        DateTime UpdatedAt { get; set; }
    }
}
