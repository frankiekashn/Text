using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace TextSample.UITests
{
	[TestFixture (Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;

		public Tests (Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest ()
		{
			app = AppInitializer.StartApp(platform);
		}

		[Test]
		public void WelcomeTextIsDisplayed ()
		{
			app.WaitForElement(ListPage.DemoTitle);
			AppResult[] results1 = app.WaitForElement(ListPage.EditorDemoXAML);
			AppResult[] results2 = app.WaitForElement(ListPage.EditorDemoCode);
			app.Screenshot ("Main View");
			Assert.IsTrue (results1.Any() && results2.Any());
		}
	}

	public class ListPage
	{
		public static readonly Func<AppQuery, AppQuery> DemoTitle = c => c.Marked("Text Demo").Class("TextSample.ListPage");
		public static readonly Func<AppQuery, AppQuery> EditorDemoXAML = c => c.Class("TextSample.EditorPage").Marked("Editor Demo - XAML");
		public static readonly Func<AppQuery, AppQuery> EditorDemoCode = c => c.Class("TextSample.EditorPage").Marked("Editor Demo - Code");
	}

	public class ListItem
	{
		static string Title { get; set; }
		static string ItemClass { get; set; }
		Func<AppQuery, AppQuery> MobileItem = c => c.Class(ItemClass).Marked(Title);
	}

}

