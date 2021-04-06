using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHome.Models
{
    public class Medicine
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Illness { get; set; }
        public int Effectiveness { get; set; } 
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
        public decimal Cost { get; set; }
        public byte[] Image { get; set; }
        public DateTime createdDate { get; set; }
        public bool IsActive { get; set; }
    }
}
