using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSolution.Framework.BaseClasses
{
    public partial class ITSDBObject : CustomDbObject
    {
        public ITSDBObject()
        {
            InitializeComponent();            
        }

        public ITSDBObject(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }
    }

    public partial class CustomDbObject : Component
    {
        private string _typedObject;
        public string TypedObject { get { return _typedObject; } set { _typedObject = value; } }

        [AttributeProvider(typeof(IListSource))]
        [DefaultValue(null)]
        [RefreshProperties(RefreshProperties.Repaint)]

        public object Datasource { get; set; }

    }
}
