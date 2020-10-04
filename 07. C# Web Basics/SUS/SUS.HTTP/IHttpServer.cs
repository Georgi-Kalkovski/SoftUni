using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SUS.HTTP
{
    public interface IHttpServer
    {
        Task StartAsync(int port);
    }
}
