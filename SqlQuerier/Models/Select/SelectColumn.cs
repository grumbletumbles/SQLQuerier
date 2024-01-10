namespace SqlQuerier.Models.Select;

public class SelectColumn
{
    public SelectColumn(string name)
    {
        Name = name;
        Alias = string.Empty;
    }

    public string Name { get; } 
    public string Alias { get; set; }

    public override string ToString()
    {
        return 
            Alias == string.Empty ? 
            Name : $"{Name} AS {Alias}";
    }
}