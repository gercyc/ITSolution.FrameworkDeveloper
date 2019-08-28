using System;
using ITSolution.Framework.Entities;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Util;

namespace ITSolution.Framework.Dao.Contexto
{
    public class LembreteDaoManager
    {
        private bool save(Lembrete novo, ITSolutionContext ctx)
        {
            //persiste o objeto
            if (ctx.LembreteDao.Save(novo))
            {
                XMessageIts.Mensagem("Lembrete salvo com sucesso!");
                return true;
            }
            return false;
        }

        private bool update(Lembrete novo, ITSolutionContext ctx)
        {
            //passe o objeto pro contexto
            var current = ctx.LembreteDao.Find(novo.IdLembrete);

            //atualiza o objeto encontrado com os dados do form
            current.Update(novo);

            if (ctx.LembreteDao.Update(current))
            {
                XMessageIts.Mensagem("Lembrete atualizado com sucesso.");
                novo = current;
                return true;
            }
            return false;
        }

        public bool SaveUpdate(Lembrete novo)
        {
            using (var ctx = new ITSolutionContext())
            {

                if (novo.IdLembrete == 0)
                {
                    //nova tupla
                    return save(novo, ctx);

                }
                else
                {
                    try
                    {
                        //procure o regstro
                        Lembrete result = ctx.LembreteDao
                            .First(f => f.NomeLembrete == novo.NomeLembrete);

                        //se encontrei uma forma de pagamento 
                        //que nao eh a igual a pk do registro selecionado
                        if (result.IdLembrete != novo.IdLembrete)
                        {
                            XMessageIts.Advertencia("Já existe um lembrete \"" + result.NomeLembrete + "\"");
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

        public bool Delete(Lembrete lembrete)
        {
            using (var ctx = new ITSolutionContext())
            {
                var l = ctx.LembreteDao.Find(lembrete.IdLembrete);
                return ctx.LembreteDao.Delete(l);
            }
        }
    }
}
