using Microsoft.VisualBasic;
using SqlQuerier.Models;
using SqlQuerier.SyntaxProviders;

namespace SqlQuerier.DefaultProviders;

public class DefaultCreateSyntaxProvider : ICreateSyntaxProvider
{
    private readonly string _delimiter;

    public DefaultCreateSyntaxProvider(string delimiter)
    {
        _delimiter = delimiter;
    }
    public string Create()
    {
        return "CREATE ";
    }

    public string Database(string name)
    {
        return $"DATABASE {name};";
    }

    public string Table(string name, IList<IColumn> columns)
    {
        var parameters = String.Join("," + _delimiter, columns.Select(x => x.ToString()).ToList());
        return $"TABLE {name} (" + _delimiter + parameters + _delimiter + ");";
    }
}