using ITSolution.Framework.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITSolution.Framework.BaseClasses.License.POCO
{
    [Serializable]
    [Table("ITS_LICENSE")]
    public class ItsLicense
    {
        [Key]//pk
        [Column]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//sera auto increment
        public int IdLicense { get; set; }
        public string CustomerName { get; set; }
        public DateTime StartDate { get; set; }
        public Nullable<DateTime> EndDate { get; set; }

        public byte[] LicenseData { get; set; }
        public bool LicenseStatus { get; set; }

        [NotMapped]
        public ItsLicenseData LicenseDataUnSerialized { get { return SerializeIts.DeserializeObject<ItsLicenseData>(this.LicenseData); } }


        //public int IdCliente { get; set; }

        //[ForeignKey("IdCliente")]
        //public virtual CliFor Cliente { get; set; }

        //public ICollection<ItsMenu> Menus { get; set; }

        public ItsLicense()
        {
            //this.Menus = new HashSet<ItsMenu>();
        }
        public void Update(ItsLicense newLicense)
        {
            this.CustomerName = newLicense.CustomerName;
            this.StartDate = newLicense.StartDate;
            this.EndDate = newLicense.EndDate;
            this.LicenseData = newLicense.LicenseData;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
