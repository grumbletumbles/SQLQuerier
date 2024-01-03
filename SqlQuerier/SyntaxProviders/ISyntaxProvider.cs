namespace SqlQuerier.SyntaxProviders;

public interface ISyntaxProvider
{
    ICreateSyntaxProvider CreateSyntaxProvider { get; }
}