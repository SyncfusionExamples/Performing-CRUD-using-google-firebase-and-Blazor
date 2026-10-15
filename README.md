# Blazor DataGrid CRUD Operations with Google Firebase

## Overview

This sample demonstrates how to perform create, read, update, and delete (CRUD) operations in a Syncfusion [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) backed by Google Firebase. The application uses a Web API endpoint as the data service layer and connects the grid to remote data through `SfDataManager`.

The sample shows how users can manage records directly from the grid interface using built-in editing commands. By combining Blazor, Syncfusion components, and Firebase, the project provides a practical example of building a cloud-connected data management application.

## Key Features

- Uses `SfGrid<Order>` as the primary data presentation component.
- Enables paging through the `AllowPaging="true"` property.
- Provides built-in toolbar actions using:
  - `Add`
  - `Edit`
  - `Delete`
  - `Cancel`
  - `Update`
- Configures CRUD editing through `GridEditSettings`.
- Enables record creation, modification, and removal with:
  - `AllowAdding="true"`
  - `AllowEditing="true"`
  - `AllowDeleting="true"`
- Uses dialog-based editing via `Mode="EditMode.Dialog"`.
- Connects to remote Web API services through `SfDataManager`.
- Uses `Adaptors.WebApiAdaptor` for server communication.
- Defines a primary key column using:
  - `Field="OrderId"`
  - `IsPrimaryKey="true"`
  - `IsIdentity="true"`
- Displays order data including fields such as `OrderId` and `ShipCountry`.
- Retrieves and updates data through the `api/Order` endpoint.

## Prerequisites

- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or [Visual Studio Code](https://code.visualstudio.com/)
- [.NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet) compatible with the project's target framework

## How to Run the Project

**Visual Studio 2022**

1. Clone or download this repository.
2. Open `GoogleFirebase.sln`.
3. Restore NuGet packages.
4. Ensure the `GoogleFirebase` project is selected as the startup project.
5. Build the solution.
6. Run the application using **Ctrl+F5**.

**Visual Studio Code**

1. Open the repository folder in Visual Studio Code.
2. Open a terminal in the project root.
3. Restore packages:

```bash
dotnet restore
```

4. Run the application:

```bash
dotnet run
```

5. Open the application URL displayed in the console after startup.

## Project Structure

- `Pages/Index.razor` - Hosts the Syncfusion Blazor DataGrid and configures remote CRUD operations using `SfDataManager` and `WebApiAdaptor`.
- `Controller/OrderController.cs` - ASP.NET Core Web API controller that exposes CRUD endpoints consumed by the DataGrid.
- `DataAccess/OrderDataAccessLayer.cs` - Implements Firestore database operations including document creation, retrieval, update, and deletion.
- `Interface/IOrder.cs` - Defines the contract for order management operations used by the data-access layer.
- `Models/Order.cs` - Firestore-enabled data model containing order properties and validation attributes.
- `Data/` - Contains application data services and supporting sample data classes.

## Support and Feedback

- For general product questions, visit the [Syncfusion Community Forum](https://www.syncfusion.com/forums) or [Syncfusion Support](https://www.syncfusion.com/support).
- To report an issue specific to this sample, open a GitHub issue in this repository.
- For DataGrid documentation, see https://help.syncfusion.com/grid-sdk/blazor/data-grid/getting-started

## License

This is a Syncfusion sample project provided to demonstrate product usage. Review the [Syncfusion license terms](https://www.syncfusion.com/sales/pricing?category=ui-components) before using Syncfusion components in your own applications.