using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CP380_B2_BlockWebAPI.Models;
using B1 = CP380_B1_BlockList.Models;

namespace CP380_B2_BlockWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class BlocksController : ControllerBase
    {
        private readonly BlockSummaryList _blocksSummaries;
        private readonly BlockList _blocks;

        public BlocksController(BlockSummaryList blocksSummaries, BlockList blocks)
        {
            _blocksSummaries = blocksSummaries;
            _blocks = blocks;
        }

        [HttpGet]
        public ActionResult<List<BlockSummary>> Get() =>
            _blocksSummaries.Blocks.ToList();

        [HttpGet("{hash}")]
        public ActionResult<BlockSummary> GetBlock(string hash) =>
            _blocksSummaries.Blocks.Where(b => b.hash == hash).First();

        [HttpGet("{hash}/Payloads")]
        public ActionResult<List<B1.Payload>> GetPayload(string hash) =>
            _blocks.Blocks.Where(b => b.hash == hash).Select(row => row.data).First().ToList();
    }
}