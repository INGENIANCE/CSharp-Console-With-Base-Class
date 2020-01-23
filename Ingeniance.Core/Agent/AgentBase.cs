namespace Ingeniance.Core
{
    using System;
    using System.Linq;
    using Enumerations;

    public abstract class AgentBase
    {
        /// <summary>
        /// The status
        /// </summary>
        private AgentStatus status = AgentStatus.Pending;

        /// <summary>
        /// Initializes static members of the <see cref="AgentBase"/> class.
        /// </summary>
        static AgentBase()
        {
        }

        /// <summary>
        /// Get or set the status.
        /// </summary>
        public AgentStatus Status
        {
            get { return this.status; }
            set
            {
                if ((this.status > value && value > AgentStatus.Success) || this.status <= AgentStatus.Success)
                {
                    this.status = value;
                }
            }
        }

        /// <summary>
        /// Run the instance.
        /// </summary>
        /// <param name="args">The arguments</param>
        /// <returns>
        /// The status when the job stops.
        /// </returns>
        public int Run(params string[] args)
        {
            try
            {
                // Does the job.
                this.DoWork(args);

                this.status = AgentStatus.Success;
            }
            catch (Exception ex)
            {
                this.status = AgentStatus.Error;
                Console.WriteLine(ex);
            }

            if (args != null && args.Any(a => string.Equals(a, "console", StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Agent status: " + this.status.ToString());
                Console.WriteLine("Press enter to quit. ");
                Console.ReadLine();
            }

            return (int)this.status;
        }

        /// <summary>
        /// Does the work.
        /// </summary>
        /// <param name="args">The arguments.</param>
        protected abstract void DoWork(params string[] args);
    }
}
