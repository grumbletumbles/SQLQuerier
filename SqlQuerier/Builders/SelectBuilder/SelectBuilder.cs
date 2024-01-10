using System.Text;
using SqlQuerier.Models;
using SqlQuerier.Models.Select;
using SqlQuerier.SyntaxProviders;

namespace SqlQuerier.Builders.SelectBuilder;

public class SelectBuilder
    : IAfterSelectBuilder,
        IAfterSelectAliasableBuilder,
        IAfterFromBuilder,
        IAfterJoinBuilder,
        IAfterWhereBuilder,
        IAfterGroupByBuilder,
        IAfterHavingBuilder,
        IAfterOrderByBuilder
{
    private readonly ISelectSyntaxProvider _syntaxProvider;
    private SelectType _selectType;
    private readonly IList<SelectColumn> _columns;
    private string _fromTable;
    private readonly IList<JoinClause> _joins;
    private readonly StringBuilder _whereConditions;
    private readonly StringBuilder _groupbyColumns;
    private readonly StringBuilder _havingConditions;
    private readonly StringBuilder _orderbyColumns;
    private OrderType _orderType;

    public SelectBuilder(ISelectSyntaxProvider syntaxProvider)
    {
        _syntaxProvider = syntaxProvider;
        _selectType = SelectType.None;
        _columns = new List<SelectColumn>();
        _fromTable = string.Empty;
        _joins = new List<JoinClause>();
        _whereConditions = new StringBuilder();
        _groupbyColumns = new StringBuilder();
        _havingConditions = new StringBuilder();
        _orderbyColumns = new StringBuilder();
        _orderType = OrderType.None;
    }

    public IAfterSelectBuilder Distinct()
    {
        _selectType = SelectType.DISTINCT;
        return this;
    }

    public IAfterSelectAliasableBuilder Column(string column)
    {
        _columns.Add(new SelectColumn(column));
        return this;
    }

    public IAfterSelectBuilder As(string alias)
    {
        _columns.Last().Alias = alias;
        return this;
    }

    public IAfterFromBuilder From(string table)
    {
        _fromTable = table;
        return this;
    }

    public IAfterJoinBuilder Join(string table)
    {
        _joins.Add(new JoinClause(JoinType.None, table));
        return this;
    }

    public IAfterJoinBuilder LeftJoin(string table)
    {
        _joins.Add(new JoinClause(JoinType.LEFT, table));
        return this;
    }

    public IAfterJoinBuilder RightJoin(string table)
    {
        _joins.Add(new JoinClause(JoinType.RIGHT, table));
        return this;
    }

    public IAfterJoinBuilder InnerJoin(string table)
    {
        _joins.Add(new JoinClause(JoinType.INNER, table));
        return this;
    }

    public IAfterFromBuilder On(string condition)
    {
        _joins.Last().Condition = condition;
        return this;
    }

    public IAfterWhereBuilder Where(string condition)
    {
        _whereConditions.Append(condition);
        return this;
    }

    public IAfterWhereBuilder And(string condition)
    {
        _whereConditions.Append(_syntaxProvider.And() + condition);
        return this;
    }


    public IAfterWhereBuilder Or(string condition)
    {
        _whereConditions.Append(_syntaxProvider.Or() + condition);
        return this;
    }

    public IAfterGroupByBuilder GroupBy(params string[] columns)
    {
        _groupbyColumns.Append(string.Join(", ", columns));
        return this;
    }

    public IAfterHavingBuilder Having(string condition)
    {
        _havingConditions.Append(condition);
        return this;
    }

    IAfterHavingBuilder IAfterHavingBuilder.And(string condition)
    {
        _havingConditions.Append(_syntaxProvider.And() + condition);
        return this;
    }

    IAfterHavingBuilder IAfterHavingBuilder.Or(string condition)
    {
        _havingConditions.Append(_syntaxProvider.Or() + condition);
        return this;
    }

    public IAfterOrderByBuilder OrderBy(params string[] columns)
    {
        _orderbyColumns.Append(string.Join(", ", columns));
        return this;
    }

    public IFinalBuilder Ascending()
    {
        _orderType = OrderType.ASC;
        return this;
    }

    public IFinalBuilder Descending()
    {
        _orderType = OrderType.DESC;
        return this;
    }

    public string Build()
    {
        var result = new StringBuilder();
        var cols = string.Join(", ", _columns.Select(x => x.ToString()).ToList());
        result.Append(_syntaxProvider.Select())
            .Append(cols);
        result.Append(_syntaxProvider.Delimiter())
            .Append(_syntaxProvider.From())
            .Append(_fromTable);
        if (_joins.Count != 0)
        {
            var joins = string.Join(_syntaxProvider.Delimiter(), _joins.Select(x => x.ToString()).ToList());
            result.Append(_syntaxProvider.Delimiter())
                .Append(joins);
        }

        var where = _whereConditions.ToString();
        if (where is not "")
        {
            result.Append(_syntaxProvider.Delimiter())
                .Append(_syntaxProvider.Where())
                .Append(where);
        }

        var groupby = _groupbyColumns.ToString();
        if (groupby is not "")
        {
            result.Append(_syntaxProvider.Delimiter())
                .Append(_syntaxProvider.GroupBy())
                .Append(groupby);
        }
        
        var having = _havingConditions.ToString();
        if (having is not "")
        {
            result.Append(_syntaxProvider.Delimiter())
                .Append(_syntaxProvider.Having())
                .Append(having);
        }
        
        var orderby = _orderbyColumns.ToString();
        if (orderby is not "")
        {
            result.Append(_syntaxProvider.Delimiter())
                .Append(_syntaxProvider.OrderBy())
                .Append(_orderType is OrderType.None ? string.Empty : _orderType);
        }

        result.Append(";");
        return result.ToString();
    }
}