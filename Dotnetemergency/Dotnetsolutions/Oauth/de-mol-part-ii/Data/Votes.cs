using System;
using System.Collections.Generic;

namespace de_mol.Data
{
    public partial class Votes
    {
        public long Id { get; set; }
        public long PlayerId { get; set; }
        public string UserId { get; set; }
        public int Episode { get; set; }
    }
}
