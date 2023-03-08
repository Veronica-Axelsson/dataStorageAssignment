using dataStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataStorage.Services
{
    //Skapa ärende/felanmälan som sparas
    //se alla ärenden.
    //se ett specifikt ärende. ------ kunna se ett ärende och se kommentarer kopplat till ärendet
    //Ärendestatus (Update)


    //Skapa/skriva kommentar av anställda



    //////Används till: ErrandTimeCreated, TimeEmployeeComment
    //var date2 = DateTime.Now;
    //Console.WriteLine(date2);



    internal class MenuService
    {

        public async Task CreateNewContactAsync()              //Skapa ny kontakt
        {
            var customer = new Errands();

            Console.WriteLine("Skapa ny kund. \n");

            Console.Write("Förnamn: ");
            customer.FirstName = Console.ReadLine() ?? "";

            Console.Write("Efternamn: ");
            customer.LastName = Console.ReadLine() ?? "";

            Console.Write("E-postadress: ");
            customer.Email = Console.ReadLine() ?? "";

            Console.Write("Telefonnummer: ");
            customer.CustomerPhoneNr = Console.ReadLine() ?? "";

            //Beskrivning av ärende

            //Skapas automatiskt --------------------
            //Tidpunkt ärendet skapas

            //status på själva ärendet


            //save customer to database
            await CustomerService.SaveAsync(customer);
        }

        public async Task CreateNewCommentAsync()              //Skapa ny kontakt
        {
            var errands = new Errands();

            // // Söka efter ett ärende
        
            //Kommentera ärendet
            Console.Write("Kommentera ärendet: ");
            errands.EmployeeComment = Console.ReadLine() ?? "";


            //Skapas automatiskt --------------------
            //Tidpunkt ärendet kommenteras


            //save erand to database
            await CustomerService.SaveAsync(errands);
        }

        public async Task ListAllContactsAsync()
        {
            //get all customers+address from database
            var errands = await CustomerService.GetAllAsync();

            Console.WriteLine("Visar alla kunder. \n");

            if (errands.Any())
            {

                foreach (Errands _errands in errands)
                {
                    Console.WriteLine($"Kundnummer: {_errands.Id}");
                    Console.WriteLine($"Namn: {_errands.FirstName} {_errands.LastName}");
                    Console.WriteLine($"E-postadress: {_errands.Email}");
                    Console.WriteLine($"Telefonnummer: {_errands.CustomerPhoneNr}");
           
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("Inga kunder finns i databasen.");
                Console.WriteLine("");
            }

        }            //Visa alla kontakter


        public async Task ListSpecificContactAsync()
        {
            Console.Write("Visa en specifik kund. Ange kunden e-postadress: ");
            var email = Console.ReadLine();

            if (!string.IsNullOrEmpty(email))
            {
                //get specific customer+address from database
                var customer = await CustomerService.GetAsync(email);

                if (customer != null)
                {
                    Console.WriteLine($"Kundnummer: {customer.Id}");
                    Console.WriteLine($"Namn: {customer.FirstName} {customer.LastName}");
                    Console.WriteLine($"E-postadress: {customer.Email}");
                    Console.WriteLine($"Telefonnummer: {customer.PhoneNumber}");
                    Console.WriteLine($"Address: {customer.StreetName}, {customer.PostalCode} {customer.City}");
                    Console.WriteLine("");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Ingen kund med den angivna e-postadressen {email} hittades.");
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine($"Ingen e-postadressen angiven.");
                Console.WriteLine("");
            }

        }        // Visa en specifik kontakt

        public async Task UpdateStatusAsync()
        {
            Console.Write("Uppdatera kund. Ange kundens e-postadress: ");
            var email = Console.ReadLine();

            if (!string.IsNullOrEmpty(email))
            {
                var customer = await CustomerService.GetAsync(email);
                if (customer != null)
                {
                    Console.WriteLine($"Uppdaterar kund: {customer.FirstName} {customer.LastName} \n");
                    Console.WriteLine("Skriv in information på de fält som du vill uppdatera. Annars tryck enter. \n");

                    Console.Write("Förnamn: ");
                    customer.FirstName = Console.ReadLine() ?? null!;

                    Console.Write("Efternamn: ");
                    customer.LastName = Console.ReadLine() ?? null!;

                    Console.Write("E-postadress: ");
                    customer.Email = Console.ReadLine() ?? null!;

                    Console.Write("Telefonnummer: ");
                    customer.PhoneNumber = Console.ReadLine() ?? null!;

                    Console.Write("Gatuadress: ");
                    customer.StreetName = Console.ReadLine() ?? null!;

                    Console.Write("Postnummer: ");
                    customer.PostalCode = Console.ReadLine() ?? null!;

                    Console.Write("Stad: ");
                    customer.City = Console.ReadLine() ?? null!;


                    //update specific customer from database
                    await CustomerService.UpdateAsync(customer);
                }
            }
            else
            {
                Console.WriteLine($"Hittade inte någon kund med den angivna e-postadressen.");
                Console.WriteLine("");
            }

        }      // Uppdatera en kontakt

        //public static async Task DeleteSpecificContactAsync()         // Ta bort en kontakt
        //{
        //    Console.Write("Ta bort kund. Ange kundens e-postadress. Om du vill avbryta. tryck enter.\n");
        //    var email = Console.ReadLine();

        //    if (!string.IsNullOrEmpty(email))
        //    {
        //        //delete specific customer from database
        //        await CustomerService.DeleteAsync(email);
        //    }
        //    else
        //    {
        //        Console.WriteLine($"Ingen e-postadressen angiven.");
        //        Console.WriteLine("");
        //    }

        //}
    }
}
