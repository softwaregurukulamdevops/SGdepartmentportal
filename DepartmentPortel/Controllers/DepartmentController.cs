using DepartmentPortel.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentPortel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : Controller
    {
        public readonly TrainingDBContext trainingDBContext;
        public DepartmentController(TrainingDBContext _trainingDBContext)
        {
            trainingDBContext = _trainingDBContext;
        }
        [HttpGet("GetDepartmentDetails")]
        public List<Department> GetDepartmentDetails()
        {
            List<Department> lstDepartment = new List<Department>();
            try
            {
                lstDepartment = trainingDBContext.Department.ToList();
                return lstDepartment;
            }
            catch (Exception ex)
            {
                lstDepartment = new List<Department>();
                return lstDepartment;
            }
        }
        [HttpPost("AddDepartment")]
        public string AddDepartmentDetails(Department department)
        {
            string message = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(department.DepartmentName))
                {
                    trainingDBContext.Add(department);
                    trainingDBContext.SaveChanges();
                    message = "Department added successfully";
                }
                else
                    message = "Description required";
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return message;
        }
    }
}
