using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba Eklendi";
        public static string CarDeleted = "Araba Silindi";
        public static string CarUpdated = "Araba Güncellendi";
        public static string CarsListed = "Arabalar Listelendi";

        public static string MaintenanceTime = "Sistem Bakımda";

        public static string RentalAdded = "Araba kiralandı";
        public static string RentalNotAdded = "Araba Kiralanamadı";
        public static string RentalsListed = "Kiralanan araçlar Listelendi";

        public static string CustomersListed = "Müşteriler Listelendi";

        public static string UsersListed = "Kullanıcılar Listelendi";
        public static string CarImageCountOfCarError ="Maksimum 5 adet resim yüklenebilir";
        public static string CarImageDeleted = "Resim silindi";
        public static string CarImagesListed = "Araba resimleri listelendi";
        public static string CarImageUpdated = "Resim güncellendi";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola Hatası";
        public static string SuccessfullLogin = "Başarılyla giriş yapıldı";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string UserRegistered = "Kayıt Olundu";
        public static string AccessTokenCreated = "AccessToken oluşturuldu";
        public static string AuthorizationDenied="Yetkiniz yok";
    }
}
