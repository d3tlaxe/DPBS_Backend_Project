using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola Yanlış";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Kullanıcı zaten var";
        public static string LessonAdded = "Ders Eklendi";
        public static string LessonDeleted = "Ders Silindi";
        public static string LessonListed = "Dersler Listelendi";
        public static string LessonUpdated = "Ders Güncellendi";

        public static string ClassRoomAdded = "Deslik Eklendi";
        public static string ClassRoomUpdated = "Derslik Güncellendi";
        public static string ClassRoomDeleted = "Derslik Silindi";
        public static string ClassRoomsListed = "Derslikler Listelendi";

        public static string PrelectorsLessonsListed = "Öğretim Görevlisine Atanan Dersler Listelendi";
        public static string LessonsPrelectorsListed = "Dersi Veren Öğretim Görevlileri Listelendi";
        public static string lessonAndPrelectorPairAdded = "Ders ve Öğretim Görevlisi Çifti Eklendi";
        public static string StudentProgramListed = "Öğrencinin Ders Programı Listelendi";
        public static string BiggerClassRoomsListed = "Verilen Parametreden Büyük Olan Derslikler Listelendi";
        internal static string studentLessonAdded = "Öğrencinin Dersi Eklendi";
        internal static string studentLessonUpdated = "Öğrencinin Dersi Güncellendi";
        internal static string studentLessonDeleted = "Öğrencinin Dersi Silindi";

        public static string ClassRoomisNotAvailable = "Derslik Müsait Değil";
        public static string ClassRoomisAvailable = "Derslik Müsait";

        public static string WeekDayListed = "Haftanın Günleri Listelendi";
        public static string LessonStartTimeListed = "Günlük Ders Saatleri Listelendi";

        public static string ThereisAPair = "Böyle Bir Kayıt Var";
        public static string ThereisNotPair = "Böyle Bir Kayıt Yok";

        public static string UserAdded = "Kullanıcı Eklendi";

        public static string PrelectorAdded = "Öğretim Görevlisi Eklendi";

        public static string StudentPeriodAdded = "Öğrencinin Dönemi Eklendi";

        public static string StudentAdded = "Öğrenci Eklendi";

        public static string StudentCountShowed = "Dersi Seçen Öğrenci Sayısı Döndürüldü";

        public static string StudentLessonAdded = "Öğrencinin Dersi Eklendi";
    }
}
