using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConexionBD
{
    public class DataStrategy : MainStrategy
    {
        public override StateStrategy Execute()
        {
            ServiceStopwatch.Restart();
            LoggerProvider.Information($"{GetType()} starting job...");
            State = StateStrategy.Execution;

            try
            {
                Process();
                State = StateStrategy.Success;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            ServiceStopwatch.Stop();
            LoggerProvider.Information($"{GetType()} Job completed in {ServiceStopwatch.ElapsedMilliseconds} ms");
            return State;
        }

        public override void Process()
        {
            throw new NotImplementedException($"{GetType().FullName} Method Process not implemented");
        }

        public override async Task<StateStrategy> ExecuteAsync(CancellationToken cancellationToken)
        {
            ServiceStopwatch.Restart();
            LoggerProvider.Information($"{GetType()} starting async job...");
            State = StateStrategy.Execution;

            try
            {
                await ProcessAsync(cancellationToken);
                State = StateStrategy.Success;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            ServiceStopwatch.Stop();
            LoggerProvider.Information($"{GetType()} async job completed in {ServiceStopwatch.ElapsedMilliseconds} ms");
            return State;
        }

        protected override Task ProcessAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException($"{GetType().FullName} Method ProcessAsync not implemented");
        }
    }

}
