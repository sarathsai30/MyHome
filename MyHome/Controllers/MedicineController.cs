using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyHome.Data;
using MyHome.DTOs;
using MyHome.Models;
using MyHome.Services;

namespace MyHome.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineService _service;
        public MedicineController(IMedicineService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get() {
            var medicines =await _service.GetAllMedicines();
            return Ok(medicines.Data);
        }

        [HttpGet("GetByName/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var medicines = await _service.GetMedicineByName(name);
            return Ok(medicines.Data);
        }

        [HttpGet("GetByDescription/{description}")]
        public async Task<IActionResult> GetByDescription(string description)
        {
            var medicines = await _service.GetMedicineByDescription(description);
            return Ok(medicines.Data);
        }
        [HttpPost("SaveMedicine")]
        public async Task<IActionResult> SaveMedicine(AddMedicine med)
        {
            var medicines = await _service.AddMedicine(med);
            return Ok(StatusMessage.ADDED);
        }

        [HttpPut("UpdateMedicine")]
        public async Task<IActionResult> UpdateMedicine(Medicine med)
        {
            var medicines = await _service.UpdateMedcine(med);
            return Ok(StatusMessage.UPDATED);
        }

        [HttpDelete("DeleteMedicine/{id}")]
        public async Task<IActionResult> DeleteMedicine(int id)
        {
            var medicines = await _service.DeleteMedicine(id);
            return Ok(StatusMessage.DELETED);
        }
    }
}
