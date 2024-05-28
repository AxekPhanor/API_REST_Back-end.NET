# PostTrades
> OpenClassrooms Projet 7 : Rendez votre back-end .NET plus flexible avec une API REST


## Informations Générales
L'objectif de ce projet était de mettre en place une API REST sur des entités qui seront ensuite utilisées pour générer des transactions.
Il fallait aussi implémenter une authentification avec JWT. Et réaliser des tests unitaire sur nos différents services.

## Technologies utilisées
- .NET - 6.0
- Microsoft.EntityFrameworkCore - 6.0.16
- Microsoft.AspNetCore.Identity.EntityFrameworkCore - 6.0.16
- Microsoft.AspNetCore.Authentication.JwtBearer - 6.0.16
- Swashbuckle.AspNetCore - 6.5.0
- Serilog - 3.1.1

## Installation
1. Cloner le projet 
	```
	git clone --single-branch --branch dev https://github.com/AxekPhanor/API_REST_Back-end.NET.git
	```
2. Modifier le fichier appsettings.json (remplacer la valeur de Server par le nom du serveur sur lequels vous voulez créer votre base de donnée)
	```
		"ConnectionStrings": {
	  "DefaultConnection": "Server=.\\SQLEXPRESS;Database=PostTrades;Trusted_Connection=True;MultipleActiveResultSets=true"
	},
	```
Ouvrez le fichier appsettings.json et dans la chaine de connexion remplacer la valeur de Data Source part le nom du serveur SQL Express.

## Utilisation
Pour se connecter à l'API, vous pouvez vous connecter pour obtenir un token d'authentification sur la route suivante avec ces identifiants :
**Route :** `POST /Auth/login`
```
{  
	"username":  "admin",  
	"password":  "Sy4oSfGDBWZJ8hcwOG?h$V&"  
}
```
**Réponse :**
```
{  
	"token":  "votre-token"
}
```

Pour accéder aux routes protégées, vous devez fournir le token récupéré lors de la connexion. Cliquez sur le bouton `Authorize` en haut de la documentation swagger et entrez le token au format suivant : `Bearer <votre-token>`.
Cela va permettre de créer un header Authorize avec pour valeur `Bearer <votre-token>`.

Cette connexion va vous permettre d'accéder à toutes les routes de l'API.

## Etat du projet
Le projet est : _Terminé_ ✅

## Contact
Créer par [@AxekPhanor](https://github.com/AxekPhanor)

Mail : axel.phanor64@gmail.com

