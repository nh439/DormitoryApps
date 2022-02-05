﻿using dormitoryApps.Server.Services;
using dormitoryApps.Shared.Model.Entity;
using Microsoft.AspNetCore.Mvc;

namespace dormitoryApps.Server.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentServices _departmentServices;
        private readonly ILogger<DepartmentController> _logger;
        private const string BaseUrl = "/api/department";
        public DepartmentController(IDepartmentServices departmentServices, ILogger<DepartmentController> logger = null)
        {
            _departmentServices = departmentServices;
            _logger = logger;
        }
        [HttpGet(BaseUrl)]
        public async Task< IActionResult> Index()
        {
            try
            {
                List<Department> departments = await _departmentServices.Getall();
                return Ok(departments);
            }
            catch (Exception x)
            {
                _logger.LogError(x, x.Message);
                return StatusCode(500,"Something Went Wrong");
            }
        }
        [HttpGet(BaseUrl+"/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            try
            {
                Department department = await _departmentServices.GetById(Id);
                return Ok(department);
            }
            catch(Exception x)
            {
                _logger.LogError(x, x.Message);
                return StatusCode(500, "Something Went Wrong");
            }
        }
        [HttpPost($"{BaseUrl}/Create")]
        public async Task<IActionResult> Create([FromBody]Department department)
        {
            try
            {
                var res = await _departmentServices.Create(department);
                return Ok(res);
            }
            catch (Exception x)
            {
                _logger.LogError(x, x.Message);
                return StatusCode(500, "Insert Incomplete");
            }
        }
    }
}