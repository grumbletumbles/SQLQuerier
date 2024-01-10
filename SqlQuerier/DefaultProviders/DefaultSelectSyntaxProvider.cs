using SqlQuerier.SyntaxProviders;

namespace SqlQuerier.DefaultProviders;

public class DefaultSelectSyntaxProvider : ISelectSyntaxProvider
{
    private readonly string _delimiter;

    public DefaultSelectSyntaxProvider(string delimiter)
    {
        _delimiter = delimiter;
    }

    public string Select() => "SELECT ";

    public string From() => "FROM ";

    public string Where() => "WHERE ";

    public string GroupBy() => "GROUP BY ";

    public string Having() => "HAVING ";

    public string OrderBy() => "ORDER BY ";

    public string And() => " AND ";


    public string Or() => " OR ";


    public string Delimiter() => _delimiter;
}