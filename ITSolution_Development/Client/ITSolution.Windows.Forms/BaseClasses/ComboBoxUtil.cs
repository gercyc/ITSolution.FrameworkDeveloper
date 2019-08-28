using ITSolution.Framework.Util;
using System;
using System.Collections.Generic;

namespace ITSolution.Framework.GuiUtil
{
    public static class ComboBoxUtil
    {
        /// <summary>
        /// Add uma lista na caixa de combinação e inicia com um item selecionado
        /// </summary>
        /// <typeparam name="T"></typeparam>Tipo
        /// <param name="cbEdit"></param>Caixa de Combinação
        /// <param name="lista"></param>Lista a ser inserida
        /// <param name="overRide"></param> false dados do combo serao substituidos true serão adicionados
        public static void AddList<T>(this DevExpress.XtraEditors.ComboBoxEdit cbEdit, List<T> lista, bool overRide = true) where T : new()
        {
            if (overRide)
            {
                cbEdit.Properties.Items.Clear();
            }

            cbEdit.Properties.Items.AddRange(lista);

            if (overRide && lista.Count > 0)
            {
                cbEdit.SelectedItem = lista[0];
            }
        }

        public static void AddEnumValues<T>(this DevExpress.XtraEditors.ComboBoxEdit cbEdit) where T : new()
        {
            cbEdit.Properties.Items.Clear();
            var values = EnumUtil.GetEnumListDescription<T>();
            foreach (var item in values)
            {
                cbEdit.Properties.Items.Add(item);
            }
        }

        public static void AddEnumValues(this DevExpress.XtraEditors.ComboBoxEdit cbEdit, Type type)
        {
            cbEdit.Properties.Items.Clear();
            //typeof(Object)
            //cbEdit.Properties.Items.AddRange(Enum.GetValues(type));
            var values = Enum.GetValues(type);

            foreach (var item in values)
            {
                cbEdit.Properties.Items.Add(item);
            }
        }

        public static void AddEnumValues(this System.Windows.Forms.ComboBox cb, Type type)
        {
            cb.Items.Clear();
            var values = Enum.GetValues(type);
            foreach (var item in values)
            {
                cb.Items.Add(item);
            }
        }

        /// <summary>
        /// Add um item na caixa de combinação 
        /// </summary>
        /// <typeparam name="T"></typeparam>Tipo
        /// <param name="cbEdit"></param>Caixa de Combinação
        /// <param name="lista"></param>Lista a ser inserida
        /// <param name="overRide"></param> false dados do combo serao substituidos true serão adicionados
        public static void AddItem<T>(this DevExpress.XtraEditors.ComboBoxEdit cbEdit, T t, bool overRide = true) where T : new()
        {
            if (t != null)
            {
                if (overRide)
                    cbEdit.Properties.Items.Clear();

                cbEdit.Properties.Items.Add(t);
                cbEdit.SelectedItem = t;
            }
        }

        /// <summary>
        /// Add uma lista na caixa de combinação e inicia com um item selecionado
        /// </summary>
        /// <typeparam name="T"></typeparam>Tipo
        /// <param name="cbEdit"></param>Caixa de Combinação
        /// <param name="lista"></param>Lista a ser inserida
        /// <param name="overRide"></param> false dados do combo serao substituidos true serão adicionados
        public static void AddList<T>(this System.Windows.Forms.ComboBox cb, List<T> lista, bool overRide = true) where T : new()
        {
            if (!overRide)
                cb.Items.Clear();
            cb.Items.AddRange(new object[] { lista });

            if (lista != null && lista.Count > 0)
            {
                cb.SelectedItem = lista[0];
            }
        }

        /// <summary>
        /// Add um item na caixa de combinação 
        /// </summary>
        /// <typeparam name="T"></typeparam>Tipo
        /// <param name="cbEdit"></param>Caixa de Combinação
        /// <param name="lista"></param>Lista a ser inserida
        /// <param name="overRide"></param> false dados do combo serao substituidos true serão adicionados
        public static void AddItem<T>(this System.Windows.Forms.ComboBox cb, T t, bool overRide = true) where T : new()
        {
            if (!overRide)
                cb.Items.Clear();

            cb.Items.Add(t);
            cb.SelectedItem = t;

        }

        /// <summary>
        /// Obtém o item selecionado ou pega o primeiro elementro que encontra na caixa de combinacao
        /// </summary>
        /// <typeparam name="T"></typeparam>Tipo
        /// <param name="cbEdit"></param>Caixa de combinação
        /// <returns></returns>O item selecionado
        public static T GetSelectedItem<T>(this DevExpress.XtraEditors.ComboBoxEdit cbEdit) where T : new()
        {
            try
            {
                T item = (T)cbEdit.SelectedItem;
                return item != null ? item : new T();
            }
            catch
            {
                return new T();
            }
        }

        /// <summary>
        /// Obtém o item selecionado
        /// </summary>
        /// <typeparam name="T"></typeparam>Tipo
        /// <param name="cb"></param>Caixa de combinação
        /// <returns></returns>O item selecionado
        public static T GetSelectedItem<T>(this System.Windows.Forms.ComboBox cb) where T : new()
        {
            T item = (T)cb.SelectedItem;

            return item != null ? item : new T();
        }

        /// <summary>
        /// Obtém o item selecionado
        /// </summary>
        /// <typeparam name="T"></typeparam>Tipo
        /// <param name="cbEdit"></param>Caixa de combinação
        /// <returns></returns>O item selecionado
        public static List<T> GetItens<T>(this DevExpress.XtraEditors.ComboBoxEdit cbEdit) where T : new()
        {
            var lista = new List<T>();
            var count = cbEdit.Properties.Items.Count;
            for (int i = 0; i < count; i++)
            {
                cbEdit.SelectedIndex = i;
                if (cbEdit.SelectedItem != null)
                {
                    T item = (T)cbEdit.SelectedItem;
                    lista.Add(item);
                }
            }
            return lista;
        }

        /// <summary>
        /// Obtém o item selecionado
        /// </summary>
        /// <typeparam name="T"></typeparam>Tipo
        /// <param name="cb"></param>Caixa de combinação
        /// <returns></returns>O item selecionado
        public static List<T> GetItens<T>(this System.Windows.Forms.ComboBox cb) where T : new()
        {
            var lista = new List<T>();
            var count = cb.Items.Count;
            for (int i = 0; i < count; i++)
            {
                cb.SelectedIndex = i;
                if (cb.SelectedItem != null)
                {
                    T item = (T)cb.SelectedItem;
                    lista.Add(item);
                }
            }
            return lista;
        }

        public static int GetItensCount(this DevExpress.XtraEditors.ComboBoxEdit cbEdit)
        {

            return cbEdit.Properties.Items.Count;
        }

        public static int GetItensCount(this System.Windows.Forms.ComboBox cb)
        {
            return cb.Items.Count;
        }

        public static void SetSelectItem<T>(this System.Windows.Forms.ComboBox cb, T t) where T : new()
        {
            var itens = cb.GetItens<T>();
            foreach (T item in itens)

                if (item.ToString() == t.ToString())
                {
                    cb.SelectedItem = item;
                }
        }

        public static void SetSelectItem<T>(this DevExpress.XtraEditors.ComboBoxEdit cbEdit, T t) where T : new()
        {
            var itens = cbEdit.GetItens<T>();
            foreach (T item in itens)

                if (item.ToString() == t.ToString())
                {
                    cbEdit.SelectedItem = item;
                }
        }
    }
}
