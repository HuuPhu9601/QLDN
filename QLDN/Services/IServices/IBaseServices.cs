using System.Collections.Generic;

namespace QLDN.Services
{
    //Nguyên tắc 2: Đóng mở
    public interface IBaseServices<T>
    {
        List<T> GetAll();

        T GetOne(int id);

        string Insert(T item);

        string Update(int id, T item);

        string Remove(int id);
    }
}
