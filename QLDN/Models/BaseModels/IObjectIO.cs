﻿using System.Data;

namespace QLDN.Models.BaseModels
{
    //Thực hiện nguyên tắc số 2: "Nguyên tắc đóng mở" cho model nhân viên, quản lý và đơn vị
    public interface IObjectIO<T> where T : class
    {
        DataTable GetAll();

        T GetOne(int id);

        string Insert(T obj);

        string Update(T obj);

        string Delete(T obj);
    }
}