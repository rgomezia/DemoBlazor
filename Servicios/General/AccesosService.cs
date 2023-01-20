using DemoBlazor.Models.Utils;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System;
using DemoBlazor.Models;
using DemoBlazor.Models.Utils;

namespace DemoBlazor.Services.General
{
    public interface IAccesosService
    {
        Task<IList<OperacionesModulo>> GetOperacionesModulo(string moduloActual);
        Task<SessionUser> GetSessionInfo();
    }

    public class AccesosService : IAccesosService
    {
        private readonly IConfiguration _config;
        private readonly IJSRuntime _JS;
        private readonly IPerfilesService _perfilesService;
        private readonly IUsuariosService _usuariosService;
        private readonly IModulosService _modulosService;

        private SessionUser? Session = null;


        public AccesosService(IConfiguration config, IJSRuntime JS , IPerfilesService perfilesService, IUsuariosService usuariosService, IModulosService modulosService)
        {
            _config = config;
            _JS = JS;
            _perfilesService = perfilesService;
            _usuariosService = usuariosService;
            _modulosService = modulosService;
        }

        public async Task<IList<OperacionesModulo>> GetOperacionesModulo(string moduloActual)
        {
            try
            {
                Session = JsonConvert.DeserializeObject<SessionUser>(await _JS.InvokeAsync<string>("sessionStorage.getItem", "SessionData"));

                var Usuarios = await _usuariosService.GetUsuariosAsync(Session.Token, Session.idEmpresa);
                var UsuarioActual = Usuarios.Where(x => x.nombre == Session.Usuario).FirstOrDefault();

                var Modulos = await _modulosService.GetModulosPerfilAsync(UsuarioActual.idPerfil);
                var Modulo = Modulos.Where(x => x.nombre == moduloActual).FirstOrDefault();

                var lstOperacionesModulo = await _modulosService.GetOperacionesModuloPerfilAsync(Modulo.id_modulo, Modulo.id_perfil);
                return lstOperacionesModulo;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<SessionUser> GetSessionInfo()
        {
            Session = JsonConvert.DeserializeObject<SessionUser>(await _JS.InvokeAsync<string>("sessionStorage.getItem", "SessionData"));
            return Session;
        }
    }
}
