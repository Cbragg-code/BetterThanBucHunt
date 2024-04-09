using NUnit.Framework;

namespace BucStop.Tests
{
    /// <summary>
    /// Contains regression tests for the BucStop application.
    /// </summary>
    [TestFixture]
    public class RegressionTest : TestSetup
    {
        private TestActions actions;

        /// <summary>
        /// Overrides the SetUp method from the TestSetup class.
        /// This method is called before each test method runs.
        /// </summary>
        public override void SetUp()
        {
            base.SetUp();
            actions = new TestActions(driver, baseUrl);
        }

        /// <summary>
        /// Navigates BucStop and tests functionality.
        /// </summary>

        [Test]
        public void NavBucStop()
        {
            actions.NavigateTo("Account/Login");
            actions.PerformLogin("Test@etsu.edu");
            actions.AssertCurrentPage(""); // Home page

            actions.NavigateTo("Games");
            actions.AssertCurrentPage("Games");

            actions.NavigateTo("Home/AUP");
            actions.AssertCurrentPage("Home/AUP");

            actions.NavigateTo("Home/GameCriteria");
            actions.AssertCurrentPage("Home/GameCriteria");

            actions.NavigateTo("Home/About");
            actions.AssertCurrentPage("Home/About");
        }
    }
}
