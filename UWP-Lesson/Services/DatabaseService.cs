using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP_Lesson.Models;
using Windows.Storage;

namespace UWP_Lesson.Services
{
    public class DatabaseService
    {
        private SQLiteConnection sqliteConnection;

        //public SQLiteConnection SqliteConnection
        //{
        //    get { return sqliteConnection; }
        //}

        public TableQuery<Class1> Class1
        {
            get { return this.sqliteConnection.Table<Class1>(); }
        }

        public TableQuery<Class2A> Class2A
        {
            get { return this.sqliteConnection.Table<Class2A>(); }
        }

        public TableQuery<Class2B> Class2B
        {
            get { return this.sqliteConnection.Table<Class2B>(); }
        }

        public List<Class2A> Class2AEager
        {
            get { return this.sqliteConnection.GetAllWithChildren<Class2A>(); }
        }

        public List<Class2B> Class2BEager
        {
            get { return this.sqliteConnection.GetAllWithChildren<Class2B>(); }
        }

        public int Save(object item)
        {
            return this.sqliteConnection.InsertOrReplace(item);
        }

        public void SaveWithChildren(Class2A item)
        {
            this.Save(item.SubClassA);
            this.sqliteConnection.InsertOrReplaceAllWithChildren(item.ListClass2B);
            this.sqliteConnection.InsertOrReplaceWithChildren(item, true);
        }

        public void SaveWithChildren(Class2B item)
        {
            this.Save(item.SubClassA);
            this.sqliteConnection.InsertOrReplaceAllWithChildren(item.ListClass2A);
            this.sqliteConnection.InsertOrReplaceWithChildren(item);
        }

        public DatabaseService()
        {
            Task.Factory.StartNew(async () =>
            {
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                StorageFile myDb = await localFolder.CreateFileAsync("mydb.sqlite",
                        CreationCollisionOption.OpenIfExists);
                this.sqliteConnection = new SQLiteConnection(myDb.Path);
                this.sqliteConnection.CreateTable<Class1>();

                this.sqliteConnection.CreateTable<Class2AB>();
                this.sqliteConnection.CreateTable<Class2A>();
                this.sqliteConnection.CreateTable<Class2B>();
            });
        }
    }
}
