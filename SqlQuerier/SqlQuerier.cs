using SqlQuerier.Builders.CreateBuilder;
using SqlQuerier.DefaultProviders;
using SqlQuerier.SyntaxProviders;

namespace SqlQuerier;

public class SqlQuerier
{
    private readonly ISyntaxProvider _syntaxProvider;

    public SqlQuerier()
    {
        _syntaxProvider = new DefaultSyntaxProvider();
    }
    
    public SqlQuerier(ISyntaxProvider syntaxProvider)
    {
        _syntaxProvider = syntaxProvider;
    }

    public IAfterCreateBuilder Create()
    {
        return new CreateBuilder(_syntaxProvider.CreateSyntaxProvider);
    }
}