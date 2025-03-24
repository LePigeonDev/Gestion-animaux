using System;
using System.Collections.Generic;

class Animal
{
    public string? ID { get; set; }
    public string? Espece { get; set; }
    public string? Surnom { get; set; }
    public int Age { get; set; }
    public string? EtatPhysique { get; set; }
    public string? Sexe { get; set; }
    public string? Couleur { get; set; }
}

class Program
{
    static void Main()
    {
        bool fin = false;
        int reponse;

        List<Animal> listeAnimaux = new List<Animal>
        {
            new Animal { ID = "1", Surnom = "Tigrou", Espece = "Chat", Age = 5, EtatPhysique = "bonne condition", Sexe = "feminin", Couleur = "roux" },
            new Animal { ID = "2", Surnom = "Toto", Espece = "Chien", Age = 7, EtatPhysique = "surpoids", Sexe = "masculin", Couleur = "blanc & noir" },
            new Animal { ID = "3", Surnom = "Momo", Espece = "Mouton", Age = 1, EtatPhysique = "maigre", Sexe = "masculin", Couleur = "blanc" }
        };

        do
        {
            Console.WriteLine("\n-----------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("\t\t\t\t\t\tEntrez le numéro du menu souhaité:\n");
            Console.WriteLine("1. Lister toutes nos informations actuelles sur les animaux.\t\t 3. Modifier La fiche d'un animal.");
            Console.WriteLine("2. Ajouter un animal dans la base de données.\t\t\t\t 4. Supprimer la fiche d'un animal.");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t 9. Quitter.");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------\n");

            string? userInput = Console.ReadLine();

            if (userInput != null)
            {
                Console.WriteLine($"Vous avez sélectionné le menu {userInput}\n");
            }

            if (int.TryParse(userInput, out reponse))
            {
                switch (reponse)
                {
                    case 1:
                        AfficherToutesInformations(listeAnimaux);
                        break;

                    case 2:
                        
                        AjouterUnAnimal(listeAnimaux);
                        break;
                    
                    case 3:
                        ModifierUnAnimal(listeAnimaux);
                        break;

                    case 4:
                        SupprimerUnAnimal(listeAnimaux);
                        break;

                    case 9:
                        Console.WriteLine("Vous quittez l'application");
                        fin = true;
                        break;

                    default:
                        Console.WriteLine("Option invalide. Veuillez entrer un numéro de menu valide.");
                        break;
                }
            }

            if (reponse != 9)
            {
                Console.WriteLine("\nAppuyez sur entrée pour continuer");
                Console.ReadLine();
            }

        } while (!fin);
    }

    static void AfficherToutesInformations(List<Animal> listeAnimaux)
    {
        Console.WriteLine("Toutes les informations sur les animaux :");
        foreach (var animal in listeAnimaux)
        {
            Console.WriteLine($"\n\t\t--------------------------------------\n\t\t\tID: {animal.ID}\n\t\t\tSurnom : {animal.Surnom}\n\t\t\tEspece: {animal.Espece}\n\t\t\tAge: {animal.Age}\n\t\t\tPhysique: {animal.EtatPhysique}\n\t\t\tSexe: {animal.Sexe}\n\t\t\tCouleur: {animal.Couleur}\n\t\t--------------------------------------");
        }
    }

    static void AjouterUnAnimal(List<Animal> listeAnimaux)
    {   

        Console.WriteLine("Ajoutez un animal");
        string id = (listeAnimaux.Count + 1).ToString();

        Console.WriteLine("Veuillez saisir le nom de l'animal");
        string? surnom = Console.ReadLine();

        Console.WriteLine("Veuillez saisir le espece de l'animal");
        string? espece = Console.ReadLine();

        int age;
        bool fin = false;
        do
        {
            Console.WriteLine("Veuillez saisir l'âge de l'animal");
            if (int.TryParse(Console.ReadLine(), out age))
            {
                fin = true;
            }

            else 
            {
                Console.WriteLine("Veuiller saisir un age valide");
            }
    
        }while(fin == false);

        string? etatPhysique;

        do
        {
            Console.WriteLine("Veuillez saisir l'état physique de l'animal [Maigre] / [Surpoids] / [Bonne condition]");            
            etatPhysique = Console.ReadLine()?.ToUpper().Trim();

            if (etatPhysique != "MAIGRE" && etatPhysique != "SURPOIDS" && etatPhysique != "BONNE CONDITION")
            {
                Console.WriteLine("\t\tDésolé, veuillez saisir une option valide.\n");
            }

        } while (etatPhysique != "MAIGRE" && etatPhysique != "SURPOIDS" && etatPhysique != "BONNE CONDITION");

        string? sexe;
        do
        {
            Console.WriteLine("Veuillez saisir le sexe de l'animal [Masculin] / [Feminin]");
            sexe = Console.ReadLine()?.ToUpper().Trim();

            if (sexe != "MASCULIN" && sexe != "FEMININ")
            {
                Console.WriteLine("\t\tDésolé, veuillez saisir une option valide.\n");
            }
        } while (sexe != "MASCULIN" && sexe != "FEMININ");

        Console.WriteLine("Veuillez saisir le couleur de l'animal");
        string? couleur = Console.ReadLine();


        Animal nouvelAnimal = new Animal
        {
            ID = id,
            Surnom = surnom,
            Espece = espece,
            Age = age,
            EtatPhysique = etatPhysique,
            Sexe = sexe,
            Couleur = couleur
        };

        listeAnimaux.Add(nouvelAnimal);
        Console.WriteLine($"La fiche a été ajouter:\n\t\t--------------------------------------\n\t\t\tID - {id}\n\t\t\tSurnom - {surnom}\n\t\t\tEspece - {espece}\n\t\t\tPhysique - {etatPhysique}\n\t\t\tAge - {age}\n\t\t\tSexe - {sexe}\n\t\t\tCouleur - {couleur}\n\t\t--------------------------------------");
 
    }
    static void ModifierUnAnimal(List<Animal> listeAnimaux)
    {
        bool ContinuerModifier = true;

        do
        {
            Console.WriteLine("Saisir le numéro d'identifiant de la fiche l'animal à modifer");
            if (int.TryParse(Console.ReadLine(), out int identifiant))
            {

                if (identifiant <= listeAnimaux.Count)
                {
                    Animal animalModifier = listeAnimaux[identifiant - 1];
                    Console.WriteLine($"Vous avez selectionné :\n\t\t--------------------------------------\n\t\t\tID - {animalModifier.ID}\n\t\t\tSurnom - {animalModifier.Surnom}\n\t\t\tEspece - {animalModifier.Espece}\n\t\t\tPhysique - {animalModifier.EtatPhysique}\n\t\t\tAge - {animalModifier.Age}\n\t\t\tSexe - {animalModifier.Sexe}\n\t\t\tCouleur - {animalModifier.Couleur}\n\t\t--------------------------------------");
                    
                    Console.WriteLine("\nVoulez-vous modifier \n\t\t\t[1. Entierement la fiche]\t [2. Un élément de la fiche]\n\n\tTaper le numéro de l'option choisit : \n");
                    if (int.TryParse(Console.ReadLine(), out int option))
                    {
                        if (option == 1)
                        {
                            Console.WriteLine("\nVeuillez saisir le nouveau surnom de l'animal :");
                            string? nouveauSurnom = Console.ReadLine();
                            animalModifier.Surnom = nouveauSurnom;
                            Console.WriteLine("\tSurnom mis à jour avec succès.");

                            Console.WriteLine("\nVeuillez saisir la nouvelle espece de l'animal :");
                            string? nouvelleEspece = Console.ReadLine();
                            animalModifier.Espece = nouvelleEspece;
                            Console.WriteLine("\tEspece mis à jour avec succès.");
                                    
                                string? nouveauPhysique;

                                do
                                {
                                    Console.WriteLine("\nVeuillez saisir le nouveau physique de l'animal [Maigre] / [Surpoids] / [Bonne condition]:");
                                    nouveauPhysique = Console.ReadLine()?.ToUpper().Trim();

                                    if (nouveauPhysique != "MAIGRE" && nouveauPhysique != "SURPOIDS" && nouveauPhysique != "BONNE CONDITION")
                                    {
                                        Console.WriteLine("\nDésolé, veuillez saisir une option valide.\n");
                                    }

                                } while (nouveauPhysique != "MAIGRE" && nouveauPhysique != "SURPOIDS" && nouveauPhysique != "BONNE CONDITION");

                            animalModifier.EtatPhysique = nouveauPhysique;
                            Console.WriteLine("\tPhysique mis à jour avec succès.");
                            
                            bool fin = false;
                            do
                            {
                                Console.WriteLine("\nVeuillez saisir le nouvel âge de l'animal :");

                                if (int.TryParse(Console.ReadLine(), out int nouvelAge))
                                {
                                    animalModifier.Age = nouvelAge;
                                    Console.WriteLine("\tÂge mis à jour avec succès.");
                                    fin = true ;
                                }
                                else
                                {
                                    Console.WriteLine("\nVeuillez saisir un nombre valide pour l'âge.");
                                }   
                            } while (fin == false);

                                string? nouveauSexe;

                                do
                                {
                                    Console.WriteLine("\nVeuillez saisir le nouveau sexe de l'animal [Masculin] / [Feminin] :");
                                    nouveauSexe = Console.ReadLine()?.ToUpper().Trim();

                                    if (nouveauSexe != "MASCULIN" && nouveauSexe != "FEMININ")
                                    {
                                        Console.WriteLine("\nDésolé, veuillez saisir une option valide.\n");
                                    }

                                } while (nouveauSexe != "MASCULIN" && nouveauSexe != "FEMININ");

                                animalModifier.Sexe = nouveauSexe;
                                Console.WriteLine("\tSexe mis à jour avec succès.");

                                Console.WriteLine("\nVeuillez saisir la nouvelle couleur de l'animal :");
                                string? nouvelleCouleur = Console.ReadLine();
                                animalModifier.Couleur = nouvelleCouleur;
                                Console.WriteLine("\tCouleur mis à jour avec succès.");

                                Console.WriteLine("\n\nVoulez-Vous continuez à modifier la fiche d'un animal [OUI] / [NON]");
                                string? message = Console.ReadLine();
                                message = message?.ToUpper().Trim();

                                if (message == "NON")
                                {
                                    ContinuerModifier = false;
                                }
                                        
                        } 

                        if (option == 2)
                        {
                            Console.WriteLine("\nVeuillez saisir la catégorie à modifier [Surnom] / [Espece] / [Physique] / [Age] / [Sexe] / [Couleur]");
                            
                            var modifer = Console.ReadLine();
                            modifer = modifer?.ToUpper().Trim();
                            
                            switch (modifer)
                            {
                                case "SURNOM":
                                    Console.WriteLine("\nVeuillez saisir le nouveau surnom de l'animal :");
                                    string? nouveauSurnom = Console.ReadLine();
                                    animalModifier.Surnom = nouveauSurnom;
                                    Console.WriteLine("\tSurnom mis à jour avec succès.");
                                break;

                                case "ESPECE":
                                    Console.WriteLine("\nVeuillez saisir la nouvelle espece de l'animal :");
                                    string? nouvelleEspece = Console.ReadLine();
                                    animalModifier.Espece = nouvelleEspece;
                                    Console.WriteLine("\tEspece mis à jour avec succès.");
                                break;

                                case "PHYSIQUE":
                                    
                                    string? nouveauPhysique;

                                    do
                                    {
                                        Console.WriteLine("\nVeuillez saisir le nouveau physique de l'animal [Maigre] / [Surpoids] / [Bonne condition] :");
                                        nouveauPhysique = Console.ReadLine()?.ToUpper().Trim();

                                        if (nouveauPhysique != "MAIGRE" && nouveauPhysique != "SURPOIDS" && nouveauPhysique != "BONNE CONDITION")
                                        {
                                            Console.WriteLine("\t\tDésolé, veuillez saisir une option valide.\n");
                                        }

                                    } while (nouveauPhysique != "MAIGRE" && nouveauPhysique != "SURPOIDS" && nouveauPhysique != "BONNE CONDITION");

                                    animalModifier.EtatPhysique = nouveauPhysique;
                                    Console.WriteLine("\tPhysique mis à jour avec succès.");
                                    break;

                                case "AGE":
                                    Console.WriteLine("\nVeuillez saisir le nouvel âge de l'animal :");

                                    if (int.TryParse(Console.ReadLine(), out int nouvelAge))
                                    {
                                        animalModifier.Age = nouvelAge;
                                        Console.WriteLine("\tÂge mis à jour avec succès.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("\tVeuillez saisir un nombre valide pour l'âge.");
                                    }
                                break;

                                case "SEXE":
                                    string? nouveauSexe;

                                    do
                                    {
                                        Console.WriteLine("\nVeuillez saisir le nouveau sexe de l'animal [Masculin] / [Feminin] : ");
                                        nouveauSexe = Console.ReadLine()?.ToUpper().Trim();

                                        if (nouveauSexe != "MASCULIN" && nouveauSexe != "FEMININ")
                                        {
                                            Console.WriteLine("\tDésolé, veuillez saisir une option valide.\n");
                                        }
                                    } while (nouveauSexe != "MASCULIN" && nouveauSexe != "FEMININ");
                                    animalModifier.Sexe = nouveauSexe;
                                    Console.WriteLine("\tSexe mis à jour avec succès.");
                                break;

                                case "COULEUR":
                                    Console.WriteLine("\nVeuillez saisir la nouvelle couleur de l'animal :");
                                    string? nouvelleCouleur = Console.ReadLine();
                                    animalModifier.Couleur = nouvelleCouleur;
                                    Console.WriteLine("\tCouleur mis à jour avec succès.");
                                break;

                                default:
                                    Console.WriteLine("\tSaisie invalide ...");
                                break;

                            }
                            Console.WriteLine("\n\nVoulez-Vous continuez à modifier la fiche d'un animal [OUI] / [NON]");
                            string? message = Console.ReadLine();
                            message = message?.ToUpper().Trim();

                            if (message == "NON")
                            {
                                ContinuerModifier = false;
                            }
                        }
                        
                        else
                        {
                            Console.WriteLine("\tVeuillez saisir une catégorie valide.");
                        }
                        
                        Console.WriteLine($"La fiche a été changer:\n\t\t--------------------------------------\n\t\t\tID - {animalModifier.ID}\n\t\t\tSurnom - {animalModifier.Surnom}\n\t\t\tEspece - {animalModifier.Espece}\n\t\t\tPhysique - {animalModifier.EtatPhysique}\n\t\t\tAge - {animalModifier.Age}\n\t\t\tSexe - {animalModifier.Sexe}\n\t\t\tCouleur - {animalModifier.Couleur}\n\t\t--------------------------------------");
                    }

                    else
                    {
                        Console.WriteLine("\tVeuillez saisir un nombre valide pour l'option.");
                    }

                }
            }

            else
            {
                Console.WriteLine("\tVeuillez saisir un identifant valide.");
            }

                
        } while (ContinuerModifier != false);
            
        
    }

    static void SupprimerUnAnimal(List<Animal> listeAnimaux)
    {
       bool fin = false;
       do
       {
           Console.WriteLine("Saisir le numéro d'identifiant de la fiche de l'animal à supprimer");
           if (int.TryParse(Console.ReadLine(), out int identifiant))
           {
               if (identifiant > 0 && identifiant <= listeAnimaux.Count)
               {
                   Animal animalSupprimer = listeAnimaux[identifiant - 1];
                   Console.WriteLine($"Vous avez sélectionné :\n\t\t--------------------------------------\n\t\t\tID - {animalSupprimer.ID}\n\t\t\tSurnom - {animalSupprimer.Surnom}\n\t\t\tEspece - {animalSupprimer.Espece}\n\t\t\tPhysique - {animalSupprimer.EtatPhysique}\n\t\t\tAge - {animalSupprimer.Age}\n\t\t\tSexe - {animalSupprimer.Sexe}\n\t\t\tCouleur - {animalSupprimer.Couleur}\n\t\t--------------------------------------");
                  
                   Console.WriteLine("Voulez-vous continuer ? [OUI] / [NON]");
                   string? message = Console.ReadLine()?.ToUpper().Trim();
                    
                   if (message == "OUI")
                   {
                        listeAnimaux.Remove(animalSupprimer);
                        Console.WriteLine("\tAnimal supprimé avec succès.");

                        Console.WriteLine("\n\nVoulez-Vous continuez à modifier la fiche d'un animal [OUI] / [NON]");
                        string? continuer = Console.ReadLine();
                        continuer = continuer?.ToUpper().Trim();
                        
                            if (continuer == "NON")
                            {
                                fin = true;
                            }
                   }
                   else if (message == "NON")
                   {
                       fin = true;
                   }
                   else
                   {
                       Console.WriteLine("Saisie invalide. Fin de l'opération.");
                       fin = true;
                   }
               }
               else
               {
                   Console.WriteLine("Identifiant invalide. Veuillez saisir un numéro d'identifiant valide.");
               }
            }
            else
            {
                Console.WriteLine("Saisie invalide. Veuillez saisir un numéro d'identifiant valide.");
            }
        } while (fin == false);

    }

}
