namespace SqlQuerier.SyntaxProviders;

public interface ISelectSyntaxProvider
{
    string Select();
    string From();
    string Where();
    string GroupBy();
    string Having();
    string OrderBy();
    string And();
    string Or();
    string Delimiter();
}