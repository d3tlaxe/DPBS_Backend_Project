using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class MyContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-C9PI61K\MSSQLSERVER01; Database = DersProgramıDB; Trusted_Connection=true; TrustServerCertificate=True");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<StudentPeriod> StudentPeriods { get; set; }
        public DbSet<StudentLesson> StudentLessons { get; set; }
        public DbSet<StudentDetail> StudentDetails { get; set; }
        public DbSet<PrelectorDetail> PrelectorDetails { get; set; }
        public DbSet<PrelectorAppellation> PrelectorAppellations { get; set; }
        public DbSet<LessonAtClassRoom> LessonsAtClassRooms { get; set; }
        public DbSet<LessonAndPrelectorPair> LessonAndPrelectorPairs { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<LessonStartTime> LessonStartTimes { get; set; }
        public DbSet<WeekDay> WeekDays { get; set; }




    }
}
