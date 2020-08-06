# MVCSampleOnDocker
このフォルダのコンテンツを実行するには、

当該リポジトリをクローンした後に、
```
git clone https://github.com/NetDevInfraWGinOSSConsortium/MVCSampleOnDocker.git
```
目的毎に、以下の操作を行う。

## 前提リポジトリ
以下のリポジトリが前提となっている

### 外部ストレージ
RDB、NoSQLなどの外部ストレージ。

- https://github.com/NetDevInfraWGinOSSConsortium/LocalServicesOnDocker

### 外部ログイン
OAuth2/OIDC, SAMLなどの認証基盤。

- https://github.com/NetDevInfraWGinOSSConsortium/OAuth2OidcArchitOnDocker

## HTTPS用の秘密鍵の生成
`.\MVCSampleOnDocker\MVC_Sample\files\tools`フォルダに移動後、  
`dotnet_dev-certs.bat` をダブルクリックし、HTTPS用の秘密鍵を生成する。

## デバッグ実行
`.\MVCSampleOnDocker\MVC_Sample`フォルダに移動後、  
`0_ExecAllBat.bat` をダブルクリックし、ライブラリ類を取得＆ビルドする。

MVC_Sample.sln を Visual Studio で開き、以下の手順で、Visual Studio Tools for Docker を使用して起動する。  

- https://techinfoofmicrosofttech.osscons.jp/index.php?Visual%20Studio%20Tools%20for%20Docker#e09b7e2d

IIS Express と Docker Compose でのみ起動する（Dockerでは環境変数の不足で外部接続が不可）。

## Docker HubとPushとPull

### DockerへPush
この操作は、基本的に、コミュニティ側で行うが、  
組織名をリネームすれば、ユーザが自由に利用可能。

`.\MVCSampleOnDocker\DockerHub\Push`フォルダに移動後、  

- `00_Transform4DockerBuild.bat` をダブルクリックし、  
Docker Hubに登録するコンテナ・イメージの作成用のビルドシステムに変形する。

- `01_DeleteDir.bat` と `02_DeleteFile.bat` をダブルクリックし、  
ビルド対象のMVC_Sampleフォルダ内のコンテンツをクリーンナップする。

- `10_DockerBuild.bat` をダブルクリックし、  
Docker Buildを行い、コンテナ・イメージを生成する。

- `21_DockerComposeUp.bat` をダブルクリックし、  
生成したコンテナ・イメージを用いてコンテナを起動し、テスト実行する。

- `22_DockerComposeDown.bat` をダブルクリックし、  
必要に応じて、コンテナを停止し、テストを終了する。

- `30_Push2DockerHub.bat` をダブルクリックし、  
コンテナ・イメージをDocker Hubに登録する。

### DockerからPull
`.\MVCSampleOnDocker\DockerHub\Pull`フォルダに移動後、  
- `0_Pull.bat`をダブルクリックし、
  - Docker Hubからコンテナ・イメージを取得し、
  - 取得したコンテナ・イメージを用いてコンテナを起動し、テスト実行する。
- `1_Stop.bat`をダブルクリックし、コンテナを停止し、テストを終了する。
