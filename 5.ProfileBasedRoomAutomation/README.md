# Room Automation
This system allows you to control the appliances in  a specific room from a mobile android app, it enable controlling of appliances automatically based on the preferences taken from the user.
## Prerequisites

### Software
 - [Android Studio](https://developer.android.com/studio)
 - [Arduino IDE](https://www.arduino.cc/en/main/software)
 - [Google Colaboratory](https://colab.research.google.com/)
 - [Google Firebase](https://firebase.google.com/)

### Hardware
- [NodeMCU](https://www.nodemcu.com/index_en.html)
- Relay Module 
- Appliance 

## Installation

### Android Studio
To install Android Studio on Windows, proceed as follows:
- Download file
	*  If you downloaded an .exe file (recommended), double-click to launch it.
	* If you downloaded a .zip file, unpack the ZIP, copy the android-studio folder into your Program Files folder, and then open the android-studio ¿ bin folder and launch studio64.exe (for 64-bit machines) or studio.exe (for 32-bit machines).

-  Follow the setup wizard in Android Studio and install any SDK packages that it recommends.

- As new tools and other APIs become available, Android Studio tells you with a pop-up,or you can check for updates by clicking Help ¿ Check for Update.

### Arduino IDE
- Download the Arduino Software (IDE)
	Get the latest version from the download page. You can choose between the Installer (.exe) and the Zip packages. 
- Proceed with board specific instructions.
When the Arduino Software (IDE) is properly installed you can go back to the Getting Started Home and choose your board from the list on the right of the page.
- Install Required Libraries 
	* [WiFi](https://github.com/arduino-libraries/WiFi)
	* [FireBase](https://github.com/FirebaseExtended/firebase-arduino)

### Google Colaboratory 
Setup Google Colaboratory by referring [this](https://medium.com/@rohansingh_46766/getting-started-with-google-colaboratory-57b4863d4d7d) 

### Google FireBase 
Setup Google Fire Base by referring [this](https://firebase.google.com/docs/android/setup)

## Building

### Android App
- Import the App file into Android Studio
- Modify according to Needs 
- Build and Install Apk

### Models 
- Use Google Colaboratory and provided  **.iypnb** file to build models

### ML Python Script 
- Use provided **.py** file as a base to create your own script to run your own models 

## Working 
### Prerequisites 
- Script to be Running in Background on a server having internet connection 
- App installed and running on the user mobile

### Features of Application
- Control of appliance 
- Setting of preference 
- Profile Handling 

### Process 
- User logs into the app 
- The Time-slot, Day of the Week,User-ID is uploaded to FireBase 
- The background script takes the input from firebase , computes and process the data , the uploads the prediction back to firebase 
- NodeMCU uses this data to automate the appliances 


## Authors
- [Aniruddh Patil](https://github.com/AniruddhPatil1998)
- [Namrata Joshi](https://github.com/namratajoshi16)
- [Gargi Surve](https://github.com/survegargi)