using Newtonsoft.Json.Linq;

namespace EVA2TI_BarPinguino.Services
{
    public class LuyanezApiResponse
    {
        private string? status;
        private string? rut;
        private string? nombre;
        private string? apPat;
        private string? apMat;
        private string? edad;
        private string? estado;
        private string? frase;
        private string? domicilio;
        private string? celular;
        private string? mail;
        private string? nacionalidad;
        private string? totalPension;
        private string? beneficio;
        private string? totalBonos;

        public LuyanezApiResponse(JObject response)
        {
            status = response["status"]?.ToString();
            rut = response["result"]?[0]?["rut"]?.ToString();
            nombre = response["result"]?[0]?["nombre"]?.ToString();
            apPat = response["result"]?[0]?["appat"]?.ToString();
            apMat = response["result"]?[0]?["apmat"]?.ToString();
            edad = response["result"]?[0]?["edad"]?.ToString();
            estado = response["result"]?[0]?["estado"]?.ToString();
            frase = response["result"]?[0]?["frase"]?.ToString();
            domicilio = response["result"]?[0]?["domicilio"]?.ToString();
            celular = response["result"]?[0]?["celular"]?.ToString();
            mail = response["result"]?[0]?["mail"]?.ToString();
            nacionalidad = response["result"]?[0]?["nacionalidad"]?.ToString();
            totalPension = response["result"]?[0]?["total_pension"]?.ToString();
            beneficio = response["result"]?[0]?["beneficio"]?.ToString();
            totalBonos = response["result"]?[0]?["total_bonos"]?.ToString();
        }

        public bool EsValidoSegunListaNegra()
        {
            if (estado!.Equals("ListaNegra")) return false;
            return true;
        }

        public string? GetStatus() => status;
        public void SetStatus(string? value) => status = value;

        public string? GetRut() => rut;
        public void SetRut(string? value) => rut = value;

        public string? GetNombre() => nombre;
        public void SetNombre(string? value) => nombre = value;

        public string? GetApPat() => apPat;
        public void SetApPat(string? value) => apPat = value;

        public string? GetApMat() => apMat;
        public void SetApMat(string? value) => apMat = value;

        public string? GetEdad() => edad;
        public void SetEdad(string? value) => edad = value;

        public string? GetEstado() => estado;
        public void SetEstado(string? value) => estado = value;

        public string? GetFrase() => frase;
        public void SetFrase(string? value) => frase = value;

        public string? GetDomicilio() => domicilio;
        public void SetDomicilio(string? value) => domicilio = value;

        public string? GetCelular() => celular;
        public void SetCelular(string? value) => celular = value;

        public string? GetMail() => mail;
        public void SetMail(string? value) => mail = value;

        public string? GetNacionalidad() => nacionalidad;
        public void SetNacionalidad(string? value) => nacionalidad = value;

        public string? GetTotalPension() => totalPension;
        public void SetTotalPension(string? value) => totalPension = value;

        public string? GetBeneficio() => beneficio;
        public void SetBeneficio(string? value) => beneficio = value;

        public string? GetTotalBonos() => totalBonos;
        public void SetTotalBonos(string? value) => totalBonos = value;
    }
}

