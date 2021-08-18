using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using CP380_B1_BlockList.Models;
using CP380_B2_BlockWebAPI.Models;
using Microsoft.Extensions.Configuration;

namespace CP380_B2_BlockWebAPI.Services
{
    class BlockListService
    {
        private PendingPayloadsList _payloads;
        private BlockList _blockList;
        private readonly IConfiguration _configure;
        private readonly JsonSerializerOptions _config = new JsonSerializerOptions(JsonSerializerDefaults.Web);

        public BlockListService(IConfiguration configuration, BlockList blockList, PendingPayloadsList payloads)
        {
            _blockList = blockList;
            _payloads = payloads;
            _configure = configuration;
        }

        public Block SubmitNewBlock(string hash, int nonce, DateTime timestamp)
        {

            Block block = new Block(timestamp, _blockList.Chain[_blockList.Chain.Count - 1].Hash, _payloads.payloads);
            block.CalculateHash();
            
            if (block.Hash == hash)
            {
                _blockList.Chain.Add(block);
                _payloads.clearPendingPayloads();
                return block;
            }

            return null;
        }
    }
}