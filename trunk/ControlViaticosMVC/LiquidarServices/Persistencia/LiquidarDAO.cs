﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LiquidarServices.Dominio;

namespace LiquidarServices.Persistencia
{
    public class LiquidarDAO : BaseDAO<Liquidar, int>
    {
    }

    public class LiquidarDetalleDAO : BaseDAO<LiquidarDetalle, LiquidarDetallePK>
    {
    }
}