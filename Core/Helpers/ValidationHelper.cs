using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers
{
    public static class ValidationHelper
    {
        public static void ThrowNullException(object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(value.ToString());
            }
        }
    }
}
