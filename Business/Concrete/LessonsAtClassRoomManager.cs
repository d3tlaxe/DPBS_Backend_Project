using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class LessonsAtClassRoomManager : ILessonsAtClassRoomService
    {

        ILessonsAtClassRoomDal _lessonAtClassRoomDal;

        ILessonAndPrelectorPairService _lessonAndPrelectorPairService;

        ILessonDal _lessonDal;

        IClassRoomDal _classRoomDal;


        public LessonsAtClassRoomManager(ILessonsAtClassRoomDal lessonAtClassRoomDal, ILessonAndPrelectorPairService lessonAndPrelectorPairService, ILessonDal lessonDal, IClassRoomDal classRoomDal)
        {
            _lessonAtClassRoomDal = lessonAtClassRoomDal;
            _lessonAndPrelectorPairService = lessonAndPrelectorPairService;
            _lessonDal = lessonDal;
            _classRoomDal = classRoomDal;
        }

        public IResult Add(LessonAtClassRoom lessonAtClassRoom)
        {
            if (lessonAtClassRoom.LessonAndPrelectorPairId != 0)
            {
                _lessonAtClassRoomDal.Add(lessonAtClassRoom);
                return new SuccessResult(Messages.LessonAtClassRoomAdded);
            }
            else
            {
                return new ErrorResult(Messages.IdCantZero);
            }
        }

        public IResult AddWithParameter(int classroomId, int lessonId, int prelectorId, int lessonDayId, int lessonStartTimeId)
        {

            int pairId = _lessonAndPrelectorPairService.GetPairId(lessonId, prelectorId).Data;

            LessonAtClassRoom lessonAtClassroom = new LessonAtClassRoom
            {
                ClassRoomId = classroomId,
                LessonAndPrelectorPairId = pairId,
                LessonDay = lessonDayId,
                LessonStartTime = lessonStartTimeId
            };


            int classRoomCapacity = _classRoomDal.Get(cr => cr.Id == classroomId).MaxCapacity;
            int lessonCapacity = _lessonDal.Get(l => l.Id == lessonId).Capacity;

            int lessonWeeklyHour = _lessonDal.Get(lh => lh.Id == lessonId).LessonHours;

            if (lessonCapacity <= classRoomCapacity)
            {
                if (_lessonAtClassRoomDal.GetByPairId(pairId).Count < lessonWeeklyHour)
                {
                    if (isThereAnyLessonSameTime(prelectorId, lessonDayId, lessonStartTimeId).Data == true)
                    {
                        if (isClassRoomAvailable(classroomId, lessonDayId, lessonStartTimeId).Data == true)
                        {
                            _lessonAtClassRoomDal.Add(lessonAtClassroom);
                            return new SuccessResult("Ders Başarılı Bir Şekilde Planlandı");
                        }
                        else
                        {
                            return new SuccessResult("Seçtiğiniz Gün ve Saatte Bu Derslik Dolu. Lütfen Farklı Bir Seçim Yapınız.");
                        }
                    }
                    else
                    {
                        return new SuccessResult("Bu Gün ve Saatte Dersiniz Var.Lütfen Başka Gün ve Saat Belirleyiniz.");

                    }
                }
                else
                {
                    return new SuccessResult("Bu Ders İçin Haftalık Ders Saatinin Tamamı Planlandı. Lütfen Diğer Dersler İçin Planlama Yapınız.");
                }
            }
            else
            {
                return new SuccessResult("Seçtiğiniz Derslik Bu Dersin Kontenjanından Küçük. Lütfen Daha Büyük Bir Derslik Seçiniz.");
            }

            

        }

        public IDataResult<List<LessonAtClassRoom>> GetPlannedClassrooms()
        {
            return new SuccessDataResult<List<LessonAtClassRoom>>(_lessonAtClassRoomDal.GetPlannedClassrooms(), "Planlanmış Derslikler Listelendi");
        }

        public IDataResult<List<ProgramForPrelectorDto>> GetPlannedLesson()
        {
            return new SuccessDataResult<List<ProgramForPrelectorDto>>(_lessonAtClassRoomDal.GetPlannedLesson(), "Planlanmış Dersler Listelendi");
        }

        public IDataResult<List<ProgramForPrelectorDto>> GetPlannedPrelector()
        {
            return new SuccessDataResult<List<ProgramForPrelectorDto>>(_lessonAtClassRoomDal.GetPlannedPrelector(), "Planlama Yapan Hocalar Listelendi");
        }

        public IDataResult<List<ProgramForPrelectorDto>> GetProgramForPrelector(int prelectorId)
        {
            return new SuccessDataResult<List<ProgramForPrelectorDto>>(_lessonAtClassRoomDal.GetProgramForPrelector(prelectorId), "Öğretim Görevlisi Programı Listelendi");
        }


        public IDataResult<bool> isClassRoomAvailable(int classRoomId, int lessonDay, int LessonStartTime)
        {
            bool isAvailable;
            if (_lessonAtClassRoomDal.Get(lacr => lacr.ClassRoomId == classRoomId && lacr.LessonDay == lessonDay && lacr.LessonStartTime == LessonStartTime) != null)
            {
                isAvailable = false;
                return new ErrorDataResult<bool>(isAvailable, Messages.ClassRoomisNotAvailable);
            }
            else
            {
                isAvailable=true;
                return new SuccessDataResult<bool>(isAvailable, Messages.ClassRoomisAvailable);
            }
        }

        public IDataResult<bool> isThereAnyLessonSameTime(int prelectorId, int lessonDay, int lessonStartTime)
        {
            bool isAvailable;

            List<ProgramForPrelectorDto> list = _lessonAtClassRoomDal.GetProgramForPrelector(prelectorId);



            if (list.Find(x => x.LessonDayId == lessonDay && x.LessonHourId == lessonStartTime) != null)
            {
                isAvailable = false;
                return new SuccessDataResult<bool>(isAvailable, "Bu Gün ve Saatte Dersiniz Var. Lütfen Başka Gün ve Saat Belirleyiniz.");
            }
            isAvailable = true;
            return new SuccessDataResult<bool>(isAvailable, "Seçilen Gün ve Saatte Dersiniz Yok. Ders Seçimi İçin UYGUN");

        }
    }
}
