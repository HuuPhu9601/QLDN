using QLDN.Models.BaseModels;
using System;
using System.Data;

namespace QLDN.Models.ManagerModels
{
    public class ManagerImportExcel : Excelmport
    {
        private readonly IObjectIO<Manager> _manager;

        public ManagerImportExcel()
        {
            _manager = Manager.Ins;
        }

        public override void ConvertDataTableToObjectType(DataTable dataTable)
        {
            base.ConvertDataTableToObjectType(dataTable);
            //Thực hiện gán dữ liệu
            var manager = SetManager(dataTable);

            //lưu dữ liệu
            _manager.Insert(manager);
        }

        public Manager SetManager(DataTable dataTable)
        {
            Manager manager = new Manager();
            manager.ManagerName = dataTable.Columns["ManagerName"].ToString();
            manager.Age = Convert.ToInt32(dataTable.Columns["Age"]);
            manager.Address = dataTable.Columns["Address"].ToString();
            return manager;
        }
    }
}