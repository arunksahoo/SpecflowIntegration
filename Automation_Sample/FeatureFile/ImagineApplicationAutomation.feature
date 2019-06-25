Feature: ImagineApplicationAutomation

Check for the Home page
Also verify the Contact Number For Hyderbad Location

@mytag
Scenario: Redirect to the Imaginea Application do some navigation
	Given User is at the Imaginea HomePage
	And   Click on the Contact button
	Then  Verify the Contact Number For Hyderbad Location
	When  Click on the Works Button
	Then  Verify if User redierct to WORKS page