# FindYourHome - Scaffold

Ce dépôt contient une structure scaffold pour le projet **FindYourHome** conforme aux exigences du document 'Projet' et au cahier des charges fourni.  
Sources: Uploaded documents 'Projet.docx' and 'CAHIER DE CHARGES.docx'. See attached files in the conversation for the originals. fileciteturn1file0 fileciteturn1file2

## Structure requise (présente)
- Models/
- ViewModels/
- Views/
- Services/
- Helpers/
- Resources/ (Styles, Images, Fonts)
- Platforms/ (Android, iOS, Windows)
- App.xaml, AppShell.xaml, MauiProgram.cs
- FindYourHome.csproj (placeholder)

## Instructions d'utilisation
1. Ouvrez Visual Studio 2022 (ou plus récent) avec le workload .NET MAUI installé.
2. Créez un nouveau projet .NET MAUI (dotnet new maui -n FindYourHome) ou ouvrez un projet existant.
3. Remplacez / copiez les fichiers fournis dans votre solution.
4. Ajustez le .csproj réel généré par Visual Studio si nécessaire.
5. Initialisez Git: `git init && git add . && git commit -m "Initial scaffold"`
6. Poussez sur GitHub en rendant le dépôt public.

## Livrables restants (à produire)
- Wireframes moyen-fidélité (Pencil) : export PDF requis par le projet. (Je peux produire des maquettes PDF mais Pencil est demandé explicitement.)
- Maquettes haute-fidélité (Figma) : lien public + export PDF.
- Implémentation complète des fonctionnalités (auth, CRUD annonces, filtres, favoris, dashboard).
- Tests unitaires et fonctionnels, et déploiement.

## Notes
- Le .csproj ici est un placeholder : pour un projet opérationnel, créez le projet depuis Visual Studio 2022 et remplacez ce fichier.
- J'ai inclus des pages et viewmodels d'exemple pour accélérer le développement.


## Additional deliverables added
- Auth pages (Login/Register) and ViewModels
- CRUD pages for houses (Add/Edit/Delete)
- DatabaseService (SQLite) scaffold
- Simple wireframes PDF and high-fidelity mockups PDF included
