using MStore.Application.Dtos.SubscriptionDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Application.Interfaces
{
    public interface ISubscriptionRepository
    {
        Task<List<GetSubscriptionDto>> GetAllSubscription();
        Task<GetSubscriptionDto> GetSubscriptionById(Guid SubscriptionId);
        Task<bool> AddSubscription(PostSubscriptionDto PostSubscriptionDto, CancellationToken cancellationToken);
        Task<bool> AddPlan(PostPlanDto postPlanDto, CancellationToken cancellationToken);
        Task<bool> UpdateSubscription(PostSubscriptionDto PostSubscriptionDto);
        Task<bool> DeleteSubscription(Guid SubscriptionId);
    }
}
