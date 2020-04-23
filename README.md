# omadaTask

I have created sample tests using .Net 4.8 with Ocaramba selenium wrapper and Specflow to support BDD. The solution supports Chrome and Firefox browsers. All what is needed to do is a change of a "browser" key in app.config file. I picked those browsers since from my experience they are stable and popular, but in terms of cross-browser testing I would check probably how the site works on IE11 and Safari(i.e. by using Browserstack that Ocaramba is compatible with).

Three tests are automated and one only in a halfway due to captcha 
that should be disabled for automated tests i.e. on test environment.

The documentation for the above is in a form of .feature files in /TestFeatures directory.

Other example test scenario(which should be placed in test management tool i.e. Microsoft Test Manager):

Feature: Contact information

precondition                            | step                             | expected result                                                                                                                                                               |
----------------------------------------| ---------------------------------| ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
Home page opened   | Click on "Contact" in a top bar       | contact site contains address information for Headquarters by default. There is google map visible pointing the office location. Right below there is contact form. There are tabs of other countries |
Contact site opened| Go through each country tab and check if address information are there | each tab contains address information to the office in this country. Each region has google map attached |


Feature: Header menu navigation tests

precondition                            | step                             | expected result                                                                                                                                                               |
----------------------------------------| ---------------------------------| ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
Omada homepage https://www.omada.net is opened | Go to the navigation header menu/main tab section | There are 5 main tabs in navigation header menu. Tabs are located at the middle top of the webpage; Tab names are as follows: <br/> -"Solutions" <br/>-"Business Value" <br/>-"Services" <br/>-"Industries" <br/>-"More" |
  | Hover the mouse on each tab separately | Each tab is active and while hovering the mouse on single tab the drop down menu appears |
   | Hover the mouse outside the modal(tab name) | The drop down menu closes when user hover the mouse outside the modal (tab name) |
   Items selected to check: <br/> "Solutions" tab (links: "Solution Overview", "Microsoft Azure") <br/>"Services" tab (links: "Risk Assessment", "Academy Overview") <br/>"More" tab (links: "Company", "Jobs") | Activate chosen tabs, one by one and check if they contain active menus | Each drop down menu contains the list of active drill downs that were built to re-direct user to another (separate) page  | 
     | Click on each link that have been provided on the test case above | Each of the tested links is responsive and after being clicked by the user opens another(new) webpage|


# Test cases choice justification

Since the site is very complex it requires a lot of testing. 
I assume that:
- it is crucial for the site to have contact information
- law compliance is mandatory - privacy policy (see feature files)
- some presentation about the partnership has high business value as well
- need of working searchbar is self-explanatory

#### It took me around 6-8 hours to do this work, mostly due to struggle to make specflow work.
