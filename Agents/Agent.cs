namespace Agents
{
    using System;
    using Ingeniance.Core;

    public class Agent : AgentBase
    {
        protected override void DoWork(params string[] args)
        {
            Console.Clear();
            DateTime dat = DateTime.Now;
            Console.WriteLine("\nToday is {0:d} at {0:T}.", dat);
        }
    }
}
