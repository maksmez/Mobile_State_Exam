using Microsoft.EntityFrameworkCore;
using Xamarin.Essentials;
using System.IO;

namespace Mobile_State_Exam
{
    class Context : DbContext
    {
        public DbSet<Science> Science { get; set; }
        public DbSet<Term> Term { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Exam> Exam { get; set; }
        public DbSet<Exam_Questions> Exam_Questions { get; set; }
        public DbSet<Theme> Theme { get; set; }
        public DbSet<Cheat> Cheat { get; set; }

        public Context()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            string dbName = "examdatabase.db";
            string dbName2 = "examdatabase.db-shm";
            string dbName3 = "examdatabase.db-wal";
            string paaath = Path.Combine(FileSystem.AppDataDirectory, dbName);

            string dbPath = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), dbName);
            if (!File.Exists(paaath))
            {
                using (BinaryReader br = new BinaryReader(Android.App.Application.Context.Assets.Open(dbName)))
                {
                    using (BinaryWriter bw = new BinaryWriter(new FileStream(paaath, FileMode.Create)))
                    {
                        byte[] buffer = new byte[4096];
                        int len = 0;
                        while ((len = br.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            bw.Write(buffer, 0, len);
                        }
                    }
                }
                using (BinaryReader br2 = new BinaryReader(Android.App.Application.Context.Assets.Open(dbName2)))
                {
                    string dbPath2 = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), dbName2);
                    string paaath2 = Path.Combine(FileSystem.AppDataDirectory, dbName2);

                    using (BinaryWriter bw2 = new BinaryWriter(new FileStream(paaath2, FileMode.Create)))
                    {
                        byte[] buffer2 = new byte[4096];
                        int len2 = 0;
                        while ((len2 = br2.Read(buffer2, 0, buffer2.Length)) > 0)
                        {
                            bw2.Write(buffer2, 0, len2);
                        }
                    }
                }
                using (BinaryReader br3 = new BinaryReader(Android.App.Application.Context.Assets.Open(dbName3)))
                {
                    string dbPath3 = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), dbName3);
                    string paaath3 = Path.Combine(FileSystem.AppDataDirectory, dbName3);

                    using (BinaryWriter bw3 = new BinaryWriter(new FileStream(paaath3, FileMode.Create)))
                    {
                        byte[] buffer3 = new byte[4096];
                        int len3 = 0;
                        while ((len3 = br3.Read(buffer3, 0, buffer3.Length)) > 0)
                        {
                            bw3.Write(buffer3, 0, len3);
                        }
                    }
                }

            }

            optionsBuilder.UseSqlite($"Filename={paaath}");
        }
    }
}

