Feature: The AMS login application
	As a user on the Account Management System application
	I want to login to the application
	So that I can view account information

#Scenarios describe a specific situation or instance
Scenario: The user should should be able to login with good credentials and view their account information
	Given the user is on the account management page
	When the user enters username and password
	Then the user should get a welcome message