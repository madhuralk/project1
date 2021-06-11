using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.CoreLogic
{

    
    public class ExecuteRules : IExecuteRules
    {


        //Execute the order for every Business Rule dynamically identified and indicate the execution completion

        public async Task<bool> GeneratePackingSlip(Order order)
        {

            bool IsSuccess = true;

            //perform action to generate the packing slip and update the IsSuccess Flag to false in case of any exception

            return IsSuccess;
        }

        public async Task<bool> DuplicatePackingSlip(Order order)
        {

            bool IsSuccess = true;

            //perform action to duplicate packing slip and update the IsSuccess Flag to false in case of any exception

            return IsSuccess;
        }
        public async Task<bool> ActivateMembership(Order order)
        {

            bool IsSuccess = true;

            //perform action to Activate the membership and update the IsSuccess Flag to false in case of any exception

            return IsSuccess;
        }
        public async Task<bool> UpgradeMembership(Order order)
        {

            bool IsSuccess = true;

            //perform action to upgrade membership and update the IsSuccess Flag to false in case of any exception

            return IsSuccess;
        }
        public async Task<bool> VideoLearningToSki(Order order)
        {

            bool IsSuccess = true;

            //perform action to  add free video learning kit and update the IsSuccess Flag to false in case of any exception

            return IsSuccess;
        }

        public async Task<bool> EmailNotification(Order order)
        {

            bool IsSuccess = true;

            //perform action to send email and update the IsSuccess Flag to false in case of any exception

            return IsSuccess;
        }


        public async Task<bool> CommissionToAgent(Order order)
        {

            bool IsSuccess = true;

            //perform action to send commission to Agent and update the IsSuccess Flag to false in case of any exception

            return IsSuccess;
        }

    }
}
