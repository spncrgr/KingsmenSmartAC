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
        public async Task<ActionResult<List<Device>>> Get([FromQuery] QueryParameters queryParams)
        {
            // Need to see if the search term could be a Device ID
            // Using TryParse to maintain safety from malicious input
            long.TryParse(queryParams.SearchTerms, out var deviceId);
            var devices = _context.Devices
                .Where(d =>
                    d.DeviceId == deviceId ||
                    d.SerialNumber.Contains(queryParams.SearchTerms) ||
                    d.FirmwareVersion.Contains(queryParams.SearchTerms));
            var deviceList = await PagedList<Device>.ToPagedListAsync(devices, queryParams.PageNumber,
                queryParams.PageSize);

            var paginationData = new
            {
                deviceList.TotalCount,
                deviceList.PageSize,
                deviceList.TotalPages,
                deviceList.CurrentPage,
                deviceList.HasNext,
                deviceList.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginationData));

            return deviceList;
        }

        [ProducesResponseType(200)]
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Device>>> GetAll()
        {
            return await _context.Devices.ToListAsync();
        }
    }
}