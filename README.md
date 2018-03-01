# FirebaseABTesting Xamarin.Forms

Plugin for Firebase A/B Testing using Firebase Remote config

Requirements:

  + google-services.json (Android, GoogleSevicesJson compilation)
  + GoogleServices-Info.plist (iOS, BundleResource compilation)
  
  In iOS you have to write Firebase.Core.App.Configure(); in the AppDelegate at the FinishedLaunching method
  
  Before you get the Firebase Remote Config values you have to use the Fetch method to get the firebase data
