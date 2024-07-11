using QLDN.Models;

namespace QLDN.Services
{
    //Nguyên tắc 2: Đóng mở và nguyên tắc 4: Phân tách interface
    public interface IOrgUnitService : IBaseServices<OrgUnit>, IGetByParent<OrgUnit>
    {

    }
}