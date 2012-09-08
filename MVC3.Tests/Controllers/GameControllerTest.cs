using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using MVC3;
using MVC3.Controllers;
using MVC3.Models;

/// ==============================================================================
/// NOTE FROM THE PROFESSOR:
/// Be sure to add the service reference in the MVC3.Tests project.  
/// Otherwise, the controller tests will fail.
/// Right-click on your MVC3.Tests project and select "Add Service Reference".
/// Then, copy the entire <system.serviceModel> section from web.config and paste 
/// into the app.config.
/// ==============================================================================

namespace MVC3.Tests.Controllers
{
    [TestClass]
    public class GameControllerTest
    {
        [TestMethod]
        public void CreateStudentTest()
        {
            GameController controller = new GameController();

            // simulate web form posting data
            FormCollection createFormValues = new FormCollection();

            Guid guid = Guid.NewGuid(); // this helps generate a random string for the ID and SSN
            string studentID = guid.ToString().Substring(0, 20);
            createFormValues.Add("ID", studentID);
            createFormValues.Add("FirstName", "Isaac");
            createFormValues.Add("LastName", "Chu");
            createFormValues.Add("SSN", "111223456");
            createFormValues.Add("EmailAddress", "ichu@ucsd.edu");
            createFormValues.Add("Password", "pass1234");

            // Call the form submission to create a new student
            RedirectToRouteResult result = controller.Create(createFormValues) as RedirectToRouteResult;

            // Verify the redirection
            string action = result.RouteValues["action"].ToString();
            Assert.AreEqual("Index", action);

            // let's take a look a the edit page's info for this student ID just created
            ViewResult editViewResult = (ViewResult)controller.Edit(studentID);

            // verify we are preloading the data correctly in the edit view 
            MVC3.Models.PLStudent model = (MVC3.Models.PLStudent)editViewResult.ViewData.Model;
            Assert.AreEqual(studentID, model.ID);
            Assert.AreEqual("Isaac", model.FirstName);
            Assert.AreEqual("Chu", model.LastName);
            Assert.AreEqual("111223456", model.SSN);
            Assert.AreEqual("ichu@ucsd.edu", model.EmailAddress);
            Assert.AreEqual("pass1234", model.Password);

            // let's test the editing of this student
            FormCollection editFormValues = new FormCollection();
            editFormValues.Add("ID", studentID);
            editFormValues.Add("FirstName", "Isaac2");
            editFormValues.Add("LastName", "Chu2");
            editFormValues.Add("SSN", "22334567");
            editFormValues.Add("EmailAddress", "ichu2@ucsd.edu");
            editFormValues.Add("Password", "pass4321");
            result = controller.Edit(studentID, editFormValues) as RedirectToRouteResult;

            // Verify the redirection is back to index page
            action = result.RouteValues["action"].ToString();
            Assert.AreEqual("Index", action);

            // let's verify the edit is successful by looking at the detail view page
            ViewResult detailViewResult = (ViewResult)controller.Details(studentID);

            // verify we are preloading the data correctly in the edit view 
            model = (MVC3.Models.PLStudent)detailViewResult.ViewData.Model;
            Assert.AreEqual(studentID, model.ID);
            Assert.AreEqual("Isaac2", model.FirstName);
            Assert.AreEqual("Chu2", model.LastName);
            Assert.AreEqual("22334567", model.SSN);
            Assert.AreEqual("ichu2@ucsd.edu", model.EmailAddress);

            // now, delete the student we just created
            result = controller.Delete(studentID) as RedirectToRouteResult;
            action = result.RouteValues["action"].ToString();
            Assert.AreEqual("Index", action);
        }
    }
}
