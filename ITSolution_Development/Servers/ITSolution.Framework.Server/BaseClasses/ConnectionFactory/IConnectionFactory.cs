
using System;

namespace ITSolution.Framework.ConnectionFactory
{
    /// <summary>
    /// Metódo para abrir um conexão
    /// </summary>
    public interface IConnectionFactory : IDisposable
    {
        /// <summary>
        /// Abre uma conexão com o banco de dados
        /// </summary>
        bool OpenConnection();


        /// <summary>
        /// Fecha a conexão com o banco de dados
        /// </summary>
        bool CloseConnection();

        /// <summary>
        /// Verifica o status da conexão
        /// </summary>
        bool IsOpen();

    }
}
