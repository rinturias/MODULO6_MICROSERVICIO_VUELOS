using System;
using System.Linq;
using System.Threading.Tasks;
using Aerolinea.Vuelos.Domain.Interfaces;
using Aerolinea.Vuelos.Infrastructure.EF.Contexts;
using MediatR;
using Sharedkernel.Core;

namespace Aerolinea.Vuelos.Infrastructure.EF {
    public class UnitOfWork : IUnitOfWork {
        private readonly WriteDbContext _context;
        private readonly IMediator _mediator;

        public UnitOfWork(WriteDbContext context, IMediator mediator) {
            _context = context;
            _mediator = mediator;
        }

        public async Task Commit() {

            var domainEvents = _context.ChangeTracker.Entries<Entity<Guid>>()
                .Select(x => x.Entity.DomainEvents)
                .SelectMany(x => x)
                .ToArray();

            foreach (var @event in domainEvents) {
                await _mediator.Publish(@event);
            }

            await _context.SaveChangesAsync();


            foreach (var @event in domainEvents) {
                Type type = typeof(ConfirmedDomainEvent<>)
                    .MakeGenericType(@event.GetType());

                var confirmedEvent = (INotification)Activator
                    .CreateInstance(type, @event);


                await _mediator.Publish(confirmedEvent);
            }
        }
    }
}
