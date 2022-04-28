using Microsoft.VisualStudio.TestTools.UnitTesting;
using CaRental.Web.Database.Contracts;
using Moq;
using CaRental.Web.Database.Models;
using AspNetCoreHero.ToastNotification.Abstractions;
using CaRental.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace CaRental.Web.Controllers.Tests
{
	[TestClass()]
	public class LoginControllerTests
	{
		[TestMethod()]
		public void OnLoginSubmitValidLoginTest()
		{
			var databaseServiceMock = new Mock<IDatabaseService>();
			databaseServiceMock.Setup(db => db.GetUserByEmail("user@mock.com")).Returns(new User
			{
				Email = "user@mock.com",
				Password = HashExtensions.ConvertToSha256Hash("password"),
				IsAdmin = false
			});

			var notificationServiceMock = new Mock<INotyfService>();

			var controller = new LoginController(databaseServiceMock.Object, notificationServiceMock.Object);
			controller.ControllerContext = new ControllerContext();
			controller.ControllerContext.HttpContext = new DefaultHttpContext();
			controller.ControllerContext.HttpContext.Session = new Mock<ISession>().Object;

			controller.OnLoginSubmit(new User
			{
				Email = "user@mock.com",
				Password = "password",
				IsAdmin = false
			});

			notificationServiceMock.Verify(mock => mock.Success("You have been logged in successfully!", null), Times.Once());
			notificationServiceMock.Verify(mock => mock.Error(It.IsAny<string>(), It.IsAny<int?>()), Times.Never());
		}

		[TestMethod()]
		public void OnLoginSubmitInvalidPasswordTest()
		{
			var databaseServiceMock = new Mock<IDatabaseService>();
			databaseServiceMock.Setup(db => db.GetUserByEmail("user@mock.com")).Returns(new User
			{
				Email = "user@mock.com",
				Password = HashExtensions.ConvertToSha256Hash("password"),
				IsAdmin = false
			});

			var notificationServiceMock = new Mock<INotyfService>();
			var controller = new LoginController(databaseServiceMock.Object, notificationServiceMock.Object);

			controller.OnLoginSubmit(new User
			{
				Email = "user@mock.com",
				Password = "incorrectpassword",
				IsAdmin = false
			});

			notificationServiceMock.Verify(mock => mock.Success(It.IsAny<string>(), It.IsAny<int?>()), Times.Never());
			notificationServiceMock.Verify(mock => mock.Error("Incorrect password! Please try again.", null), Times.Once());
		}

		[TestMethod()]
		public void OnLoginSubmitUserDoesNotExistsTest()
		{
			var databaseServiceMock = new Mock<IDatabaseService>();
			databaseServiceMock.Setup(db => db.GetUserByEmail("user@mock.com")).Throws(new UserException("User with email (user@mock.com) not found!"));

			var notificationServiceMock = new Mock<INotyfService>();

			var controller = new LoginController(databaseServiceMock.Object, notificationServiceMock.Object);

			controller.OnLoginSubmit(new User
			{
				Email = "user@mock.com",
				Password = "password",
				IsAdmin = false
			});

			notificationServiceMock.Verify(mock => mock.Success(It.IsAny<string>(), It.IsAny<int?>()), Times.Never());
			notificationServiceMock.Verify(mock => mock.Error("User with email (user@mock.com) not found!", null), Times.Once());
		}
	}
}
