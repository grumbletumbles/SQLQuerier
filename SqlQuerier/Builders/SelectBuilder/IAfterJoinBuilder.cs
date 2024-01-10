namespace SqlQuerier.Builders.SelectBuilder;

public interface IAfterJoinBuilder
    : IBeforeWhereBuilder
{
    IAfterFromBuilder On(string condition);
}