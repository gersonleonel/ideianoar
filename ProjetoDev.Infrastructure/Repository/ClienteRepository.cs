using ProjetoDev.Core;
using ProjetoDev.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDev.Infrastructure.Repository
{
    public class ClienteRepository : BaseRepository<Cliente, Testeideianoardev99>
    {
        public Cliente BuscarCliente(int clienteId)
        {
            return base.GetById(x => x.ClienteId == clienteId);
        }

        public int SalvarCliente(Cliente cliente)
        {
            int retorno = 0;
            if (cliente.ClienteId > 0)
                retorno = base.Update(cliente);
            else
                retorno = base.Add(cliente).ClienteId > 0 ? 1 : 0;
            return retorno;
        }

        public List<Cliente> ListarClientes()
        {
            return base.List();
        }

        public int ExcluirCliente(int id)
        {
            var cli = BuscarCliente(id);
            return base.Delete(cli);
        }
    }
}
