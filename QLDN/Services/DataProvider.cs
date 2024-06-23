using System.Data.Entity;

namespace QLDN.Services
{
    public class DataProvider
    {
        public static DataProvider _ins;

        public static DataProvider Ins { get { if (_ins == null) _ins = new DataProvider(); return _ins; } set { _ins = value; } }

        public Models.QLDN DB { get; set; }

        public DataProvider()
        {
            DB = new Models.QLDN();
        }
    }
}