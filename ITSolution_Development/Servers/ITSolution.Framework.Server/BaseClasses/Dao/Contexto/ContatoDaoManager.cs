using System;
using ITSolution.Framework.Entities;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Util;

namespace ITSolution.Framework.Dao.Contexto
{
    public class ContatoDaoManager
    {
        private bool save(Contato novo, ITSolutionContext ctx)
        {
            //persiste o objeto
            if (ctx.ContatoDao.Save(novo))
            {
                XMessageIts.Mensagem("Contato cadastrado com sucesso!");
                return true;
            }
            return false;
        }

        private bool update(Contato novo, ITSolutionContext ctx)
        {
            //passe o objeto pro contexto
            var current = ctx.ContatoDao.Find(novo.IdContato);

            //atualiza o objeto encontrado com os dados do form
            current.Update(novo);

            if (ctx.ContatoDao.Update(current))
            {
                XMessageIts.Mensagem("Contato atualizado com sucesso.");
                novo = current;
                return true;
            }
            return false;
        }

        public bool SaveUpdate(Contato novo)
        {
            using (var ctx = new ITSolutionContext())
            {

                if (novo.IdContato == 0)
                {
                    //nova tupla
                    return save(novo, ctx);

                }
                else
                {
                    try
                    {
                        //procure o regstro
                        Contato result = ctx.ContatoDao
                            .First(f => f.NomeContato == novo.NomeContato);

                        //se encontrei uma forma de pagamento 
                        //que nao eh a igual a pk do registro selecionado
                        if (result.IdContato != novo.IdContato)
                        {
                            XMessageIts.Advertencia("Contato " + result.NomeContato + " já existe !");
                            return false;

                        }

                        //atualize o registro
                        return update(novo, ctx);
                    }
                    catch (Exception ex)
                    {
                        //nada encontrado pode atualizar
                        LoggerUtilIts.ShowExceptionMessage(ex);

                        //a pk nao eh a mesma a sendo editadava entao atualize
                        return update(novo, ctx);

                    }
                }
            }
        }
    }

}
