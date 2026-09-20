# Nombre Magique

Projet .NET composé de plusieurs clients utilisant une logique partagée :

- **NombreMagique.Hybrid** : application .NET MAUI Blazor Hybrid
- **NombreMagique.Server** : application ASP.NET Core / Blazor Server
- **NombreMagique.WASM** : application Blazor WebAssembly
- **NombreMagique.Shared** : composants et logique partagés

Le projet utilise **.NET 9**.

---

# Création de la solution

Exécuter la commande suivante dans **PowerShell** :

```shell
dotnet new sln -n NombreMagique
```

---

## NOMBRE MAGIQUE HYBRID

![NOMBRE MAGIQUE](Documents/img/nombreMagique.jpg)

---

## NOMBRE MAGIQUE SERVER

![NOMBRE MAGIQUE](Documents/img/nombreMagiqueServer.jpg)

---

## NOMBRE MAGIQUE WASM

![NOMBRE MAGIQUE](Documents/img/nombreMagiqueWASM.jpg)

---

# Docker

Le projet `NombreMagique.Server` peut être exécuté dans un conteneur Docker.

Le serveur utilise une image Docker basée sur **.NET 9** avec un build multi-stage.

Le principe est le suivant :

```text
Code source
    ↓
.NET SDK 9
    ↓
dotnet restore
    ↓
dotnet publish
    ↓
ASP.NET Runtime 9
    ↓
Image Docker
    ↓
Conteneur
    ↓
http://localhost:8083
```

Le projet `NombreMagique.Shared` est utilisé pendant la compilation du serveur mais ne possède pas son propre conteneur.

Les projets `NombreMagique.Hybrid` et `NombreMagique.WASM` ne sont actuellement pas lancés par Docker.

---

## Prérequis Docker

Installer :

- Docker Desktop
- Git
- Visual Studio ou Visual Studio Code

Les dépendances .NET nécessaires au build et à l'exécution du serveur sont fournies directement par les images Docker Microsoft utilisées dans le `Dockerfile`.

---

## Dockerfile

Le `Dockerfile` se trouve dans :

```text
NombreMagique.Server/Dockerfile
```

Il utilise deux étapes.

### Étape de build

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
```

Cette image contient le SDK .NET 9 nécessaire pour restaurer les dépendances et compiler l'application.

### Étape runtime

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
```

L'image finale contient uniquement le runtime ASP.NET et les fichiers nécessaires à l'exécution de l'application.

Cela permet d'obtenir une image finale plus légère que si le SDK complet était conservé.

---

## .dockerignore

Le fichier `.dockerignore` se trouve à la racine du projet.

Il permet d'éviter l'envoi de fichiers inutiles lors du build Docker :

```text
**/bin/
**/obj/
.git/
.vs/
**/*.user
**/TestResults/
**/*.suo
```

---

# Docker Compose

Le fichier :

```text
compose.yaml
```

permet de construire et lancer le serveur sans avoir à utiliser directement une longue commande `docker run`.

Configuration actuelle :

```yaml
services:
  server:
    build:
      context: .
      dockerfile: NombreMagique.Server/Dockerfile
    image: nombremagique-server:local
    container_name: nombremagique-server
    ports:
      - "8083:8080"
    restart: unless-stopped
```

Le port :

```text
8083:8080
```

correspond à :

```text
Port du PC      Port du conteneur
    8083    →        8080
```

L'application est donc accessible sur :

```text
http://localhost:8083
```

---

# Lancer le projet avec Docker

Depuis la racine du projet :

```text
NombreMagique/
```

construire l'image et lancer le conteneur avec :

```shell
docker compose up -d --build
```

Cette commande :

1. lit le fichier `compose.yaml`
2. utilise le `Dockerfile`
3. construit l'image `nombremagique-server:local`
4. crée le conteneur `nombremagique-server`
5. démarre le serveur en arrière-plan
6. expose l'application sur le port `8083`

---

## Vérifier les conteneurs

```shell
docker ps
```

Le conteneur doit apparaître avec un mapping similaire à :

```text
0.0.0.0:8083->8080/tcp
```

---

## Accéder à l'application

Ouvrir dans un navigateur :

```text
http://localhost:8083
```

---

## Arrêter le projet

```shell
docker compose down
```

Cette commande arrête et supprime les conteneurs créés par Docker Compose.

L'image Docker reste disponible.

---

## Relancer le projet

```shell
docker compose up -d
```

Si le code ou le `Dockerfile` a été modifié et que l'image doit être reconstruite :

```shell
docker compose up -d --build
```

---

## Redémarrage automatique

Le fichier `compose.yaml` contient :

```yaml
restart: unless-stopped
```

Le conteneur peut donc être automatiquement redémarré lorsque Docker redémarre, sauf s'il a été volontairement arrêté.

---

## Commandes Docker utiles

Afficher les conteneurs actifs :

```shell
docker ps
```

Afficher tous les conteneurs :

```shell
docker ps -a
```

Afficher les images :

```shell
docker images
```

Afficher les logs du serveur :

```shell
docker logs nombremagique-server
```

Arrêter le conteneur :

```shell
docker stop nombremagique-server
```

Démarrer le conteneur :

```shell
docker start nombremagique-server
```

---

# Architecture du projet

```text
│   .dockerignore
│   .gitattributes
│   .gitignore
│   compose.yaml
│
├───NombreMagique.Hybrid
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
│   │   ├───iOS
│   │   ├───MacCatalyst
│   │   └───Windows
│   │
│   ├───Properties
│   ├───Resources
│   └───wwwroot
│
├───NombreMagique.Server
│   │   Dockerfile
│   │   appsettings.Development.json
│   │   appsettings.json
│   │   NombreMagique.Server.csproj
│   │   Program.cs
│   │
│   ├───Components
│   │   ├───Layout
│   │   └───Pages
│   │
│   ├───Properties
│   └───wwwroot
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
    ├───Pages
    ├───Properties
    └───wwwroot
```

---

# Architecture Docker

```text
NombreMagique
      │
      ├── NombreMagique.Server
      │          │
      │          └── Dockerfile
      │
      ├── NombreMagique.Shared
      │
      ├── .dockerignore
      │
      └── compose.yaml
               │
               ↓
        Docker Build
               │
               ↓
   nombremagique-server:local
               │
               ↓
   nombremagique-server
               │
               ↓
     localhost:8083
```

