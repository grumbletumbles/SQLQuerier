namespace SqlQuerier.Models;

public interface IColumn
{
    string Name { get; }
    ColumnType Type { get; }
}