#include <ESP8266WiFi.h>
#include <FirebaseArduino.h>

#define FIREBASE_HOST "bottomnavigationbar-d5987.firebaseio.com"
#define FIREBASE_AUTH "VTsBhFzd6NLgBMDksWtNfw8kljNtDHr1BWCMa4lL"
#define WIFI_SSID "TopGunMav"
#define WIFI_PASSWORD "Ramen@123"

int relayLight = 5; //1
//int relayLighttwo = 12 ; //6
int LightPin = 4;//2
//int relayLightfour = 2; //4

int L1 = 0 ;
int L2 = 0 ;
int L3 = 0 ;
int L4 = 0 ;


//const String Path = "/";

const String Light1 = "Light1";
const String Light2 = "Light2";
const String Light3 = "Light3";
const String Light4 = "Light4";

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  //Setting up output pins
   pinMode(relayLight, OUTPUT);
   pinMode(LightPin, OUTPUT); 
  // Connect to Wifi
   WiFi.begin(WIFI_SSID, WIFI_PASSWORD);
  Serial.print("connecting");
  while (WiFi.status() != WL_CONNECTED) {
    Serial.print(".");
    delay(500);
  }
  Serial.println();
  Serial.print("connected: ");
  Serial.println(WiFi.localIP());
  
  Firebase.begin(FIREBASE_HOST, FIREBASE_AUTH);

  if(Firebase.success())
  {
    Serial.println("Fetched");
  }
    if(Firebase.failed())
  {
    
    Serial.println("Internet lost");
    Serial.println(Firebase.error());
    delay(5000);
  }

}

void loop() {
  //FirebaseObject object = Firebase.get(Path);
  // put your main code here, to run repeatedly:
  
   Serial.println(" OG L1");
  Serial.println(L1);
  Serial.println(Firebase.getInt("/day"));
  L1=Firebase.getInt(Light1);
   if(Firebase.success())
  {
    Serial.println("Fetched");
  }
  if(Firebase.failed())
  {
    Serial.println("Internet lost");
   
  }
  Serial.println("Light1 new ");
  Serial.println(L1);


  Serial.println(L2);
  L2=Firebase.getInt(Light2);
   if(Firebase.failed())
  {
    Serial.println("Internet lost");
    Serial.println(Firebase.error());
    delay(5000);
  }
  Serial.println("Light2");
  Serial.println(L2);
 

  Serial.println(L3);
  L3=Firebase.getInt(Light3);
   if(Firebase.failed())
  {
    Serial.println("Internet lost");
    
  }
  Serial.println("Light3");
  Serial.println(L3);
  //delay(100);

  Serial.println(L4);
  L4=Firebase.getInt(Light4);
  Serial.println("Light4");
  Serial.println(L4);
 // delay(100);

  if(L1 == 1){
      digitalWrite(relayLight, LOW);
      Serial.println("Light 1 on ");
    }else{
      digitalWrite(relayLight, HIGH);
      Serial.println("Light 1 off ");

    }

//    if(L2 == 1){
//      digitalWrite(relayLighttwo, LOW);
//      Serial.println("Light 2 on ");
//
//    }else{
//      digitalWrite(relayLighttwo, HIGH);
//      Serial.println("Light 2 off ");
//
//    }

    if(L3 == 1){
      digitalWrite(LightPin, LOW);
      Serial.println("Light 3 on ");

    }else{
      digitalWrite(LightPin, HIGH);
      Serial.println("Light 3 off ");

    }

//    if(L4 == 1){
//      digitalWrite(relayLightfour, LOW);
//      Serial.println("Light 4 on ");
//
//    }else{
//      digitalWrite(relayLightfour, HIGH);
//      Serial.println("Light 4 off ");
//
//    }

}
