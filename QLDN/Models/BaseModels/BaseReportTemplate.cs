using System.Data;

namespace QLDN.Models.BaseModels
{
    public abstract class BaseReportTemplate : IReportGenerator
    {
        /// <summary>
        /// lấy dữ liệu cần tạo báo cáo
        /// </summary>
        /// <param name="table">trả ra datatable</param>
        public virtual void GetData(out DataTable table)
        {
            //Thực hiện lấy dữ liệu
            table = null;
        }

        /// <summary>
        /// Tạo ra báo cáo
        /// </summary>
        /// <param name="table"></param>
        public virtual void ReportGenerator(DataTable table)
        {
            SetTemplateReport(table);

            //Thực hiện tạo ra báo cáo
        }

        /// <summary>
        /// Tạo ra mẫu template cho từng báo cáo
        /// </summary>
        /// <param name="table">dữ liệu báo cáo</param>
        public virtual void SetTemplateReport(DataTable table)
        {
            //Tạo ra mẫu template cho từng báo cáo
        }
    }
}