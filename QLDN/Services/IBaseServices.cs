using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDN.Services
{
    internal interface IBaseServices<T>
    {
        List<T> GetAll();

        T GetOne(int id);

        string Insert(T item);

        string Update(int id,T item);

        string Remove(int id);
    }
}
