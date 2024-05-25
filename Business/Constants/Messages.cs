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
    }
}
