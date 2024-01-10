namespace SqlQuerier.Models.Create;

public interface IColumn
{
    string Name { get; }
    ColumnType Type { get; }
}