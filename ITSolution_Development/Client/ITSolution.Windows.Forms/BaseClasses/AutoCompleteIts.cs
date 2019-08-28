using DevExpress.XtraEditors;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ITSolution.Framework.GuiUtil
{
    public class AutoCompleteIts
    {
        //base http://www.linhadecodigo.com.br/artigo/1051/usando-o-recurso-quotauto-completequot-no-windows-forms-20.aspx
        /// <summary>
        /// Adiciona uma ação de auto complementar o campo
        /// Crie uma AutoCompleteStringCollection dadosLista = new AutoCompleteStringCollection();
        /// Add os elementos que deseja nela
        /// </summary>
        /// Exemplo
        /// ///private void addAutoComplete()
        ///{
        ///    var lista = new BalcaoContext().Entidade.FindAll();
        ///    AutoCompleteStringCollection autoCompleteList = new AutoCompleteStringCollection();
        ///    foreach (var i in lista)
        ///    {
        ///        autoCompleteList.Add(i.prop);//onde prop a proprieda quando nao informado utiliza o toString()
        ///    }
        ///    AutoCompleteIts.AutoCompleteTextBox(this.XFrmLogin.GetTextNomeUsuario(), autoCompleteList);
        ///}
        /// <param name="textBox"></param>
        /// <param name="dados"></param>
        public static void AutoCompleteTextBox(TextBox textBox, AutoCompleteStringCollection dados)
        {
            textBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox.AutoCompleteCustomSource = dados;
        }


        /// <summary>
        /// Adiciona uma ação de auto complementar o campo
        /// Crie uma AutoCompleteStringCollection utilizando o toString da o objeto informado
        /// Add os elementos que deseja nela
        /// </summary>
        /// <param name="textBox"></param>Campo de texto
        /// <param name="dados"></param>Dados a ser utilizado
        public static void AddAutoCompleteTextBox<T>(TextBox textBox, List<T> dados) where T : new()
        {

            AutoCompleteStringCollection autoCompleteList = new AutoCompleteStringCollection();

            foreach (T item in dados)
            {
                autoCompleteList.Add(item.ToString());
            }
            textBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox.AutoCompleteCustomSource = autoCompleteList;
        }


        /// <summary>
        /// Adiciona uma ação de auto complementar o campo
        /// Crie uma AutoCompleteStringCollection utilizando o toString da o objeto informado
        /// Add os elementos que deseja nela
        /// </summary>
        /// <param name="textEdit"></param>Campo de texto
        /// <param name="dados"></param>Dados a ser utilizado
        public static void AddAutoCompleteTextEdit<T>(TextEdit textEdit, List<T> dados) where T : new()
        {
            AutoCompleteStringCollection autoCompleteList = new AutoCompleteStringCollection();

            foreach (T item in dados)
            {
                autoCompleteList.Add(item.ToString());
            }

            textEdit.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textEdit.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textEdit.MaskBox.AutoCompleteCustomSource = autoCompleteList;
        }

        /// <summary>
        /// Adiciona uma ação de auto complementar o campo
        /// Cria uma AutoCompleteStringCollection utilizando o toString da o objeto informado
        /// Add os elementos que deseja nela
        /// </summary>
        /// <param name="buttonEdit"></param>Campo de texto
        /// <param name="dados"></param>Dados a ser utilizado
        public static void AddAutoCompleteButtonEdit(ButtonEdit buttonEdit, params string[] dados) 
        {
            AutoCompleteStringCollection autoCompleteList = new AutoCompleteStringCollection();

            foreach (string item in dados)
            {
                autoCompleteList.Add(item);
            }

            buttonEdit.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            buttonEdit.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            buttonEdit.MaskBox.AutoCompleteCustomSource = autoCompleteList;
        }

    }
}
