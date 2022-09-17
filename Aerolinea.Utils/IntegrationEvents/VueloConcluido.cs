using System;
using Sharedkernel.Core;

namespace Sharedkernel.IntegrationEvents {
    public record VueloConcluido : IntegrationEvent {
        public DateTime horaLLegada { get; set; }
        public string estado { get; set; }
        public decimal precio { get; set; }
        public DateTime fecha { get; set; }
        public Guid vueloId { get; set; }

    }
}

