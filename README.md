# payblast-purchases-unity

Payblast Unity purchases SDK

This repository does not vendor RevenueCat source. The public API shape is studied from [https://github.com/RevenueCat/purchases-unity](https://github.com/RevenueCat/purchases-unity) and reimplemented against Payblast.

## Contract

```text
configure(apiKey, appUserId)
logIn(appUserId) / logOut()
getOfferings()
purchase(package)
restore()
getCustomerInfo()
presentPaywall(offering?)
```

`getCustomerInfo` exposes `entitlements[lookupKey].isActive`. Packages carry the store product identifier for this SDK's platform. Purchases of digital goods inside the native app go through that store. Web purchases use Stripe Checkout on the app maker's connected account.

## Tests

Headless contract tests:

```bash
dotnet test
```

Unity Editor edit-mode tests: put `PurchasesTests.cs` under `Assets/Payblast/Editor/` in a Unity project that references `Purchases.cs`. The Editor test runner executes the same `[Fact]` cases in edit mode. This repository runs them with `dotnet test` when the Unity Editor is not installed. The edit-mode path does not call the Unity Player or a store sandbox.

## Reference

- https://github.com/RevenueCat/purchases-unity
