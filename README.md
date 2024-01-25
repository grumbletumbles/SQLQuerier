# SQLQuerier
An easy way to construct sql queries. Makes sure your queries are correct(except for the content) by restricting operation order.

## Usage
```cs
var querier = new SqlQuerier();
var query = querier.Select()
                   .Column("col1")
                   .From("table")
                   .Build();
```
Result:
```sql
SELECT col1 FROM table;
```

You can also do aliases:
```cs
var query = new SqlQueirer().Select()
                            .Column("col1")
                            .As("alias")
                            .From("table")
                            .Build();
```

Result:
```sql
SELECT col1 AS alias FROM table;
```

Example of a complex query:
```cs
var query = new SqlQeurier().Select()
                            .Column("col1")
                            .Column("col2)
                            .From("table1")
                            .Join("table2").On("table1.col1 = table2.col2")
                            .RightJoin("table3").On("table1.col2 = table3.col2")
                            .GroupBy("col1")
                            .OrderBy("col1");
```

Result:
```sql
SELECT col1, col2 FROM table1 JOIN table2 ON table1.col1 = table2.col2 RIGHT JOIN table3 ON table1.col2 = table3.col2 GROUP BY col1 ORDER BY col1;
```
