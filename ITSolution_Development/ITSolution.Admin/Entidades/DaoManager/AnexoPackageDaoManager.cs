using System.Linq;
using ITSolution.Admin.Repositorio;
using ITSolution.Admin.Entidades.EntidadesBd;

namespace ITSolution.Admin.Entidades.DaoManager
{
    public class AnexoPackageDaoManager
    {
        //Esse eh um relacionamento 1 para N

        public void UpdateAnexos(AdminContext ctx, Package package, Package novo)
        {
            //add novos itens
            foreach (var item in novo.Anexos)
            {
                //atualizando e removendos os arquivos da lista atual
                //verifica se o arquivo atual esta na nova lista
                var currentItem = package.Anexos.ToList().Find(i => i.IdAnexo == item.IdAnexo);
                if (currentItem == null)
                {
                    item.IdPacote = package.IdPacote;
                    //adicione o item na lista
                    ctx.AnexoPackageDao.Save(item);
                }
            }
            updateItens(ctx, package, novo);
        }

        private void updateItens(AdminContext ctx, Package package, Package novo)
        {
            //atualizando os itens atuais
            for (int i = 0; i < package.Anexos.Count; i++)
            {
                var item = package.Anexos.ToList()[i];
                //verifica se o item atual ja esta na nova lista
                var itemAtualizado = novo.Anexos.ToList().Find(x => x.IdAnexo == item.IdAnexo);

                //se ele existe ou vou atualiza-lo
                if (itemAtualizado != null) {
                    var a = ctx.AnexoPackageDao.Find(itemAtualizado.IdAnexo);

                    //atualiza o item
                    item.Update(itemAtualizado);
                    ctx.AnexoPackageDao.Update(a);
                }

                //ele nao existe
                else
                {
                    var a = ctx.AnexoPackageDao.Find(item.IdAnexo);
                    // então ele nao faz parte da lista de arquivos
                    //marque o item para ser removido
                    ctx.AnexoPackageDao.Delete(a);
                }
            }
        }
    }
}
