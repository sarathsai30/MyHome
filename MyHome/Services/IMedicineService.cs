using MyHome.DTOs;
using MyHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHome.Services
{
    public interface IMedicineService
    {
        Task<ServiceResponse<List<Medicine>>> GetAllMedicines();
        Task<ServiceResponse<Medicine>> GetMedicineByName(string name);
        Task<ServiceResponse<List<Medicine>>> GetMedicineByDescription(string description);
        Task<ServiceResponse<List<Medicine>>> AddMedicine(AddMedicine newMedicine);
        Task<ServiceResponse<Medicine>> UpdateMedcine(Medicine updateMedicine);
        Task<ServiceResponse<Medicine>> DeleteMedicine(int id);
    }
}
