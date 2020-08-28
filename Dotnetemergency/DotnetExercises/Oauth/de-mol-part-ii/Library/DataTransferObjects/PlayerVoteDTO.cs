using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;



namespace Library.DataTransferObjects
{
    public class PlayerVoteDTO{
        public int Total {get; set;}
        public decimal Percentage {get; set;}
    }
}