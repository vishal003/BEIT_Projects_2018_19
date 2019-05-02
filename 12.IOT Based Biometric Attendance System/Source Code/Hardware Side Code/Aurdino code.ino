 //!!AUM!!
#include <Adafruit_Fingerprint.h>
#include <SoftwareSerial.h>
SoftwareSerial mySerial(12, 13); // RX, TX
#include <LiquidCrystal.h>
// RS-2  ; EN-3 ; D4-4    ;  D5-5   ; D6-6    ; D7-7
LiquidCrystal lcd(2, 3, 4, 5, 6, 7);

#define KEY_1   A0
#define KEY_2   A1
#define KEY_3   A2
#define KEY_4   A3

#define MAX_STUDENT             5

Adafruit_Fingerprint finger = Adafruit_Fingerprint(&mySerial);
uint8_t getFingerprintEnroll();


int crnt_match_point = 0;
char App_LinkID = 0; 
char AppContDataSending = 0;
int ContSending_timer = 0;

char check_attendance = 0;
int base_ms = 0;
byte attendance_id = 0;
byte register_id = 0;

void setup()  
{ Serial.begin(115200); 

  pinMode(KEY_1,INPUT_PULLUP);
  pinMode(KEY_2,INPUT_PULLUP);
  pinMode(KEY_3,INPUT_PULLUP);
  pinMode(KEY_4,INPUT_PULLUP);

  lcd.begin(16, 2);
  lcd.setCursor(0, 0);
  lcd.print("   BIOMETRIC    ");    
  lcd.setCursor(0, 1);
  lcd.print("AttendanceSystem");  
  delay(3000);

  // set the data rate for the sensor serial port
  finger.begin(57600);
  if (!finger.verifyPassword()) 
  {   lcd.setCursor(0, 0);
      lcd.print(" FINGER PRINT   ");    
      lcd.setCursor(0, 1);
      lcd.print(" MODULE ERROR   "); 
    while (1);
  }  
  if(!AT_test())   
  { Serial.println(F("Check ESP Module and Restart Arduino"));
    lcd.setCursor(0, 1);
    lcd.print("WIFI MODULE ERR ");  
    delay(5000);
  }
  if(!Client_setup()) 
  { Serial.println(F("Server Not Setup"));
    lcd.setCursor(0, 1);
    lcd.print("CONNECTION ERROR");
    delay(5000);
  }  
}


void loop()
{ GET_NEW_DATA(); 
  if(!digitalRead(KEY_1))        register_student_id();
  if(!digitalRead(KEY_3))         check_attendance = 1;
  if(!digitalRead(KEY_4))         check_attendance = 0;
  
  delay(1);
  base_ms++;
  if(base_ms < 1000)  return;
  base_ms = 0;

  if(check_attendance == 1) 
  { lcd.setCursor(0, 0);
    lcd.print("MARK ATTENDANCE ");    
    lcd.setCursor(0, 1);
    lcd.print("                ");
    check_for_attendance();
  }
  else    
  { lcd.setCursor(0, 0);
    lcd.print("   BIOMETRIC    ");    
    lcd.setCursor(0, 1);
    lcd.print("AttendanceSystem");  
  }
}


int check_for_attendance(void)
{ 
  int p = finger.getImage();
  if (p == FINGERPRINT_NOFINGER)  return p;
  char student_match_id = 0;
  char  i = 0,id_number = 0;
//--------------------------------------------------------------------------------
  p = finger.image2Tz(2);
//---------------------------------------------------------------
  for(i = 1;i<=MAX_STUDENT;i++)
  { p = finger.loadModel(i);
    p = finger.createModel();
    if(p == FINGERPRINT_OK)
    { id_number = i;
      break;
    }
  }

  if(id_number != 0)
  { attendance_id = id_number;             
    lcd.setCursor(0, 1);
    lcd.print("STUDENT ID: "+String(attendance_id)+"  ");  
    delay(3000);
    if(SEND_DATA())     
    { lcd.setCursor(0, 1);
      lcd.print("  DATA  SENT    ");    
    }
    else              
    { lcd.setCursor(0, 1);
      lcd.print(" DATA NOT SENT  ");    
    }
    delay(3000);
    lcd.setCursor(0, 1);
    lcd.print("STUDENT ID: "+String(attendance_id)+"  "); 
    return  0;
   }
    lcd.setCursor(0, 1);
    lcd.print("Student NotMatch");    
    delay(3000);
    lcd.setCursor(0, 1);
    lcd.print("                ");
    
}

int register_student_id(void)
{ uint8_t id;
  id = readnumber();
//---GET IMAGE---------------------------------------------------
  int p = -1;
  lcd.setCursor(0, 1);
  lcd.print("TAP FINGER ONCE ");      
  while (p != FINGERPRINT_OK) 
  { p = finger.getImage();
    delay(50);
  }
  // OK success!
 //------CONVERT IMAGE--------------------------------------------------------------------------  
  p = finger.image2Tz(1);

 //----WAIT FOR REMOVE FINGER--------------------------------------------------------------- 
  lcd.setCursor(0, 1);
  lcd.print("REMOVE FINGER   ");      
  delay(2000);
  p = 0;
  while (p != FINGERPRINT_NOFINGER) {
    p = finger.getImage();
  }
//-------TAB AGAIN---------------------------------------------------------------
  lcd.setCursor(0, 1);
  lcd.print("TAP FINGER AGAIN");   
  p = -1;
  while (p != FINGERPRINT_OK) 
  { p = finger.getImage();     
  }
  // OK success! 
//--------------------------------------------------------------------------------
  p = finger.image2Tz(2);
  p = finger.createModel();   
//-------STORE FINGER IMAGE-----------------------------------------------------------  
  p = finger.storeModel(id);
  lcd.setCursor(0, 1);
  lcd.print("RegistrationDone");                                                                      //  CC2500
  check_attendance = 0;  
  delay(2000);    
  register_id = id;
  if(SEND_DATA())     
    { lcd.setCursor(0, 1);
      lcd.print("  DATA NOT SENT    ");    
    }
    else              
    { lcd.setCursor(0, 1);
      lcd.print(" DATA  SENT  ");    
    }
    delay(3000);

    register_id=0;
}

uint8_t readnumber(void) 
{ uint8_t num = 1;
  
  lcd.setCursor(0, 0);
  lcd.print("STUDENT ID      ");      
  lcd.setCursor(0, 1);
  lcd.print("  REGISTRATION  ");
  delay(1000);
  
  while (1) 
  { lcd.setCursor(12, 0);
    lcd.print("   ");
    lcd.setCursor(12, 0);
    lcd.print(num,DEC); 
    
    if(!digitalRead(KEY_1))        return num;
    if(!digitalRead(KEY_2))        
    {  if(num < MAX_STUDENT)     num++;
       else             num = 1;
    }
    if(!digitalRead(KEY_3)) 
    {  if(num > 1)      num--;
           else             num = MAX_STUDENT;
    }
    
    delay(300);
 }
}



//----------Wifi Code-------------------------------------
bool Client_setup(void)
{ AT_RESTORE();
  AT_CWMODE(3);
  AT_CIPMUX();
  if(!AT_CWJAP("smart","123123123"))
  {   Serial.println("Not Connected to server");
      return false;
  }
  return true;
}

byte SEND_DATA(void)
{ if(!AT_CIPSTART())    return 0;
  if(!AT_CIPSEND())     return 0;
  return 1; 
//  AT_CIPCLOSE();
}

void AT_CIPCLOSE(void)
{ String data = "";
  Serial.println("AT+CIPCLOSE=1");
  data = readData(1000);
}

bool AT_CIPSTART(void)
{ String data = "";
  bool return_flag = 0;
  Serial.println("AT+CIPSTART=1,\"TCP\",\"192.168.43.211\",80");
  data = readData(5000);
  return_flag = compare_string(data,(char *)"1,CONNECT",9); 
  return(return_flag);
}
//http://192.168.0.55/1509/smart_attendance/data.php?ID=1
bool AT_CIPSEND(void)
{ String Senddata = "GET /1509/smart_attendance/data.php?&ID="+String(attendance_id)+"&RID="+String(register_id)+" HTTP/1.1\r\nHost: 192.168.43.211\r\n\r\n";
  int Str_length = Senddata.length();
  String data = "";
  Serial.print("AT+CIPSEND=1,");
  Serial.println(Str_length,DEC);
  data = readData(2000);
  if(compare_string(data,(char *)">",1))
  { Serial.println(Senddata);
    data = readData(10000);
    if(compare_string(data,(char *)"SEND OK",7))
    { return true;
    }
  }
  return false;
}


void GET_NEW_DATA(void)
{ if (Serial.available() == 0) return;

  String Data = "";
  Data = readData(1000);
}
 
bool AT_CWJAP(String ipaddr,String passwrd)
{ String data = "";
  bool return_flag = 0;
  Serial.print("AT+CWJAP=\"");
  Serial.print(ipaddr);
  Serial.print("\",\"");
  Serial.print(passwrd);
  Serial.println("\"");
  data = readData(10000);
  return_flag = compare_string(data,(char *)"WIFI CONNECTED",14); 
  return(return_flag);
}

bool AT_test(void)
{ String data = "";
  Serial.println(F("AT"));
  data = readData(1000);
  return(compare_string(data,(char *)"OK",2));
}

void AT_RESTORE(void)
{ Serial.println(F("AT+RESTORE"));
  readData(5000);
}

void AT_RST(void)
{ Serial.println(F("AT+RST"));
  readData(1000);
}

void AT_CWMODE(char Mode)
{ Serial.print(F("AT+CWMODE="));
  Serial.println(Mode,DEC);
  readData(1000);
}
void AT_CIPMUX(void)
{ String data = "";
  Serial.println(F("AT+CIPMUX=1"));
  data = readData(1000);
}

bool AT_CWSAP(String My_WifiName,String My_Wifipswd)
{ String data = "";
  Serial.print(F("AT+CWSAP=\""));
  Serial.print(My_WifiName);
  Serial.print(F("\",\""));
  Serial.print(My_Wifipswd);
  Serial.println(F("\",5,3"));
  data = readData(5000);
  return (compare_string(data, (char *)"OK", 2));
}

bool AT_CIPSERVER(int port_num)
{ String data = "";
  Serial.print(F("AT+CIPSERVER=1,"));
  Serial.println(port_num,DEC);
  data = readData(1000);
  return(compare_string(data,(char *)"OK",2));    
}

bool AT_CIPCLOSE(char linkID)
{ String data = "";
  Serial.print(F("AT+CIPCLOSE="));
  Serial.println(linkID);
  data = readData(1000);
  return(compare_string(data,(char *)"OK",2));    
}

bool compare_string(String main_str,char *sub_str,char String2_size)
{ int main_str_length = 0,i = 0;
  main_str_length  = main_str.length();
  while(main_str_length != i)
  { if(main_str.substring(i,i + String2_size) == sub_str)
    { crnt_match_point = i+String2_size;
      return true; 
    }                                              
    i++;
  }
  return false;
}

String readData(unsigned long timeout) 
{   String data = "";
    unsigned long t = millis();
    while(millis() - t < timeout) 
    { if(Serial.available() > 0) 
      {   char r = Serial.read();
          data += r;
          t = millis();
      }
    } 
//  Serial.println(data);
    return data;
}
//--------------------------------------------------------
