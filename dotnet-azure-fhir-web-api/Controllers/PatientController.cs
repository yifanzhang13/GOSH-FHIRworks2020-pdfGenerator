﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using HDR_UK_Web_Application.IServices;
using System;
using System.IO;

namespace HDR_UK_Web_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {

        private readonly IPatientService _service;

        public PatientController(IPatientService service)
        {
            _service = service;
        }

        // GET: api/Patient/
        [HttpGet]
        public async Task<List<JObject>> GetPatients()
        {
            return await _service.GetPatients();
        }

        // GET: api/Patient/<patient ID>
        [HttpGet("{id}", Name = "GetPatient")]
        public async Task<JObject> GetPatient(string id)
        {
            return await _service.GetPatient(id);
        }

        // GET: api/Patient/pages/<number of pages>
        [HttpGet("pages/{pages}", Name = "GetPatientPages")]
        public async Task<List<JObject>> GetPatientPages(int pages)
        {
            return await _service.GetPatientPages(pages);
        }

        // GET: api/Patient/<patient ID>/view
        [HttpGet("{id}/view", Name = "ViewPatient")]
        public async Task<IActionResult> ViewPatient(string id)
        {
            var pdfPath = Directory.GetCurrentDirectory()+"/patient.pdf";
            var pdfMimeType = "application/pdf";
            var stream = System.IO.File.OpenRead(pdfPath);

            return File(stream,pdfMimeType);
        }

    }
}
