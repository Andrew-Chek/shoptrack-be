using System;
using System.Security.Cryptography;

public static class PasswordHasher
{
    private const int SaltSize = 16; // 16 bytes salt
    private const int HashSize = 20; // 20 bytes hash (for SHA1)

    // Iterations count for PBKDF2
    private const int Iterations = 10000;

    // Function to hash the password
    public static string HashPassword(string password)
    {
        // Generate a random salt
        byte[] salt;
        new RNGCryptoServiceProvider().GetBytes(salt = new byte[SaltSize]);

        // Create the PBKDF2 hash
        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations);
        byte[] hash = pbkdf2.GetBytes(HashSize);

        // Combine the salt and hash
        byte[] hashBytes = new byte[SaltSize + HashSize];
        Array.Copy(salt, 0, hashBytes, 0, SaltSize);
        Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

        // Convert to base64 string
        string hashedPassword = Convert.ToBase64String(hashBytes);

        return hashedPassword;
    }

    // Function to verify if the provided password matches the hashed password
    public static bool VerifyPassword(string password, string hashedPassword)
    {
        // Convert the base64 string back to bytes
        byte[] hashBytes = Convert.FromBase64String(hashedPassword);

        // Extract the salt from the hash
        byte[] salt = new byte[SaltSize];
        Array.Copy(hashBytes, 0, salt, 0, SaltSize);

        // Compute the hash using the provided password and salt
        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations);
        byte[] hash = pbkdf2.GetBytes(HashSize);

        // Compare the computed hash with the hashed password
        for (int i = 0; i < HashSize; i++)
        {
            if (hashBytes[i + SaltSize] != hash[i])
            {
                return false; // Passwords don't match
            }
        }

        return true; // Passwords match
    }
}
