int gas_bulb=12;
int buzz=13;
int gas_value;
int gas_avalue;
int sensorThres=700;
int ledPin = 8;                // choose the pin for the LED
int inputPin = 2;               // choose the input pin (for PIR sensor)
int pirState = LOW;             // we start, assuming no motion detected
int val = 0;  

void setup()
{

pinMode(gas_bulb,OUTPUT);
pinMode(buzz,OUTPUT);
pinMode(A0,INPUT);            //PIR Sensor
pinMode(ledPin, OUTPUT);      // declare LED as output
pinMode(inputPin, INPUT);     // declare sensor as input
Serial.begin(9600);

}

void loop()

{

gas_avalue=analogRead(A0);

if (gas_avalue > sensorThres)

{

digitalWrite(gas_bulb, HIGH);
digitalWrite( buzz, HIGH);
Serial.println("DANGER!!!!");
Serial.println(gas_avalue);

}

else

{

digitalWrite(gas_bulb, LOW);
digitalWrite( buzz, LOW);
Serial.println("NO LEAKAGE");
Serial.println(gas_avalue);

}
 val = digitalRead(inputPin);  // read input value
  if (val == HIGH) {            // check if the input is HIGH
    digitalWrite(ledPin, HIGH);  // turn LED ON
    if (pirState == LOW) {
      // we have just turned on2
      Serial.println("Motion detected!");
      // We only want to print on the output change, not state
      pirState = HIGH;
      delay(500);
    }
  } else {
    digitalWrite(ledPin, LOW); // turn LED OFF
    if (pirState == HIGH){
      // we have just turned of
      Serial.println("Motion ended!");
      // We only want to print on the output change, not state
      pirState = LOW;
    }
  }

delay(100);

}



