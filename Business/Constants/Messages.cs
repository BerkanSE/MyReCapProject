using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araç eklendi";
        public static string CarNameInvalid = "Araç ismi geçersiz";
        public static string CarsListed = "Araçlar listelendi";
        public static string CarDeleted = "Araç silindi";
        public static string CarsListedByBrand = "Araçlar markaya göre listelendi";
        public static string CarsListedByColor = "Araçlar renge gore listelendi";
        public static string CarUpdated = "Araç güncellendi";

        public static string CustomerAdded = "Müşteri Eklendi";
        public static string CustomerNotAdded = "HATA. Müşteri Eklenemedi";
        public static string CustomerDeleted = "Müşteri Silindi";
        public static string CustomerNotDeleted = "HATA. Müşteri Silinemedi";
        public static string CustomerUpdated = "Müşteri Güncellendi";
        public static string CustomersListed = "Müşteriler Listeleniyor...";

        public static string UserAdded = "Kullanıcı Eklendi";
        public static string FirstNameLastNameInvalid = "İsim veya Soyisim Girilmemiş";
        public static string UserDeleted = "Kullanıcı Silindi";
        public static string UserNotDeleted = "HATA. Kullanıcı Silinemedi";
        public static string UserUpdated = "Kullanıcı Güncellendi";
        public static string UsersListed = "Kullanıcılar Listeleniyor...";

        public static string RentalAdded = "Kiralama Bilgisi Eklendi";
        public static string RentalAddedError = "Araç teslim edilmediği için tekrar kiraya verilemez";
        public static string RentalUpdateReturnDate = "Araç Teslim Alındı";
        public static string RentalUpdateReturnDateError = "Araç Teslim Alınmış";
        public static string RentalUpdated = "Kiralama Bilgisi Güncellendi";
        public static string RentalListed = "Kiralama Bilgileri Listeleniyor...";
        public static string RentalDeleted = "Kiralama Bilgisi Silindi";

        public static string MaintenanceTime = "Sistem bakımda";
       
        public static string ColorListed = "Renkler listelendi";
        public static string ColorAdded = "Renk eklendi";
        public static string ColorNameInvalid = "Renk ismi geçersiz";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorUpdated = "Renk güncellendi";

        public static string BrandAdded = "Marka eklendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string BrandNameInvalid = "Marka ismi geçersiz";
        public static string BrandsListed = "Markalar listelendi";
        
        public static string CarCountOfBrandError = "Bir kategoride en fazla 10 araç olabilir";
        public static string CarNameAlreadyExists = "Aynı isimde araç eklenemez";
        public static string CarImageLimited = "Araç resmi sınırlı";
        public static string CarImageAdded = "Araç resmi eklendi";
        
        public static string AuthorizationDenied = "Yetkiniz yok";

        public static string UserRegistered = "Kullanıcı kayıtlıdır";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatalı";
        public static string UserAlreadyExists = "Kullanıcı zaten ekli";
        public static string AccessTokenCreated =  "Access token oluşturuldu";
        public static string SuccessfulLogin = "Başarılı giriş";
    }
}
