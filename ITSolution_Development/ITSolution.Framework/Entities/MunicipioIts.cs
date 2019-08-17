using System.ComponentModel.DataAnnotations;

namespace ITSolution.Framework.Entities
{
    public class MunicipioIts
    {

        [Required]
        [StringLength(100)]
        public string NomeMunicipio { get; set; }

        [StringLength(7)]
        public string CodigoIbge { get; set; }


        public MunicipioIts()
        {

        }
        public MunicipioIts(string nome, string codigoIbge, string uf)
        {
            this.NomeMunicipio = nome;
            this.CodigoIbge = codigoIbge;

        }
        public virtual void Update(MunicipioIts novo)
        {
            this.NomeMunicipio = novo.NomeMunicipio;
            this.CodigoIbge = novo.CodigoIbge;

        }
        public override string ToString()
        {
            return NomeMunicipio;
        }
    }
}
