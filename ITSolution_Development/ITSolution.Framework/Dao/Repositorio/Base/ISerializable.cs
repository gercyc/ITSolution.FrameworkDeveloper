namespace ITSolution.Framework.Dao.Repositorio.Base
{
    /// <summary>
    /// Marcacao para o Dao
    /// Obriga todas entidade que usarem o Dao implementarem o metodo
    /// </summary>
    /// <typeparam name="PK"></typeparam>Tipo da chave Primaria
    public interface ISerializable<PK> {
    
         PK GetId ();
 
    }
}
