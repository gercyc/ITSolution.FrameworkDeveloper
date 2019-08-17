using ITSolution.Framework.Dao.Contexto;
using System.IO;

namespace ITSolution.Framework.Forms
{
    public class ParamsFindEntity
    {
        public DbContextIts Context { get; set; }
        public string[] Columns { get; set; }
        public string Title { get; set; }
        public string WhereCondition { get; set; }
        public string Order { get; set; }
        public Stream Layout { get; set; }
        public dynamic DynamicObject { get; set; }

    }
}
