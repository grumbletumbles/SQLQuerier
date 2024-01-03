namespace SqlQuerier.Models;

public record Column(string Name, ColumnType Type) : IColumn
{
    public override string ToString()
    {
        return $"{Name} {Type}";
    }
}