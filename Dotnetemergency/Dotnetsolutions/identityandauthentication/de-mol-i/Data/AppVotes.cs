using System;
using System.Collections.Generic;

namespace de_mol.Data
{
    public partial class AppVotes
    {
        public long PlayerId { get; set; }
        public string UserId { get; set; }
        public int Episode { get; set; }
        public long Id { get; set; }
    }
}
