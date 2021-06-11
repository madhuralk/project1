/*
 * API to call from your local host - /api/BusinessRules/OrderProcessing
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.CoreLogic;

namespace WebApplication1.Controllers
{
    [Route("api/BusinessRules")]
    [ApiController]
    public class BusinessRulesController : ControllerBase
    {


        [HttpPost("OrderProcessing")]
        public async Task<IActionResult> OrderProcessing([FromBody] Order order)
        {
            DefineRules defineRules = new  DefineRules();
            OrderResponse orderSummary = await defineRules.ProcessOrder(order).ConfigureAwait(false);

            return Ok(orderSummary);

        }

       
    }
}
