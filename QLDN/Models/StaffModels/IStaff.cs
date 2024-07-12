using QLDN.Models.BaseModels;
using System.Collections.Generic;

namespace QLDN.Models.StaffModels
{
    public interface IStaff : IObjectIO<Staff>
    {
        void AssignStaffToAManager(); //Thêm một nhân viên cho một quản lý

        List<Staff> GetOtherStaffOfStaff(); //Lấy thông tin các đồng nghiệp của nhân viên đó

        List<Staff> GetStaffOfOrgUnit(); //Lấy danh sách nhân viên của đơn vị

        List<Staff> GetStaffsOfManager();  //Lấy ra thông tin các nhân viên của quản lý

        bool CheckExistedStaffInAOrgUnit(); //Kiểm tra nhân viên đã tồn tại trong đơn vị chưa?

        bool HasManagerOfStaff(); //Kiểm tra nhân viên đã có quản lý chưa?
    }
}