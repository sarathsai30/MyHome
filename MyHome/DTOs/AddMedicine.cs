using MyHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHome.DTOs
{
    public class AddMedicine
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Illness { get; set; }
        public Effectiveness Effectiveness { get; set; } = Effectiveness.Average;
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
        public decimal Cost { get; set; }
        public byte[] Image { get; set; }
    }
}
