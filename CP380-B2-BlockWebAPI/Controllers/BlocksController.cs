using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CP380_B2_BlockWebAPI.Models;
using CP380_B1_BlockList.Models;

namespace CP380_B2_BlockWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class BlocksController : ControllerBase
    {
        private readonly BlockList _blocks;

        public BlocksController(BlockList blocks)
        {
            _blocks = blocks;
        }

        [HttpGet]
        public ActionResult<List<BlockSummary>> Get()
        {
            List<Block> blocks = _blocks.Chain.ToList();
            List<BlockSummary> blockSummaries = new List<BlockSummary>();

            foreach (var bl in blocks)
            {
                _blocks.AddBlock(bl);
                blockSummaries.Add(new BlockSummary()
                {
                    hash = bl.Hash,
                    previousHash = bl.PreviousHash,
                    timestamp = bl.TimeStamp
                });
            }

            return blockSummaries;
        }

        [HttpGet("{hash}")]
        public ActionResult<Block> GetBlock(string hash)
        {
            var output = _blocks.Chain.Where(b => b.Hash == hash).First();
            if (output.Hash.Length > 0)
            {
                return output;
            } else
            {
                return NotFound();
            }
        }

        [HttpGet("{hash}/Payloads")]
        public ActionResult<List<Payload>> GetPayload(string hash) =>
            _blocks.Chain.Where(b => b.Hash == hash).Select(row => row.Data).First().ToList();
    }
}