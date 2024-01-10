namespace SqlQuerier.Models.Select;

public class JoinClause
{
    public JoinClause(JoinType type, string table)
    {
        Type = type;
        Table = table;
        Condition = string.Empty;
    }

    public JoinType Type { get; }
    public string Table { get; }
    public string Condition { get; set; }

    public override string ToString()
    {
        return Type == JoinType.None ? 
            $"JOIN {Table} ON {Condition}" 
            : $"{Type} JOIN {Table} ON {Condition}";
    }
}