using MediatR;
using Persistance.Entities;
using Persistance.Interfaces;

namespace Persistance.Mediators;
public class OnNewStudentAddedCommandHandler : IRequestHandler<OnNewStudentAddedCommand>
{
    private readonly IAdminstrationService _adminstrationService;

    public OnNewStudentAddedCommandHandler(IAdminstrationService adminstrationService)
    {
        _adminstrationService = adminstrationService;
    }
    public Task Handle(OnNewStudentAddedCommand request, CancellationToken cancellationToken)
    {
       
        _adminstrationService.OnNewStudentAdded(request);

        Console.WriteLine("Handler exuceted Successfully");

        return Task.CompletedTask;
    }
}

