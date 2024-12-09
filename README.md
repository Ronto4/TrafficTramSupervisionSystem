# Traffic Tram Supervision System

This is a C# interface for the Traffic Tram Supervision System (TTSS).
TTSS is known to be used by the public transit operators in Kraków (PL) and Potsdam (DE).
It allows operators to provide real-time information about their vehicles and trips to customers.

This project is created in a similar fashion as the equivalent Python project at <https://github.com/tomekzaw/ttss>.

## Usage

### Installation

The TTSS Client is available via Nuget at <https://www.nuget.org/packages/TtssClient>.

### API routes

This client supports most but not all TTSS routes.
Have a look at [`./TtssClient/TtssApi.cs`](./TtssClient/TtssApi.cs) for supported routes.
