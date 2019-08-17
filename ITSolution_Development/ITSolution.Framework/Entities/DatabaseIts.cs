using System;

namespace ITSolution.Framework.Entities
{
    //Ia usar isso so nao lembro onde
    public class DatabaseIts
    {

        public int IdDatabase { get; set; }//database_id

        public string DatabaseName { get; set; } //name

        public DateTime DataCreate { get; set; } //create_date

        public decimal Size   { get; set; }// terminar isso depois

        public DatabaseIts()
        {

        }
    }
}
