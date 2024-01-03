namespace SqlQuerier.Builders.CreateBuilder;

public interface IAfterCreateBuilder
{
    IFinalBuilder Database(string name);
    IAfterTableBuilder Table(string name);
}