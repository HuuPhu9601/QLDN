using System.Collections.Generic;

namespace QLDN.Models.JobPositionModels
{
    //Thực hiện nguyên tắc số 3: "Nguyên tắc thay thế Liskov" cho model đơn vị và quản lý để thực hiện thêm vị trí công việc cho nhân viên

    public abstract class AssignJobPositon : IJobPosition
    {
        #region Vị trí công việc
        public virtual void AddJobPosition()
        {
            //Thực hiện thêm một vị trí công việc
        }

        public virtual void AssignStaffToAPosition()
        {
            //Thực hiện thêm một nhân viên vào một vị trí công việc
        }

        public virtual void AssignStaffToMultiPosition()
        {
            //Thực hiện thêm một nhân viên vào nhiều vị trí công việc
        }

        public virtual void AssignMultiStaffToAPosition()
        {
            //Thực hiện thêm nhiều nhân viên vào một vị trí công việc
        }

        public virtual bool CheckMaxQtyStaff()
        {
            //Kiểm tra số lượng nhân viên có cho phép thêm nhân viên vào vị trí hay không?
            return true;
        }

        public virtual bool CheckExistedStaffInAPositon()
        {
            //Kiểm tra nhân viên đã tồn tại trong vị trí công việc chưa?
            return true;
        }

        public virtual bool CheckExistedPositionInOrgUnit()
        {
            //Kiểm tra côn việc đã tồn tại trong đơn vị chưa?
            return true;
        }

        public List<JobPosition> GetJobPositionOfStaff()
        {
            //Lấy ra danh sách vị trí của một nhân viên
            return new List<JobPosition>();
        }

        public JobPosition GetJobPostionStaffOrOrgUnit()
        {
            //Lấy ra vị trí của nhân viên trong đơn vị
            return new JobPosition();
        }

        public List<JobPosition> GetJobPositionOfOrgUnit()
        {
            //Lấy ra danh sách vị trí của một đơn vị
            return new List<JobPosition>();
        }
        #endregion
    }
}