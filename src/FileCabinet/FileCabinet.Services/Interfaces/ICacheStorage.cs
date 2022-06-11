namespace FileCabinet.Service.Interfaces
{
    public interface ICacheStorage<T>
    {
        T GetItem(int key);

        void AddItem(int key, T value);
    }
}
