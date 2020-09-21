using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using WindowsFirewallPowershellHelper;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using WindowsFirewallHelper.Data;

namespace WindowsFirewallPowershellHelper.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {

            await Utilities.SetExecutionPolicy();
            //await GetProfiles();
            //await GetProfiles();
            //await GetRules(false);
            await GetRules(true);



            Console.ReadLine();


        }

        static async Task GetProfiles()
        {
            var t = new Stopwatch();
            t.Start();

            var profileCollection = await WindowsFirewallPowershellHelper.FirewallRuleUtilities.GetFirewallProfile();


            foreach (var profile in profileCollection)
            {
                Console.WriteLine($@"{profile.BuildScript}");
            }

            t.Stop();

            Console.WriteLine($@"{profileCollection.Count.ToString()} profiles : elapsed {t.Elapsed}");
        }

        static async Task GetRules(bool GetExt)
        {
            var port = 5050;
            var t = new Stopwatch();
            t.Start();

            //var firewallRuleCollection = await FirewallRuleUtilities.GetFirewallRule(
            //    pWildcard: "TEST",
            //    pDirection: Enumerations.Direction.Any,
            //    GetExtendedProps: GetExt
            //);

            var firewallRuleCollection = await FirewallRuleUtilities.GetFirewallRule(
                pDisplayName: "TEST - Complex",
                pDirection: Enumerations.Direction.Any,
                GetExtendedProps: GetExt
            );




            var portCollection = firewallRuleCollection.FindByPort(port);
            var addressCollection = firewallRuleCollection.FindByAddress("127.0.0.1");


            foreach (var rule in portCollection)
            {
                Console.WriteLine($@"{rule.DisplayName} port {port}");
            }

            t.Stop();

            Console.WriteLine($@"-----------------------");
            Console.WriteLine($@"{firewallRuleCollection.Count} Rules returned in {t.Elapsed} ms");
        }

    }
}
