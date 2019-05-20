using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucilvio.Ticket.Infra.BuscasComDapper
{
    public class Contexto
    {
        private readonly string _stringDeConexao;

        public Contexto(string stringDeConexao)
        {
            this._stringDeConexao = stringDeConexao;
        }

        public SqlConnection Conexao => new SqlConnection(this._stringDeConexao);
    }
}
