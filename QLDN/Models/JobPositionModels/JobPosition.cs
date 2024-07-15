using QLDN.Models.BaseModels;
using System.Data;

namespace QLDN.Models.JobPositionModels
{
    //Thực hiện nguyên tắc số 1: "Nguyên tắc trách nhiệm đơn lẻ" cho model vị trí công việc để làm rõ trách nhiệm của model
    //Thực hiện nguyên tắc số 2: "Nguyên tắc đóng/ mở" cho model vị trí công việc để thực hiện CRUD cho cho model
    //Thực hiện nguyên tắc số 3: "Nguyên tắc thay thế liskow" cho model JobPosition để sử dụng đc các hàm base của abstract class "AssignJobPositon" và có thể ghi đè lại

    public class JobPosition : AssignJobPositon, IObjectIO<JobPosition>
    {
        public int PositionID { get; set; }
        public string PositionName { get; set; }
        public int MaxQtyStaff { get; set; }

        public string Delete(JobPosition obj)
        {
            return string.Empty;
        }

        public DataTable GetAll()
        {
            return new DataTable();
        }

        public JobPosition GetOne(int id)
        {
            return new JobPosition();
        }

        public string Insert(JobPosition obj)
        {
            return string.Empty;
        }

        public string Update(JobPosition obj)
        {
            return string.Empty;
        }
    }
}