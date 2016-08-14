// Ultrasonic - Library for HR-SC04 Ultrasonic Ranging Module.
// Rev.4 (06/2012)
// J.Rodrigo ( www.jrodrigo.net )
// more info at www.ardublog.com

#include <Ultrasonic.h>

Ultrasonic ultrasonic(5,6); // (Trig PIN,Echo PIN)

void setup() {
  Serial.begin(9600);
pinMode(4,INPUT);
pinMode(3,INPUT);
}

void loop()
{
  Serial.print(ultrasonic.Ranging(CM)); // CM or INC
//Serial.println(" cm" );
  Serial.println(" " );
  int val = digitalRead(4);
  Serial.print(val);
  Serial.println(" " );
  int val2 = digitalRead(3);
  Serial.print(val2);
 Serial.println(" " );
  delay(100);
}
