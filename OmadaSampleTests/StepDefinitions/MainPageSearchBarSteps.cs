using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ocaramba;
using OmadaSampleTestsProject.PageObjects;
using TechTalk.SpecFlow;

namespace OmadaSampleTestsProject.StepDefinitions
{
    [Binding]
    public class MainPageSearchBarSteps
    {
        private readonly DriverContext driverContext;
        private readonly ScenarioContext scenarioContext;

        private HomePage homePage;
        private SearchResultsPage searchResultsPage;

        public MainPageSearchBarSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }

            this.scenarioContext = scenarioContext;

            this.driverContext = this.scenarioContext["DriverContext"] as DriverContext;
        }


        [Given(@"I open Omada home page")]
        public void GivenIOpenOmadaHomePage()
        {
            homePage = new HomePage(driverContext);
            homePage.OpenHomePage();
        }
        
        [When(@"I type ""(.*)"" in a searchbar")]
        public void WhenITypeInASearchbar(string phrase)
        {
            searchResultsPage = homePage.SearchForArticle(phrase);
        }
        
        [Then(@"There should be at least one result")]
        public void ThenThereShouldBeAtLeastOneResult()
        {
            var resultsAmount = searchResultsPage.CountResults();
            Assert.IsTrue(resultsAmount >= 1);
        }
        
        [Then(@"The title of the first result should be ""(.*)""")]
        public void ThenTheTitleOfTheFirstResultShouldBe(string expectedTitle)
        {
            var firstResultTitle = searchResultsPage.GetResultTitle(0);
            StringAssert.Contains(firstResultTitle, expectedTitle);
        }
    }
}
