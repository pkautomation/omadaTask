Feature: Partners
	In order to become a partner
	As a potential partner
	I want get to know more about partnership

Scenario: Get partnership brochure
	Given I am on partnership page
	When I click Download button
	And I fill up contact details
	Then The partnership brochure will be downloaded to my pc
