using System.Data;

namespace QLDN.Models.BaseModels
{
    public interface IObjectIO<T> where T : class
    {
        DataTable GetAll();

        T GetOne(int id);

        string Insert(T obj);

        string Update(T obj);

        string Delete(T obj);
    }
}