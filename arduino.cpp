#include <Arduino.h>

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  pinMode(8,OUTPUT);
}

void loop() {
  if (Serial.available()) // seri haberleşme var ise...
  {
    char gelen_bilgi=Serial.read();
    
    if (gelen_bilgi=='1')
    {
      /* code */
      digitalWrite(8,HIGH);
    }
    else if (gelen_bilgi=='0')
    {
      /* code */
      digitalWrite(8, LOW);
    }
    
    
    
  }
  
  // put your main code here, to run repeatedly:
}
