
# InvestmentOptionCalculator---bankend
An ASP.NET CORE 3.1 webapi project

## Development Environment
- Visual Studio 2019 Community
- .NET Core SDK 3.1

## Setup

**1.** Start `InvestmentOptionCalculator.Api` project.
  - **Important:** This must be running on http://localhost:5000, default Url should be http://localhost:5000/docs/index.html

**2.** Start any SPA project.
  - **Important:** This must be running on http://localhost:3000
  

## Auchitecture 
- N-tier Auchitecture (no databse access layer since no db involved)

## Features
- RESTFul API for getting investment options and calculating ROI and Fees 
- Strategy and factory pattern for implementing calculation rules
- Dependency Injection on services
- Fluent validation for server-side model validation
- 3rd-party API services in Libs folder
 


