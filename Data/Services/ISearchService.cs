﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public interface ISearchService : INotifyPropertyChanged
    {
        object SearchGiayView { get; }
    }
}
