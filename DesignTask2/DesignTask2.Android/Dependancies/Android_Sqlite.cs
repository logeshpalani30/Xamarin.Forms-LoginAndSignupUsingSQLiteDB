//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Runtime.CompilerServices;
//using System.Text;

//using Android.App;
//using Android.Content;
//using Android.OS;
//using Android.Runtime;
//using Android.Views;
//using Android.Widget;
//using DesignTask2.Droid.Dependancies;
//using DesignTask2.Interfaces;
//using SQLite.Net;

//[assembly: Dependency(typeof(GetSQLiteConnnection))]
//namespace DesignTask2.Droid.Dependancies
//{
//    public class Android_Sqlite :ISQLite
//    {
//        public SQLiteConnection GetSQLiteConnection()
//        {
//            var fileName = "UserDatabase.db3";
//            var documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
//            var path = Path.Combine(documentPath, fileName);
//            var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
//            var connection = new SQLiteConnection(platform, path);
//            retrun connection;
//        }

//        SQLiteConnection ISQLite.GetSQLiteConnection()
//        {
//            throw new NotImplementedException();
//        }
//    }
//}