using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula09.Infra.Interfaces
{
    public  interface IPersistencia
    {
        Task Salvar(object objeto);
        void Excluir(object objeto);
        void Alterar(string Id, object objeto);
        List<Object> Todos();
        List<Object> BuscaPorId(string Id);

        string GetLocalGravacao();
    }
}
