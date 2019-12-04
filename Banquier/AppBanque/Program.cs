using System;
using Banquier;

namespace AppBanque
{
    class Program
    {
        static void Main(string[] args)
        {
            //Déclaration de toutes les variables et instances utiles au programme
            ConsoleKey choix = new ConsoleKey();
           
            int numeCompte;
            string nom = "";
            double solde, debit, montant;          
            Banque bnp = new Banque();

            Random numCompte = new Random();
            int numeroCompte = numCompte.Next(100000000, 999999999);
            Compte c = new Compte();
            Compte d = new Compte();

            Console.WriteLine("-----______-----_____-----||  Bienvenue dans le programme banque  ||-----______-----_____-----\n\n");
            Console.WriteLine("Pour faire votre choix utilisez le pavé numérique du clavier:");
            do
            {
                try
                {

                    Console.WriteLine("[1] - Créer un compte\n" +
                                      "[2] - Afficher dernier compte crée\n" +
                                      "[3] - Initialiser des comptes aléatoires\n" +
                                      "[4] - Afficher tous les comptes\n" +
                                      "[5] - Créditer un compte\n" +
                                      "[6] - Débiter un compte\n" +
                                      "[7] - Faire un virement\n" +
                                      "[8] - Comparer le solde de deux comptes\n" +
                                      "[9] - Afficher le compte avec le plus d'argent\n" +
                                      "[Echap] - Pour quitter le programme\n");

                    choix = Console.ReadKey().Key;

                    switch (choix)
                    {   //Case pour créer un compte(récupération de la saisie utilisateur dans des variables pour les assigner au constructeur 
                        //de la classse Compte (le numéro de compte est crée aléatoirement).
                        case ConsoleKey.NumPad1:

                            Console.WriteLine("\nVeuillez saisir votre nom");
                            nom = Console.ReadLine();
                            Console.WriteLine("Veuillez saisir le montant que vous voulez déposer");
                            solde = double.Parse(Console.ReadLine());
                            Console.WriteLine("Veuillez saisir le découvert autorisé que vous souhaitez");
                            debit = double.Parse(Console.ReadLine());
                            c = new Compte(numeroCompte, nom, solde, debit);
                            bnp.LesComptes.Add(c);

                            Console.WriteLine("\nVous avez créer le compte :\n{0}", c + "\n");
                            break;

                        //Case pour afficher le dernier compte creé
                        case ConsoleKey.NumPad2:
                            Console.WriteLine("\nLe dernier compte crée est :\n{0}", c);
                            break;

                        //Case pour créer des comptes par défaut
                        case ConsoleKey.NumPad3:
                            bnp.Init();
                            Console.WriteLine("\nVous avez crée les comptes aléatoires suivants :\n" + bnp.AfficherCompte() + "\n");
                            break;

                        //Case pour afficher tout les comptes contenus dans la banque
                        case ConsoleKey.NumPad4:
                            Ecran.AfficherBanque(bnp);
                            break;

                        //Case pour créditer un compte
                        case ConsoleKey.NumPad5:

                            Console.WriteLine("Quel est le numéro de votre compte ?");
                            numeCompte = int.Parse(Console.ReadLine());
                            if (bnp.CheckCompte(numeCompte) != null)
                            {
                                c = bnp.CheckCompte(numeCompte);
                            }
                            Console.WriteLine("\nDe quel montant voulez vous créditer votre compte ?");
                            montant = int.Parse(Console.ReadLine());
                            c.Crediter(montant);
                            Console.WriteLine("\n1Voici votre compte avec le crédit\n" + c.Afficher() + "\n");
                            break;

                        //Case pour débiter un compte
                        case ConsoleKey.NumPad6:

                            Console.WriteLine("Quel est le numéro de votre compte ?");
                            numeCompte = int.Parse(Console.ReadLine());
                            if (bnp.CheckCompte(numeCompte) != null)
                            {
                                c = bnp.CheckCompte(numeCompte);
                            }
                            Console.WriteLine("Quel est le montant que vous souhaitez débiter ?");
                            montant = int.Parse(Console.ReadLine());
                            c.Debiter(montant);
                            Console.WriteLine("Voici le solde de votre compte après le débit\n" + c.Afficher() + "\n");
                            break;

                        //Case pour effectuer un virement
                        case ConsoleKey.NumPad7:
                            int numeroCompte1;

                            Console.WriteLine("Quel est le numéro de votre compte ?");
                            numeCompte = int.Parse(Console.ReadLine());
                            if (bnp.CheckCompte(numeCompte) != null)
                            {
                                c = bnp.CheckCompte(numeCompte);
                            }
                            Console.WriteLine("Quel est le compte sur le quel vous voulez faire un virement ?");
                            numeroCompte1 = int.Parse(Console.ReadLine());
                            if (bnp.CheckCompte(numeroCompte1) != null)
                            {
                                d = bnp.CheckCompte(numeroCompte1);
                            }
                            Console.WriteLine("Quel est le montant que vous souhaitez virer ?");
                            montant = double.Parse(Console.ReadLine());
                            bnp.Transferer(c, d, montant);
                            Console.WriteLine("Voici le solde de votre compte après le virement\n" + c.Afficher() + "\n");
                            Console.WriteLine("Voici le compte sur le quel vous avez effectué le virement\n" + d.Afficher() + "\n");
                            break;

                        //Case pour comparer le solde de deux comptes
                        case ConsoleKey.NumPad8:
                            Console.WriteLine("Quel est le premier compte que vous voulez comparer ?");
                            numeCompte = int.Parse(Console.ReadLine());

                            if (bnp.CheckCompte(numeCompte) != null)
                            {
                                c = bnp.CheckCompte(numeCompte);
                            }
                            Console.WriteLine("Quel est le deuxième compte que vous voulez comparer ?");
                            numeCompte = int.Parse(Console.ReadLine());
                            if (bnp.CheckCompte(numeCompte) != null)
                            {
                                d = bnp.CheckCompte(numeCompte);
                            }
                            if (c.Superieur(d))
                            {
                                Console.WriteLine("\nLe compte:\n{0}     à un solde supérieur.", c.Afficher());
                            }
                            else
                            {
                                Console.WriteLine("\nLe compte:\n{0}     à un solde supérieur.", d.Afficher());
                            }

                            break;

                        //Case pour afficher le compte qui a le plus grand solde
                        case ConsoleKey.NumPad9:
                            Console.WriteLine("Voici le compte qui a le solde le plus haut :\n");
                            Console.WriteLine(bnp.CompteSuperieur());
                            break;

                        //Case uniquement pour affichage d'une phrase finale
                        case ConsoleKey.Escape:
                            Console.WriteLine("Vous avez décider de quitter le programme, à bientôt dans la Becker's Bank.");
                            break;
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (ConsoleKey.Escape != choix);

            Console.ReadLine();
        }
    }
}
