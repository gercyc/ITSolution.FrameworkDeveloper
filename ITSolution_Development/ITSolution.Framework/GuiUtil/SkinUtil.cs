using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using ITSolution.Framework.Arquivos;
using ITSolution.Framework.Enumeradores;
using System;
using System.Collections.Generic;

namespace ITSolution.Framework.GuiUtil
{
    public class SkinUtil
    {
        //Skins Padrão
        private static List<string> SKINS_DEFAULT = FileManagerIts.
            GetDataFromBytes(Properties.Resources.skins_default);
        //Skins Extras
        private static List<string> SKINS_BONUS = FileManagerIts.
           GetDataFromBytes(Properties.Resources.skins_bonus);
        //Skins temáticos
        private static List<string> SKINS_THEME = FileManagerIts.
            GetDataFromBytes(Properties.Resources.skins_theme);

        //Skins Personalizadas => nao tem

        /// <summary>
        /// Retorna o tema default caso algo errado => Office 2013 Light Gray
        /// </summary>
        /// <param name="skinRibbonGalleryBarItem1"></param>
        /// <returns></returns>
        public static string GetSelectSkin(SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1)
        {
            int i = 0;
            foreach (GalleryItemGroup group in skinRibbonGalleryBarItem1.Gallery.Groups)
            {
                var galleryItemList = group.GetCheckedItems();
                //Skins Padrão
                //Skins Extras
                //Skins temáticos
                //Skins Personalizadas
                foreach (var item in galleryItemList)
                {
                    Console.WriteLine(item.Caption);
                    if (item.Checked)
                    {
                        TypeSkinTheme indexGroup = (TypeSkinTheme)i;

                        string skin = GetSelectSkinFromGalleryItem(group, item, indexGroup);

                        return skin;
                    }
                }
                i++;
            }
            return "Office 2013 Light Gray";

        }
        /// <summary>
        /// Retorna o tema default caso algo errado => Office 2013 Light Gray
        /// </summary>
        /// <param name="group"></param>Grupo do tema
        /// <param name="indexGroup"></param>
        /// <returns></returns>
        public static string GetSelectSkinFromGalleryItem(GalleryItemGroup group, GalleryItem g, TypeSkinTheme indexGroup)
        {
            string skin = "Office 2013 Light Gray";//tema padrão

            for (var i = 0; i < group.Items.Count; i++)
            {
                var item = group.Items[i];

                if (item != null && item.Caption.Equals(g.Caption))
                {

                    try
                    {
                        //Esse eh o skin que eu preciso salvar
                        //pega o nome original
                        if (indexGroup == TypeSkinTheme.Default)
                            skin = SKINS_DEFAULT[i];

                        else if (indexGroup == TypeSkinTheme.Bonus)
                            skin = SKINS_BONUS[i];
                        else
                            skin = SKINS_THEME[i];

                        //obtem o tema 
                        return skin;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Tema nao encontrado => " + ex.Message);
                        //Nao se importe se realizou ou nao uma acao tao simples
                        //no pior caso deixa o tema q tava 
                    }
                }
            }
            return skin;
        }


        /// <summary>
        /// Retorna o tema default caso algo errado => Office 2013 Light Gray
        /// </summary>
        /// <param name="group"></param>Grupo do tema
        /// <param name="indexGroup"></param>
        /// <returns></returns>
        public static string GetSelectSkin(GalleryItemGroup group, TypeSkinTheme indexGroup)
        {
            string skin = "Office 2013 Light Gray";//tema padrão

            for (var j = 0; j < group.Items.Count; j++)
            {
                var item = group.Items[j];

                if (item != null)
                {
                    if (item.Checked)
                    {
                        //Esse eh o skin que eu preciso salvar
                        skin = item.Caption;

                        try
                        {
                            //pega o nome original
                            if (indexGroup == TypeSkinTheme.Default)
                                skin = SKINS_DEFAULT[j];

                            else if (indexGroup == TypeSkinTheme.Bonus)
                                skin = SKINS_BONUS[j];
                            else
                                skin = SKINS_THEME[j];

                            //obtem o tema 
                            return skin;
                        }
                        catch
                        {
                            //Nao se importe se realizou ou nao uma acao tao simples
                            //no pior caso deixa o tema q tava 
                        }
                    }
                }
            }
            return skin;
        }



        /// <summary>
        /// Retorna o tema default caso algo errado => Office 2013 Light Gray
        /// </summary>
        /// <param name="skinRibbonGalleryBarItem1"></param>
        /// <returns></returns>
        public static void PrintGroupSkins(SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1)
        {
            for (int i = 0; i < skinRibbonGalleryBarItem1.Gallery.Groups.Count; i++)
            {
                var group = skinRibbonGalleryBarItem1.Gallery.Groups[i];
                Console.WriteLine(group.Caption);
                Console.WriteLine("============================================================");
                TypeSkinTheme indexGroup = (TypeSkinTheme)i;
                PrintSkins(group, indexGroup);
                Console.WriteLine("============================================================");
            }
        }

        /// <summary>
        /// Retorna o tema default caso algo errado => Office 2013 Light Gray
        /// </summary>
        /// <param name="group"></param>Grupo do tema
        /// <param name="indexGroup"></param>
        /// <returns></returns>
        private static void PrintSkins(GalleryItemGroup group, TypeSkinTheme indexGroup)
        {

            foreach (GalleryItem item in group.Items)
            {
                //Esse eh o skin que eu preciso salvar
                string skin = item.Caption;
                Console.WriteLine(skin);
            }
            
        }

        private static void generateScriptToSkin()
        {

            //todos os arquivo sem extensao
            var skins = FileManagerIts.ToFiles(@"D:\Program Files\TFS\ITSolution\ITSolution.Framework\Resources", new string[] { "" });
            //lista de temas do dev express
            var lista = new List<string>();
            foreach (var f in skins)
            {
                var skinsData = FileManagerIts.GetDataFile(f);
                Console.WriteLine(f);
                Console.WriteLine("=======================================================================================================");
                foreach (var skin in skinsData)
                {
                    Console.WriteLine("'" + skin + "',");//concatenar usando o excel posteriomente eh mais rapido
                }

            }

        }

        //Teste para ocultar os skin que achar desnecessarios
        // populate with names of unnecessary skins
        //string[] skinsToHide = { "Black", "Blue", "Seven", "Sharp" }; 
        //iMaginary

        /*DevExpress.Skins.SkinManager.EnableMdiFormSkins();
        DevExpress.Skins.SkinManager.EnableFormSkins();
        DevExpress.UserSkins.BonusSkins.Register();
        SkinContainerCollection skins = SkinManager.Default.Skins;
        for (int i = 0; i < skins.Count; i++)
        {
            Console.WriteLine(
                String.Format("{0}{1}", skins[i].SkinName, Environment.NewLine));
        }*/


    }
}
