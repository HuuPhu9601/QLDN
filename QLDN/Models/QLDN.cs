using System;
using System.Data.Entity;
using System.Linq;

namespace QLDN.Models
{
    public class QLDN : DbContext
    {
        // Your context has been configured to use a 'QLDN' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'QLDN.Models.QLDN' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'QLDN' 
        // connection string in the application configuration file.
        public QLDN()
            : base("name=QLDN")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public DbSet<OrgUnit> OrgUnits { get; set; }

        public DbSet<Manager> Managers { get; set; }

        public DbSet<Staff> Staffs { get; set; }

        public DbSet<OrgUnitManager> OrgUnitManagers { get; set; }

        public DbSet<OrgUnitStaff> OrgUnitStaffs { get; set; }
    }

}