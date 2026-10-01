using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsArchivioVolatili
{
    public class CPennuto
    {
        private int codice;
        private string specie;
        private string habitat;
        private bool tipoMigratorio;
        private double aperturaAlare;
        public List<CAvvistamenti> Avvistamenti { get; set; }
        public CPennuto(int codice, string specie, string habitat, bool tipoMigratorio, double aperturaAlare)
        {
            this.Codice = codice;
            this.Specie = specie;
            this.Habitat = habitat;
            this.TipoMigratorio = tipoMigratorio;
            this.AperturaAlare = aperturaAlare;
            Avvistamenti = new List<CAvvistamenti>();
        }
        public int Codice
        {
            get => codice;
            set
            {
                if (value <= 0)
                    throw new Exception("Il codice identificativo del pennuto non può essere <= 0 ");

                codice = value;
            }
        }
        public string Specie
        {
            get => specie;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Bel pennuto senza nome. Il nome della specie non può essere vuoto");

                specie = value;
            }
        }
        public string Habitat
        {
            get => habitat;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Bravo, hai trovato un pennuto senzza habitat. Il valore di habitat non può essere vuoto");

                habitat = value;
            }
        }
        public bool TipoMigratorio
        {
            get => tipoMigratorio;
            set => tipoMigratorio = value;
        }
        public double AperturaAlare
        {
            get => aperturaAlare;
            set
            {
                if (value <= 0)
                    throw new Exception("Hai calcolato l'apertura alare senza ali? Il valore di apertura alare non può essere negativo o nullo");

                aperturaAlare = value;
            }
        }
        public void AggiungiAvvistamento(DateTime data, string luogo, string note)
        {
            CAvvistamenti avvistamento = new CAvvistamenti(data, luogo, note);
            Avvistamenti.Add(avvistamento);
        }
        public string GetAvvistamenti()
        {
            string risultato = "";

            foreach (CAvvistamenti a in Avvistamenti)
            {
                risultato += a.ToString() + "\n";
            }

            return risultato;
        }
        public int ContaAvvistamenti()
        {
            return Avvistamenti.Count;
        }
        public override string ToString()
        {
            string migratorio = TipoMigratorio ? "Si" : "No";
            return $"Codice: {codice}, Specie: {specie}, Habitat: {habitat}, Migratore: {migratorio}, Apertura alare: {aperturaAlare} cm";

        }
    }
}
