﻿using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace TechStoreWebApp
{
  public static class Pbkdf2Hasher
  {
    public static string ComputeHash(string password, byte[] salt)
    {
      return Convert.ToBase64String(
        KeyDerivation.Pbkdf2(
          password: password,
          salt: salt,
          prf: KeyDerivationPrf.HMACSHA1,
          iterationCount: 10000,
          numBytesRequested: 256 / 8
        )
      );
    }

    public static byte[] GenerateRandomSalt()
    {
      var salt = new byte[128 / 8];

      using var rng = RandomNumberGenerator.Create();
      rng.GetBytes(salt);

      return salt;
    }
  }
}