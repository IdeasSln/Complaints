using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Complaints.Models
{
    public class EquipmentType
    {
        public int Id { get; set; }
        public string Decription { get; set; }

        public bool Active { get; set; }
    }
}