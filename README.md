# create Projet Solution

Run the following command in **_PowerShell_** as Administrator :

```shell
dotnet new sln -n NameSolution
```

---

## NOMBRE MAGIQUE HYBRID

![NOMBRE MAGIQUE](Documents/img/nombreMagique.jpg)

## NOMBRE MAGIQUE SERVER

![NOMBRE MAGIQUE](Documents/img/nombreMagiqueServer.jpg)

## NOMBRE MAGIQUE WASM

![NOMBRE MAGIQUE](Documents/img/nombreMagiqueWASM.jpg)

### Architecture du projet

```
│   .gitattributes
│   .gitignore
│
│
├───NombreMagique.Hybrid
│   │
│   │   MauiProgram.cs
│   │
│   ├───Components
│   │   │   Main.razor
│   │   │   _Imports.razor
│   │   │
│   │   ├───Layout
│   │   │       MainLayout.razor
│   │   │       MainLayout.razor.css
│   │   │
│   │   └───Pages
│   │           Index.razor
│   │
│   ├───Platforms
│   │   ├───Android
│   │   │       AndroidManifest.xml
│   │   │       MainActivity.cs
│   │   │       MainApplication.cs
│   │   │
│   │   ├───iOS
│   │   │   │   AppDelegate.cs
│   │   │   │   Info.plist
│   │   │   │   Program.cs
│   │   │   │
│   │   │
│   │   ├───MacCatalyst
│   │   │       AppDelegate.cs
│   │   │       Entitlements.plist
│   │   │       Info.plist
│   │   │       Program.cs
│   │   │
│   │   │
│   │   └───Windows
│   │           app.manifest
│   │           App.xaml
│   │           App.xaml.cs
│   │           Package.appxmanifest
│   │
│   ├───Properties
│   │       launchSettings.json
│   │
│   ├───Resources
│   │   ├───AppIcon
│   │   │       appicon.svg
│   │   │       appiconfg.svg
│   │   │
│   │   ├───Fonts
│   │   │       OpenSans-Regular.ttf
│   │   │
│   │   ├───Images
│   │   │       dotnet_bot.svg
│   │   │
│   │
│   └───wwwroot
│       │   favicon.ico
│       │   favicon.png
│       │   index.html
│       │   site.css
│       │
│       └───images
│               background.jpg
│               etoile.png
│               life.png
│
├───NombreMagique.Server
│   │   appsettings.Development.json
│   │   appsettings.json
│   │   NombreMagique.Server.csproj
│   │   Program.cs
│   │
│   ├───Components
│   │   │   App.razor
│   │   │   Routes.razor
│   │   │   _Imports.razor
│   │   │
│   │   ├───Layout
│   │   │       MainLayout.razor
│   │   │       MainLayout.razor.css
│   │   │
│   │   └───Pages
│   │           Error.razor
│   │           Home.razor
│   │
│   ├───Properties
│   │       launchSettings.json
│   │
│   └───wwwroot
│       │   favicon.ico
│       │   favicon.png
│       │   site.css
│       │
│       └───images
│               background.jpg
│               etoile.png
│               life.png
│
├───NombreMagique.Shared
│       Game.razor
│       Game.razor.cs
│       NombreMagique.Shared.csproj
│       _Imports.razor
│
└───NombreMagique.WASM
    │   App.razor
    │   NombreMagique.WASM.csproj
    │   Program.cs
    │   _Imports.razor
    │
    ├───Layout
    │       MainLayout.razor
    │
    ├───Pages
    │       Home.razor
    │
    ├───Properties
    │       launchSettings.json
    │
    └───wwwroot
        │   favicon.ico
        │   favicon.png
        │   icon-192.png
        │   index.html
        │   site.css
        │
        └───images
                background.jpg
                etoile.png
                life.png
```
