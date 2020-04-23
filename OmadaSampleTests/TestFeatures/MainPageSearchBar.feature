Feature: MainPageSearchBar
	In order to find information in page quickly
	I want to be able to find information by a search engine

Scenario: Find specific article
	Given I open Omada home page
	When I type "Omada Academy" in a searchbar
	Then There should be at least one result
	And The title of the first result should be "Omada Academy"
