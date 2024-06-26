﻿using System.Security.Cryptography;
using System.Text;

namespace Sevriukoff.Gwalt.Application.Helpers;

public class PasswordHasher
{
    public string GenerateSalt(int length = 32)
    {
        var salt = new byte[length / 2];

        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        return BitConverter.ToString(salt).Replace("-", "");
    }
    
    public string HashPassword(string password, string salt)
    {
        using (var sha256 = SHA256.Create())
        {
            var combinedBytes = Encoding.UTF8.GetBytes(password + "." + salt);
            
            var hashedBytes = sha256.ComputeHash(combinedBytes);

            var builder = new StringBuilder(128);

            foreach (var b in hashedBytes)
            {
                builder.Append(b.ToString("X2"));
            }

            return builder.ToString().ToLower();
        }
    }
    
    public bool VerifyPassword(string password, string salt, string hashedPassword)
    {
        return HashPassword(password, salt) == hashedPassword;
    }
}