using System.Security.Cryptography;
using System.Text;

namespace api.Util
{
    public class MD5Generator
    {
        public static string CreateHash(string sValue)
        {
            byte[] arrBytesValue;
            byte[] arrBytesValueEncript;
            StringBuilder strBuilder;
            MD5 md5Hasher = MD5.Create();
        
            // Obtemos os bytes do valor recebido e encriptamos em MD5 Hash
            arrBytesValue = Encoding.Default.GetBytes(sValue);
            arrBytesValueEncript = md5Hasher.ComputeHash(arrBytesValue);
        
            strBuilder = new StringBuilder();
        
            // Passamos por todos bytes convertendo em formato hexadecimal para a string
            for (int i = 0; i < arrBytesValueEncript.Length; i++)
            {
                strBuilder.Append(arrBytesValueEncript[i].ToString("x2"));
            }
        
            return strBuilder.ToString();
        }

    }
}