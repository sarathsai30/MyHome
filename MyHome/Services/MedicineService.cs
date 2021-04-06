using Microsoft.EntityFrameworkCore;
using MyHome.Data;
using MyHome.DTOs;
using MyHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHome.Services
{
    public class MedicineService : IMedicineService
    {
        private readonly DataContext _context;
        public MedicineService(DataContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<Medicine>>> AddMedicine(AddMedicine addmed)
        {
            ServiceResponse<List<Medicine>> allmedicines = new ServiceResponse<List<Medicine>>();
            Medicine newMedicine = new Medicine();
            newMedicine.Name = addmed.Name;
            newMedicine.Description = addmed.Description;
            newMedicine.DoctorName = addmed.DoctorName;
            newMedicine.Effectiveness = 1;
            newMedicine.Illness = addmed.Illness;
            newMedicine.IsActive = true;
            newMedicine.PatientName = addmed.PatientName;
            newMedicine.createdDate = DateTime.Now;
            newMedicine.Image = addmed.Image;
            newMedicine.Cost = addmed.Cost;
            await _context.Medicines.AddAsync(newMedicine);
            await _context.SaveChangesAsync();
            allmedicines.Data = await _context.Medicines.ToListAsync();
            return allmedicines;

        }

        public async Task<ServiceResponse<Medicine>> DeleteMedicine(int id)
        {
            ServiceResponse<Medicine> medicine = new ServiceResponse<Medicine>();
            Medicine med = await _context.Medicines.FirstAsync(x => x.ID == id);
            _context.Medicines.Remove(med);
            await  _context.SaveChangesAsync();
            medicine.Data =med;
            return medicine;

        }

        public async Task<ServiceResponse<List<Medicine>>> GetAllMedicines()
        {
            ServiceResponse<List<Medicine>> allmedicines = new ServiceResponse<List<Medicine>>();
            allmedicines.Data = await _context.Medicines.ToListAsync();
            return allmedicines;
        }

        public async Task<ServiceResponse<List<Medicine>>> GetMedicineByDescription(string description)
        {
            ServiceResponse<List<Medicine>> allmedicines = new ServiceResponse<List<Medicine>>();
            allmedicines.Data = await _context.Medicines.Where(x => x.Description.Contains(description.ToUpper())).ToListAsync();
            return allmedicines;
        }

        public async Task<ServiceResponse<Medicine>> GetMedicineByName(string name)
        {
            ServiceResponse<Medicine> allmedicines = new ServiceResponse<Medicine>();
            allmedicines.Data = await _context.Medicines.Where(x => x.Name == name).FirstOrDefaultAsync();
            return allmedicines;
        }

        public async Task<ServiceResponse<Medicine>> UpdateMedcine(Medicine updateMedicine)
        {
            ServiceResponse<Medicine> allmedicines = new ServiceResponse<Medicine>();
            Medicine updatemed = await _context.Medicines.FirstAsync(x => x.ID == updateMedicine.ID);
            updatemed.Name = updateMedicine.Name;
            updatemed.Illness = updateMedicine.Illness;
            updatemed.PatientName = updateMedicine.PatientName;
            updatemed.Description = updateMedicine.Description;
            updatemed.Effectiveness = updateMedicine.Effectiveness;
            updatemed.DoctorName = updateMedicine.DoctorName;
            updatemed.createdDate = DateTime.Now;
            updatemed.IsActive = updateMedicine.IsActive;
            updatemed.Cost = updateMedicine.Cost;
             _context.Medicines.Update(updatemed);
            await _context.SaveChangesAsync();
            allmedicines.Data = updatemed;
            return allmedicines;
        }
    }
}
