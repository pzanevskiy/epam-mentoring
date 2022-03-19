namespace FileSystemVisitor.Lib.Interfaces
{
    public interface IEventSubscriber<T> where T : class
    {
        void Subscribe(T publisher);

        void Unubscribe(T publisher);
    }
}
