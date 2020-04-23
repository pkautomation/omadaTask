using System;
using System.Threading.Tasks;
using Ocaramba;
using OmadaSampleTestsProject.Common.Models;
using OmadaSampleTestsProject.PageObjects;
using TechTalk.SpecFlow;

namespace OmadaSampleTestsProject.StepDefinitions
{
    [Binding]
    public class PartnersSteps
    {
        private readonly DriverContext driverContext;
        private readonly ScenarioContext scenarioContext;

        private PartnersPage partnersPage;
        private DownloadBrochurePage downloadBrochurePage;

        public PartnersSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }

            this.scenarioContext = scenarioContext;

            this.driverContext = this.scenarioContext["DriverContext"] as DriverContext;
        }

        [Given(@"I am on partnership page")]
        public void GivenIAmOnPartnershipPage()
        {
            partnersPage = new PartnersPage(driverContext);
            partnersPage.GoToPartnersPage();
        }
        
        [When(@"I click Download button")]
        public void WhenIClickDownloadButton()
        {
            downloadBrochurePage = partnersPage.ClickDownloadBrochureButton();
        }
        
        [When(@"I fill up contact details")]
        public void WhenIFillUpContactDetails()
        {
            downloadBrochurePage.FillUpTheForm(new BrochureFormInfo()
            {
                firstName = "John",
                lastName = "Doe",
                businessEmail = "lorem.ipsum@gmail2.com",
                company = "Frion",
                numberOfEmployees = "0-500",
                title = "Senior Tester",
                country = "Poland",
                acceptOmadaPolicy = true
            });

            throw new NotImplementedException();
        }
        
        [Then(@"The partnership brochure will be downloaded to my pc")]
        public void ThenThePartnershipBrochureWillBeDownloadedToMyPc()
        {
           
        }
    }
}
