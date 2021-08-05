using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B1 = CP380_B1_BlockList.Models;

namespace CP380_B2_BlockWebAPI.Models
{
    public class BlockSummary
    {
        public DateTime timestamp { get; set; }
        public string? previousHash { get; set; }
        public string? hash { get; set; }

        public BlockSummary(B1.Block block)
        {
            timestamp = block.TimeStamp;
            previousHash = block.PreviousHash;
            hash = block.Hash;
        }
    }

    public class Block
    {
        public DateTime timestamp { get; set; }
        public string? previousHash { get; set; }
        public string? hash { get; set; }
        public List<B1.Payload> data { get; set; }
        public int nonce { get; set; }

        public Block(B1.Block block)
        {
            timestamp = block.TimeStamp;
            previousHash = block.PreviousHash;
            hash = block.Hash;
            data = block.Data;
            nonce = block.Nonce;
        }
    }

    public class BlockSummaryList
    {
        public List<BlockSummary> Blocks { get; set; }
    }

    public class BlockList
    {
        public List<Block> Blocks { get; set; }
    }
}
