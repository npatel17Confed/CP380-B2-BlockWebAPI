using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B1 = CP380_B1_BlockList.Models;

namespace CP380_B2_BlockWebAPI.Models
{
    public class PendingPayloads
    {
        public string? user { get; set; }
        public B1.TransactionTypes transactionType { get; set; }
        public int amount { get; set; }
        public string? item { get; set; }

        public PendingPayloads(B1.Payload payload)
        {
            user = payload.User;
            transactionType = payload.TransactionType;
            amount = payload.Amount;
            item = payload.Item;
        }
    }

    public class PendingPayloadsList
    {
        public List<PendingPayloads> PendingPayloads { get; set; }

        public PendingPayloads Add(PendingPayloads payload)
        {
            PendingPayloads.Add(payload);
            return payload;
        }
    }
}
