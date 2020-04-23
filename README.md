# omadaTask

I have created sample tests using .Net 4.8 with Ocaramba selenium wrapper and Specflow to support BDD.

Three tests are automated and one only in a halfway due to captcha 
that should be disabled for automated tests i.e. on test environment

The documentation for the above is in a form of .feature files in /TestFeatures directory

Other test scenarios(which should be placed in test management tool i.e. Microsoft Test Manager):

Feature: Contact information
 step 1: Open home page						result: home page openened
 step 2: Click on "Contact" in a top bar	result: contact site contains address information for Headquarters by default. There is google map visible pointing the office location. Right below there is contact form

#Test cases choice justification

Since the site is very complex it requires a lot of testing. 
I assume that:
- it is crucial for the site to have contact information (see above test)
- law compliance is mandatory - privacy policy (see feature files)
- some presentation about the partnership has high business value as well
- need of working searchbar is self-explanatory