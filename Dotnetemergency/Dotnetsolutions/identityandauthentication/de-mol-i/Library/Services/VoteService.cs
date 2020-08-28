using System;
using System.Linq;
using System.Collections.Generic;
using de_mol.Data;
using ViewModels;
using Library.DataTransferObjects;

namespace Library.Services
{
    public class VoteService
    {
        de_molContext context = new de_molContext();
        

        public Dictionary<long, PlayerVoteDTO> TotalPerPlayer(int episode){
            
            var votes = context.AppVotes
                    .Where(vote => vote.Episode == episode)
                    .GroupBy(vote => vote.PlayerId)
                    
                    .Select(vote => new {
                        PlayerId = vote.Key, 
                        Votes = vote.Count()
                    });

            var total = TotalPerEpisode(episode);
            Dictionary<long, PlayerVoteDTO> playerVotes = initPlayerVotes();
            foreach (var vote in votes){
                if( ! playerVotes.ContainsKey(vote.PlayerId)) {
                    playerVotes.Add(vote.PlayerId, new PlayerVoteDTO());
                }//endif

                playerVotes[vote.PlayerId].Total = vote.Votes;
                playerVotes[vote.PlayerId].Percentage = (Convert.ToDecimal(vote.Votes) / Convert.ToDecimal(total)) * 100;
                
            }//endforeach



            Dictionary<long, Decimal> myVotes = new Dictionary<long, Decimal>();
            foreach (var vote in votes){
                if( ! myVotes.ContainsKey(vote.PlayerId)) {
                    myVotes.Add(vote.PlayerId, 0);
                }//endif

     
                myVotes[vote.PlayerId] = (Convert.ToDecimal(vote.Votes) / Convert.ToDecimal(total)) * 100;
                
            }//endforeach

            return playerVotes;
        }

        public int TotalPerEpisode(int episode) {
            return context.AppVotes.Where(vote => vote.Episode == episode).Count();
        }

        public AppVotes VoteOn(long playerId, string userId, int episode){
            AppVotes appVotes = new AppVotes();
            appVotes.PlayerId = playerId;
            appVotes.UserId = userId;
            appVotes.Episode = episode;

            context.Add(appVotes);
            context.SaveChanges();

            return appVotes;
        }

        public void UnVoteOn(long playerId, string userId, int episode){
            var appVote  = context.AppVotes
                        .Where(vote => vote.PlayerId == playerId && vote.UserId == userId && vote.Episode == episode)
                        .FirstOrDefault();

            if(appVote != null){
                context.Remove(appVote);
                context.SaveChanges();
            }
        }   

        public long YourVote(string userId, int episode){
            return context.AppVotes
                .Where(vote => vote.UserId == userId && vote.Episode == episode)
                .Select(vote => vote.PlayerId)
                .FirstOrDefault();
        }

        public IEnumerable<AppVotes> All(int episode){
            return context.AppVotes.Where(vote => vote.Episode == episode).ToList();
        }

        private Dictionary<long, PlayerVoteDTO> initPlayerVotes(){
            Dictionary<long, PlayerVoteDTO> playerVotes = new Dictionary<long, PlayerVoteDTO>();
            
            var players = context.AppPlayers.OrderBy(player => player.Id);
            foreach(var player in players) {
                if( ! playerVotes.ContainsKey(player.Id)) {
                    playerVotes.Add(player.Id,new PlayerVoteDTO());
                }//endif
            }//endforeach

            return playerVotes;
        }



    }
}