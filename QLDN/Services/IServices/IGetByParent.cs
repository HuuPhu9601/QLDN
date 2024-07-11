using System.Collections.Generic;

namespace QLDN.Services
{
    //Nguyên tắc 2: Đóng mở và 4: Phân tách interface
    public interface IGetByParent<T> where T : class
    {
        List<T> GetByParent(int id);
    }
}