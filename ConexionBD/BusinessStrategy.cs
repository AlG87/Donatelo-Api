using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConexionBD
{
    public class BusinessStrategy : MainStrategy
    {
        public override StateStrategy Execute()
        {
            ServiceStopwatch.Restart();
            State = StateStrategy.Execution;

            try
            {
                Validate();
                if (State != StateStrategy.Execution)
                {
                    Process();
                }
            }
            catch (Exception ex)
            {
                HandleException(ex); 
            }

            ServiceStopwatch.Stop(); 
            return State; 
        }
        protected virtual void Validate()
        {
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
                await ValidateAsync();
                if (State == StateStrategy.Execution)
                {
                    await ProcessAsync(cancellationToken);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            ServiceStopwatch.Stop();
            LoggerProvider.Information($"{GetType()} async job completed in {ServiceStopwatch.ElapsedMilliseconds} ms");
            return State;
        }
        protected virtual Task ValidateAsync()
        {
            return Task.CompletedTask; 
        }

        protected override Task ProcessAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException($"{GetType().FullName} Method ProcessAsync not implemented");
        }
    }

}
