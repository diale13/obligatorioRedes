using Domain;
using System.Collections.Generic;

namespace IServices
{
    public interface ILogService
    {
        void CreateLog(ServerEvent log);
        List<string> GetLog(string filter);

    }
}
