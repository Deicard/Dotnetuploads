using System;
using System.Collections.Generic;
using de_mol.Data;
using Library.DataTransferObjects;

namespace ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Players> Players {get; set;}
        public Dictionary<long,PlayerVoteDTO> Votes { get; set;}
        public int TotalVotes {get; set;}
        public Boolean CanVote { get; set;}

        public long YourVote {get; set;}
        public int Episode { get; set;}
    }
}