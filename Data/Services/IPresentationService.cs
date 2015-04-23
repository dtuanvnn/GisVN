using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public interface IPresentationService
    {
        double VirtualscreenWidth { get; }
        double VirtualScreenHeight { get; }

        void InitializeCultures();
    }
}
