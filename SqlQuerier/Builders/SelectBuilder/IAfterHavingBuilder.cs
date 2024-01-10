namespace SqlQuerier.Builders.SelectBuilder;

public interface IAfterHavingBuilder
    : IBeforeOrderByBuilder
{
    IAfterHavingBuilder And(string condition);
    IAfterHavingBuilder Or(string condition);
}