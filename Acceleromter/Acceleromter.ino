// The SFE_LSM9DS1 library requires both Wire and SPI be
// included BEFORE including the 9DS1 library.
#include <Wire.h>
#include <SPI.h>
#include <SparkFunLSM9DS1.h>

//////////////////////////
// LSM9DS1 Library Init //
//////////////////////////
// Use the LSM9DS1 class to create an object. [imu] can be
// named anything, we'll refer to that throught the sketch.
LSM9DS1 imu;
float roll;
float pitch;
float heading;

///////////////////////
// Example I2C Setup //
///////////////////////
// SDO_XM and SDO_G are both pulled high, so our addresses are:
#define LSM9DS1_M  0x1C // Would be 0x1C if SDO_M is LOW
#define LSM9DS1_AG  0x6A // Would be 0x6A if SDO_AG is LOW

////////////////////////////
// Sketch Output Settings //
////////////////////////////
#define PRINT_CALCULATED
//#define PRINT_RAW
#define PRINT_SPEED 15// 250 ms between prints

// Earth's magnetic field varies by location. Add or subtract
// a declination to get a more accurate heading. Calculate
// your's here:
// http://www.ngdc.noaa.gov/geomag-web/#declination
#define DECLINATION -8.58 // Declination (degrees) in Boulder, CO.


void setup()
{

  Serial.begin(9600);


  imu.settings.device.commInterface = IMU_MODE_I2C;
  imu.settings.device.mAddress = LSM9DS1_M;
  imu.settings.device.agAddress = LSM9DS1_AG;

  if (!imu.begin())
  {
    Serial.println("Failed to communicate with LSM9DS1.");
    Serial.println("Double-check wiring.");
    Serial.println("Default settings in this sketch will " \
                   "work for an out of the box LSM9DS1 " \
                   "Breakout, but may need to be modified " \
                   "if the board jumpers are.");
    while (1)
      ;
  }
}

double AX, GX;
double AY, GY;
double AZ, GZ;

double y = 1;
double py = 1;
double ky;

double x = 1;
double px = 1;
double kx;

double z = 1;
double pz = 1;
double kz;

double timestamp = 0;
double delta_time;

double pre_heading;
double pre_roll;
double pre_pitch;

int x_step = 0;
int y_step = 0;
int z_step = 0;

float pre_AZ;
int pi_state = 2;

#define num 5
float s_pitch[num] = {0};
float s_roll[num] = {0};
float s_heading[num] = {0};
int array_count = 0;


void loop()
{
  imu.readAccel();
  imu.readMag();
  imu.readGyro();
  // printAttitude(imu.ax, imu.ay, imu.az, -imu.my, -imu.mx, imu.mz);

  AY = imu.calcAccel(imu.ay);
  GY = imu.calcGyro(imu.gy);


  roll = roll;


  delta_time = (micros() - timestamp) / 1000000;
  timestamp = micros();

  //project the state ahead
  y = y - delta_time * AY;

  //project the error covariance ahead
  float ptemp = 1.0;

  py = py + abs(py * delta_time * AY) * ptemp;

  ky = py / ( py + 0.003565444 );



  y = y + ky * (roll - y);

  //Update the error covariance

  py = (1 - ky) * py;

  
    Serial.print( y*90);
    Serial.println(" ");

  
  delay(100);

}
