using System;
using System.Text;

namespace Banquier
{
    public class Compte
    {
        private double decouvertAutorise;

        private string nomClient;

        private int numero;

        private double solde;

        public Compte()
        {
            Random numAlea = new Random();
            this.numero = numAlea.Next(100000000, 999999999);
            this.nomClient = "compte par defaut";
            this.Solde = 0;
            this.DecouvertAutorise = 0;
        }

        public Compte(int _numero, string _nomClient, double _solde, double _decouvert)
        {
            this.numero = _numero;
            this.nomClient = _nomClient;
            this.Solde = _solde;
            this.DecouvertAutorise = _decouvert;
        }

        public void Crediter(double _montant)
        {
            if (_montant < 0)
            {
                throw new ArgumentOutOfRangeException("Vous essayez de créditer une somme négative !");
            }

            Solde = Solde + _montant;
        }

        public bool Debiter(double _montant)
        {
            if (_montant < 0)
            {
                throw new ArgumentOutOfRangeException("Vous essayez de débiter une somme négative!");
            }

            if ((Solde - _montant) < DecouvertAutorise)
            {
                throw new ArgumentOutOfRangeException("Vous dépassez le découvert autorisé !!");
            }

            if ((Solde - _montant) >= DecouvertAutorise)
            {
                Solde -= _montant;
                return true;
            }

            return false;
        }

        public bool Transferer(double _montant, Compte _autreCompte)      
        {
            if (_montant < 0)
            {
                throw new ArgumentOutOfRangeException("Vous essayez de transferer une somme négative!");
            }

            if ((Solde - _montant) < DecouvertAutorise)
            {
                throw new ArgumentOutOfRangeException("Vous essayez de transferer une somme au dela du découvert autorisé !");
            }

            if ((Solde - _montant) >= DecouvertAutorise)
            {
                Solde = Solde - _montant;
                _autreCompte.Debiter(_montant);
                return true;
            }

            return false;
        }

        public bool Superieur(Compte _autreCompte)
        {
            if (Solde > _autreCompte.Solde)
            {
                return true;
            }
            return false;
        }

        public double DecouvertAutorise
        {
            get
            {
                return decouvertAutorise;
            }

            set
            {
                decouvertAutorise = value;
            }
        }

        public string NomClient
        {
            get
            {
                return nomClient;
            }
        }

        public int Numero
        {
            get
            {
                return numero;
            }
        }

        public double Solde
        {
            get
            {
                return solde;
            }

            set
            {
                solde = value;
            }
        }

        public string Afficher()
        {
            //return "\nNuméro compte : " + Numero + " Nom client: " + NomClient + " Solde: " + Solde + " Découvert Autorisé" + DecouvertAutorise + "\n";
            return ($"Numéro compte : {this.Numero.ToString("0000-0000-0000-0000")} \nNom : {this.nomClient.ToString()} \nSolde : {this.solde.ToString()} Euros \nDécouvert autorisé: {this.decouvertAutorise.ToString()} Euros");
        }

        public override string ToString()
        {
            StringBuilder tostring = new StringBuilder();
            tostring.AppendFormat($"Numéro de compte: {this.Numero.ToString("0000-0000-0000-0000")}\n")
                    .AppendFormat("Nom: {0}\n", this.NomClient)
                    .AppendFormat("Solde: {0} euros\n", this.Solde)
                    .AppendFormat("Découvert autorisé: {0}\n", this.DecouvertAutorise);
            return tostring.ToString();
        }
    }
}
