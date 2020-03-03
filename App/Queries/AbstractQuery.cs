namespace App.Queries
{
    public abstract class AbstractQuery : IQuery
    {
        public abstract string Name { get; }
        public abstract string Query { get; }
    }
}