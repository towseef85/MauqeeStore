using System;
using Microsoft.AspNetCore.Mvc;
using MStore.Application.Dtos.CustomerDto.AddressDto;
using MStore.Application.CustomerBL.AddressBL;
using Microsoft.Data.SqlClient;

namespace MStore.AdminAPI.Controllers
{
	public class AddressController: BaseApiController
    {
        //     [HttpGet]
            
        //    public async Task<IActionResult> GetData()
        //    {
        //      try
        //     {
        //         List<SqlParameter> l = new List<SqlParameter>();
        //         l.Add(new SqlParameter("@User", DataHelper.GetUserName()));
        //         l.Add(new SqlParameter("@FormId", DataHelper.GetDataFromHeaders(Request, "FormId")));
        //         l.Add(new SqlParameter("@RoutePath", DataHelper.GetDataFromHeaders(Request, "RoutePath")));
        //         l.Add(new SqlParameter("@Lang", DataHelper.GetDataFromHeaders(Request, "Lang")));
        //         l.Add(new SqlParameter("@PageSize", pageSize));
        //         l.Add(new SqlParameter("@PageNumber", pageNumber));
        //         if (!string.IsNullOrEmpty(orderBy))
        //             l.Add(new SqlParameter("@OrderBy", orderBy));
        //         if (!string.IsNullOrEmpty(orderDirection))
        //             l.Add(new SqlParameter("@OrderDirection", orderDirection));
        //         if (!string.IsNullOrEmpty(criteria))
        //             l.Add(new SqlParameter("@Criteria", criteria));

        //         var x = DataHelper.ExecScalar("sys_CitiesGetList", System.Data.CommandType.StoredProcedure, l.ToArray());
        //         if (string.IsNullOrEmpty(x.ToString()))
        //         {
        //             return Content(HttpStatusCode.OK, "");
        //         }
        //         JObject o = JObject.Parse(x.ToString());
        //         return Content(HttpStatusCode.OK, o);
        //     }
        //     catch (Exception ex)
        //     {

        //         return Content(HttpStatusCode.InternalServerError, ex.Message);
        //     }

        //    }
            [HttpGet]
            public async Task<IActionResult> GetList()
            {
                return HandleResult(await Mediator.Send(new List.Query { SubscriptionId = GetSubscriptionId() }));
            }
            [HttpPost]
            public async Task<IActionResult> Create(PostAddressDto Address)
            {
                Address.SubscriptionId = GetSubscriptionId();
                return HandleResult(await Mediator.Send(new Create.Command { Address = Address }));
            }

            [HttpGet("{Id}")]
            public async Task<IActionResult> Details(Guid Id)
            {
                return HandleResult(await Mediator.Send(new Details.Query { Id = Id }));
            }

            [HttpPut("{Id}")]
            public async Task<IActionResult> Edit(PostAddressDto Address)
            {
                Address.SubscriptionId = GetSubscriptionId();
                return HandleResult(await Mediator.Send(new Edit.Command { Address = Address }));
            }

            [HttpDelete("{Id}")]
            public async Task<IActionResult> Delete(Guid Id)
            {
               return HandleResult(await Mediator.Send(new Delete.Command { Id = Id }));
            }


        }
    }

	
