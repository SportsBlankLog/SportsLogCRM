## DevOps

```
sudo apt-get update -y && sudo apt-get upgrade -y && sudo apt-get dist-upgrade -y && sudo apt-get install git -y

sudo apt-get install wget
sudo apt-get install nano
sudo apt-get install sqlite3

apt-get install ufw
ufw allow 22
ufw allow 443
ufw allow 80
ufw enable

# our .net8

chown -R www-data:www-data /root/.vs-debugger
chmod -R 777 /root/.vs-debugger

chown -R www-data:www-data /srv/db-backups
chmod -R 777 /srv/db-backups

chown -R www-data:www-data /srv/Cloud.Disk
chmod -R 777 /srv/Cloud.Disk

# PROD
ln -s /etc/nginx/sites-available/web.app /etc/nginx/sites-enabled/
ln -s /etc/nginx/sites-available/api.app /etc/nginx/sites-enabled/

# STAGING
ln -s /etc/nginx/sites-available/web.staging.app /etc/nginx/sites-enabled/
ln -s /etc/nginx/sites-available/api.staging.app /etc/nginx/sites-enabled/


systemctl reload nginx
docker-compose up -d

apt update -y && apt upgrade -y && apt dist-upgrade -y && apt install git -y

cd /srv/git
rm -r *
git clone https://github.com/badhitman/BlankCRM.git
git clone https://github.com/badhitman/HtmlGenerator.git

dotnet publish -c Debug --output /srv/git/builds/ApiRestService /srv/git/BlankCRM/ApiRestService/ApiRestService.csproj
dotnet publish -c Debug --output /srv/git/builds/StorageService /srv/git/BlankCRM/StorageService/StorageService.csproj
dotnet publish -c Debug --output /srv/git/builds/CommerceService /srv/git/BlankCRM/CommerceService/CommerceService.csproj
dotnet publish -c Debug --output /srv/git/builds/HelpdeskService /srv/git/BlankCRM/HelpdeskService/HelpdeskService.csproj
dotnet publish -c Debug --output /srv/git/builds/ConstructorService /srv/git/BlankCRM/ConstructorService/ConstructorService.csproj
dotnet publish -c Debug --output /srv/git/builds/TelegramBotService /srv/git/BlankCRM/TelegramBotService/TelegramBotService.csproj

#  *** ���� ���� ������� ������������ ��������� ������. �� �������� ������� �� �������� (����������� �������, ������� �������� �� ������ ��������� �����������)
#  cd /srv/git/BlankCRM/BlankBlazorApp/BlankBlazorApp/
#  dotnet tool install -g Microsoft.Web.LibraryManager.Cli
#  dotnet workload restore
#  libman restore
#  dotnet publish -c Release --output /srv/git/builds/BlankBlazorApp /srv/git/BlankCRM/BlankBlazorApp/BlankBlazorApp/BlankBlazorApp.csproj
#  *** ������� � ��� �������� ������� ��������, ��������� ����� sftp, ������������ � ��������� ������ ���-�� ������� ��������� ����������

systemctl stop web.app.service comm.app.service tg.app.service api.app.service bus.app.service constructor.app.service hd.app.service

# rm -r /srv/git/builds/*
rm -r /srv/services/*

cp -r /srv/git/builds/ApiRestService /srv/services/ApiRestService
cp -r /srv/git/builds/StorageService /srv/services/StorageService
cp -r /srv/git/builds/CommerceService /srv/services/CommerceService
cp -r /srv/git/builds/HelpdeskService /srv/services/HelpdeskService
cp -r /srv/git/builds/ConstructorService /srv/services/ConstructorService
cp -r /srv/git/builds/TelegramBotService /srv/services/TelegramBotService
cp -r /srv/git/builds/BlankBlazorApp /srv/services/BlankBlazorApp

chown -R www-data:www-data /srv/services.stage
chmod -R 777 /srv/services.stage

chown -R www-data:www-data /srv/tmp
chmod -R 777 /srv/tmp


systemctl start comm.app.service web.app.service bus.app.service tg.app.service api.app.service hd.app.service constructor.app.service

journalctl -f -u constructor.app.service
journalctl -f -u docker-compose-app.service

systemctl status constructor.app.service
```

#### Win
```
docker run -e RABBITMQ_DEFAULT_USER=guest -e RABBITMQ_DEFAULT_PASS=guest -p 15671:15671  -p 15672:15672  -p 15691:15691  -p 15692:15692  -p 25672:25672  -p 4369:4369  -p 5671:5671  -p 5672:5672  -p 5670:5670 rabbitmq:3-management
```