using System.Collections.Generic;

namespace QLDN.Services
{
    public interface IGetByParent<T> where T : class
    {
        List<T> GetByParent(int id);
    }
}