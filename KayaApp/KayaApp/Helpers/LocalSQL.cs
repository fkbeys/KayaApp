using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KayaApp.Helpers
{
    public class LocalSQL<T> where T : new()
    {
        #region default generic methods for sql
        public static SQLiteAsyncConnection conn;
        public LocalSQL()
        {
            //  Baglan().Wait();
        }

        public static async Task Baglan()
        {
            try
            {
                if (conn == null)
                {
                    conn = new SQLiteAsyncConnection(App.databaselocation);
                    //,SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.FullMutex  );
                    //  conn.CreateTableAsync<T>().Wait();
                    //await conn.EnableWriteAheadLoggingAsync();

                    await conn.CreateTableAsync<T>();
                }
            }
            catch (Exception ex)
            {

                await App.Current.MainPage.DisplayAlert("Local SQL Error:", ex.Message, "ok");


            }


        }


        public static async Task<int> DBINSERTALL(List<T> DataIn)
        {

            try
            {
                await Baglan();


                return await conn.InsertAllAsync(DataIn);

            }
            catch (Exception ex)
            {

                await App.Current.MainPage.DisplayAlert("Local SQL Error:", ex.Message, "ok");

            }
            return 0;


        }
        public static async Task<int> DBROWINSERT(T datain)
        {
            await Baglan();
            // bu null durumunu bi kontrol et





            //if (datain != null)
            //{
            //    return await conn.UpdateAsync(datain);
            //}
            //else
            //{
            return await conn.InsertAsync(datain);
            //    }

        }
        public static async Task<List<T>> GETLISTALL()
        {
            try
            {
                await Baglan();
                return await conn.Table<T>().ToListAsync();
            }
            catch (Exception ex)
            {

                //  await HelpME.MessageShow("Local SQL List Error", ex.Message, "okkk");
                return null;
            }


        }

        //where cumlelerini T class i ile degilde, sql sorgusu ile alicak
        public static async Task<string> STOKGETROWSQL(string tabloadi, int id)
        {
            await Baglan();
            return await conn.ExecuteScalarAsync<string>("select * from " + tabloadi + " where stockid=?", id);
        }

        public static async Task<List<T>> GETCELL(string sorgu)
        {
            await Baglan();
            return await conn.QueryAsync<T>(sorgu);
        }

        public static async Task<List<T>> DBIslem(string sorgu)
        {
            await Baglan();

            return await conn.QueryAsync<T>(sorgu);

        }

        public static async Task<int> DELETEROW(T gelendata)
        {
            await Baglan();
            return await conn.DeleteAsync(gelendata);
        }
        public static async Task<int> DELETEALL()
        {
            await Baglan();
            return await conn.DeleteAllAsync<T>();
        }
        public static async Task<int> DROPTABLE()
        {
            await Baglan();
            return await conn.DropTableAsync<T>();
        }
        #endregion

        #region custom selects




        #endregion

    }
}