namespace Mobile_Project_Api.Data.Framework
{
    internal interface ISqlCommands<T>
    {
        SelectResult Select();
        InsertResult Insert(T t);
    }
}
