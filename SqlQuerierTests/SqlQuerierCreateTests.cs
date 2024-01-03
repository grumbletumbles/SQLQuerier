using Xunit;
using SqlQuerier;
using SqlQuerier.DefaultProviders;

namespace SqlQuerierTests;

public class SqlQuerierCreateTests
{
    [Fact]
    public void SqlQuerier_CreateDatabase_Test()
    {
        var querier = new SqlQuerier.SqlQuerier();
        var result = querier.Create().Database("test_database").Build();
        Assert.Equal("CREATE DATABASE test_database;", result);
    }

    [Fact]
    public void SqlQuerier_CreateTable_SingleColumnTest()
    {
        var querier = new SqlQuerier.SqlQuerier();
        var result = querier.Create().Table("test_table").Int("column").Build();
        Assert.Equal("CREATE TABLE test_table ( column INT );", result);
    }
    
    [Fact]
    public void SqlQueirer_CreateTable_MultipleColumnTest()
    {
        var querier = new SqlQuerier.SqlQuerier();
        var result = querier.Create().Table("test_table").Date("date").Decimal("decimal").Build();
        Assert.Equal("CREATE TABLE test_table ( date DATE, decimal DECIMAL );", result);
    }

    [Fact]
    public void SqlQueirer_CreateTable_ParameterColumnTest()
    {
        var querier = new SqlQuerier.SqlQuerier();
        var result = querier.Create().Table("test_table").BigInt("bigint", 1).Varchar("varchar", 239).Build();
        Assert.Equal("CREATE TABLE test_table ( bigint BIGINT(1), varchar VARCHAR(239) );", result);
    }
}