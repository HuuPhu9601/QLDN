namespace QLDN.Models.BaseModels
{
    public interface IAssignStaffOrgUnit
    {
        void AssignStaffToAOrgUnit(); //Thêm nhân viên vào một đơn vị

        void AssignStaffToMultiOrgUnit(); //Thêm nhân viên vào nhiều đơn vị

        void AssignMultiStaffToAOrgUnit(); //Thêm nhiều nhân viên vào một đơn vị

        void MoveStaffToAOtherOrgUnit(); //Chuyển nhân viên từ đơn vị này sang đơn vị khác

        void MoveStafftoOtherJobPosition(); //Điều chuyển nhân viên sang vị trí khác
    }
}