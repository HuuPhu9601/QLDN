using System.Data;

namespace QLDN.Models.BaseModels
{
    public interface IExport
    {
        void GetData(out DataTable table);
        void Exportor(DataTable table);

        void ColumnConfigure(DataTable table);
    }
}