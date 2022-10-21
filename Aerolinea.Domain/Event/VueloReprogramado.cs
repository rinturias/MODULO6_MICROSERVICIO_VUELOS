﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aerolinea.Vuelos.Domain.Entities;
using Sharedkernel.Core;

namespace Aerolinea.Vuelos.Domain.Event {
    public class VueloReprogramado : DomainEvent {

        public VueloReprogramado(Vuelo vuelo, DateTime occuredOn) : base(occuredOn) {

            vueloReprogramado = vuelo;

        }

        public Vuelo vueloReprogramado { get; set; }
    }
}
