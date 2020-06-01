using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace NetCoreConsole
{
    public class ConsultaSql
    {
        DbContext contexto;
        public string Script {private get; set; }
        public DbDataReader Valores { get; private set; }
        public ConsultaSql( DbContext contexto)
        {
            this.contexto = contexto;
        }

        public void Ejecutar()
        {
            using (var comando = contexto.Database.GetDbConnection().CreateCommand())
            {
                comando.CommandText = Script;
                contexto.Database.CloseConnection();
                contexto.Database.OpenConnection();
                Valores=comando.ExecuteReader();
            }
        }
        public bool Recorre()
        {
           return Valores.Read();
        }

    }
}


