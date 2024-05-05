namespace UtmBuilder.Core.Extensions;

public static class ListExtensions
{
    /// <summary>
    /// Add to list if not null or empty
    /// param name="list">List of strings</param>
    /// param name="item">Item to add</param>
    public static void AddIfNotNullOrEmpty (
          this List<string> list,
          string? item)
    {
        if ( !string.IsNullOrEmpty( item ) )
            list.Add( item );
    }
}
