using QLDN.Models.JobPositionModels;

namespace QLDN.Models.BaseModels
{
    public abstract class CheckMaxQtyAndAssignJobPosition : AssignJobPositon, IAcceptInsertToAOrgUnit
    {
        public virtual void CheckMaxQtyOfOrgToAcceptInsert()
        {
            //Thực hiện kiểm tra còn chỗ cho nhân viên mới không?
        }
    }

    public abstract class AssignStaffOrgUnit : CheckMaxQtyAndAssignJobPosition, IAssignStaffOrgUnit
    {
        public virtual void AssignMultiStaffToAOrgUnit()
        {
            //Thực hiện thêm nhiều nhân viên vào một đơn vị
        }

        public virtual void AssignStaffToAOrgUnit()
        {
            //Thực hiện thêm một nv/ quản lý vào một đơn vị
        }

        public virtual void AssignStaffToMultiOrgUnit()
        {
            //Thực hiện thêm một nv/ quản lý vào nhiều đơn vị
        }

        public virtual void MoveStaffToAOtherOrgUnit()
        {
            //Điều chuyển nhân viên/ quản lý sang đơn vị khác
        }

        public virtual void MoveStafftoOtherJobPosition()
        {
            //Điều chuyển nhân viên/ quản lý sang vị trí khác
        }
    }
}