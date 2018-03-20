using ProjetoDev.Core;
using ProjetoDev.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDev.Infrastructure.Repository
{
    public class EmpresaRepository : BaseRepository<Empresa, Testeideianoardev99>
    {
        public Empresa BuscarEmpresa(int empresaId)
        {
            return base.GetById(x => x.EmpresaId == empresaId);
        }

        public int SalvarEmpresa(Empresa empresa)
        {
            int retorno = 0;
            if (empresa.EmpresaId > 0)
                retorno = base.Update(empresa);
            else
                retorno = base.Add(empresa).EmpresaId > 0 ? 1 : 0;
            return retorno;
        }

        public List<Empresa> ListarEmpresas()
        {
            return base.List();
        }

        public int ExcluirEmpresa(Empresa empresa)
        {
            return base.Delete(empresa);
        }
    }
}
