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

using System;
using System.Globalization;
using NLog;
using Ocaramba;
using Ocaramba.Extensions;
using Ocaramba.Types;

namespace OmadaSampleTestsProject.PageObjects
{
    public class PartnersPage : ProjectPageBase
    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();

        private readonly ElementLocator downloadBtn = new ElementLocator(Locator.CssSelector, ".oneliner__button");
        private readonly ElementLocator cookieCloseBtn = new ElementLocator(Locator.CssSelector, "[data-init='cookiebar'] span");

        public PartnersPage(DriverContext driverContext)
            : base(driverContext)
        {
        }

        public DownloadBrochurePage ClickDownloadBrochureButton()
        {
            Driver.GetElement(downloadBtn).Click();
            
            return new DownloadBrochurePage(DriverContext);
        }

        public void GoToPartnersPage()
        {
            string path = @"/more/omada-partner-program";
            var url = $"{BaseConfiguration.GetUrlValue}{path}";
            Logger.Info(CultureInfo.CurrentCulture, "Opening page {0}", url);
            this.Driver.NavigateTo(new Uri(url));

            Driver.GetElement(cookieCloseBtn).Click();
        }
    }
}
