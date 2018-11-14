using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using Xamarin.UITest.Queries;

namespace CreditCardValidator.Droid.UITests
{
	[TestFixture]
	public class Tests
	{
		AndroidApp app;

		[SetUp]
		public void BeforeEachTest()
		{
			app = ConfigureApp
			    .Android
			    .EnableLocalScreenshots()
			    .PreferIdeSettings()
                .ApkFile(@"C:\Projects\Xamarin\CreditCardValidator\CreditCardValidator.Droid\bin\Release\com.xamarin.example.creditcardvalidator-Signed.apk")
                .StartApp();
		}

		[Test]
		public void CreditCardNumber_TooShort_DisplayErrorMessage()
		{
			app.WaitForElement(c => c.Marked("action_bar_title").Text("Enter Credit Card Number"));
			app.EnterText(c=>c.Marked("creditCardNumberText"), new string('9', 15));
			app.Tap(c => c.Marked("validateButton"));

			app.WaitForElement(c => c.Marked("errorMessagesText").Text("Credit card number is too short."));
		}
	}
}

