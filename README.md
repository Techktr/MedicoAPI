# MedicoAPI

Application fullstack de gestion d'un cabinet de médecin du sport, développée comme projet de portfolio pour illustrer une architecture backend en couches sur **.NET 8**, couplée à un frontend **Angular**.

> **Statut :** En cours de développement — modules Patient et Praticien finalisés (front + back), module Rendez-vous back-end complet, formulaires front en cours.

---

## Stack technique

| Couche | Technologie |
|---|---|
| Backend | .NET 8 / ASP.NET Core Web API |
| ORM | Entity Framework Core |
| Base de données | SQL Server |
| Frontend | Angular (TypeScript) |
| Versioning BDD | EF Core Migrations |

---

## Architecture

Le backend suit une architecture en couches strictement découplées, avec injection de dépendances et séparation interface / implémentation à chaque niveau.

```
Controllers/
├── Data/
├── Models/
├── Repositories/
└── Services/
    ├── DTOs/
    └── Mappers/
```

### Détail des couches

**Models** — entités EF Core mappées à la base de données (`Patient`, `Practitioner`, `Appointment`).

**Repositories** — accès aux données derrière une interface (`IPatientRepository`, `IPractitionerRepository`, `IAppointmentRepository`). Chaque entité a son interface et son implémentation concrète.

**Services** — logique métier derrière une interface (`IPatientService`, etc.). Consomme les repositories via injection de dépendances. Regroupe les **DTOs** (séparation des contrats API / modèles BDD) et les **Mappers** (conversions entité ↔ DTO) dans ses propres sous-dossiers.

**Controllers** — exposition de l'API REST. Délèguent entièrement aux services, sans logique métier embarquée.

**Data** — `MedicoDbContext` (EF Core), configuration du contexte et des DbSets.

**Migrations** — historique versionné de la base de données :
- `InitialCreate` — table Patient
- `PractitionerTable` — ajout Praticien
- `AppointmentTable` — ajout Rendez-vous

---

## Fonctionnalités

### Module Patient ✅
- Création, consultation, mise à jour, suppression
- Couplage front-to-back complet

### Module Praticien ✅
- CRUD complet
- Couplage front-to-back complet

### Module Rendez-vous 🚧
- Backend complet (modèle, repository, service, controller)
- Frontend en cours : formulaires de création et de mise à jour

---

## Lancer le projet

### Prérequis
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- SQL Server (local ou Docker)
- [Node.js](https://nodejs.org/) + Angular CLI (`npm install -g @angular/cli`)

### Backend

```bash
# Cloner le repo
git clone https://github.com/Techktr/MedicoAPI.git
cd MedicoAPI

# Copier le fichier exemple et renseigner ta chaîne de connexion
cp appsettings.example.json appsettings.json

# Appliquer les migrations
dotnet ef database update

# Lancer l'API
dotnet run
```

L'API est disponible sur `https://localhost:5001` (Swagger UI inclus en mode développement).

### Frontend

```bash
git clone https://github.com/Techktr/GestionPatient.git
cd GestionPatient

npm install
ng serve
```

L'application est disponible sur `http://localhost:4200`.

---

## Ce que ce projet démontre

- Application du **Repository Pattern** avec interfaces pour faciliter la testabilité et l'inversion de dépendances
- **Séparation stricte des responsabilités** : aucune logique métier dans les controllers, aucun accès BDD dans les services
- Utilisation des **DTOs** pour découpler les contrats API des modèles de persistance
- **Injection de dépendances** native ASP.NET Core (enregistrement dans `Program.cs`)
- **EF Core Migrations** pour un versioning propre du schéma
- Architecture pensée pour **évoluer** : ajout d'un module = ajout d'un Model + Repository + Service + Controller sans toucher à l'existant

---

## Projets liés

- **[GestionPatient](https://github.com/Techktr/GestionPatient)** — frontend Angular associé à cette API
- **[LibraFlow](https://github.com/Techktr/LibraFlow)** *(à venir)* — application microservices de gestion de bibliothèque (Go, Java, Angular, RabbitMQ, Redis, Kubernetes)
