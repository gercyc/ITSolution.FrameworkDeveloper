using ITSolution.Admin.Entidades.EntidadesBd;
using ITSolution.Admin.Repositorio;
using ITSolution.Framework.Arquivos;
using ITSolution.Framework.Mensagem;
using ITSolution.Framework.Util;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace ITSolution.Admin.Entidades.DaoManager
{
    public class PackageDaoManager
    {
        public PackageDaoManager()
        {

        }

        public bool SavePackage(Package pacote)
        {
            try
            {
                using (var ctx = new AdminContext())
                {
                    return ctx.PackageDao.Save(pacote);
                }
            }
            catch (Exception ex)
            {
                XMessageIts.ExceptionMessage(ex);
                return false;
            }

        }

        public bool UpdatePackage(Package package)
        {
            try
            {
                using (var ctx = new AdminContext())
                {
                    var current = ctx.PackageDao.Find(package.IdPacote);

                    current.Update(package);

                    //ok agora funciona corretamente
                    new AnexoPackageDaoManager().UpdateAnexos(ctx, current, package);

                    var transaction = ctx.PackageDao.Update(current);
                    return transaction;

                }
            }
            catch (Exception ex)
            {
                XMessageIts.ExceptionMessage(ex);
                return false;
            }

        }

        public Task<List<PackageDTO>> FindAllPackagesNoData()
        {
            using (var ctx = new AdminContext())
            {
                ctx.LazyLoading(false);
                //nao vou carregar os dados do pacote
                var lista = (from p in ctx.Packages
                             select new PackageDTO
                             {
                                 IdPacote = p.IdPacote,
                                 NumeroPacote = p.NumeroPacote,
                                 Descricao = p.Descricao,
                                 Sintoma = p.Sintoma,

                                 Tratamento = p.Tratamento,
                                 Status = p.Status,
                                 DataCriacao = p.DataCriacao,
                                 DataPublicacao = p.DataPublicacao
                             }
                ).ToListAsync<PackageDTO>();

                return lista;
            }
        }

        public bool AddInformationUpdate(Package pacote, string log, TypeStatusUpdate status, string connectionString)
        {
            try
            {
                var ctx = new AdminContext();

                if (connectionString != null)
                {
                    ctx.Dispose();
                    ctx = new AdminContext(connectionString);
                }
                using (ctx)
                {
                    var updateInfo = new UpdateInfo(pacote, log, status);

                    try
                    {

                        //busca o pacote com erro
                        var current = ctx.UpdateInfoDao.Where(p => p.NumeroPacote == pacote.NumeroPacote &&
                                                                    p.Status == TypeStatusUpdate.Erro).First();

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
                XMessageIts.ExceptionMessage(ex,"Falha ao inserir log de aplicação de pacote","Aplicação de Pacote");
                return false;
            }
        }

        public bool PublicarPacote(Package pacote)
        {
            try
            {
                using (var ctx = new AdminContext())
                {
                    var pkgCurrent = ctx.PackageDao.Find(pacote.IdPacote);
                    var pkgNew = new Package();

                    //passa tudo do pacote atual pro novo
                    pkgNew.Update(pkgCurrent);

                    //novo status
                    pkgNew.Status = Enumeradores.TypeStatusPackage.Publicado;

                    foreach (var anx in pacote.Anexos)
                    {
                        var anxSalvar = new AnexoPackage(anx.DataFile, anx.FileName, anx.PathFile);
                        pkgNew.Anexos.Add(anxSalvar);
                    }

                    var bytes = SerializeIts.SerializeObject(pkgNew);
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "IT Solution package| *.itspkg";
                    //sfd.FilterIndex = 0;
                    //sfd.DefaultExt = ".itsPkg";
                    sfd.FileName = "ITS_Package_" + pkgNew.NumeroPacote;
                    var op = sfd.ShowDialog();

                    if (op == DialogResult.OK)
                    {
                        if (FileManagerIts.WriteBytesToFile(sfd.FileName, bytes))
                        {
                            //publicar o pacote
                            pkgCurrent.Publish(DateTime.Now, bytes);

                            var transation = ctx.PackageDao.Update(pkgCurrent);
                            if (transation)
                            {
                                XMessageIts.Mensagem("Pacote publicado com sucesso!");

                                pacote.Update(pkgCurrent);
                                return transation;
                            }
                        }
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                XMessageIts.ExceptionMessage(ex, "Falha ao publicar pacote", "Publicação de Pacote");

                return false;
            }
        }

        public TypeStatusUpdate GetStatusPacote(Package pacote, string connectionString = null)
        {
            try
            {
                var ctx = new AdminContext();

                if (connectionString != null)
                {
                    ctx.Dispose();
                    ctx = new AdminContext(connectionString);
                }
                using (ctx)
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
                return TypeStatusUpdate.NaoAplicado;
            }
        }

        public Package FindPackage(int idPacote)
        {
            using (var ctx = new AdminContext())
            {
                try
                {
                    return ctx.PackageDao.Find(idPacote);

                }
                catch (Exception ex)
                {
                    LoggerUtilIts.ShowExceptionMessage(ex);
                    return null;
                }
            }
        }

        public Package SaveFilePacote(Package pacote)
        {
            try
            {
                var pkgSalvar = new Package();

                pkgSalvar.DataCriacao = pacote.DataCriacao;
                pkgSalvar.DataPublicacao = pacote.DataPublicacao;
                pkgSalvar.Descricao = pacote.Descricao;
                pkgSalvar.NumeroPacote = pacote.NumeroPacote;
                pkgSalvar.Sintoma = pacote.Sintoma;
                pkgSalvar.Status = pacote.Status;
                pkgSalvar.Tratamento = pacote.Tratamento;

                foreach (var anx in pacote.Anexos)
                {
                    var anxSalvar = new AnexoPackage();
                    anxSalvar.DataFile = anx.DataFile;
                    anxSalvar.FileName = anx.FileName;
                    anxSalvar.PathFile = anx.PathFile;
                    pkgSalvar.Anexos.Add(anxSalvar);
                }

                var bytes = SerializeIts.SerializeObject(pkgSalvar);
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "IT Solution package| *.itspkg";
                sfd.FileName = "ITS_Package_" + pkgSalvar.NumeroPacote;

                var op = sfd.ShowDialog();

                if (op == DialogResult.OK)
                {
                    if (FileManagerIts.WriteBytesToFile(sfd.FileName, bytes))
                    {
                        XMessageIts.Mensagem("Pacote salvo com sucesso!");
                    }
                }
                return pkgSalvar;
            }
            catch (Exception ex)
            {
                XMessageIts.ExceptionMessage(ex);
                return null;
            }

        }

        public string GeneratePackageNumber()
        {
            using (var ctx = new AdminContext())
            {
                string numeroPacote = "";
                var pkg = ctx.PackageDao.Last();
                int num = pkg != null
                    ? pkg.IdPacote + 1
                    : 1;

                if (num.ToString().Length == 1)
                    numeroPacote = "000000000" + num;

                else if (num.ToString().Length == 2)
                    numeroPacote = "00000000" + num;

                else if (num.ToString().Length == 3)
                    numeroPacote = "0000000" + num;

                else if (num.ToString().Length == 4)
                    numeroPacote = "000000" + num;

                else if (num.ToString().Length == 5)
                    numeroPacote = "00000" + num;

                else if (num.ToString().Length == 6)
                    numeroPacote = "0000" + num;

                else if (num.ToString().Length == 7)
                    numeroPacote = "000" + num;

                else if (num.ToString().Length == 8)
                    numeroPacote = "00" + num;

                else if (num.ToString().Length == 8)
                    numeroPacote = "0" + num;

                else
                    numeroPacote = "" + num;

                return numeroPacote;
            }
        }
    }
}
