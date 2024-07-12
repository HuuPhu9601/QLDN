using System.Collections.Generic;

namespace QLDN.Models.JobPositionModels
{
    public interface IJobPosition
    {
        void AddJobPosition(); //Thêm một vị trí công việc

        void AssignStaffToAPosition(); //Chuyển nhân viên vào một vị trí công việc

        void AssignStaffToMultiPosition(); //Chuyển nhân viên vào nhiều vị trí công việc

        void AssignMultiStaffToAPosition(); //Chuyển nhân viên vào nhiều vị trí công việc

        bool CheckMaxQtyStaff(); //Kiểm tra vị trí công việc đã đủ nhân viên chưa?

        bool CheckExistedStaffInAPositon(); //Kiểm tra nhân viên đã ở vị trí này chưa?

        bool CheckExistedPositionInOrgUnit();//Kiểm tra vị trí đã có trong đơn vị chưa?

        List<JobPosition> GetJobPositionOfStaff(); //Lấy ra sanh sách các vị trí của quản lý

        JobPosition GetJobPostionStaffOrOrgUnit(); //Lấy ra vị trí của quản lý trong một công ty

        List<JobPosition> GetJobPositionOfOrgUnit(); //Lấy ra danh sách các chức vụ trong đơn vị

    }
}