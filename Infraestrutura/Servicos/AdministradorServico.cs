using minimal_api.Dominio.Interfaces;
using minimal_api.Dominio.Entidades;
namespace minimal_api.Infraestrutura.Servicos
{
    public class AdministradorServico : IAdministradorServico
    {
        private readonly DbContexto? _dbContexto;

        public AdministradorServico(DbContexto? dbContexto)
        {
            _dbContexto = dbContexto ?? throw new NullReferenceException(nameof(dbContexto));
        }

        public Administrador? Login(LoginDTO loginDTO)
        {
            var adm = _dbContexto.Administradores.Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha).FirstOrDefault();
            return adm;
        }
    }
}