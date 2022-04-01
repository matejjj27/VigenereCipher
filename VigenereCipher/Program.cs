using System;

namespace VigenereCipher
{
    class Program
    {
        private static String CreateKey(String str, String key)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (key.Length == str.Length)
                    break;
                key += (key[i]);
            }
            key = key.ToUpper();
            return key;
        }

        private static String Encrypt(String str, String key)
        {
            String encrypted_text = "";
            str = str.ToUpper();

            for (int i = 0; i < str.Length; i++)
            {
                // converting in range 0-25
                int x = (str[i] + key[i]) % 26;

                // convert into alphabets(ASCII)
                x += 'A';

                encrypted_text += (char)(x);
            }
            return encrypted_text;
        }

        private static String Decrypt(String encrypted_text, String key)
        {
            String decrypted_text = "";
            encrypted_text.ToUpper();

            for (int i = 0; i < encrypted_text.Length && i < key.Length; i++)
            {
                // converting in range 0-25
                int x = (encrypted_text[i] -
                            key[i] + 26) % 26;
                
                // convert into alphabets(ASCII)
                x += 'A';
                decrypted_text += (char)(x);
            }
            return decrypted_text;
        }

        static void Main(string[] args)
        {
            Console.Write("Enter text you want to encrypt: ");
            String str = Console.ReadLine();
            Console.Write("Enter key: ");
            String keyword = Console.ReadLine();
            Console.WriteLine();

            String key = CreateKey(str, keyword);
            String encrypted_text = Encrypt(str, key);

            Console.WriteLine("Encrypted Text: " + encrypted_text + "\n");

            Console.WriteLine("Original/Decrypted Text: " + Decrypt(encrypted_text, key));
        }
    }
}

