using System.Threading.Tasks;

namespace XamarinMvvm
{
    public delegate Task ActionAsync();
    public delegate Task ActionAsync<in T>(T obj);
}
