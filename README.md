# Stripe C# Integration with a basic form

This VS MVC solution contains a basic HTML form and a set of models and controllers that allows the user to submit a payment to a Stripe account.

A requirement to use this integration is Stripe.net NuGet https://www.nuget.org/packages/Stripe.net/ v6.2.2.

## Setup

Modify the following key/value pair in the Web.config `appSettings` node and replace the value with the one from your Stripe account.

``` xml

<add key="StripeApiKey" value="ADD_API_KEY_HERE" />

```

Build and run project.