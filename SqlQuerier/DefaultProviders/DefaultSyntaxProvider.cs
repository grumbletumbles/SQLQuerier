using SqlQuerier.SyntaxProviders;

namespace SqlQuerier.DefaultProviders;

public class DefaultSyntaxProvider : ISyntaxProvider
{
    private readonly string _delimiter;

    public DefaultSyntaxProvider()
    {
        _delimiter = " ";
    }

    public DefaultSyntaxProvider(string delimiter)
    {
        _delimiter = delimiter;
    }

    public ICreateSyntaxProvider CreateSyntaxProvider => new DefaultCreateSyntaxProvider(_delimiter);
    public ISelectSyntaxProvider SelectSyntaxProvider => new DefaultSelectSyntaxProvider(_delimiter);
}