namespace QLDN.Models.BaseModels
{
    //Thực hiện nguyên tắc số 4: "Nguyên tắc phân tách interface" cho model các model nhân viên, quản lý và đơn vị
    //Các model đề cần thực hiện bước check này
    public interface IAcceptInsertToAOrgUnit
    {
        void CheckMaxQtyOfOrgToAcceptInsert();
    }
}
