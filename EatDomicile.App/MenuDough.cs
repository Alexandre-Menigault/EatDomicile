using EatDomicile.Core.Dtos;
using EatDomicile.Core.Models;
using EatDomicile.Core.Services;
using EatDomicile.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatDomicile.App
{
    public class MenuDough
    {

        private DoughDTO _DoughDto { get; set; }
        public MenuDough()
        {

        }

        public void Run()
        {
            var input = 0;
            do
            {
                Console.WriteLine("Menu Dough");
                Console.WriteLine("Que voulez-vous faire ?");
                Console.WriteLine("1. Ajouter un Dough");
                Console.WriteLine("2. Lister les Doughs existant");
                Console.WriteLine("3. Mettre à jour un Dough");
                Console.WriteLine("4. Supprimer un Dough");
                Console.WriteLine("9. Quitter");

                input = int.Parse(Console.ReadLine()!);

                switch (input)
                {
                    case 1:
                        AjouterUnDough();
                        break;
                    case 2:
                        ListerTouts();
                        break;
                    case 3:
                        UpdateDough();
                        break;
                    case 4:
                        DeleteDough();
                        break;
                    default:
                        Console.WriteLine("Choix invalide");
                        break;
                }


            } while (input != 9);
        }

        private void AjouterUnDough()
        {
            DoughDTO Dough= new DoughDTO("DoughDeTests");
            Console.WriteLine("Ajouter");
            try
            {

                Dough.Name = ConsoleUtils.ReadLineString("Quel nom ? ");
                

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Retour au menu");
            }


            var DoughService = new DoughsService();

            var DoughAdded = DoughService.AddDough(DoughDTO.ToEntity(Dough));
            Console.WriteLine("Dough ajouté");
            Console.WriteLine(DoughAdded.AsString());
        }

        private void ListerTouts()
        {
            Console.WriteLine("Liste des Doughs");
            var doughService = new DoughsService();
            var doughs = doughService.GetAllDoughs();

            Console.WriteLine(doughs.AsString());
        }

        private void DeleteDough()
        {
            ListerTouts();
            var Id = ConsoleUtils.ReadLineString("Quel Id ? ");
            
            var doughService = new DoughsService();
            Dough doughToDelete = doughService.GetDough(int.Parse(Id));
            doughService.RemoveDough(doughToDelete);
            Console.WriteLine("Dough supprimé ");

        }

        private void UpdateDough()
        {

        }
    }
}
