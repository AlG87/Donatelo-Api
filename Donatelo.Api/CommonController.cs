using Microsoft.AspNetCore.Mvc;

namespace Donatelo.Api
{
    using ConexionBD;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading;
    using System.Threading.Tasks;

    public class CommonController : Controller
    {
        public IActionResult Execute(MainStrategy mainStrategy)
        {
            try
            {
                mainStrategy.Execute();
                if (mainStrategy.State == StateStrategy.Success)
                {
                    return Ok(mainStrategy.Result);
                }

                if (mainStrategy.State == StateStrategy.Validation)
                {
                    return BadRequest(mainStrategy.Validation);
                }

                return StatusCode(500, mainStrategy.Exception);
            }
            catch (Exception ex)
            {
                LoggerProvider.Fatal(ex.ToString());
                return StatusCode(500, "Error inesperado.");
            }
            finally
            {
                
            }
        }

        public async Task<IActionResult> ExecuteAsync(MainStrategy mainStrategy, CancellationToken token)
        {
            try
            {
                await mainStrategy.ExecuteAsync(token);
                if (mainStrategy.State == StateStrategy.Success)
                {
                    return Ok(mainStrategy.Result);
                }

                if (mainStrategy.State == StateStrategy.Validation)
                {
                    return BadRequest(mainStrategy.Validation);
                }

                return StatusCode(500, mainStrategy.Exception);
            }
            catch (Exception ex)
            {
                LoggerProvider.Fatal(ex.ToString());
                return StatusCode(500, "Error inesperado.");
            }
            finally
            {
                
            }
        }
    }

}
