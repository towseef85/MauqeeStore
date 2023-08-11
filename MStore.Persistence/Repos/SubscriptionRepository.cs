using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MStore.Application.Dtos.SubscriptionDtos;
using MStore.Application.Interfaces;
using MStore.Domain.Entities.Identities;
using MStore.Domain.Entities.Subscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MStore.Persistence.Context;

namespace MStore.Persistence.Repos
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly UserManager<AppUsers> _userManager;
        public readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        public SubscriptionRepository(ApplicationDbContext context, RoleManager<IdentityRole> roleManager, UserManager<AppUsers> userManager, IMapper mapper)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<bool> AddSubscription(PostSubscriptionDto PostSubscriptionDto, CancellationToken cancellationToken)
        {
            var userExists = await _userManager.FindByEmailAsync(PostSubscriptionDto.Email);
            if (userExists == null)
            {
                _context.Subscriptions.Add(_mapper.Map<Subscription>(PostSubscriptionDto));
                var result = await _context.SaveChangesAsync(cancellationToken) > 0;
                if (result)
                {
                var user = new AppUsers
                {
                    EngName = PostSubscriptionDto.EngName,
                    Email = PostSubscriptionDto.Email,
                    ArbName = PostSubscriptionDto.ArbName,
                    UserName = PostSubscriptionDto.UserName,
                    UserType = "Subscriber",
                    SubscriptionId= PostSubscriptionDto.Id
                };

                IdentityResult identityResult = await _userManager.CreateAsync(user, PostSubscriptionDto.Password);
                if (identityResult.Succeeded)
                {

                        //var role = new IdentityRole
                        //{
                        //    Name = "Subscriber"
                        //};

                        //await _roleManager.CreateAsync(role);
                        await _userManager.AddToRoleAsync(user, "Subscriber");
                    return true;
                   
                }
                }
            }
            return false;
        }

        public Task<bool> DeleteSubscription(Guid SubscriptionId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GetSubscriptionDto>> GetAllSubscription()
        {
            var result = await _context.Subscriptions.Include(x=>x.Plans).Include(x=>x.Users).ToListAsync();

            var resultData = _mapper.Map<List<GetSubscriptionDto>>(result);
            return resultData;
        }

        public Task<GetSubscriptionDto> GetSubscriptionById(Guid SubscriptionId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateSubscription(PostSubscriptionDto PostSubscriptionDto)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddPlan(PostPlanDto postPlanDto, CancellationToken cancellationToken)
        {
            _context.Plans.Add(_mapper.Map<Plans>(postPlanDto));
            var result = await _context.SaveChangesAsync(cancellationToken) > 0;
            return result;
        }
    }
}
