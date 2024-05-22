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
        internal static string ClassRoomUpdated = "Derslik Güncellendi";
        internal static string ClassRoomDeleted = "Derslik Silindi";
        internal static string ClassRoomsListed = "Derslikler Listelendi";
    }
}
