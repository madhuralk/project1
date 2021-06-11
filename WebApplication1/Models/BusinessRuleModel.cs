using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{

    /// <summary>
    /// Model to store the payment type and associated  'n' no.of Business Rules
    /// </summary>
    public class BusinessRules
    {
        [Required]
        public PaymentTypes paymentType { get; set; }

        [Required]
        public List<RuleTypes> ruleType { get; set; }


    }


    /// <summary>
    /// sample model to store the order details
    /// </summary>
    public class Order
    {
        [Required]
        public int OrderID { get; set; }
        [Required]
        public PaymentTypes paymentType { get; set; }
        [Required]
        public string Email { get;set; }
    }


    /// <summary>
    /// Different types of Products for Payment types
    /// </summary>

    public enum PaymentTypes
    {

        Physical_product,
        Book ,
        New_membership ,
        Upgrade_membership,
        Video_learning_to_ski 
    }


    /// <summary>
    /// Various Departments
    /// </summary>
    public enum Departments
    {
        Shipping = 1,
        Royalty = 2,
        Legal = 3,
        Agent = 4,
        Other = 5
    }


    /// <summary>
    /// Business Rules. Add or Remobe the rules dynamically
    /// </summary>

    public enum RuleTypes
    {
        Generate_packing_slip = 1,
        Duplicate_packing_slip = 2,
        Activate_membership = 3,
        Upgrade_Membership = 4,
        Email_Notification = 5,
        Add_Free_First_Aid_Video = 6,
        Generate_commission_Payment_to_Agent = 7
    }
}
