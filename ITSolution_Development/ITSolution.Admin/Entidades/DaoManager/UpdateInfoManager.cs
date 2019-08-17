using ITSolution.Admin.Entidades.EntidadesBd;
using ITSolution.Admin.Repositorio;
using ITSolution.Framework.Entities;
using ITSolution.Framework.Mensagem;
using System;
using System.Linq;

namespace ITSolution.Admin.Entidades.DaoManager
{
    public class UpdateInfoManager
    {

        public bool AddInformationUpdate(Package pacote, UpdateInfo updateInfo, AppConfigIts app)
        {
            try
            {
                using (var ctx = new AdminContext(app.ConnectionString))
                {
                    try
                    {
                        //busca o pacote 
                        var current = ctx.UpdateInfoDao.Where(u => u.NumeroPacote == pacote.NumeroPacote
                                                                   && u.Status == TypeStatusUpdate.Erro)
                                                                    .First();

                        current.Update(updateInfo);

                        return ctx.UpdateInfoDao.Update(current);
                    }
                    catch (Exception)
                    {
                        return ctx.UpdateInfoDao.Save(updateInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                XMessageIts.ExceptionMessage(ex, "Falha ao inserir log de aplicação de pacote", "Aplicação de Pacote");
                return false;
            }
        }


        public TypeStatusUpdate GetStatusPacote(Package pacote, AppConfigIts app)
        {
            try
            {

                using (var ctx = new AdminContext(app.ConnectionString))
                {
                    try
                    {
                        //busca o pacote no banco
                        var pkgCurrent = ctx.UpdateInfoDao.Where(u => u.NumeroPacote == pacote.NumeroPacote)
                            .First();

                        return pkgCurrent.Status;
                    }
                    catch
                    {
                        //whatever
                        return TypeStatusUpdate.NaoAplicado;
                    }
                }
            }
            catch (Exception)
            {
                //fodase, retorna nao aplicado e tenta de novo
                return TypeStatusUpdate.Erro;
            }
        }


    }
}
