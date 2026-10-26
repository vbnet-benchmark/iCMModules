# iCMModules

Add-on modules for the iCMServer content management system, built by iConsulting. Each module is a self-contained ASP.NET user control (`.ascx`) or web form (`.aspx`) that an editor can drop onto a page inside iCMServer. The repo holds 52 such modules plus the SQL scripts that register them and create their tables.

## What this is

iCMServer is a page-based CMS. A page is assembled from modules, and this repo is the module library. Every module inherits from `clsSiteModuleControl` (defined in `iConsulting.iCMServer`, the core engine — the compiled DLL is included under `Source/`), registers itself in the `mde_moduledefinitions` table, and stores its UI strings in `lgt_languagetext` so it can be localized.

A module ships as a folder under `wwwroot/iCMServer.Modules.<Name>/` and is deployed to `Desktop/Modules/<Name>/` in a running iCMServer site. The `.sql` files in each folder do the registration and schema setup.

## What's included

The 52 modules range from generic CMS building blocks to one-off work for specific customers. Grouped roughly by what they do:

**Site and content management**
- `Pages`, `LitePages`, `Sites`, `LiteSites` — page and site administration
- `Menu`, `LiteMenu`, `Quicklinks` — navigation
- `Publisher`, `Publisher2006` — rich-content publishing (Publisher2006 is the Telerik RadControls-based editor)
- `Documents`, `LiteDocuments`, `DocumentsFromDisk` — document libraries
- `Mediagallery` — image/media gallery
- `Search` — site search
- `Redirect`, `iFrame`, `Execute` — embedding and routing helpers

**Users and access**
- `Users`, `Roles` — account and permission administration
- `SignIn`, `AutoLogin` — authentication
- `Language` — language administration

**Collaboration and scheduling**
- `Calendar`, `Events` — calendars and events
- `Discussion` — discussion board
- `Notice` — notices/announcements
- `BB` — the "baby" / pregnancy-week board (`bab_baby` table)
- `TaskList`, `ProjectList` — task and project tracking
- `Timeline`, `Timesheet`, `Timesheet2`, `Timesheet3`, `iCTimePlan` — time tracking and planning (several iterations)

**Module tooling**
- `Modules`, `ModuleDefinition` — manage which modules a site uses
- `NewModuleTemplate` — starting point for writing a new module
- `Template` plus `Template003`–`Template013` — page/layout templates

**Customer-specific**
- `BNIMembers` — member directory for a BNI chapter (logo upload, member profiles)
- `ICERoute`, `NorskFilmWizard` — bespoke modules for specific sites

## Tech stack

- **VB.NET** for almost everything (285 `.vb` files); a few modules use C# (38 `.cs` files), mainly `ModuleDefinition` and the Publisher2006 Telerik examples.
- **ASP.NET Web Forms** — `.aspx` pages and `.ascx` user controls, code-behind model.
- **Visual Studio .NET 2003 project format** (`.vbproj`, `ProductVersion 7.10`), targeting **.NET Framework 1.1**. Each module folder has its own `.sln`.
- **SQL Server** is the primary database (scripts use `USE iCMServer` and `GO` batches). MySQL ports are provided alongside as `mySQL_*.sql`.
- Compiled module DLLs and PDBs are checked in under each `bin/` folder, named `iConsulting.iCMServer.Modules.<Name>.dll`.

## Related repositories

- **iCMServer** — the core CMS engine these modules plug into. The base class `clsSiteModuleControl` and the database schema live there. This repo references it as `iConsulting.iCMServer` (DLL bundled under `Source/`).
- **iCMComponents** — shared component library for the same system.

## Getting started

This is a legacy ASP.NET 1.1 codebase. To work with a module you need a running iCMServer install and an environment that can build .NET Framework 1.1 web projects (Visual Studio .NET 2003, or a newer VS with the right targeting pack).

1. Open the module's `.sln` (for example `wwwroot/iCMServer.Modules.Calendar/iCMServer.Modules.sln`).
2. Build it — output is `iConsulting.iCMServer.Modules.<Name>.dll` in `bin/`. The build needs `iConsulting.iCMServer.dll` (in `Source/`) on the reference path.
3. Copy the module folder to `Desktop/Modules/<Name>/` in your iCMServer web root.
4. Run the registration SQL against your database — `<Name>.sql` for SQL Server or `mySQL_<Name>.sql` for MySQL. Apply any `*_Upgrade_*.sql` scripts in order if you are upgrading an existing install.

To create a new module, copy `iCMServer.Modules.NewModuleTemplate` and rename the class, project, and namespace.

## Status

Archived/legacy. There is a single commit (October 2024), and the code targets .NET Framework 1.1 and VS .NET 2003 — a stack that has been out of mainstream support for many years. Treat this as a historical snapshot of the iCMServer module library, not an actively maintained project. No license file is present; assume all rights reserved by iConsulting unless told otherwise.
