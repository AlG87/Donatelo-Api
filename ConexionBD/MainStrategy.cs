using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConexionBD
{
    public abstract class MainStrategy
    {
        private object result = null;

        private StrategyError error = null;

        public Stopwatch ServiceStopwatch { get; } = new Stopwatch();

        public StateStrategy State { get; set; }

        public object Result
        {
            get
            {
                if (State == StateStrategy.Success)
                {
                    return result;
                }

                throw new StrategyException("El proceso no finalizó correctamente");
            }
        }

        public StrategyError Validation
        {
            get
            {
                if (State != StateStrategy.Validation)
                {
                    return error;
                }

                throw new StrategyException("El proceso no finalizó en validación");
            }
        }

        public StrategyError Exception
        {
            get
            {
                if (State == StateStrategy.Exception)
                {
                    return error;
                }

                throw new StrategyException("El proceso no finalizó en excepción");
            }
        }
        public abstract StateStrategy Execute();

        public abstract void Process();

        public abstract Task<StateStrategy> ExecuteAsync(CancellationToken token);

        protected abstract Task ProcessAsync(CancellationToken token);

        public void SetResult(object result)
        {
            this.result = result;
            State = StateStrategy.Success;
        }

        public void SetValidation(StrategyError error)
        {
            this.error = error;
            State = StateStrategy.Validation;
        }

        public void SetException(StrategyError error)
        {
            this.error = error;
            State = StateStrategy.Exception;
        }

        internal void HandleException(Exception ex)
        {
            if (ex is StrategyException)
            {
                SetException(new StrategyError(4, ex.Message));
                return;
            }

            if (ex is NotImplementedException)
            {
                SetException(new StrategyError(4, ex.Message));
                return;
            }

            if (ex is NullReferenceException)
            {
                SetException(new StrategyError(4, "NullReferenceException: Message - " + ex.Message + " StackTrace " + ex.StackTrace));
                return;
            }

            if (ex is TaskCanceledException)
            {
                SetException(new StrategyError(4, "TimedOut - " + ex.Message));
                return;
            }

            LoggerProvider.Fatal(ex.ToString());
            SetException(new StrategyError(4, "Excepción no controlada. Message: " + ex.Message));
        }
    }

}
