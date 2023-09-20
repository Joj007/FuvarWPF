using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doga
{
    class Fuvar
    {
        int taxiId;
        DateTime indulas;
        int idotartam;
        double tavolsag;
        double vitelDij;
        double borravalo;
        string fizetesiMod;

        public Fuvar(int taxiId, DateTime indulas, int idotartam, double tavolsag, double vitelDij, double borravalo, string fizetesiMod)
        {
            this.taxiId = taxiId;
            this.indulas = indulas;
            this.idotartam = idotartam;
            this.tavolsag = tavolsag;
            this.vitelDij = vitelDij;
            this.borravalo = borravalo;
            this.fizetesiMod = fizetesiMod;
        }

        public int TaxiId { get => taxiId;}
        public DateTime Indulas { get => indulas;}
        public int Idotartam { get => idotartam;}
        public double TavolsagMerfold { get => tavolsag;}
        public double VitelDij { get => vitelDij;}
        public double Borravalo { get => borravalo;}
        public string FizetesiMod { get => fizetesiMod;}
        public double TavolsagKilometer { get => tavolsag * 1.6; }
        public string OsszesAdat { get => $"\tFuvar hossza: {idotartam} másodperc\n\tTaxi azonosítója: {taxiId}\n\tMegtett távolság: {Math.Round(TavolsagKilometer, 2)} km\n\tViteldíj: {vitelDij}$"; }
        public string Fajlba { get => $"{taxiId};{indulas};{idotartam};{tavolsag};{vitelDij};{borravalo};{fizetesiMod}"; }
    }
}
