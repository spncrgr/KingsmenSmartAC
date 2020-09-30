using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingsmenSmartAC.API.Data;
using KingsmenSmartAC.API.Helpers;
using KingsmenSmartAC.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KingsmenSmartAC.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public DeviceController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/<DeviceController>
        [ProducesResponseType(200)]
        [HttpGet]
        public async Task<ActionResult<List<Device>>> Get([FromQuery] PagingParameters pagingParameters)
        {
            var devices = await PagedList<Device>.ToPagedListAsync(_context.Devices, pagingParameters.PageNumber,
                pagingParameters.PageSize);

            var paginationData = new
            {
                devices.TotalCount,
                devices.PageSize,
                devices.TotalPages,
                devices.CurrentPage,
                devices.HasNext,
                devices.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginationData));

            return devices;
        }

        [ProducesResponseType(200)]
        [HttpGet("devices")]
        public async Task<ActionResult<List<Device>>> GetAll()
        {
            return await _context.Devices.ToListAsync();
        }
    }
}