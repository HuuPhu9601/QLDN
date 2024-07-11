using System;
using System.Data;

namespace QLDN.Models.BaseModels
{
    public abstract class ExportExcel : IExport
    {
        public virtual void ProcessExportExcel()
        {
            GetData(out DataTable table);
            Exportor(table);

        }

        /// <summary>
        /// Cấu hình tên các cột excel trả ra
        /// </summary>
        /// <param name="table">dữ liệu kết xuất</param>
        /// <exception cref="NotImplementedException"></exception>
        public virtual void ColumnConfigure(DataTable table)
        {
            //Thực hiện cấu hình tên và vị trí các cột
        }

        /// <summary>
        /// Lấy dữ liệu kết xuất
        /// </summary>
        public virtual void GetData(out DataTable table)
        {
            //thực hiện lấy ra dữ liệu kết xuất
            table = null;
        }

        /// <summary>
        /// Export ra file excel
        /// </summary>
        public virtual void Exportor(DataTable table)
        {
            ColumnConfigure(table);

            //Thực hiện kết xuất ra excel
        }
    }
}