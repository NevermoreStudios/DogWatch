int portplus=13;
int portlow=5;
int portmid=6;
int porthigh=7;
int portmotion=12;
int val;
int drink;
int drinkv;
int preval=-1;
int pred=-1;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  pinMode(portplus,OUTPUT);
  pinMode(portlow,INPUT);
  pinMode(portmid,INPUT);
  pinMode(porthigh,INPUT);
  pinMode(portmotion,INPUT);
}

void loop() {
  // put your main code here, to run repeatedly:
  drink=digitalRead(portmotion);
  if(drink==HIGH)
  {
    digitalWrite(portplus,LOW);
    drinkv=1;
  }
  else
  {
    digitalWrite(portplus,HIGH);
    if(digitalRead(porthigh)==HIGH)
    {
      val=0;
    }
    else if(digitalRead(portmid)==HIGH)
    {
      val=1;
    }
    else if(digitalRead(portlow)==HIGH)
    {
      val=2;
    } 
    else
    {
      val=3;
    } 
    drinkv=0;
  }
  if(preval != val || pred != drinkv){
  Serial.print(val);
  Serial.println(drinkv);
  preval=val;
  pred=drinkv;
  }
}