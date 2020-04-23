using Ocaramba;
using Ocaramba.Extensions;
using Ocaramba.Types;

namespace OmadaSampleTestsProject.PageObjects
{
    public class SearchResultsPage : ProjectPageBase
    {
        public SearchResultsPage(DriverContext driverContext)
            : base(driverContext)
        {
        }

        public readonly ElementLocator searchResults = new ElementLocator(Locator.CssSelector, ".search-results__item");

        public int CountResults()
        {
            Driver.GetElement(searchResults, 5);

            return Driver.GetElements(searchResults).Count;
        }

        public string GetResultTitle(int index)
        {
            var result = Driver.GetElements(searchResults)[index];

            return result.GetElement(new ElementLocator(Locator.CssSelector, "a")).Text;
        }
    }
}
