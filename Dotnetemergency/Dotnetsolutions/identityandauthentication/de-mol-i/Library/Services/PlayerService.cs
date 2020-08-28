using System;
using System.Linq;
using System.Collections.Generic;
using de_mol.Data;

namespace Library.Services
{
    public class PlayerService
    {
        de_molContext context = new de_molContext();

        public IEnumerable<AppPlayers> All(){
            return context.AppPlayers
                
                .OrderBy(player => player.Name);
        }

        public Dictionary<long, AppPlayers> AllDictionary(){
            var results = context.AppPlayers
                
                .OrderBy(player => player.Id);

            Dictionary<long, AppPlayers> players = new Dictionary<long, AppPlayers>();
            foreach(var player in results) {
                players.Add(player.Id, player);
            }

            return players;
        }

    }
}