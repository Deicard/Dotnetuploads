using System;
using System.Collections.Generic;

namespace de_mol.Data
{
    public partial class AppPlayers
    {
        public string Name { get; set; }
        public long Id { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public string Profession { get; set; }
        public string Photo { get; set; }
    }
}
