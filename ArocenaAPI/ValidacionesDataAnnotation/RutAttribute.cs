using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ArocenaAPI.ValidacionesDataAnnotation
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class RutAttribute : ValidationAttribute
    {
  
            public override bool IsValid(object value)
            {
                if (value == null)
                {
                    return true; // Permite valores nulos
                }

                string rut = value as string;

                if (rut == null)
                {
                    return false;
                }
            rut = rut.Trim();
            if (rut.Length == 12) { 
            var rutPrimeros11Dig = rut.Substring(0, 11);
            var rutDigVerificador= rut.Substring(11, 1);
            var rutPrimerosDosDigitos = rut.Substring(0, 2);
            var posicion3eraA8va= rut.Substring(2, 6);
            var posicion9naY10ma = rut.Substring(8, 2);

            var rutPrimerosDosDigitosOk = int.Parse(rutPrimerosDosDigitos) > 0 && int.Parse(rutPrimerosDosDigitos) <= 21;
            var posicion3eraA8vaOk = posicion3eraA8va != "000000";
            var posicion9naY10maOk = posicion9naY10ma == "00";

            int suma = 0;
            int multiplicador = 4;

            for (int i = 0; i < rutPrimeros11Dig.Length ; i++)
            {
          
                int digito = int.Parse(rutPrimeros11Dig[i].ToString());
                suma += digito * multiplicador;
                if (i == 2 ) multiplicador = 10;
                multiplicador --;
            }

            int resto = suma % 11;
            int PosibledigitoEsperado  = 11 - resto;

            if (PosibledigitoEsperado == 10) return false;

            return rutPrimerosDosDigitosOk && posicion3eraA8vaOk && posicion9naY10maOk && (PosibledigitoEsperado < 10 || PosibledigitoEsperado == 11);
            }else
            {
                return false;
            }
        }
    }
}
