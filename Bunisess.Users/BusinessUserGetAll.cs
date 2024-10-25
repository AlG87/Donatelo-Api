using ConexionBD;
using Data.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunisess.Users
{
    public class BusinessUserGetAll : BusinessStrategy
    {
        

        public BusinessUserGetAll()
        {
            
        }
        protected override void Validate()
        {
            
        }
        public override void Process()
        {
            DataUserGetAll dataUserGetAll = new DataUserGetAll();

            if (dataUserGetAll.Execute() != StateStrategy.Success)
            {
                SetException(dataUserGetAll.Exception);

            }
            else
            {
                SetResult(dataUserGetAll);
            }
        }
    }
}
