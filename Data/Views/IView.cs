using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Views
{
    public interface IView
    {
        object DataObject { get; set; }
    }
}
