// <copyright file="HomePage.cs" company="Objectivity Bespoke Software Specialists">
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

using NLog;
using Ocaramba;
using Ocaramba.Extensions;
using Ocaramba.Types;
using Ocaramba.WebElements;
using OmadaSampleTestsProject.Common.Models;

namespace OmadaSampleTestsProject.PageObjects
{
    public class DownloadBrochurePage : ProjectPageBase
    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();

        private readonly ElementLocator firstNameTbx = new ElementLocator(Locator.CssSelector, "[name='581103_110653pi_581103_110653']");
        private readonly ElementLocator lastNameTbx = new ElementLocator(Locator.CssSelector, "[name='581103_110655pi_581103_110655']");
        private readonly ElementLocator businessEmailTbx = new ElementLocator(Locator.CssSelector, "[name='581103_110659pi_581103_110659']");
        private readonly ElementLocator companyTbx = new ElementLocator(Locator.CssSelector, "[name='581103_110657pi_581103_110657']");
        private readonly ElementLocator numberOfEmployeesDpd = new ElementLocator(Locator.CssSelector, "[name='581103_139493pi_581103_139493']");
        private readonly ElementLocator titleTbx = new ElementLocator(Locator.CssSelector, "[name='581103_110663pi_581103_110663']");
        private readonly ElementLocator countryDpn = new ElementLocator(Locator.CssSelector, "[name='581103_110661pi_581103_110661']");
        private readonly ElementLocator acceptPolicyRbtn = new ElementLocator(Locator.CssSelector, "[name='581103_110671pi_581103_110671[]']");
        private readonly ElementLocator notRobotCbx = new ElementLocator(Locator.CssSelector, ".recaptcha-checkbox-border");
        private readonly ElementLocator submitBtn = new ElementLocator(Locator.CssSelector, "input[type='submit']");

        public DownloadBrochurePage(DriverContext driverContext)
            : base(driverContext)
        {
        }

        public void FillUpTheForm(BrochureFormInfo info)
        {
            Driver.SwitchTo().Frame(0);

            Driver.GetElement(firstNameTbx).SendKeys(info.firstName);
            Driver.GetElement(lastNameTbx).SendKeys(info.lastName);
            Driver.GetElement(businessEmailTbx).SendKeys(info.businessEmail);
            Driver.GetElement(companyTbx).SendKeys(info.company);
            Driver.GetElement<Select>(numberOfEmployeesDpd).SelectByText(info.numberOfEmployees);
            Driver.GetElement(titleTbx).SendKeys(info.title);
            Driver.GetElement<Select>(countryDpn).SelectByText(info.country);

            if (info.acceptOmadaPolicy)
            {
                Driver.GetElement(acceptPolicyRbtn).Click();
            }

            Driver.GetElement(submitBtn).Click();

            Driver.SwitchTo().ParentFrame();
        }
    }
}
