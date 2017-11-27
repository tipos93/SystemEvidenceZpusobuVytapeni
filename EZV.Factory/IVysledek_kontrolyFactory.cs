﻿using EZV.DAOFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZV.Factory
{
    public interface IVysledek_kontrolyFactory
    {
        IVysledek_kontroly CreateVysledekKontroly();
    }
}