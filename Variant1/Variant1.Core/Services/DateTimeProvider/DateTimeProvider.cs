namespace Variant1.Core.Services.DateTimeProvider;

public class DateTimeProvider : IDateTimeProvider
{
    /// <inheritdoc />
    public DateTime CurrentDate => DateTime.UtcNow;
}