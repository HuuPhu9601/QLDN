using QLDN.Models.BaseModels;
using System.Data;

namespace QLDN.Models.JobPositionModels
{
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