# MVCSampleOnDocker
以下のリポジトリが前提となっている（RDB、NoSQLなどのサービス）。

- https://github.com/NetDevInfraWGinOSSConsortium/LocalServicesOnDocker

このフォルダのコンテンツを実行するには、

当該リポジトリをクローンした後に、
```
git clone https://github.com/NetDevInfraWGinOSSConsortium/MVCSampleOnDocker.git
```

目的毎に、以下の操作を行う。

## デバッグ実行
`.\MVCSampleOnDocker\MVC_Sample`フォルダに移動後、  
`0_ExecAllBat.bat` をダブルクリックし、ライブラリ類を取得＆ビルド。

MVC_Sample.sln を Visual Studio で開き、以下の手順で、Visual Studio Tools for Docker を使用して起動する。  

- https://techinfoofmicrosofttech.osscons.jp/index.php?Visual%20Studio%20Tools%20for%20Docker#e09b7e2d

IIS Express と Docker Compose でのみ起動する（DockerではDB接続不可）。

## Docker HubとPushとPull

### DockerへPush
この操作は、基本的に、コミュニティ側で行うが、  
組織名をリネームすれば、ユーザが自由に利用可能。

`.\MVCSampleOnDocker\DockerHub\Push`フォルダに移動後、  

- `0_Transform_MVC_Sample4DockerBuild.bat` をダブルクリックし、  
Docker Hubに登録するコンテナ・イメージの作成用のビルドシステムに変形する。

- `1_DockerBuild_MVC_Sample.bat` をダブルクリックし、  
Docker Buildを行い、コンテナ・イメージを生成する。

- `2_DockerCompose_MVC_Sample.bat` をダブルクリックし、  
生成したコンテナ・イメージをテスト実行する。

- `3_Push_MVC_Sample2DockerHub.bat` をダブルクリックし、  
コンテナ・イメージをDocker Hubに登録する。

### DockerからPull
`.\MVCSampleOnDocker\DockerHub\Pull`フォルダに移動後、  
`0_Pull_MVC_SampleFromDockerHub.bat`をダブルクリックし、  
Docker Hubからコンテナ・イメージを取得し、テスト実行する。
