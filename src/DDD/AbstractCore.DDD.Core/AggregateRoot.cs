using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace AbstractCore.DDD.Core
{
    public class Command : IRequest<CommandResult> { }

    public class DomainEvent : INotification { }

    public class CommandResult
    {

    }

    public abstract class AggregateRoot<T> : IRequestHandler<Command, CommandResult>
    {
        private readonly IMediator _mediator;

        public AggregateRoot(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<CommandResult> Handle(Command request, CancellationToken cancellationToken)
        {
            await _mediator.Publish(new DomainEvent());
            return new CommandResult();
        }
    }

    public abstract class DomainEventHandler<T> : INotificationHandler<DomainEvent>
    {
        public Task Handle(DomainEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}