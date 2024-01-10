using System.ComponentModel;
using System.Text;
using SqlQuerier.Models.Create;
using SqlQuerier.SyntaxProviders;

namespace SqlQuerier.Builders.CreateBuilder;

public class CreateBuilder
    : IAfterCreateBuilder,
        IFinalTableBuilder
{
    private readonly ICreateSyntaxProvider _syntaxProvider;
    private readonly IList<IColumn> _columns;
    private CreateType _createType;
    private string _name = string.Empty;

    public CreateBuilder(ICreateSyntaxProvider syntaxProvider)
    {
        _syntaxProvider = syntaxProvider;
        _columns = new List<IColumn>();
    }

    public IFinalBuilder Database(string name)
    {
        _name = name;
        _createType = CreateType.DATABASE;
        return this;
    }

    public IAfterTableBuilder Table(string name)
    {
        _name = name;
        _createType = CreateType.TABLE;
        return this;
    }

    public IFinalTableBuilder Int(string name)
    {
        _columns.Add(new Column(name, ColumnType.INT));
        return this;
    }

    public IFinalTableBuilder Int(string name, int size)
    {
        _columns.Add(new ParameterColumn(name, ColumnType.INT, size));
        return this;
    }

    public IFinalTableBuilder BigInt(string name)
    {
        _columns.Add(new Column(name, ColumnType.BIGINT));
        return this;
    }

    public IFinalTableBuilder BigInt(string name, int size)
    {
        _columns.Add(new ParameterColumn(name, ColumnType.BIGINT, size));
        return this;
    }

    public IFinalTableBuilder Decimal(string name)
    {
        _columns.Add(new Column(name, ColumnType.DECIMAL));
        return this;
    }

    public IFinalTableBuilder Varchar(string name, int size)
    {
        _columns.Add(new ParameterColumn(name, ColumnType.VARCHAR, size));
        return this;
    }

    public IFinalTableBuilder Text(string name, int size)
    {
        _columns.Add(new ParameterColumn(name, ColumnType.TEXT, size));
        return this;
    }

    public IFinalTableBuilder Date(string name)
    {
        _columns.Add(new Column(name, ColumnType.DATE));
        return this;
    }

    public string Build()
    {
        var builder = new StringBuilder();
        builder.Append(_syntaxProvider.Create());

        switch (_createType)
        {
            case CreateType.DATABASE:
                builder.Append(_syntaxProvider.Database(_name));
                break;
            case CreateType.TABLE:
                builder.Append(_syntaxProvider.Table(_name, _columns));
                break;
            default:
                throw new InvalidEnumArgumentException(nameof(_createType));
        }

        return builder.ToString();
    }
}