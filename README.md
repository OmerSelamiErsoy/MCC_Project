# MCC_Project

Projeyi ayağa kaldırmak için lütfen aşağıdaki adımları uygulayınız.
1) DB_Script projesi içindeki MSSQL backup dosyasını kurunuz.
2) Utility > Data > Settings.xml içerisindeki "Connnection_DB" fileld'ına güncel connection string bilginizi giriniz.
3) Aşağıda belirtilen config dosyalarına projelerin genel config dosyası olan "Utility > Data > Settings.xml"'i görebilmesi için,
   kendi makinanızdaki "Utility > Data > Settings.xml" klasör path'ini giriniz.
  - AdminPanel > Web.config içerisindeki "ConfigFilePath"
  - WebApplication > Web.config içerisindeki "ConfigFilePath"
  - UnitTestProject > App.config içerisindeki "ConfigFilePath"
4) Makinanızda "AdminPanel" projesine ait port "59091" değil ise, Upload edilen fotoğrafların kullanıcı arayüzünde görünebilmesi için 
  "Utility > Data > Settings.xml" içindeki "AdminDirectoryLocal" fileld'ını kendi makinanızdaki port ile güncelleyiniz.

Yönetim paneline "yonetici@mcc.com.tr" / "123" ile giriş yapablirsiniz. 
