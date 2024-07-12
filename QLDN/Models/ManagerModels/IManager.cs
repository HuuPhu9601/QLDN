using QLDN.Models.BaseModels;

namespace QLDN.Models.ManagerModels
{
    public interface IManager : IObjectIO<Manager>
    {
        void AssignMultiStaffToAManager(); //Thêm nhiều nhân viên cho một quản lý

        Manager GetManagerOfOrgUnit(); //Lấy thông tin quản lý của đơn vị

        Manager GetManagerOfStaff(); //Lấy ra thông tin quản lý của một nhân viên

        bool CheckExistedManager(); //kiểm tra manager đã tồn tại chưa?
    }
}