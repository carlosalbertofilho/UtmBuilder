namespace UtmBuilder.Core.ValueObjects;

public enum UtmKey
{
    UtmSource,
    UtmMedium,
    UtmCampaign,
    UtmId,
    UtmTerm,
    UtmContent
}

public record struct UtmParameters ( string? Source, string? Medium, string? Name, string? Id, string? Term, string? Content )
{
    public static implicit operator (string? source, string? medium, string? name, string? id, string? term, string? content) ( UtmParameters value )
    {
        return (value.Source, value.Medium, value.Name, value.Id, value.Term, value.Content);
    }

    public static implicit operator UtmParameters ( (string? source, string? medium, string? name, string? id, string? term, string? content) value )
    {
        return new UtmParameters( value.source, value.medium, value.name, value.id, value.term, value.content );
    }
}