namespace SqlQuerier.Builders.CreateBuilder;

public interface IAfterTableBuilder
{
    IFinalTableBuilder Int(string name);
    IFinalTableBuilder Int(string name, int size);
    IFinalTableBuilder BigInt(string name);
    IFinalTableBuilder BigInt(string name, int size);
    IFinalTableBuilder Decimal(string name);
    IFinalTableBuilder Varchar(string name, int size);
    IFinalTableBuilder Text(string name, int size);
    IFinalTableBuilder Date(string name);
}