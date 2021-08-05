﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CP380_B2_BlockWebAPI.Models;

namespace CP380_B2_BlockWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PendingPayloadsController : ControllerBase
    {
        private readonly List<PendingPayloads> _payloads;
        private PendingPayloadsList _payloadList;

        public PendingPayloadsController(PendingPayloadsList payloads)
        {
            _payloads = payloads.PendingPayloads;
        }

        [HttpGet]
        public ActionResult<List<PendingPayloads>> Get() =>
            _payloads.ToList();

        [HttpPost]
        public ActionResult<PendingPayloads> Post(PendingPayloads payload) =>
            _payloadList.Add(payload);
    }
}
