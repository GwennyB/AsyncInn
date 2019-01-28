# AsyncInn
This ASP.NET Core MVC web application is a full-CRUD SQL Server based room 'inventory' management system for a fictional hotel chain. 

# Installation
1. Clone this repo.
2. Open /AsyncInn/AsyncInn/AsyncInn.csproj (in Visual Studio 2017 or later).
3. Build database:
   - Open NuGet Package Manager Console (Tools > NuGet Package Manager > Package Manager Console):
      PM> Add-Migration initial
   - Confirm DB build in SQL Object Explorer (look for 'AsyncInn')
4. Launch page by pressing green arrow in 'Standard' toolbar with 'IIS Express' selected.

# Architecture
MODEL - The classes define the data model. They are built to the database schema.  See "Database Schema" below for more detail.

VIEW - This application uses Razor syntax to inject model data into HTML view templates.

CONTROLLER - Controllers exist for the splash page ('Home') and each (non-enum) table listed in the database schema. Each contains CRUD features to permit all allowed database data manipulation (some CRUD features are excluded for to support business rules (such as editing an amenity)).

## Database Schema
Inventory
This table lists every room available in the entire Async Inn network of hotels. Each record in this table assigns a RoomConfig to a Hotel, and it sets location- and room-specific rules (such as room number, pricing, pets policy, and locally relevant room name). Rooms are identified by composite of HotelID and RoomNumber.

RoomPlan
This table groups a RoomConfig (ie – collection of amenities) to Layout and assigns that configuration to primary key RoomPlanID for reference in the Inventory table.

RoomConfig
This table associates amenities (AmenityID) to RoomPlan to fully configure a room. It is strictly intended to relate the room configurations to the amenities (ie – pure join), so it does not assign a unique identifier to each record.

Amenity
This table lists available room amenities and gives them unique identifiers (AmenityID). It is referenced by RoomConfig table to build up room configurations.

Hotel
This table identifies unique hotels and assigns them unique identifiers (primary = HOTEL_ID). It associates location name, address, and region (LOC_ID) details for each. The primary key is referenced by the Inventory table to associate specific rooms to locations.

Layouts (Enum)
This table standardizes nomenclature for the 3 available room formats (1-bedroom, 2-bedroom, studio), which is referenced by RoomPlan to associate with room configurations. 
States (Enum), Country (Enum)
This table standardizes abbreviations for states and relevant countries in the US for use in identifying locations in Hotel.

![database schema](assets/schema.png)

# Usage
Shown below are landing (default) pages for each table's interface.
Home/Index:
![home page](assets/run-home.png)

Inventory/Index:
![home page](assets/run-inventory.png)

RoomPlan/Index:
![home page](assets/run-roomplan.png)

RoomConfig/Index:
![home page](assets/run-roomconfig.png)

Amenity/Index;
![home page](assets/run-amenity.png)

Hotel/Index;
![home page](assets/run-hotel.png)


# Credit
Logo graphics: https://www.freeiconspng.com/img/25314

# License
MIT License

Copyright (c) 2019 Gwendolyn Zubatch

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
