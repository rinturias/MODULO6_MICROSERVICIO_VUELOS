using System;
using Sharedkernel.Core;

namespace Sharedkernel.IntegrationEvents {
    public record VueloConcluido : IntegrationEvent {
        public DateTime horaLLegada { get; set; }
        public string estado { get; set; }
        public decimal precio { get; set; }
        public string fechaInicio { get; set; }
        public Guid vueloId { get; set; }
        public DateTime horaConcluido { get; set; }
        public string fechaConcluido { get; set; }

    }
}

