using EVA2TI_BarPinguino.Data;
using EVA2TI_BarPinguino.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using Newtonsoft.Json.Linq;

namespace EVA2TI_BarPinguino.Services
{
    public class AuthService
    {
        private readonly AppDataContext _context;
        private readonly HasherService _passwordHasher;

        public AuthService(AppDataContext context)
        {
            _context = context;
            _passwordHasher = new HasherService();
        }

        public async Task<bool> RegisterUser(Usuarios usuario)
        {
            if (usuario == null) return false;
            var hashResult = _passwordHasher.HashPassword(usuario.Clave);
            var newUser = new Usuarios
            {
                Clave = hashResult.Hash,
                PasswordSalt = hashResult.Salt,
                Nombre = usuario.Nombre,
                TipoUsuario = usuario.TipoUsuario,
                Correo = usuario.Correo
            };

            _context.Usuarios.Add(newUser);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool ValidateLogin(string credential, string password)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.CredencialVendedor == int.Parse(credential));

            if (usuario == null)
                return false;

            return _passwordHasher.VerifyPassword(
                password,
                usuario.Clave,
                usuario.PasswordSalt
            );
        }

        public async Task<bool> ValidateRutByApi(string rut)
        {
            string apiURL = $"https://api.luyanez.cl/?rut={rut}";

            using HttpClient client = new HttpClient();
            JObject res = JObject.Parse(await client.GetStringAsync(apiURL));

            if (res["status"]?.ToString() != "200") return false;

            LuyanezApiResponse response = new LuyanezApiResponse(res);

            if (!response.EsValidoSegunListaNegra()) return false;

            return true;
        }
    }
}
