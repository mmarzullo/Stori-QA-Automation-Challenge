# Stori-QA-Automation-Challenge UI Automated tests Repository

This repository holds of the automated tests for https://rahulshettyacademy.com/AutomationPractice/

#### Prerequisites

- Make sure to have [.NET 6.0](https://dotnet.microsoft.com/download/dotnet-core) installed.
- Make sure you have the browsers in which you want to run the tests.

#### Usage

1. Launch a Web Application from Visual Studio, making sure to select the desired Solution:
2. You can run the tests from the Test Explorer sale.
3. You can change the browser on the file Config/Enviroment.json

* Alternatively, you can open the Command Prompt (CMD), navigate to the solution folder and run these commands:
```sh
        dotnet test --verbosity:d
```

** For a specific browser you should use:
```sh
        SET DriverType=Firefox
        dotnet test --verbosity:d
```

** For a specific test you can use:
```sh
        dotnet test --verbosity:d --filter DisplayName="Task 5"
```
- You can check the [dotnet test](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-test).
