using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.CoreLogic
{
    public interface IExecuteRules
    {
        Task<bool> GeneratePackingSlip(Order order);
        Task<bool> DuplicatePackingSlip(Order order);
        Task<bool> ActivateMembership(Order order);
        Task<bool> UpgradeMembership(Order order);
        Task<bool> VideoLearningToSki(Order order);
        Task<bool> EmailNotification(Order order);
        Task<bool> CommissionToAgent(Order order);
    }
}
