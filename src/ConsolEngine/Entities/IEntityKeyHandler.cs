using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsolEngine
{
    public interface IEntityKeyHandler
    {
        void HandleKey(ConsoleKeyInfo key);
    }
}
