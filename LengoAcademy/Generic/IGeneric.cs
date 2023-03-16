using System.Collections.Generic;
using System.Threading.Tasks;

namespace LengoAcademy.Generic
{
    public interface IGeneric<T>
    {
        int Insert(T obj);
        void Update(T Obj);
        void Delete(int Id);
        T Load(int Id);
        List<T> LoadAll();
    }
}
