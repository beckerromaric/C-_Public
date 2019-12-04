using System;
using System.Collections.Generic;
using System.Text;

namespace Banquier
{
    public class Banque
    {
        private int nbComptes;

        private List<Compte> lesComptes;

        public List<Compte> LesComptes
        {
            get
            {
                return lesComptes;
            }
        }

        public Banque()
        {
            lesComptes = new List<Compte>();
            this.nbComptes = 0;
        }

        public void Init()
        {
            Compte compte6 = new Compte(12345, "Jojo", 1000, -500);
            Compte compte7 = new Compte(45785, "Jaja", 2000, -1000);
            Compte compte8 = new Compte(21574, "Jiji", 2000, -1500);
            Compte compte9 = new Compte(45745, "Juju", 1200, -500);
            Compte compte10 = new Compte(48715, "Jyjy", -200, -500);

            LesComptes.Add(compte6);
            LesComptes.Add(compte7);
            LesComptes.Add(compte8);
            LesComptes.Add(compte9);
            LesComptes.Add(compte10);
        }

        public string AfficherCompte()
        {
            string str = "";

            foreach (var affichage in LesComptes)
            {
                str += affichage.Afficher();
            }

            return str;
        }

        public void AjouterComptes(int _numeroCpt, string _nom, double _solde, double _decouvert)
        {
            if (_numeroCpt < 0)
            {
                throw new ArgumentOutOfRangeException("Vous esssayez de rentrer un numéro de compte négatif !");
            }
            
            LesComptes.Add(new Compte(_numeroCpt, _nom, _solde, _decouvert));
        }

        public Compte CompteSuperieur()
        {   
            Compte min = LesComptes[0];

            for (int i = 1; i < LesComptes.Count; i++)
            {
                if (LesComptes[i].Superieur(min))
                {
                    min = LesComptes[i];
                }
            }
            return min;
        }

        public Compte CheckCompte(int _numeroCompte)
        {

            if (_numeroCompte < 0)
            {
                throw new ArgumentOutOfRangeException("Vous essayez de trouver un compte avec un numéro négatif !");
            }

            for (int i = 0; i < LesComptes.Count; i++)
            {
                if (LesComptes[i].Numero == _numeroCompte)
                {
                    return LesComptes[i];
                }
            }
            return null;
        }

        public bool Transferer(Compte _compteProprietaire, Compte _compteDestinataire, double _montant)
        {
            if (_montant < 0)
            {
                throw new ArgumentOutOfRangeException("Vous essayez de transferer un solde négatif, demande plutôt au destinataire " +
                                                        "de t'envoyer de l'argent !!");
            }

            if((_compteDestinataire.Solde - _montant) >= _compteProprietaire.DecouvertAutorise)
            {
                _compteDestinataire.Crediter(_montant);
                _compteProprietaire.Debiter(_montant);
                return true;
            }

            return false;
        }
    }
}
