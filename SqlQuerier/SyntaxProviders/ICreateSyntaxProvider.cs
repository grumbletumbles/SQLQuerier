using SqlQuerier.Models.Create;

namespace SqlQuerier.SyntaxProviders;

public interface ICreateSyntaxProvider
{
    string Create();
    string Database(string name);
    string Table(string name, IList<IColumn> columns);
}