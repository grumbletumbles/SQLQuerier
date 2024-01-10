namespace SqlQuerier.Builders.SelectBuilder;

public interface IAfterSelectBuilder
{
    IAfterSelectBuilder Distinct();
    IAfterSelectAliasableBuilder Column(string column);
    IAfterFromBuilder From(string table);
}

public interface IAfterSelectAliasableBuilder
    : IAfterSelectBuilder
{
    IAfterSelectBuilder As(string alias);
}