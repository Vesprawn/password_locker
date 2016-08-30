using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PasswordLocker {
    class StringCipher {
        // Determines encryption keysize algorithim in bits.
        // Divided by 8 gets equivalent bytes.
        private const int KEYSIZE = 256;

        // Determines iterations of password bytes generation function.
        private const int DERIVATION_ITERATIONS = 1000;

        public static string Encrypt(string text, string pass_phrase) { 
            // Randomly generates Salt and IV everytime, but is prepended to cipher text
            // to allow decryption with same Salt and IV.

            var salt_string_bytes = generate256BitsOfRandomEntropy();
            var iv_string_bytes = generate256BitsOfRandomEntropy();
            var plain_text_bytes = Encoding.UTF8.GetBytes(text);

            using (var password = new Rfc2898DeriveBytes(pass_phrase, salt_string_bytes, DERIVATION_ITERATIONS)) { 
                var key_bytes = password.GetBytes(KEYSIZE / 8);

                using (var symmetric_key = new RijndaelManaged()) { 
                    symmetric_key.BlockSize = 256;
                    symmetric_key.Mode = CipherMode.CBC;
                    symmetric_key.Padding = PaddingMode.PKCS7;

                    using (var encryptor = symmetric_key.CreateEncryptor(key_bytes, iv_string_bytes)) {
                        using (var memory_stream = new MemoryStream()) {
                            using (var crypto_stream = new CryptoStream(memory_stream, encryptor, CryptoStreamMode.Write)) { 
                                crypto_stream.Write(plain_text_bytes, 0, plain_text_bytes.Length);
                                crypto_stream.FlushFinalBlock();

                                // Create the final bytes as a concatenation of random salt, iv and cipher bytes.
                                var cipher_text_bytes = salt_string_bytes;
                                cipher_text_bytes = cipher_text_bytes.Concat(iv_string_bytes).ToArray();
                                cipher_text_bytes = cipher_text_bytes.Concat(memory_stream.ToArray()).ToArray();
                                memory_stream.Close();
                                crypto_stream.Close();

                                return Convert.ToBase64String(cipher_text_bytes);
                            }
                        }
                    }
                }
            }
        }

        public static string Decrypt(string cipher_text, string pass_phrase) { 
            // Get complete byte stream representing:
            // [32 bytes Salt] + [32 bytes IV] + [n bytes Cipher Text].
            var complete_cipher_stream = Convert.FromBase64String(cipher_text);
            
            // Get salt bytes extracted first 32 bytes from cipher text bytes.
            var salt_string_bytes = complete_cipher_stream.Take(KEYSIZE / 8).ToArray();

            // Get IV bytes extracted next 32 bytes from cipher text bytes.
            var iv_string_bytes = complete_cipher_stream.Skip(KEYSIZE / 8).Take(KEYSIZE / 8).ToArray();

            // Removes first 64 bytes to get actual cipher text.
            var cipher_text_bytes = complete_cipher_stream.Skip((KEYSIZE / 8) * 2).Take(complete_cipher_stream.Length - ((KEYSIZE / 8) * 2)).ToArray();

            using (var password = new Rfc2898DeriveBytes(pass_phrase, salt_string_bytes, DERIVATION_ITERATIONS)) { 
                var key_bytes = password.GetBytes(KEYSIZE / 8);

                using (var symmetric_key = new RijndaelManaged()) {
                    symmetric_key.BlockSize = 256;
                    symmetric_key.Mode = CipherMode.CBC;
                    symmetric_key.Padding = PaddingMode.PKCS7;

                    using (var decryptor = symmetric_key.CreateDecryptor(key_bytes, iv_string_bytes)) {
                        using (var memory_stream = new MemoryStream(cipher_text_bytes)) {
                            using (var crypto_stream = new CryptoStream(memory_stream, decryptor, CryptoStreamMode.Read)) { 
                                var plain_text_bytes = new byte[cipher_text_bytes.Length];
                                var decrypted_byte_count = crypto_stream.Read(plain_text_bytes, 0, plain_text_bytes.Length);
                                memory_stream.Close();
                                crypto_stream.Close();

                                return Encoding.UTF8.GetString(plain_text_bytes, 0, decrypted_byte_count);
                            }
                        }
                    }
                }
            }
        }

        private static byte[] generate256BitsOfRandomEntropy() {
            // 32 Bytes provides 256 bits.
            var random_bytes = new byte[32];

            using (var rng_csp = new RNGCryptoServiceProvider()) {
                // Fill array with random cryptographically secure bytes.
                rng_csp.GetBytes(random_bytes);
            }

            return random_bytes;
        }
    }
}
