using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using XamarinProject.persistence;

namespace XamarinProject.Model
{
    class DBManager : ISQLiteDB
    {
        public SQLiteConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(documentsPath, "checkIt");
            return new SQLiteConnection(path);
        }
    }
}
