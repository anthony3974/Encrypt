using System;

namespace Encrypt
{
    /// <summary>
    /// Good for high enryption of text
    /// </summary>
    public class HighEncrypt
    {
        #region class info
        /// <summary>
        /// Gets version of the class
        /// </summary>
        /// <returns>Version</returns>
        public string getVersion() { return "1"; }
        #endregion
        #region constructors
        /// <summary>
        /// Makes a HighEncrypt class
        /// Must make a instance but use static methods
        /// </summary>
        public HighEncrypt()
        {
            outAlpha = new string[inAlpha.Length];
            for (int i = 0; i < inAlpha.Length; i++) outAlpha[i] = (i + 10).ToString();
        }
        #endregion
        #region vars
        static private readonly char[] inAlpha = new char[] { '\r', '\n', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', ' ', '.', ',', '\'', '\"', '!', '@', '#', '$', '%', '^', '&', '<', '>', '?', '/', '*', '-', '+', '=', '_', '(', ')', ';', ':' };
        static string[] outAlpha;
        #endregion
        #region methods
        /// <summary>
        /// Estamated double lenght
        /// Turns alpha to numbers
        /// </summary>
        /// <param name="text">Sets the text to encrypt</param>
        /// <returns>Encrypted text</returns>
        static public string Encrypt(string text)
        {
            string R = "";
            for (int i = 0; i < text.Length; i++)
            {
                try { R += outAlpha[Array.IndexOf(inAlpha, text[i])]; }
                catch (IndexOutOfRangeException) { }
            }
            return R;
        }
        /// <summary>
        /// Estamated 4x lenght
        /// Turns alpha to numbers then does number encyption
        /// </summary>
        /// <param name="text">Sets the text to encrypt</param>
        /// <returns>Encrypted text</returns>
        static public string EncryptLevel2(string text)
        {
            string R = "";
            string S = Encrypt(text);
            for (int i = 0; i < S.Length; i++) R += (int.Parse(S[i].ToString()) / 2).ToString() + (int.Parse(S[i].ToString()) % 2);
            return R;
        }
        /// <summary>
        /// Turns numbers to alpha
        /// </summary>
        /// <param name="text">Sets the text to decrypt</param>
        /// <returns>Decrypted text</returns>
        static public string Decrypt(string text)
        {
            string R = "";
            for (int i = 0; i < text.Length; i += 2)
            {
                string txt = text[i].ToString() + text[i + 1].ToString();
                int num = Array.IndexOf(outAlpha, txt);
                R += inAlpha[num];
            }
            return R;
        }
        /// <summary>
        /// Does number decyption then turns numbers to alpha 
        /// </summary>
        /// <param name="text">Sets the text to decrypt</param>
        /// <returns>Decrypted text</returns>
        static public string DecryptLevel2(string text)
        {
            string R = "";
            string S = text;
            for (int i = 0; i < S.Length; i += 2) R += (int.Parse(S[i].ToString()) * 2) + int.Parse(S[i + 1].ToString());
            return Decrypt(R);
        }
        #endregion
    }
}
/// <summary>
/// Just for Encrypting numbers
/// </summary>
public class NumEncrypt
{
    #region class info
    /// <summary>
    /// Gets version of the class
    /// </summary>
    /// <returns>Version</returns>
    public string getVersion() { return "1"; }
    #endregion
    #region methods
    /// <summary>
    /// Encrypt a number
    /// </summary>
    /// <param name="pin">Sets the number to encrypt</param>
    /// <returns>The encrypted number</returns>
    static public int Encrypt(int pin)
    {
        string R = "";
        string S = pin.ToString();
        for (int i = 0; i < S.Length; i++) R += (int.Parse(S[i].ToString()) / 2).ToString() + (int.Parse(S[i].ToString()) % 2).ToString();
        return int.Parse(R);
    }
    /// <summary>
    /// Decrypt a number
    /// </summary>
    /// <param name="pin">Number to decrypt</param>
    /// <returns>The number to decrypt</returns>
    static public int Decrypt(int pin)
    {
        string R = "";
        string S = pin.ToString();
        for (int i = 0; i < S.Length; i += 2) R += (int.Parse(S[i].ToString()) * 2) + int.Parse(S[i + 1].ToString());
        return int.Parse(R);
    }
    #endregion
}