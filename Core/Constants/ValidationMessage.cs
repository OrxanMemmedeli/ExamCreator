﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Constants
{
    public static class ValidationMessage
    {
        public static string NotEmptyAndNotNull { get; private set; } = "{0} sahəsi boş ola bilməz";
        public static string MinimumLength { get; private set; } = "{0} sahəsi ən az {1} simvol ola bilər";
        public static string MaximumLength { get; private set; } = "{0} sahəsi ən çox {1} simvol ola bilər";
        public static string EmailAddress { get; private set; } = "Email düzgün yazılmamışdır";
        public static string CapitalLetter { get; private set; } = "Şifrədə ən azı 1 BÖYÜK simvol olmalıdır (nümunə Aa123!!)";
        public static string LowercaseLetter { get; private set; } = "Şifrədə ən azı 1 KİÇİK simvol olmalıdır (nümunə Aa123!!)";
        public static string Number { get; private set; } = "Şifrədə ən azı 1 RƏQƏM olmalıdır (nümunə Aa123!!)";
        public static string SpecialCharacter { get; private set; } = "Şifrədə xüsusi simvollar olmalıdır (nümunə Aa123!!)";
        public static string EqualPassword { get; private set; } = "Şifrə ilə təkrarı arasında uyğunsuzluq var";
        public static string NotEqual { get; private set; } = "{0} sahələri eyni ola bilməz";
        public static string LessThanOrEqualTo { get; private set; } = "{0} tarixin ən kiçik qiyməti {1} ola bilər";
        public static string InclusiveBetween { get; private set; } = "qiymət aralığı {0} - {1} kimi olmalıdır";
        public static string WrongGuidFormat { get; private set; } = "xətalı Guid formatı";
        public static string DateTimeMinValue { get; private set; } = "Daxil edilmiş tarix cari tarixdən kiçik ola bilməz";
        public static string GreaterThanOrEqualTo { get; private set; } = "{0} sahəsi {1} və ya daha böyük dəyər olmalıdır";
        public static string ContainsTextForTextTitle { get; private set; } = "Mətn Başlığında mütləq formada \"{0} – {1}\" ifadəsi yer almalıdır. (Sual nömrələrini avtomatik vermək üçün)";

        public static string PaymentGreaterFromDebt { get; private set; } = "Ödəniş məbləği borcdan az ola bilməz. {0} tarixi üçün minimal ödəniş məbləği {1} olmalıdır.";

    }
}
