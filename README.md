# Securing our mobile app and services

Security is one of the most important concerns we need to keep in mind once we design mobile solutions. In this scenario will be reviewing how to implement Azure Active Directory authentication in our mobile application (Xamarin Application) and then how to protect our Azure App Service (Mobile App, Logic App, Function App) to prevent not authorized requests in our service.

# Configuring Azure environment

For these scenario we are going to use the following Azure resources:

- Mobile App Service.
- Azure Active Directory application (Native).
- Azure Active Directory application (Web/API).

It's time to create our App Service, in this sample we are using Mobile App Service, you can also create an App Service family member.

<img src="http://rcervantes.me/images/xamarinadal-createappservice.png" width="250">

Now you can set the Authentication/Authorization feature to enable the Azure Active Directory authentication provider.

<img src="http://rcervantes.me/images/xamarinadal-authorization-aad.png" width="550">

It's time to create our first Azure Active Directory application in the Express settings. In this sample I used the Prefix: XamarinAdal since is our Project and the Sufix: Backend since is our API REST.

* Write a name for the Azure Active Directory application: e.g. XamarinAdalBackend.
* Enable "Grant Graph Permissions" and "Grant Common Data Services Permissions".
* Save all the changes.

<img src="http://rcervantes.me/images/xamarinadal-aad-application-backend.png" width="550">

Once our changes have been applied in the Mobile App Service, we can go to Azure Active Directory workload and search the application recently created, in this sample is: XamarinAdalBackend. 

* Copy the Application ID and save it temporarily.

<img src="http://rcervantes.me/images/xamarinadal-backend-configuration.png" width="550">

Go directly to the Azure Active Directory application settings, it's not required to modify any settings because all permissions are delegated.

<img src="http://rcervantes.me/images/xamarinadal-backend-preview-settings.png" width="550">

Just press "Grant Permissions".

<img src="http://rcervantes.me/images/xamarinadal-backend-settings.png" width="550">

**At this point we have successfully configured our Mobile App Service and the Azure Active Directory application. It's time to configure our Azure Active Directory application for the mobile application.**

Go to Azure Active Directory and select App Registrations, then press "+ New application registration", and fill the following fields:

* Write a name for the Azure Active Directory application: e.g. XamarinAdalMobile.
* Select Native application type.
* Write the redirect uri, e.g. https://YOUR_APP_SERVICE.azurewebsites.net/.auth/login/done

<img src="http://rcervantes.me/images/xamarinadal-mobile-creation.png" width="250">

As the same as Azure Active Directory application for backend (XamarinAdalBackend), go to the application settings, and now add the your backend Azure Active Directory application to the scope of the Azure Active Directory application for mobile (XamarinAdalMobile).

<img src="http://rcervantes.me/images/xamarinadal-mobile-add-settings.png" width="550">

Then press "Grant Permissions".

<img src="http://rcervantes.me/images/xamarinadal-mobile-settings.png" width="550">

Congrats!! :) At this point you have setup all we need to execute our mobile application.

***Clone the project from GitHub repo***

`git clone https://github.com/rcervantes/xamarin-adal.git`

* Proceed publish the App Service project to your Mobile App Service previously created.

* Then configure the file: source/XamarinAdal/XamarinAdal/Settings.cs to add the following settings:

APP_SERVICE: The name of your Mobile App Service. 
RESOURCE_ID: The Application ID of your Azure Active Directory backend application.
CLIENT_ID: The Application ID of your Azure Active Directory mobile application.

```csharp
using System;
namespace XamarinAdal
{
    public class Settings
    {
        public static string AppServiceURL = "https://APP_SERVICE.azurewebsites.net/";
        public static string TenantId = "https://login.windows.net/common";
        public static string ResourceId = "RESOURCE_ID";
        public static string ClientId = "CLIENT_ID";
        public static string ReturnUrl = $"{Settings.AppServiceURL}.auth/login/done";
    }
}
```

**Now it's time to run our mobile application**

The app display the buttons to login and clear token:

<img src="http://rcervantes.me/images/xamarinadal-mobile-app1.png" width="250">

When login the app request a valid mail and password:

<img src="http://rcervantes.me/images/xamarinadal-mobile-app2.png" width="250">

Proceed with the authentication process and ask the user to grant access to the profile information:

<img src="http://rcervantes.me/images/xamarinadal-mobile-app3.png" width="250">

The profile information (name) is displayed in the application and a asynchronous request is made to retrieve data from the Mobile App Service with the token provided:

<img src="http://rcervantes.me/images/xamarinadal-mobile-app4.png" width="250">

**Credits**

I want to thank Michael Watson (@michael-watson) for the support in this excercise and hope soon have the UWP implementation public.
