# blood_flow

A new Flutter project. This project is hosted on Azure and can be accessed at [Blood Flow Presentation Layer](https://bloodflowpresentaionlayer20240428063721.azurewebsites.net/).

## Getting Started

This project is a starting point for a Flutter application.

### Overview of BloodFlow
BloodFlow is designed to enhance the blood donation system, facilitating efficient connections between donors and blood collection points. It features an intuitive interface that helps donors easily find nearby centers in need and view current blood requests by type and volume. Blood collection points can post announcements for donor needs, ensuring timely responses to critical situations.

### Architecture
BloodFlow employs a monolithic architecture that integrates various layers for reliability and performance:
- **Business Layer**: Equipped with services like `IDonorService` and `IOrderService`, this layer manages business logic including donor data and blood orders.
- **Data Layer**: Utilizes Entity Framework for database interactions, ensuring efficient data handling.

### Key Features
- **Registration for donors and blood centers**: Users can create profiles containing all necessary information for participating in blood donation.
- **Search and selection of blood collection points**: An interactive map allows donors to locate centers in need, displaying detailed information about each.

### Running the Application
Since the API and database are hosted on Azure, no local server setup is required. To run the application in Visual Studio:
1. Clone the repository.
2. Open the solution in Visual Studio.
3. Ensure the connection strings in `appsettings.json` are set to point to the Azure-hosted database.
4. Build and run the solution using the built-in Visual Studio tools like IIS or Kestrel.

### Running Flutter Application
To run the Flutter application:
1. Ensure you have Flutter installed and environment paths set up.
2. Open a terminal or command prompt.
3. Navigate to the project directory.
4. Run `flutter pub get` to install dependencies.
5. Run `flutter run` to start the application on an emulator or connected device.

A few resources to get you started if this is your first Flutter project:
- [Lab: Write your first Flutter app](https://docs.flutter.dev/get-started/codelab)
- [Cookbook: Useful Flutter samples](https://docs.flutter.dev/cookbook)

For help getting started with Flutter development, view the
[online documentation](https://docs.flutter.dev/), which offers tutorials,
samples, guidance on mobile development, and a full API reference.
