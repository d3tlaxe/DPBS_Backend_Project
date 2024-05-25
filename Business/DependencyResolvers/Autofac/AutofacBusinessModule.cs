using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<LessonManager>().As<ILessonService>().SingleInstance();
            builder.RegisterType<EfLessonDal>().As<ILessonDal>().SingleInstance();

            builder.RegisterType<ClassRoomManager>().As<IClassRoomService>().SingleInstance();
            builder.RegisterType<EfClassRoomDal>().As<IClassRoomDal>().SingleInstance();

            builder.RegisterType<StudentLessonManager>().As<IStudentLessonService>().SingleInstance();
            builder.RegisterType<EfStudentLessonDal>().As<IStudentLessonDal>().SingleInstance();

            builder.RegisterType<LessonAndPrelectorManager>().As<ILessonAndPrelectorPairService>().SingleInstance();
            builder.RegisterType<EfLessonAndPrelectorPairDal>().As<ILessonAndPrelectorPairDal>().SingleInstance();


        }
    }
}
