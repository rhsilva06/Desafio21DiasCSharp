﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula09.Models
{
    public struct ContaCorrente
    {
        public string ClienteId { get; set; }
        public double Valor { get; set; }
        public DateTime Data { get; set; }
    }
}
