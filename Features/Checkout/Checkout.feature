Feature: Verify Checkout scenarios
	This feature file contains scenarios to test the checkout feature of the application.

Background:
	Given Login Page is displayed.
	When User enters valid credentials in the login page.
	Then User successfully logs into the application.
	And User is able to view the Product Cards page.

@SmokeTest
Scenario: Checkout any product
	Given Product Cards are displayed on the PDP page.
	And Add to Cart buttons are clickable on the product cards.
	When User clicks Add to Cart button of the first product card.
	And User navigate to Basket Page.