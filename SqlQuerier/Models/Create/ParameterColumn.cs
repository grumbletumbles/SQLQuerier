namespace SqlQuerier.Models.Create;

public record ParameterColumn(string Name, ColumnType Type, int Size) : IColumn
{
    public override string ToString()
    {
        return $"{Name} {Type}({Size})";
    }
}