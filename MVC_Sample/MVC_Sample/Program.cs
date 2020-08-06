//**********************************************************************************
//* テンプレート
//**********************************************************************************

// サンプル中のテンプレートなので、必要に応じて使用して下さい。

//**********************************************************************************
//* クラス名        ：Program
//* クラス日本語名  ：Program
//*
//* 作成日時        ：－
//* 作成者          ：－
//* 更新履歴        ：－
//*
//*  日時        更新者            内容
//*  ----------  ----------------  -------------------------------------------------
//*  20xx/xx/xx  ＸＸ ＸＸ         ＸＸＸＸ
//**********************************************************************************

using System;
using System.Net.Http;

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

using Touryo.Infrastructure.Framework.Authentication;

namespace MVC_Sample
{
    /// <summary>Program</summary>
    public class Program
    {
        /// <summary>
        /// Main（エントリポイント）</summary>
        /// <param name="args">コマンドライン引数</param>
        public static void Main(string[] args)
        {
            // OpenID用
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                OAuth2AndOIDCClient.HttpClient = new HttpClient();
            }
            else
            {
                //OAuth2AndOIDCClient.HttpClient = new HttpClient();

                // 暫定
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback 
                    = (message, cert, chain, sslPlicyErrors) => true;
                OAuth2AndOIDCClient.HttpClient = new HttpClient(handler);
            }

            // BuildWebHostが返すIWebHostをRunする。
            // 呼び出し元スレッドは終了までブロックされる。
            Program.BuildWebHost(args).Run();
        }

        /// <summary>BuildWebHost</summary>
        /// <param name="args">コマンドライン引数</param>
        /// <returns>IWebHost</returns>
        public static IWebHost BuildWebHost(string[] args)
        {
            // WebHost経由で、IWebHost, IWebHostBuilderにアクセスする。

            string url = Environment.GetEnvironmentVariable("UseUrl");
            if (string.IsNullOrEmpty(url))
            {
                url = "http://0.0.0.0:5000/";
            }

            return WebHost.CreateDefaultBuilder(args) //  IWebHostBuilderを取得する。
                .UseStartup<Startup>() // IWebHostBuilder.UseStartup<TStartup> メソッドにStartupクラスを指定。
                .UseUrls(url) // 使用するプロトコルとポートを決定する。
                .Build(); // IWebHostBuilder.Build メソッドでIWebHostクラスインスタンスを返す。
        }
    }
}
