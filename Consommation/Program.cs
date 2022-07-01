using DAL.Entities;
using DAL.Services;
using System.Collections.Generic;


#region CategorieTest

//CategorieService categorieService = new CategorieService();
//IEnumerable<Categorie> lesCategorie;

//lesCategorie = categorieService.GetAll();
//foreach (Categorie categorie in lesCategorie)
//{
//    Console.WriteLine($"Id : {categorie.Id} - Nom : {categorie.Nom}");
//}

//Categorie categorieRecup = categorieService.GetId(5);
//Console.WriteLine($"{categorieRecup.Id} - {categorieRecup.Nom}");

//Categorie categorieAAjouter = new Categorie()
//{
//    Nom = "Aller aux toilettes"
//};
//categorieService.AddCategorie(categorieAAjouter);

//lesCategorie = categorieService.GetAll();
//foreach (Categorie categorie in lesCategorie)
//{
//    Console.WriteLine($"Id : {categorie.Id} - Nom : {categorie.Nom}");
//}

//Console.WriteLine(categorieService.DeleteCategorie(9) + " ligne(s) supprimée(s)");

//lesCategorie = categorieService.GetAll();
//foreach (Categorie categorie in lesCategorie)
//{
//    Console.WriteLine($"Id : {categorie.Id} - Nom : {categorie.Nom}");
//} 

#endregion

#region PersonneTest

//PersonneService personneService = new PersonneService();
//IEnumerable<Personne> lesPersonne;

//lesPersonne = personneService.GetAll();
//foreach (Personne personne in lesPersonne)
//{
//    Console.WriteLine($"Id : {personne.Id} - Nom : {personne.Nom} - Prenom : {personne.Prenom}");
//}

//Personne personneRecup = personneService.GetId(5);
//Console.WriteLine($"{personneRecup.Id} - {personneRecup.Nom} - {personneRecup.Prenom}");

//Personne personneAAjouter = new Personne()
//{
//    Nom = "Père",
//    Prenom = "Fouras"
//};
//personneService.AddPersonne(personneAAjouter);

//lesPersonne = personneService.GetAll();
//foreach (Personne personne in lesPersonne)
//{
//    Console.WriteLine($"Id : {personne.Id} - Nom : {personne.Nom} - Prenom : {personne.Prenom}");
//}

//Personne pere = personneService.GetId(24);
//Console.WriteLine($"{pere.Id} - {pere.Nom} {pere.Prenom}");

//pere.Nom = "Mere";
//pere.Prenom = "Fougas";
//personneService.UpdatePersonne(pere);

//lesPersonne = personneService.GetAll();
//foreach (Personne personne in lesPersonne)
//{
//    Console.WriteLine($"Id : {personne.Id} - Nom : {personne.Nom} - Prenom : {personne.Prenom}");
//}

//Console.WriteLine(personneService.DeletePersonne(24) + " ligne(s) supprimée(s)");

//lesPersonne = personneService.GetAll();
//foreach (Personne personne in lesPersonne)
//{
//    Console.WriteLine($"Id : {personne.Id} - Nom : {personne.Nom} - Prenom : {personne.Prenom}");
//}

#endregion

#region TacheTest
//TacheService TacheService = new TacheService();
//IEnumerable<Tache> lesTache;

//lesTache = TacheService.GetAll();
//foreach (Tache tache in lesTache)
//{
//    Console.WriteLine
//        ($"Id : {tache.Id} - " +
//        $"Nom : {tache.Nom} - " +
//        $"Categorie : {tache.Categorie} - " +
//        $"Description : {tache.Description} - " +
//        $"DateCreation : {tache.DateCreation} - " +
//        $"DateFinPrevu : {tache.DateFinPrevu}) - " +
//        $"DateFinReel : {tache.DateFinReel}) - " +
//        $"PersonneAssignee : {tache.PersonneAssignee}"); 
//}

//Tache TacheRecup = TacheService.GetId(5);
//Console.WriteLine($"{TacheRecup.Id} - " +
//    $"{TacheRecup.Nom} - " +
//    $"{TacheRecup.Categorie} - " +
//    $"{TacheRecup.Description} - " +
//    $"{TacheRecup.DateCreation} - " +
//    $"{TacheRecup.DateFinPrevu} - " +
//    $"{TacheRecup.DateFinReel} - " +
//    $"{TacheRecup.PersonneAssignee}");

//Tache TacheAAjouter = new Tache()
//{
//    Nom = "Test",
//    Categorie = 1,
//    Description = "Description pour la tache test",
//    DateCreation = DateTime.Now,
//    DateFinPrevu = new DateTime(2022, 07, 02),
//    PersonneAssignee = 1
//};
//TacheService.AddTache(TacheAAjouter);

//lesTache = TacheService.GetAll();
//foreach (Tache tache in lesTache)
//{
//    Console.WriteLine
//        ($"Id : {tache.Id} - " +
//        $"Nom : {tache.Nom} - " +
//        $"Categorie : {tache.Categorie} - " +
//        $"Description : {tache.Description} - " +
//        $"DateCreation : {tache.DateCreation} - " +
//        $"DateFinPrevu : {tache.DateFinPrevu}) - " +
//        $"DateFinReel : {tache.DateFinReel}) - " +
//        $"PersonneAssignee : {tache.PersonneAssignee}");
//}

//Tache tachechercher = TacheService.GetId(10);
//Console.WriteLine($"{tachechercher.Id} - {tachechercher.Nom} {tachechercher.Description}");

//tachechercher.Nom = "Test2";
//tachechercher.Description = "Nouvelle Description Test";
//TacheService.UpdateTache(tachechercher);

//lesTache = TacheService.GetAll();
//foreach (Tache tache in lesTache)
//{
//    Console.WriteLine
//        ($"Id : {tache.Id} - " +
//        $"Nom : {tache.Nom} - " +
//        $"Categorie : {tache.Categorie} - " +
//        $"Description : {tache.Description} - " +
//        $"DateCreation : {tache.DateCreation} - " +
//        $"DateFinPrevu : {tache.DateFinPrevu}) - " +
//        $"DateFinReel : {tache.DateFinReel}) - " +
//        $"PersonneAssignee : {tache.PersonneAssignee}");
//}
//Console.WriteLine(TacheService.DeleteTache(11) + " ligne(s) supprimée(s)");
//lesTache = TacheService.GetAll();
//foreach (Tache tache in lesTache)
//{
//    Console.WriteLine
//        ($"Id : {tache.Id} - " +
//        $"Nom : {tache.Nom} - " +
//        $"Categorie : {tache.Categorie} - " +
//        $"Description : {tache.Description} - " +
//        $"DateCreation : {tache.DateCreation} - " +
//        $"DateFinPrevu : {tache.DateFinPrevu}) - " +
//        $"DateFinReel : {tache.DateFinReel}) - " +
//        $"PersonneAssignee : {tache.PersonneAssignee}");
//}
#endregion

TacheService TacheService = new TacheService();
IEnumerable<Tache> lesTache;

lesTache = TacheService.GetbyCategorie(1);

foreach (Tache tache in lesTache)
{
    Console.WriteLine
        ($"Id : {tache.Id} - " +
        $"Nom : {tache.Nom} - " +
        $"Categorie : {tache.Categorie} - " +
        $"Description : {tache.Description} - " +
        $"DateCreation : {tache.DateCreation} - " +
        $"DateFinPrevu : {tache.DateFinPrevu}) - " +
        $"DateFinReel : {tache.DateFinReel}) - " +
        $"PersonneAssignee : {tache.PersonneAssignee}");
}

lesTache = TacheService.GetbyPersonne(1);

foreach (Tache tache in lesTache)
{
    Console.WriteLine
        ($"Id : {tache.Id} - " +
        $"Nom : {tache.Nom} - " +
        $"Categorie : {tache.Categorie} - " +
        $"Description : {tache.Description} - " +
        $"DateCreation : {tache.DateCreation} - " +
        $"DateFinPrevu : {tache.DateFinPrevu}) - " +
        $"DateFinReel : {tache.DateFinReel}) - " +
        $"PersonneAssignee : {tache.PersonneAssignee}");
}

lesTache = TacheService.GetbyTacheNonFini();

foreach (Tache tache in lesTache)
{
    Console.WriteLine
        ($"Id : {tache.Id} - " +
        $"Nom : {tache.Nom} - " +
        $"Categorie : {tache.Categorie} - " +
        $"Description : {tache.Description} - " +
        $"DateCreation : {tache.DateCreation} - " +
        $"DateFinPrevu : {tache.DateFinPrevu}) - " +
        $"DateFinReel : {tache.DateFinReel}) - " +
        $"PersonneAssignee : {tache.PersonneAssignee}");
}