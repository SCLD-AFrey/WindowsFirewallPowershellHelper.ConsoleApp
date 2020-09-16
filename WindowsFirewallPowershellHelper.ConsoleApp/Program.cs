using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using WindowsFirewallPowershellHelper;

namespace WindowsFirewallPowershellHelper.ConsoleApp
{
    class Program
    {
        List<FirewallRule> ruleCollection = new List<FirewallRule>();
        static async Task Main(string[] args)
        {
            await FirewallRuleUtilities.GetTestScript();
            //await GetProfiles();
            //await GetRules();



            Console.ReadLine();


        }

        static async Task GetProfiles()
        {
            var t = new Stopwatch();
            t.Start();
            await Utilities.SetExecutionPolicy();
            var profileCollection = await WindowsFirewallPowershellHelper.FirewallRuleUtilities.GetFirewallProfile();


            foreach (var profile in profileCollection)
            {
                Console.WriteLine($@"{profile.BuildScript}");
            }

            t.Stop();

            Console.WriteLine($@"{profileCollection.Count.ToString()} profiles : elapsed {t.Elapsed}");
        }

        static async Task GetRules()
        {
            var t = new Stopwatch();
            t.Start();

            await Utilities.SetExecutionPolicy();
            var ruleCollection = await FirewallRuleUtilities.GetFirewallRule(
                pWildcard: "TEST",
                pDirection: Enumerations.Direction.Any
            );

            var ruleExtCollection = new ObservableCollection<FirewallRule>();
            var taskList = new List<Task<FirewallRule>>();

            int i = 0;
            foreach (var rule in ruleCollection)
            {
                i++;
                Task<FirewallRule> task = Task.Run(async () => await FirewallRuleUtilities.GetRuleExt(rule));
                taskList.Add(task);

                if (i == 25 || taskList.Count == ruleCollection.Count)
                {
                    Task.WaitAll(taskList.ToArray());

                    foreach (var cTask in taskList)
                    {
                        Console.WriteLine($@"{cTask.Result.BuildScript}");
                        ruleExtCollection.Add(cTask.Result);
                    }
                    i = 0;
                    taskList = new List<Task<FirewallRule>>();
                }
            }

            t.Stop();

            Console.WriteLine($@"{ruleCollection.Count.ToString()} rules : elapsed {t.Elapsed}");
        }

    }
}
