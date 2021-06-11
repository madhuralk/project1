using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.CoreLogic
{
    public class DefineRules : IDefineRulesInterface
    {
        ExecuteRules executeRules = new ExecuteRules();
        OrderResponse orderResponse = new OrderResponse();

        /// <summary>
        /// Process the order by  the payment type for items and identify business rules associated dynamically.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public async Task<OrderResponse> ProcessOrder(Order order)
        {

            BusinessRules response = new BusinessRules();
            response.paymentType = order.paymentType;

            List<RuleTypes> ruleTypes = new List<RuleTypes>();

            switch (order.paymentType)
            {
                case PaymentTypes.Physical_product:
                    {
                        ruleTypes.Add(RuleTypes.Generate_packing_slip);

                        break;
                    }

                case PaymentTypes.Book:
                    {
                        ruleTypes.Add(RuleTypes.Duplicate_packing_slip);
                        break;
                    }

                case PaymentTypes.New_membership:
                    {
                        ruleTypes.Add(RuleTypes.Activate_membership);
                        ruleTypes.Add(RuleTypes.Email_Notification);
                        break;
                    }

                case PaymentTypes.Upgrade_membership:
                    {
                        ruleTypes.Add(RuleTypes.Upgrade_Membership);
                        ruleTypes.Add(RuleTypes.Email_Notification);
                        break;
                    }

                case PaymentTypes.Video_learning_to_ski:
                    {
                        ruleTypes.Add(RuleTypes.Add_Free_First_Aid_Video);

                        break;
                    }
                default:
                    {

                        break;
                    }
            }
            response.ruleType = ruleTypes;

            //Call Execute Order method
            var IsSuccess = await CompleteOrder(response.ruleType, order).ConfigureAwait(false);
            if (IsSuccess)
            {
                orderResponse.Message = "Thank you. Your order has reached us successfully!";
            }
            else
            {
                orderResponse.Message = "Error in processing the order. Please contact the support team.";
            }

            //return response back
            return orderResponse;

        }


        /// <summary>
        /// Identify the action to perform based on the business rule type and call corresponding methods
        /// </summary>
        /// <param name="ruleTypes"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public async Task<bool> CompleteOrder(List<RuleTypes> ruleTypes, Order order)
        {

            foreach (var ruleType in ruleTypes)
            {

                bool IsSuccess = false;

                switch (ruleType)
                {
                    case RuleTypes.Activate_membership:
                        {
                            IsSuccess = await executeRules.ActivateMembership(order).ConfigureAwait(false);

                            break;
                        }

                    case RuleTypes.Add_Free_First_Aid_Video:
                        {
                            IsSuccess = await executeRules.VideoLearningToSki(order).ConfigureAwait(false);

                            break;
                        }


                    case RuleTypes.Duplicate_packing_slip:
                        {
                            IsSuccess = await executeRules.DuplicatePackingSlip(order).ConfigureAwait(false);

                            break;
                        }


                    case RuleTypes.Email_Notification:
                        {
                            IsSuccess = await executeRules.EmailNotification(order).ConfigureAwait(false);

                            break;
                        }


                    case RuleTypes.Generate_commission_Payment_to_Agent:
                        {
                            IsSuccess = await executeRules.CommissionToAgent(order).ConfigureAwait(false);

                            break;
                        }


                    case RuleTypes.Generate_packing_slip:
                        {
                            IsSuccess = await executeRules.GeneratePackingSlip(order).ConfigureAwait(false);

                            break;
                        }

                    case RuleTypes.Upgrade_Membership:
                        {
                            IsSuccess = await executeRules.UpgradeMembership(order).ConfigureAwait(false);

                            break;
                        }

                }

                if (!IsSuccess)
                {

                    //perform logging and notify the same to caller
                }



            }
            return true;

        }
    }
}
