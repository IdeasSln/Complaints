using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Complaints.Models
{
    public class ComplaintsContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ComplaintsContext() : base("name=ComplaintsContext")
        {
        }

        public System.Data.Entity.DbSet<Complaints.Models.Gender> Genders { get; set; }
        public System.Data.Entity.DbSet<Complaints.Models.Person> Person { get; set; }
        public System.Data.Entity.DbSet<Complaints.Models.Complaint> Complaints { get; set; }
        public System.Data.Entity.DbSet<Complaints.Models.Equipment> Equipment { get; set; }
        public System.Data.Entity.DbSet<Complaints.Models.Disposition> Disposition { get; set; }
        public System.Data.Entity.DbSet<Complaints.Models.Equipment_Status> Eqipment_Status { get; set; }
        public System.Data.Entity.DbSet<Complaints.Models.Equipment_Type> Equipment_Typ { get; set; }
        public System.Data.Entity.DbSet<Complaints.Models.Location> Incident_Location { get; set; }
        public System.Data.Entity.DbSet<Complaints.Models.POI_Type> POI_Type { get; set; }

     
        public System.Data.Entity.DbSet<Complaints.Models.Incident_Type> Incident_Type { get; set; }



    }
}
