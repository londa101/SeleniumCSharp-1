Feature: ShoppingCart
	As a visitor on the Shopping Cart application
	I want to search for products
	So that I can buy them

Scenario: Add a product to the cart
	Given user is on the ecommerce page
	When user searches for a product
	And user adds product to cart
	Then user should see the product in their cart

Scenario: Search for products
	Given user is on the ecommerce page
	When user searches for a product
	Then user should see product results