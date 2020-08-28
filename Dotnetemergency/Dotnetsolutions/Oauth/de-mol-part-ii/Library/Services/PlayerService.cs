using System;
using System.Linq;
using System.Collections.Generic;
using de_mol.Data;

namespace Library.Services
{
    public class PlayerService
    {
        de_molContext context = new de_molContext();

        public IEnumerable<Players> All(){
            return context.Players
                
                .OrderBy(player => player.Name);
        }

        public Dictionary<long, Players> AllDictionary(){
            var results = context.Players
                
                .OrderBy(player => player.Id);

            Dictionary<long, Players> players = new Dictionary<long, Players>();
            foreach(var player in results) {
                players.Add(player.Id, player);
            }

            return players;
        }

    }
}