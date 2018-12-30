namespace Websites.Services.System.Interfaces
{
    public interface ICachingService<T> where T : class
    {
        void Create(T item, string key, int? days, int? minutes, int? seconds);

        T Get(string key);
    }
}