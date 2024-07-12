
const int buttonPin  = 7;
int buttonState = HIGH;  

void setup(){
  pinMode( buttonPin , INPUT_PULLUP );
  Serial.begin( 9600 );
}

void loop(){
  buttonState = digitalRead(buttonPin);

  //ボタンを押した
  if (buttonState == LOW) 
  {
    Serial.println(true);
  } 
  //ボタンを押していない
  else
  {
    Serial.println(false);  
  }

    delay(1000);
}