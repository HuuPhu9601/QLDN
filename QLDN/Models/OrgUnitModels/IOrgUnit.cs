using QLDN.Models.BaseModels;
using System.Collections.Generic;

namespace QLDN.Models.OrgUnitModels
{
    public interface IOrgUnit : IObjectIO<OrgUnit>
    {
        bool CheckOnlyManagerOfOrg(); //Chỉ cho phép org chỉ có 1 manager duy nhất

        bool CheckOnlyParentOrg(); //Kiểm tra một đơn vị chỉ có một đơn vị cha

        bool CheckExistedOrg(); //Kiểm tra đơn vị đã tồn tại hay chưa?

        List<OrgUnit> GetOrgUnitsOfStaff(); //Lấy ra thông tin các danh sách đơn vị của nhân viên

        void AddMultiChildrenOrgToAOrgUnit(); //Thêm nhiều đơn vị con vào một đơn vị

        void AddParentOrgToAOrgUnit(); //Thêm một đơn vị cha vào một đơn vị

    }
}