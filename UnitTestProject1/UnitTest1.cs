using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using WebApplication1.Controllers;
using WebApplication1.Models;

namespace UnitTestProject1
{

    
  [TestClass]
    public class UnitTest1
    { 
        BusinessRulesController _businessRulesController = null;
        OrderResponse successMessage = null;

        OrderResponse FailireMessage = null;


        [TestInitialize]
        public void Initialize()
        {

            _businessRulesController = new BusinessRulesController();
             successMessage = new OrderResponse();
             FailireMessage = new OrderResponse();

            successMessage.Message = "Thank you. Your order has reached us successfully!";
            FailireMessage.Message = "Error in processing the order. Please contact the support team.";
        }

        [TestCleanup]
        public void CleanUp()
        {
            _businessRulesController = null;
        }

        [TestMethod]
        [Description("OrderProcessing")]
        public void Test_OrderProcessing_Book_Success()
        {
            Order order = new Order();
            order.OrderID = 1;
            order.paymentType = PaymentTypes.Book;
            order.Email = "test@gmail.com";

        

            var taskResult = _businessRulesController.OrderProcessing(order);

            var actualResult = taskResult.Result as OkObjectResult;

            //Assert
            Assert.IsNotNull(actualResult.Value);
            Assert.AreEqual(StatusCodes.Status200OK, actualResult.StatusCode);
            Assert.AreEqual(((OrderResponse)actualResult.Value).Message, successMessage.Message);
  


        }


        [TestMethod]
        [Description("OrderProcessing")]
        public void Test_OrderProcessing_NewMemberShip_Success()
        {
            Order order = new Order();
            order.OrderID = 1;
            order.paymentType = PaymentTypes.New_membership;
            order.Email = "test@gmail.com";



            var taskResult = _businessRulesController.OrderProcessing(order);

            var actualResult = taskResult.Result as OkObjectResult;

            //Assert
            Assert.IsNotNull(actualResult.Value);
            Assert.AreEqual(StatusCodes.Status200OK, actualResult.StatusCode);
            Assert.AreEqual(((OrderResponse)actualResult.Value).Message, successMessage.Message);



        }

        [TestMethod]
        [Description("OrderProcessing")]
        public void Test_OrderProcessing_PysicalProduct_Success()
        {
            Order order = new Order();
            order.OrderID = 1;
            order.paymentType = PaymentTypes.Physical_product;
            order.Email = "test@gmail.com";



            var taskResult = _businessRulesController.OrderProcessing(order);

            var actualResult = taskResult.Result as OkObjectResult;

            //Assert
            Assert.IsNotNull(actualResult.Value);
            Assert.AreEqual(StatusCodes.Status200OK, actualResult.StatusCode);
            Assert.AreEqual(((OrderResponse)actualResult.Value).Message, successMessage.Message);



        }

    }
}
