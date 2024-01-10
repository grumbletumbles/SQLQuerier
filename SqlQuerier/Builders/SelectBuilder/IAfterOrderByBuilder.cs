namespace SqlQuerier.Builders.SelectBuilder;

public interface IAfterOrderByBuilder
    : IFinalBuilder
{
    IFinalBuilder Ascending();
    IFinalBuilder Descending();
}