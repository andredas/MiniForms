
#include <SPI.h>//include the SPI bus library
#include <MFRC522.h>//include the RFID reader library

#include <Wire.h> 
#include <LiquidCrystal_I2C.h>

LiquidCrystal_I2C lcd(0x27, 2, 1, 0, 4, 5, 6, 7, 3, POSITIVE);

#define SS_PIN 10  //slave select pin
#define RST_PIN 9  //reset pin
MFRC522 mfrc522(SS_PIN, RST_PIN);        // instatiate a MFRC522 reader object.
MFRC522::MIFARE_Key key;//create a MIFARE_Key struct named 'key', which will hold the card information

void setup() {
  lcd.begin(16,2);
    pinMode(8,OUTPUT);
  // put your setup code here, to run once:
  Serial.begin(9600);        // Initialize serial communications with the PC
    SPI.begin();               // Init SPI bus
    mfrc522.PCD_Init();        // Init MFRC522 card (in case you wonder what PCD means: proximity coupling device)
    //Serial.println("Scan a MIFARE Classic card");
    
    // Prepare the security key for the read and write functions - all six key bytes are set to 0xFF at chip delivery from the factory.
    // Since the cards in the kit are new and the keys were never defined, they are 0xFF
    // if we had a card that was programmed by someone else, we would need to know the key to be able to access it. This key would then need to be stored in 'key' instead.

    for (byte i = 0; i < 6; i++) {
            key.keyByte[i] = 0xFF;//keyByte is defined in the "MIFARE_Key" 'struct' definition in the .h file of the library
    }

}

int block=2;//this is the block number we will write into and then read. Do not write into 'sector trailer' block, since this can make the block unusable.
  
//byte blockcontent[16] = {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};//all zeros. This can be used to delete a block.

void loop() 
{
  byte readbackblock[18];//This array is used for reading out a block. The MIFARE_Read method requires a buffer that is at least 18 bytes to hold the 16 bytes of a block.
  String s = Serial.readString(); 
  if(s == "Read")
  {
    Serial.println("Reading");
    lcd.clear();
    lcd.home();
    lcd.print("Scan Card");
    while(newCard() == 0)
    {
      delay(1);
    }
  
  
    digitalWrite(8, HIGH);   // turn the Buzzer on
    readBlock(block, readbackblock);//read the block back
    lcd.clear();
    lcd.home();
    for (int j=0 ; j<16 ; j++)//print the block contents
    { 
      Serial.write (readbackblock[j]);//Serial.write() transmits the ASCII numbers as human readable characters to serial monitor
      //lcd.write (readbackblock[j]);
    }
    digitalWrite(8, LOW);   // turn the Buzzer off
    Serial.println("");
    mfrc522.PCD_Init();
    //delay(2000);
    lcd.clear();
   }
  else if(s == "Denied"){
    lcd.clear();
    lcd.home();
    lcd.print("Access denied");
  }
}

