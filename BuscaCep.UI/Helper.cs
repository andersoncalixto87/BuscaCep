using System.Text.RegularExpressions;

namespace BuscaCep.UI
{
    public class Helper
    {
       
        public static bool validaCEP(ref string cep)
        {

            if (cep.Length == 8)
            {
                cep = cep.Substring(0, 5) + "-" + cep.Substring(5, 3);
                //txt.Text = cep;
            }
            if (cep == "00000-000")
                return false;

            return Regex.IsMatch(cep, ("[0-9]{5}-[0-9]{3}"));
        }
    }
}
