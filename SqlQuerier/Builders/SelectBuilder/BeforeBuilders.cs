namespace SqlQuerier.Builders.SelectBuilder;

public interface IBeforeOrderByBuilder
    : IFinalBuilder
{
    IAfterOrderByBuilder OrderBy(params string[] columns);
}

public interface IBeforeHavingBuilder
    : IBeforeOrderByBuilder
{
    IAfterHavingBuilder Having(string condition);
}

public interface IBeforeGroupByBuilder
    : IBeforeHavingBuilder
{
    IAfterGroupByBuilder GroupBy(params string[] columns);
}

public interface IBeforeWhereBuilder
    : IBeforeGroupByBuilder
{
    IAfterWhereBuilder Where(string condition);
}

public interface IBeforeJoinBuilder
    : IBeforeWhereBuilder
{
    IAfterJoinBuilder Join(string table);
    IAfterJoinBuilder LeftJoin(string table);
    IAfterJoinBuilder RightJoin(string table);
    IAfterJoinBuilder InnerJoin(string table);
}