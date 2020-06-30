using Domain;
using IServices;
using System;
using System.Collections.Generic;

namespace Services
{
    public class LogService : MarshalByRefObject, ILogService
    {
        public void CreateLog(ServerEvent log)
        {
            throw new NotImplementedException();
        }

        public List<string> GetLog(string filter)
        {
            throw new NotImplementedException();
        }
    }
}
