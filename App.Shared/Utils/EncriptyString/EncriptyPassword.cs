namespace App.Shared.Utils.EncriptyString
{
    public static class EncriptPassword
    {
        public static string EncriptPasswordMd5(string pass)
        {
            if (!string.IsNullOrEmpty(pass))
            {
                var password = string.Empty;
                password = pass + "|1234566-asdfasdf-qweqer-tyeryrey";
                System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
                byte[] data = md5.ComputeHash(System.Text.Encoding.Default.GetBytes(password));
                System.Text.StringBuilder sbString = new System.Text.StringBuilder();
                for(int i = 0; i < data.Length; i++)
                    sbString.Append(data[i].ToString("x2"));

                return sbString.ToString();
            }
            return "";
        }
    }
}