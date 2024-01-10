namespace SqlQuerier.Builders.SelectBuilder;

public interface IAfterWhereBuilder
    : IBeforeGroupByBuilder
{
    IAfterWhereBuilder And(string condition);
    IAfterWhereBuilder Or(string condition);
}