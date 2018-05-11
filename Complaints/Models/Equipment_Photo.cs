using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Complaints.Models
{
    public class Equipment_Photo
    {
        public int Id { get; set; }
        public int Equipment_Id { get; set; }

        public string Photo { get; set; }

        public string Description { get; set; }
    }
}