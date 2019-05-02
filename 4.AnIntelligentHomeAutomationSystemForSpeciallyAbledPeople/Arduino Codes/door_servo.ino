

#include "ThingSpeak.h"
#include <Servo.h>
Servo myservo;
const char* ssid = "sitaphal";
const char* password = "1234567897";
 
unsigned long channel = 701005;
 

unsigned int led1=1;
unsigned int led2=2;
unsigned int led3=3;
unsigned int led4=4;
unsigned int moto5=5;
bool toggle = false;
bool toggle1 = false;
bool toggle2 = false;
bool toggle3 = false;
bool toggle4 = false;
 


#define USE_WIFI101_SHIELD
#define USE_ETHERNET_SHIELD

#if !defined(USE_WIFI101_SHIELD) && !defined(USE_ETHERNET_SHIELD) && !defined(ARDUINO_SAMD_MKR1000) && !defined(ARDUINO_AVR_YUN) && !defined(ARDUINO_ARCH_ESP8266) && !defined(ARDUINO_ARCH_ESP32)
  #error "Uncomment the #define for either USE_WIFI101_SHIELD or USE_ETHERNET_SHIELD"
#endif

#if defined(ARDUINO_AVR_YUN)
    #include "YunClient.h"
    YunClient client;
#else
  #if defined(USE_WIFI101_SHIELD) || defined(ARDUINO_SAMD_MKR1000) || defined(ARDUINO_ARCH_ESP8266) || defined(ARDUINO_ARCH_ESP32)
    // Use WiFi
    #ifdef ARDUINO_ARCH_ESP8266
      #include <ESP8266WiFi.h>
  #elif defined(ARDUINO_ARCH_ESP32)
      #include <WiFi.h>
    #else
      #include <SPI.h>
      #include <WiFi101.h>
    #endif
       // your network password
    int status = WL_IDLE_STATUS;
    WiFiClient  client;
  #elif defined(USE_ETHERNET_SHIELD)
    // Use wired ethernet shield
    #include <SPI.h>
    #include <Ethernet.h>
    byte mac[] = { 0xDE, 0xAD, 0xBE, 0xEF, 0xFE, 0xED};
    EthernetClient client;
  #endif
#endif


unsigned long myChannelNumber = 701005;
const char * myReadAPIKey = "WYH5OHVEH274PE51";

void setup() {

   Serial.begin(115200);
  delay(100);
  
  pinMode(D1, OUTPUT);
  pinMode(D2, OUTPUT);
   pinMode(D3, OUTPUT);
  pinMode(D4, OUTPUT);
  
   myservo.attach(D5);
  
  Serial.println();
  Serial.println();
  Serial.print("Connecting to ");
  Serial.println(ssid);
  
  WiFi.begin(ssid, password);
  
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
 
  Serial.println("");
  Serial.println("WiFi connected");  
  Serial.println("IP address: ");
  Serial.println(WiFi.localIP());
  Serial.print("Netmask: ");
  Serial.println(WiFi.subnetMask());
  Serial.print("Gateway: ");
  Serial.println(WiFi.gatewayIP());
  ThingSpeak.begin(client);
}

void loop() {
  int led_1 = ThingSpeak.readFloatField(channel,led1,myReadAPIKey);
  int led_2 = ThingSpeak.readFloatField(channel,led2,myReadAPIKey);
  int led_3 = ThingSpeak.readFloatField(channel, led3,myReadAPIKey);
  int led_4 = ThingSpeak.readFloatField(channel, led4,myReadAPIKey);
  int moto_5 = ThingSpeak.readFloatField(channel, moto5,myReadAPIKey);

  if(led_1 == 1)
  {
    if(toggle==false)
    {
      toggle=true;
    digitalWrite(D1, HIGH);
    Serial.println("D1 is On..!");  
      }
    }
  else if(led_1==2){
    digitalWrite(D1, LOW);
    toggle= false;
    Serial.println("D1 is Off..!");
  }

  if(led_2 == 1){
    if(toggle1==false)
    {
      toggle1=true;
    digitalWrite(D2, HIGH);
    Serial.println("D2 is On..!");
    }
    }
  else if(led_2==2)
  {
    toggle1=false;
    digitalWrite(D2, LOW);
    Serial.println("D2 is Off..!");
  }

  if(led_3 == 1){
    if(toggle2==false)
    {
      toggle2=true;
    digitalWrite(D3, HIGH);
    Serial.println("D3 is On..!");
    }
    }
  else if(led_3==2) {
    toggle2=false;
    digitalWrite(D3, LOW);
    Serial.println("D3 is Off..!");
  }
    if(led_4 == 1){
    if(toggle3==false)
    {
      toggle3=true;
    digitalWrite(D4, HIGH);
    Serial.println("D4 is On..!");
    }
    }
  else if(led_4==2) {
    toggle3=false;
    digitalWrite(D4, LOW);
    Serial.println("D4 is Off..!");
  }
  if(moto_5 == 1){
    if(toggle4==false)
    {
      toggle4=true;
          Serial.println("D5 is On..!");
    myservo.write(90);              
  delay(500);
  }
  }
  else if(moto_5 == 2){
    if(toggle4==true)
    {
     toggle4=false;
         Serial.println("D5 is Off..!");
    myservo.write(0);              
  delay(1500);
    }
  }
  
  Serial.println(led_1);
  Serial.println(led_2);
  Serial.println(led_3);
  Serial.println(led_4);
  Serial.println(moto_5);
  delay(5000);
}
