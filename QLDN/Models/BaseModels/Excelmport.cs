using System.Data;

namespace QLDN.Models.BaseModels
{
    public abstract class Excelmport : IImport
    {
        /// <summary>
        /// Đọc file excel
        /// </summary>
        /// <param name="path">đường dẫn file</param>
        public virtual void Importor(string path)
        {
            DataTable dataTable = null;
            //Thực hiện đọc file excel
            ProcessData(dataTable);
        }
        /// <summary>
        /// Lấy dữ liệu gán vào Object
        /// </summary>
        /// <param name="dataTable">datatable dữ liệu khi đọc xong file</param>
        public virtual void ConvertDataTableToObjectType(DataTable dataTable)
        {
            //Lấy dữ liệu gán vào object
        }

        /// <summary>
        /// Thực hiện gán và thực hiện các logic nếu cần
        /// </summary>
        /// <param name="dataTable"></param>
        public virtual void ProcessData(DataTable dataTable)
        {
            ConvertDataTableToObjectType(dataTable);
            SaveData();
        }

        //Thực hiện lưu dữ liệu
        public virtual void SaveData()
        {
            //Thực hiện lưu dữ liệu
        }

    }
}