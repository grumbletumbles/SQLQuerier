using Xunit;

namespace SqlQuerierTests;

public class SqlQuerierSelectTests
{
    [Fact]
    public void SqlQuerier_Select_OneTable()
    {
        var querier = new SqlQuerier.SqlQuerier();
        var result = querier.Select()
            .Column("col1")
            .From("table")
            .Build();
        Assert.Equal("SELECT col1 FROM table;", result);
    }

    [Fact]
    public void SqlQuerier_Select_Alias()
    {
        var querier = new SqlQuerier.SqlQuerier();
        var result = querier.Select()
            .Column("col1").As("not col1")
            .From("table")
            .Build();
        Assert.Equal("SELECT col1 AS not col1 FROM table;", result);
    }

    [Fact]
    public void SqlQuerier_Select_MultipleColumns()
    {
        var querier = new SqlQuerier.SqlQuerier();
        var result = querier.Select()
            .Column("col1")
            .Column("col2")
            .Column("col3")
            .From("table")
            .Build();
        Assert.Equal("SELECT col1, col2, col3 FROM table;", result);
    }

    [Fact]
    public void SqlQuereier_Select_Join()
    {
        var querier = new SqlQuerier.SqlQuerier();
        var result = querier.Select()
            .Column("col1")
            .From("table1")
            .Join("table2").On("table1.col1 = table2.col1")
            .Build();
        Assert.Equal("SELECT col1 FROM table1 "
            + "JOIN table2 ON table1.col1 = table2.col1;", result);
    }
}