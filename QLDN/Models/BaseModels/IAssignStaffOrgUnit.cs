namespace QLDN.Models.BaseModels
{
    //Thực hiện nguyên tắc số 1: "Nguyên tắc trách nhiệm đơn lẻ" cho model đơn vị
    public interface IAssignStaffOrgUnit
    {
        void AssignStaffToAOrgUnit(); //Thêm nhân viên vào một đơn vị

        void AssignStaffToMultiOrgUnit(); //Thêm nhân viên/ quản lý vào nhiều đơn vị

        void AssignMultiStaffToAOrgUnit(); //Thêm nhiều nhân viên/ quản lý vào một đơn vị

        void MoveStaffToAOtherOrgUnit(); //Chuyển nhân viên/quản lý từ đơn vị này sang đơn vị khác

        void MoveStafftoOtherJobPosition(); //Điều chuyển nhân viên/quản lý sang vị trí khác
    }
}