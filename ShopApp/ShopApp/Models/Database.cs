using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Models
{
    public class Database
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public bool createDatabase()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "ShopDB.db")))
                {
                    connection.CreateTable<Item>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
              //  Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }
        //Add or Insert Operation  

        public bool insertIntoTable(Item item)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "ShopDB.db")))
                {
                    connection.Insert(item);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
              //  Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }
        public List<Item> selectTable()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "ShopDB.db")))
                {                    
                    return connection.Table<Item>().ToList();
                }
            }
            catch (SQLiteException ex)
            {
              //  Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }
        //Edit Operation  

        //public bool updateTable(Item item)
        //{
        //    try
        //    {
        //        using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Persons.db")))
        //        {
        //            connection.Query<Person>("UPDATE Person set Name=?, Department=?, Email=? Where Id=?", person.Name, person.Department, person.Email, person.Id);
        //            return true;
        //        }
        //    }
        //    catch (SQLiteException ex)
        //    {
        //        Log.Info("SQLiteEx", ex.Message);
        //        return false;
        //    }
        //}
        //Delete Data Operation  

        public bool removeTable(Item person)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "ShopDB.db")))
                {
                    connection.Delete(person);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
               // Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }
        //Select Operation  

        public bool selectTable(int Id)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "ShopDB.db")))
                {
                    connection.Query<Item>("SELECT * FROM Person Where Id=?", Id);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                //Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }
    }
}
