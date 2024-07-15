using QLDN.Models.JobPositionModels;

namespace QLDN.Models.BaseModels
{
    //Class áp dụng nguyên tắc số 3: "Nguyên tắc thay thế Liskov"
    //Tạo ra abstract class để gộp interface và abstract class để sử dụng cho đơn vị: Vì 1 class con không thể kế thừa dc nhiều asbtract class nên phải làm abstract class trung gian
    // interface IAcceptInsertToAOrgUnit: kiểm tra số lượng đơn vị trc khi thêm vào đơn vị
    //abstract class: thêm vị trí cho các nhân viên trong đơn vị
    //Thực hiện nguyên tắc số 4: "Nguyên tắc phân tách interface" để có thẻ sử dụng hàm check và thực hiện hàm check thành hàm chung để sử dụng cho các model nhân viên, quản lý và đơn vị
    public abstract class CheckMaxQtyAndAssignJobPosition : AssignJobPositon, IAcceptInsertToAOrgUnit
    {
        public virtual void CheckMaxQtyOfOrgToAcceptInsert()
        {
            //Thực hiện kiểm tra còn chỗ cho nhân viên mới không?
        }
    }

    //Class áp dụng nguyên tắc số 3: "Nguyên tắc thay thế Liskov"
    //Tạo ra abstract class cho phép thực hiện các phương thức chung của quản lý và đơn vị
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