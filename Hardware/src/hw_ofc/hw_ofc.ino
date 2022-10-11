#include <Arduino.h>
#include <WiFi.h>
#include <WiFiMulti.h>
#include <HTTPClient.h>
#include <WiFiClientSecure.h>
#include <base64.h>
#include "soc/soc.h"
#include "soc/rtc_cntl_reg.h"
#include "esp_camera.h"

const char* rootCACertificate = \
"-----BEGIN CERTIFICATE-----\n" \
"MIIEDzCCAvegAwIBAgIBADANBgkqhkiG9w0BAQUFADBoMQswCQYDVQQGEwJVUzEl\n" \
"MCMGA1UEChMcU3RhcmZpZWxkIFRlY2hub2xvZ2llcywgSW5jLjEyMDAGA1UECxMp\n" \
"U3RhcmZpZWxkIENsYXNzIDIgQ2VydGlmaWNhdGlvbiBBdXRob3JpdHkwHhcNMDQw\n" \
"NjI5MTczOTE2WhcNMzQwNjI5MTczOTE2WjBoMQswCQYDVQQGEwJVUzElMCMGA1UE\n" \
"ChMcU3RhcmZpZWxkIFRlY2hub2xvZ2llcywgSW5jLjEyMDAGA1UECxMpU3RhcmZp\n" \
"ZWxkIENsYXNzIDIgQ2VydGlmaWNhdGlvbiBBdXRob3JpdHkwggEgMA0GCSqGSIb3\n" \
"DQEBAQUAA4IBDQAwggEIAoIBAQC3Msj+6XGmBIWtDBFk385N78gDGIc/oav7PKaf\n" \
"8MOh2tTYbitTkPskpD6E8J7oX+zlJ0T1KKY/e97gKvDIr1MvnsoFAZMej2YcOadN\n" \
"+lq2cwQlZut3f+dZxkqZJRRU6ybH838Z1TBwj6+wRir/resp7defqgSHo9T5iaU0\n" \
"X9tDkYI22WY8sbi5gv2cOj4QyDvvBmVmepsZGD3/cVE8MC5fvj13c7JdBmzDI1aa\n" \
"K4UmkhynArPkPw2vCHmCuDY96pzTNbO8acr1zJ3o/WSNF4Azbl5KXZnJHoe0nRrA\n" \
"1W4TNSNe35tfPe/W93bC6j67eA0cQmdrBNj41tpvi/JEoAGrAgEDo4HFMIHCMB0G\n" \
"A1UdDgQWBBS/X7fRzt0fhvRbVazc1xDCDqmI5zCBkgYDVR0jBIGKMIGHgBS/X7fR\n" \
"zt0fhvRbVazc1xDCDqmI56FspGowaDELMAkGA1UEBhMCVVMxJTAjBgNVBAoTHFN0\n" \
"YXJmaWVsZCBUZWNobm9sb2dpZXMsIEluYy4xMjAwBgNVBAsTKVN0YXJmaWVsZCBD\n" \
"bGFzcyAyIENlcnRpZmljYXRpb24gQXV0aG9yaXR5ggEAMAwGA1UdEwQFMAMBAf8w\n" \
"DQYJKoZIhvcNAQEFBQADggEBAAWdP4id0ckaVaGsafPzWdqbAYcaT1epoXkJKtv3\n" \
"L7IezMdeatiDh6GX70k1PncGQVhiv45YuApnP+yz3SFmH8lU+nLMPUxA2IGvd56D\n" \
"eruix/U0F47ZEUD0/CwqTRV/p2JdLiXTAAsgGh1o+Re49L2L7ShZ3U0WixeDyLJl\n" \
"xy16paq8U4Zt3VekyvggQQto8PT7dL5WXXp59fkdheMtlb71cZBDzI0fmgAKhynp\n" \
"VSJYACPq4xJDKVtHCN2MQWplBqjlIapBtJUhlbl90TSrE9atvNziPTnNvT51cKEY\n" \
"WQPJIrSPnNVeKtelttQKbfi3QBFGmh95DmK/D5fs4C8fF5Q=\n" \
"-----END CERTIFICATE-----\n";


const char* ssid = "PEDRO DIA 2G";
const char* password = "pedro123";
const String serverPath = "https://container-analise-expressao.herokuapp.com/";
const int funcional = 987335338;

WiFiClientSecure *client = new WiFiClientSecure;
HTTPClient https;
WiFiMulti WiFiMulti;

// CAMERA_MODEL_AI_THINKER
#define PWDN_GPIO_NUM     32
#define RESET_GPIO_NUM    -1
#define XCLK_GPIO_NUM      0
#define SIOD_GPIO_NUM     26
#define SIOC_GPIO_NUM     27

#define Y9_GPIO_NUM       35
#define Y8_GPIO_NUM       34
#define Y7_GPIO_NUM       39
#define Y6_GPIO_NUM       36
#define Y5_GPIO_NUM       21
#define Y4_GPIO_NUM       19
#define Y3_GPIO_NUM       18
#define Y2_GPIO_NUM        5
#define VSYNC_GPIO_NUM    25
#define HREF_GPIO_NUM     23
#define PCLK_GPIO_NUM     22

const int timerInterval = 10000;    // time between each HTTP POST image
unsigned long previousMillis = 0;   // last time image was sent

void setup() {
  //Configuração WIFI
  WRITE_PERI_REG(RTC_CNTL_BROWN_OUT_REG, 0); 
  Serial.begin(115200);

  WiFi.mode(WIFI_STA);
  WiFiMulti.addAP(ssid, password);

  // wait for WiFi connection
  Serial.print("Waiting for WiFi to connect...");
  while ((WiFiMulti.run() != WL_CONNECTED)) {
    Serial.print(".");
  }
  Serial.println("connected");
  
  Serial.println();
  Serial.print("ESP32-CAM IP Address: ");
  Serial.println(WiFi.localIP());

  //Configuração de Client WIFI
  WiFiClientSecure *client = new WiFiClientSecure;
  client -> setCACert(rootCACertificate);
  
  //Configuração de Camera 
  camera_config_t config;
  config.ledc_channel = LEDC_CHANNEL_0;
  config.ledc_timer = LEDC_TIMER_0;
  config.pin_d0 = Y2_GPIO_NUM;
  config.pin_d1 = Y3_GPIO_NUM;
  config.pin_d2 = Y4_GPIO_NUM;
  config.pin_d3 = Y5_GPIO_NUM;
  config.pin_d4 = Y6_GPIO_NUM;
  config.pin_d5 = Y7_GPIO_NUM;
  config.pin_d6 = Y8_GPIO_NUM;
  config.pin_d7 = Y9_GPIO_NUM;
  config.pin_xclk = XCLK_GPIO_NUM;
  config.pin_pclk = PCLK_GPIO_NUM;
  config.pin_vsync = VSYNC_GPIO_NUM;
  config.pin_href = HREF_GPIO_NUM;
  config.pin_sscb_sda = SIOD_GPIO_NUM;
  config.pin_sscb_scl = SIOC_GPIO_NUM;
  config.pin_pwdn = PWDN_GPIO_NUM;
  config.pin_reset = RESET_GPIO_NUM;
  config.xclk_freq_hz = 20000000;
  config.pixel_format = PIXFORMAT_JPEG;

  // init with high specs to pre-allocate larger buffers
  if(psramFound()){
    Serial.println("Parametros encontrados");
    config.frame_size = FRAMESIZE_UXGA;
    config.jpeg_quality = 15;  //0-63 lower number means higher quality
    config.fb_count = 3;
  } else {
    Serial.println("Parametros não encontrados... Reiniciando sistema...");
    ESP.restart();
  }
  
  // camera init
  esp_err_t err = esp_camera_init(&config);
  if (err != ESP_OK) {
    Serial.printf("Falha ao iniciar camera... Erro 0x%x", err);
  } else {
     Serial.println("Camera iniciada com sucesso");
  }
}

void loop() {
  unsigned long currentMillis = millis();
  if (currentMillis - previousMillis >= timerInterval) {
    sendPhoto();
    previousMillis = currentMillis;
  }
}

void sendPhoto() {    
  String getAll;
  String getBody;

  camera_fb_t * fb = NULL;
  fb = esp_camera_fb_get(); //Método que tira a foto
  if(!fb) {
    Serial.println("Falha ao capturar imagem");
    ESP.restart();
  } else {
    Serial.println("Sucesso ao capturar imagem");

    //Conversão de imagem (jpg) para base64
    uint8_t *fbBuf = fb->buf;
    String encodedImg = base64::encode(fbBuf, fb->len);
    const char* convertedImage = encodedImg.c_str();

    String json = "{\"funcional\":987335338,\"imagem\":\"" + (String)convertedImage +"\"}";  
    
    if(client) {
      HTTPClient https;
      
      Serial.print("[HTTPS] begin...\n");
        if (https.begin(serverPath, rootCACertificate)) {  // HTTPS
          https.addHeader("Content-Type", "application/json");
          Serial.print("[HTTPS] POST...\n");
          
          int httpCode = https.POST(json);
      
          // httpCode will be negative on error
          if (httpCode > 0) {
            // HTTP header has been send and Server response header has been handled
            Serial.printf("[HTTPS] POST... code: %d\n", httpCode);
    
            // file found at server
            if (httpCode == HTTP_CODE_OK || httpCode == HTTP_CODE_MOVED_PERMANENTLY) {
              String payload = https.getString();
              Serial.println(payload);
            }
          } else {
            Serial.printf("[HTTPS] POST... falha, erro: %s\n", https.errorToString(httpCode).c_str());
          }    
          
          https.end();        
      } else {
        Serial.println("Não foi possivel se conectar ao client https");
      }
          
      delete client;
    } else {
      Serial.println("Não foi possivel se conectar ao client WiFiClientSecure");
    }
  }
}
