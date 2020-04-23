// <copyright file="SmokeTestsSteps.cs" company="Objectivity Bespoke Software Specialists">
// Copyright (c) Objectivity Bespoke Software Specialists. All rights reserved.
// </copyright>
// <license>
//     The MIT License (MIT)
//     Permission is hereby granted, free of charge, to any person obtaining a copy
//     of this software and associated documentation files (the "Software"), to deal
//     in the Software without restriction, including without limitation the rights
//     to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//     copies of the Software, and to permit persons to whom the Software is
//     furnished to do so, subject to the following conditions:
//     The above copyright notice and this permission notice shall be included in all
//     copies or substantial portions of the Software.
//     THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//     IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//     FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//     AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//     LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//     OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//     SOFTWARE.
// </license>

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ocaramba;
using Ocaramba.Extensions;
using OmadaSampleTestsProject.Common.Enums;
using OmadaSampleTestsProject.PageObjects;
using TechTalk.SpecFlow;

namespace OmadaSampleTestsProject.StepDefinitions
{
    [Binding]
    public class SmokeTestsSteps
    {
        private readonly DriverContext driverContext;
        private readonly ScenarioContext scenarioContext;

        private HomePage homePage;
        private PrivacyPolicyPage privacyPolicyPage;
        
        public SmokeTestsSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }

            this.scenarioContext = scenarioContext;

            this.driverContext = this.scenarioContext["DriverContext"] as DriverContext;
        }

        [When(@"I open Omada home page")]
        public void WhenIOpenOmadaHomePage()
        {
            homePage = new HomePage(this.driverContext).OpenHomePage();
        }

        [Then(@"I can see basic home page components")]
        public void ThenICanSeeBasicHomePageComponents()
        {
            Assert.IsTrue(driverContext.Driver.IsElementPresent(homePage.topNavigationSection, (double)Timeouts.Long), "Top section not displayed");
            Assert.IsTrue(driverContext.Driver.IsElementPresent(homePage.footerSection, (double)Timeouts.Long), "Footer section not displayed");
            Assert.IsTrue(driverContext.Driver.IsElementPresent(homePage.searchBar, (double)Timeouts.Long), "Search bar not displayed");
        }

        [When(@"I click on privacy policy link from the footer")]
        public void WhenIClickOnPrivacyPolicyLinkFromTheFooter()
        {
             privacyPolicyPage = homePage.ClickPrivacyPolicyLink();
        }

        [Then(@"I can see Website Privacy Policy document")]
        public void ThenICanSeeWebsitePrivacyPolicyDocument()
        {
            var title = privacyPolicyPage.GetTitle();

            StringAssert.Contains("WEBSITE PRIVACY POLICY", title);
        }

    }
}
