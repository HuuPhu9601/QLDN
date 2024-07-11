using QLDN.Models.BaseModels;
using System;
using System.Data;

namespace QLDN.Models.OrgUnitModels
{
    public class OrgImportExcel : Excelmport
    {
        private IObjectIO<OrgUnit> _org;

        public OrgImportExcel()
        {
            _org = OrgUnit.Ins;
        }

        public override void ConvertDataTableToObjectType(DataTable dataTable)
        {
            base.ConvertDataTableToObjectType(dataTable);
            //Thực hiện gán dữ liệu
            var org = SetOrgUnit(dataTable);

            //lưu dữ liệu
            _org.Insert(org);
        }

        public OrgUnit SetOrgUnit(DataTable dataTable)
        {
            OrgUnit orgUnit = new OrgUnit();
            orgUnit.ManagerName = dataTable.Columns["ManagerName"].ToString();
            orgUnit.OrgUnitName = dataTable.Columns["OrgUnitName"].ToString();
            orgUnit.MaxQty = Convert.ToInt32(dataTable.Columns["MaxQty"]);
            return orgUnit;
        }
    }
}