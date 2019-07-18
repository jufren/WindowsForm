using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSocketSample
{
    public interface SC8131MessageEventHandler
    {
        void OnEventMessageReceived(int totalIn, int totalOut, int zoneTotalIn);
    }
}
