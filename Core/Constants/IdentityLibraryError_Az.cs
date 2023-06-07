using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Constants
{
    public class IdentityLibraryError_Az : IdentityErrorDescriber
    {
        public override IdentityError DefaultError() => new IdentityError { Code = nameof(DefaultError), Description = $"An unknown failure has occurred. (Naməlum nasazlıq baş verdi.)" }; 
        public override IdentityError ConcurrencyFailure() => new IdentityError { Code = nameof(ConcurrencyFailure), Description = "Optimistic concurrency failure, object has been modified. (Optimist paralellik xətası, obyekt dəyişdirildi.)" }; 
        public override IdentityError PasswordMismatch() => new IdentityError { Code = nameof(PasswordMismatch), Description = "Incorrect password. (Yanlış şifrə.)" };
        public override IdentityError InvalidToken() => new IdentityError { Code = nameof(InvalidToken), Description = "Invalid token. (Yanlış token.)" };
        public override IdentityError LoginAlreadyAssociated() => new IdentityError { Code = nameof(LoginAlreadyAssociated), Description = "A user with this login already exists. (Bu məlumatlara uyğun istifadəçi artıq mövcuddur.)" };
        public override IdentityError InvalidUserName(string userName) => new IdentityError { Code = nameof(InvalidUserName), Description = $"User name '{userName}' is invalid, can only contain letters or digits. ('{userName}' istifadəçi adı doğru deyil. Yalnız hərf və rəqəmlərdən istifadə edilməlidir.) " };
        public override IdentityError InvalidEmail(string email) => new IdentityError { Code = nameof(InvalidEmail), Description = $"Email '{email}' is invalid. ('{email}' doğru deyil.) " };
        public override IdentityError DuplicateUserName(string userName) => new IdentityError { Code = nameof(DuplicateUserName), Description = $"User Name '{userName}' is already taken. ('{userName}' İstifadəçi adı artıq mövcuddur.)" };
        public override IdentityError DuplicateEmail(string email) => new IdentityError { Code = nameof(DuplicateEmail), Description = $"Email '{email}' is already taken. ('{email}' Email artıq mövcuddur.)" };
        public override IdentityError InvalidRoleName(string role) => new IdentityError { Code = nameof(InvalidRoleName), Description = $"Role name '{role}' is invalid. (Xətalı Rol adı)" };
        public override IdentityError DuplicateRoleName(string role) => new IdentityError { Code = nameof(DuplicateRoleName), Description = $"Role name '{role}' is already taken. ('{role}' Role adı artıq mövcuddur.) " };
        public override IdentityError UserAlreadyHasPassword() => new IdentityError { Code = nameof(UserAlreadyHasPassword), Description = "User already has a password set. (İstifadəçi artıq şifrə təyin edib.)" };
        public override IdentityError UserLockoutNotEnabled() => new IdentityError { Code = nameof(UserLockoutNotEnabled), Description = "Lockout is not enabled for this user. (Lokaut bu istifadəçi üçün aktiv deyil.)" };
        public override IdentityError UserAlreadyInRole(string role) => new IdentityError { Code = nameof(UserAlreadyInRole), Description = $"User already in role '{role}'. (İstifadəçi artıq '{role}' rolundadır." };
        public override IdentityError UserNotInRole(string role) => new IdentityError { Code = nameof(UserNotInRole), Description = $"User is not in role '{role}'. (İstifadəçi '{role}' rolunda deyil.)" };
        public override IdentityError PasswordTooShort(int length) => new IdentityError { Code = nameof(PasswordTooShort), Description = $"Passwords must be at least {length} characters. (Şifrələr ən azı {length} simvoldan ibarət olmalıdır.)" };
        public override IdentityError PasswordRequiresNonAlphanumeric() => new IdentityError { Code = nameof(PasswordRequiresNonAlphanumeric), Description = "Passwords must have at least one non alphanumeric character. (Şifrələrdə ən azı bir hərf-rəqəmsiz simvol olmalıdır.)" };
        public override IdentityError PasswordRequiresDigit() => new IdentityError { Code = nameof(PasswordRequiresDigit), Description = "Passwords must have at least one digit ('0'-'9'). (Şifrələrdə ən azı bir rəqəm olmalıdır ('0'-'9').)" };
        public override IdentityError PasswordRequiresLower() => new IdentityError { Code = nameof(PasswordRequiresLower), Description = "Passwords must have at least one lowercase ('a'-'z'). Şifrələrdə ən azı bir kiçik hərf ('a'-'z') olmalıdır." };
        public override IdentityError PasswordRequiresUpper() => new IdentityError { Code = nameof(PasswordRequiresUpper), Description = "Passwords must have at least one uppercase ('A'-'Z'). (Şifrələrdə ən azı bir böyük hərf olmalıdır ('A'-'Z').)" };
        public override IdentityError PasswordRequiresUniqueChars(int uniqueChars) => new IdentityError { Code = nameof(PasswordRequiresUniqueChars), Description = $"Password requires at least {uniqueChars} unique characters. (Şifrə, ən az {uniqueChars} fərqli simvoldan ibarət olmalıdır.)" };
        public override IdentityError RecoveryCodeRedemptionFailed() => new IdentityError { Code = nameof(RecoveryCodeRedemptionFailed), Description = "Recovery code redemption failed. (Bərpa kodunun istifadəsi uğursuz oldu.)" };
    }
}
