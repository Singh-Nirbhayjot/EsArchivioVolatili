using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsArchivioVolatili
{
    public enum TipoAcqua
    {
        dolce,
        salata
    }
    public class Program
    {
        public static List<CPennuto> pennuti = new List<CPennuto>();

        static void Main(string[] args)
        {
            int scelta;
            do
            {
                Console.WriteLine("\n-- ARCHIVIO PENNUTI --");
                Console.WriteLine("1. Inserisci pennuto");
                Console.WriteLine("2. Visualizza pennuti");
                Console.WriteLine("3. Elimina pennuto");
                Console.WriteLine("4. Aggiungi avvistamento");
                Console.WriteLine("5. Visualizza avvistamenti");
                Console.WriteLine("6. Cerca per specie");
                Console.WriteLine("7. Visualizza migratori");
                Console.WriteLine("8. Conta esemplari per categoria");
                Console.WriteLine("9. Conta avvistamenti");
                Console.WriteLine("0. Esci");
                Console.Write("Scelta: ");


                while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 0 || scelta > 9)
                {
                    Console.WriteLine("Scelta non valida");
                    Console.WriteLine("Scelta: ");
                }

                switch (scelta)
                {
                    case 1:
                        InserisciPennuto();
                        break;
                    case 2:
                        VisualizzaPennuti();
                        break;
                    case 3:
                        EliminaPennuto();
                        break;
                    case 4:
                        AggiungiAvvistamento();
                        break;
                    case 5:
                        VisualizzaAvvistamenti();
                        break;
                    case 6:
                        CercaPerSpecie();
                        break;
                    case 7:
                        VisualizzaMigratori();
                        break;
                    case 8:
                        ContaPerCategoria();
                        break;
                    case 9:
                        ContaAvvistamenti();
                        break;
                    case 0:
                        Console.WriteLine("Programma terminato");
                        break;
                }
            } while (scelta != 0);
        }
        public static void InserisciPennuto()
        {
            int codice;
            int migratore;
            double apertura;

            Console.Write("Codice: ");

            while (!int.TryParse(Console.ReadLine(), out codice) || TrovaPennuto(codice) != null)
            {
                Console.WriteLine("Inserisci un numero valido o non già esistente");
                Console.Write("Codice: ");
            }

            Console.Write("Specie: ");
            string specie = Console.ReadLine();

            Console.Write("Habitat: ");
            string habitat = Console.ReadLine();

            Console.Write("È migratore? (0 = no, 1 = sì): ");

            while (!int.TryParse(Console.ReadLine(), out migratore) ||
                   migratore < 0 || migratore > 1)
            {
                Console.WriteLine("Inserisci 0 oppure 1.");
                Console.Write("È migratore? (0 = no, 1 = sì): ");
            }

            bool tipoMigratorio = migratore == 1 ? true : false;


            Console.Write("Apertura alare: ");
            while (!double.TryParse(Console.ReadLine(), out apertura))
            {
                Console.WriteLine("Inserisci un numero valido.");
                Console.WriteLine("Apertura alare:");
            }

            Console.WriteLine("1. Rapace");
            Console.WriteLine("2. Canterino");
            Console.WriteLine("3. Acquatico");

            Console.Write("Categoria: ");
            int categoria;
            while (!int.TryParse(Console.ReadLine(), out categoria) ||
                   categoria < 1 || categoria > 3)
            {
                Console.WriteLine("Inserisci 1, 2 oppure 3.");
                Console.Write("Categoria: ");
            }
            try
            {
                CPennuto p;

                if (categoria == 1)
                {
                    Console.Write("Dieta: ");
                    string dieta = Console.ReadLine();

                    p = new CRapace(codice, specie, habitat, tipoMigratorio, apertura, dieta);
                }
                else if (categoria == 2)
                {
                    Console.Write("Canto caratteristico: ");
                    string canto = Console.ReadLine();

                    p = new CCanterino(codice, specie, habitat, tipoMigratorio, apertura, canto);
                }
                else
                {
                    Console.WriteLine("1.Dolce");
                    Console.WriteLine("2. Salata");

                    int acqua;

                    Console.Write("Tipo acqua: ");

                    while (!int.TryParse(Console.ReadLine(), out acqua) ||
                           acqua < 1 || acqua > 2)
                    {
                        Console.WriteLine("Inserisci 1 oppure 2.");
                        Console.Write("Tipo acqua: ");
                    }

                    TipoAcqua tipoAcqua = acqua == 1 ? TipoAcqua.dolce : TipoAcqua.salata;

                    p = new CAcquatico(codice, specie,habitat,tipoMigratorio,apertura, tipoAcqua);
                }

                pennuti.Add(p);
                Console.WriteLine("Pennuto inserito");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void VisualizzaPennuti()
        {
            if(pennuti.Count ==0)
            {
                Console.WriteLine("Non ci sono pennuti nell'archivio.");
                return;
            }

            foreach(CPennuto p in pennuti)
            {
                Console.WriteLine(p.ToString());
            }
        }
        public static void EliminaPennuto()
        {
            int codice;

            Console.Write("Inserisci il codice del pennuto da eliminare: ");

            while (!int.TryParse(Console.ReadLine(),out codice))
            {
                Console.WriteLine("Inserisci un numero valido.");
                Console.Write("Codice: ");
            }

            CPennuto p = TrovaPennuto(codice);

            if (p ==null)
            {
                Console.WriteLine("pennuto non trovato.");
                return;
            }
            pennuti.Remove(p);

            Console.WriteLine("pennuto eliminato.");
        }
        public static void AggiungiAvvistamento()
        {
            int codice;
            Console.Write("Codice dell'esemplare: ");

            while (!int.TryParse(Console.ReadLine(),out codice))
            {
                Console.WriteLine("Inserisci un numero valido.");
                Console.Write("Codice: ");
            }

            CPennuto p =TrovaPennuto(codice);

            if (p == null)
            {
                Console.WriteLine("Esemplare non trovato.");
                return;
            }

            DateTime data;

            Console.Write("Data dell'avvistamento: ");
            while (!DateTime.TryParse(Console.ReadLine(), out data))
            {
                Console.WriteLine("Inserisci una data valida.");
                Console.Write("Data: ");
            }

            Console.Write("Luogo: ");
            string luogo = Console.ReadLine();

            Console.Write("Note: ");
            string note =Console.ReadLine();

            try
            {
                p.AggiungiAvvistamento(data,luogo, note);

                Console.WriteLine("Avvistamento registrato.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void VisualizzaAvvistamenti()
        {
            int codice;
            Console.Write("Codice dell'esemplare: ");

            while(!int.TryParse(Console.ReadLine(),out codice))
            {
                Console.WriteLine("Inserisci un numero valido.");
                Console.Write("Codice: ");
            }

            CPennuto p= TrovaPennuto(codice);

            if (p ==null)
            {
                Console.WriteLine("pennuto non trovato.");
                return;
            }

            string avvistamenti =p.GetAvvistamenti();

            if (avvistamenti == "")
                Console.WriteLine("Nessun avvistamento.");
            else
                Console.WriteLine(avvistamenti);
        }
        public static void CercaPerSpecie()
        {
            Console.Write("Specie da cercare: ");
            string specie= Console.ReadLine();

            bool trovato=false;

            foreach (CPennuto p in pennuti)
            {
                if (p.Specie.ToLower() == specie.ToLower())
                {
                    Console.WriteLine(p.ToString());
                    trovato =true;
                }
            }

            if (!trovato)
                Console.WriteLine("Nessun pennuto trovato.");
        }
        public static void VisualizzaMigratori()
        {
            bool trovato= false;

            foreach (CPennuto p in pennuti)
            {
                if (p.TipoMigratorio)
                {
                    Console.WriteLine(p.ToString());
                    trovato = true;
                }
            }

            if (!trovato)
                Console.WriteLine("Nessun pennuto migratore trovato.");
        }
        public static void ContaPerCategoria()
        {
            int rapaci =0;
            int canterini = 0;
            int acquatici = 0;

            foreach (CPennuto p in pennuti)
            {
                if(p is CRapace)
                    rapaci++;
                else if (p is CCanterino)
                    canterini++;
                else if(p is CAcquatico)
                    acquatici++;
            }

            Console.WriteLine($"Rapaci: {rapaci}");
            Console.WriteLine($"Canterini: {canterini}");
            Console.WriteLine($"Acquatici: {acquatici}");
            Console.WriteLine($"Totale: {pennuti.Count}");
        }
        public static void ContaAvvistamenti()
        {
            int totale= 0;

            foreach (CPennuto p in pennuti)
            {
                totale+= p.ContaAvvistamenti();
            }

            Console.WriteLine($"Numero complessivo degli avvistamenti: {totale}");
        }
        public static CPennuto TrovaPennuto(int codice)
        {
            foreach(CPennuto p in pennuti)
            {
                if (p.Codice == codice)
                    return p;
            }
            return null;
        }
    }
}

