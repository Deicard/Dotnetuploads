using System;
using System.Collections.Generic;
using lab_traceroute;
using lab_traceroute.network;

namespace networktools
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Please provide a command (ping, traceroute, ...) and a destination");
                return;
            }

            var client = new Client();
            var command = args[0];
            var destination = args[1];

            switch (command)
            {
                case "--ping":
                    printResults(client.Ping(destination), true);
                    break;
                case "--traceroute":
                    printResults(client.TraceRoute(destination), false);
                    break;
                default:
                    Console.WriteLine("No valid command is provided.");
                    break;
            }
        }

        // Boolean should be replaced by a method reference. This is beyond the scope of this module.
        static void printResults(IEnumerable<IcmpResult> results, Boolean isPing)
        {
            foreach (var icmpResult in results)
            {
                if (!icmpResult.Success)
                {
                    printErrorResult(icmpResult);
                    return;
                }

                if (isPing)
                {
                    printPingResult(icmpResult);
                }
                else
                {
                    printTraceRouteResult(icmpResult);
                }
            }
        }

        static void printPingResult(IcmpResult icmpResult)
        {
            Console.WriteLine($"Reply from {icmpResult.IPEndPoint}: bytes = {icmpResult.Weight}, " +
                $"time = {Math.Round(icmpResult.Duration.TotalMilliseconds)}ms, " +
                $"TTL = {icmpResult.TTL}");
        }

        static void printTraceRouteResult(IcmpResult icmpResult)
        {
            Console.WriteLine($"{new string(' ', 3).Substring(0, 3 - icmpResult.HopNumber.ToString().Length)} " +
                $"{icmpResult.HopNumber}\t {Convert.ToInt32(Math.Max(1, icmpResult.Duration.TotalMilliseconds))}ms\t " +
                $"{icmpResult.Host} [{icmpResult.IPEndPoint}]");
        }

        static void printErrorResult(IcmpResult icmpResult)
        {
            Console.WriteLine($"Error: {icmpResult.ErrorMessage}");
        }
    }
}
