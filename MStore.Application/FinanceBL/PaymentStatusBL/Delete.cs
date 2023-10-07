using MediatR;
using MStore.Application.Core;
using MStore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Application.FinanceBL.PaymentStatusBL
{
    public class Delete
    {
        public class Command : IRequest<ServiceStatus<Unit>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Command, ServiceStatus<Unit>>
        {
            private readonly IPaymentStatusRepository _iPaymentStatusRepo;
            public Handler(IPaymentStatusRepository iPaymentStatusRepo)
            {
                _iPaymentStatusRepo = iPaymentStatusRepo;
            }

            public async Task<ServiceStatus<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {

                var result = await _iPaymentStatusRepo.DeletePaymentStatus(request.Id);
                return result;
            }
        }
    }
}
