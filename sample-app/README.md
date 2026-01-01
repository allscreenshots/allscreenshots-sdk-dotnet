# Allscreenshots Demo Application

A sample Blazor Server application demonstrating the Allscreenshots .NET SDK.

## Prerequisites

- .NET 8.0 SDK or later
- An Allscreenshots API key

## Setup

1. Set your API key as an environment variable:

   ```bash
   export ALLSCREENSHOTS_API_KEY=your-api-key
   ```

2. Navigate to this directory:

   ```bash
   cd sample-app
   ```

3. Run the application:

   ```bash
   dotnet run
   ```

4. Open your browser to `https://localhost:5001` (or the URL shown in the console).

## Features

- **URL input**: Enter any URL to capture
- **Device selector**: Choose from Desktop HD, iPhone 14, or iPad presets
- **Full page toggle**: Capture the entire scrollable page
- **Screenshot display**: View the captured screenshot directly in the browser
- **Error handling**: User-friendly error messages for common issues

## Usage

1. Enter a URL in the text field (e.g., `https://github.com`)
2. Select a device preset from the dropdown
3. Optionally check "Full page" for full-page captures
4. Click "Take Screenshot"
5. Wait for the screenshot to appear in the result section

## Project structure

```
sample-app/
├── Components/
│   ├── App.razor         # Main application component
│   └── _Imports.razor     # Razor imports
├── Pages/
│   ├── _Host.cshtml       # Host page
│   └── Error.cshtml       # Error page
├── wwwroot/
│   └── css/
│       └── app.css        # Application styles
├── Program.cs             # Application entry point
├── appsettings.json       # Configuration
└── AllScreenshotsDemo.csproj
```

## License

Apache License 2.0. See [LICENSE](LICENSE) for details.
