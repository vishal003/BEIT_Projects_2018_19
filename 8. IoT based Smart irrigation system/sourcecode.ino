#define threshold 60 // Defining Thresholds
#define wateringTime 5000 //5 seconds
#include <SoftwareSerial.h> 

int plantSensor1 = A0;    // sensor pins  
int value1 = 0;  //initializing sensor value & variables 
int pump = 6; // water pump control pin
void watering1(); 
int ledPin = 13; // LED 13 will be used to let the user know when the code has looped back again.
int tempval;     //to store temperature value
int tempPin = 2; //temp sensor connection
int lumval;     //to store luminosity value
int lumPin = 4;  //luminosity sensor connection
int t;          // for counting pump on off
int waterpumped; //to store amount of water pumped

String apiKey = "UMXY0NJNKH173S0J"; // ThingSpeak Write API key,
#define SSID "Freedom" // WiFi Name
#define PASS "qwerty123"// WiFi password

SoftwareSerial SoftSer(9, 8); // Everywhere from here on when you see SoftSer, it is being used as a command

void setup() 
{

 pinMode(ledPin, OUTPUT);
 pinMode(pump, OUTPUT);
 digitalWrite(pump, HIGH); //pump off at initial 

  // Begins serial communication at a baud of 9600.
  Serial.begin(9600);
  
  // Begins software serial communication at a baud of 9600.
  SoftSer.begin(9600); 

}

void loop() 
{

//   Connecting to your internet source------------* 
 String join="AT+CWJAP=\""; // Join accesspoint
  join+=SSID;
  join+="\",\"";
  join+=PASS;
  join+="\"";
  SoftSer.println(join);
  delay(5000);
  
  // blink LED on board 
  digitalWrite(ledPin, HIGH);
  delay(200);
  digitalWrite(ledPin, LOW);

//luminosity read & dusplay
lumval = analogRead(lumPin); 
Serial.print("Luminosity : ");
Serial.println(lumval); 
delay(1000);

//temperature, read, convert voltage to celsius & display
tempval = analogRead(tempPin);
float mv = ( tempval/1024.0)*500;
float cel = mv/10;
Serial.print("Temperature : ");
Serial.print(cel);
Serial.print("*C");
Serial.println();
delay(1000);

//moisture sensor, read, map value in percentage & display
 value1= analogRead(plantSensor1);
 value1 = map(value1,1023,74,0,100);
 Serial.print("Moisture : ");
 Serial.print(value1);
 Serial.println("%");
    
    if(value1 <= threshold)
     {
       watering1();  //control watering operations     
       ++t;          //count number of times pump started & store in t
       waterpumped = t * 150;  //no of times pump strted x 150 ml   
       Serial.print("Water pumped so far : ");
       Serial.print(waterpumped);
       Serial.print(" Millilitres");
       Serial.println();
     } 

  // TCP connection
  String cmd = "AT+CIPSTART=\"TCP\",\"";
  cmd += "184.106.153.149"; // api.thingspeak.com
  cmd += "\",80";
  SoftSer.println(cmd);

  if (SoftSer.find("Error")) 
  {
    Serial.println("AT+CIPSTART error");
    return;
  }

  String getStr = "GET /update?api_key=";
  getStr += apiKey;
  getStr += "&field1=";
  getStr += String(value1);
  getStr += "&field2="; 
  getStr += String(cel); 
  getStr += "&field3="; 
  getStr += String(lumval);
  getStr += "&field4="; 
  getStr += String(waterpumped);
  getStr += "\r\n\r\n";

  // send data length
  cmd = "AT+CIPSEND=";
  cmd += String(getStr.length());
  SoftSer.println(cmd);

  SoftSer.print(getStr); // Send data.

  SoftSer.println("AT+RST"); //restart wifi chip, helps with reliability
  delay(15000);
}

//plant watering
void watering1()
{    
    Serial.println("Watering Plant:");      
    digitalWrite(pump, LOW); //Pump onn
    delay(wateringTime); //Watering Time
    digitalWrite(pump, HIGH); //Pump off              
  }
