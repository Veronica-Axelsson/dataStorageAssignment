using dataStorage.Models;
using System.Text;

namespace dataStorage.Services
{
    internal class MenuService
    {
        public async Task CreateNewErrandAsync()
        {
            var errands = new Errands();

            Console.WriteLine("Skapa ett nytt ärende. \n");

            Console.Write("Förnamn: ");
            errands.FirstName = Console.ReadLine() ?? "";

            Console.Write("Efternamn: ");
            errands.LastName = Console.ReadLine() ?? "";

            Console.Write("E-postadress: ");
            errands.Email = Console.ReadLine() ?? "";

            Console.Write("Telefonnummer: ");
            errands.CustomerPhoneNr = Console.ReadLine() ?? "";

            Console.Write("Beskrivning av ärendet: ");
            errands.CustomerDescription = Console.ReadLine() ?? "";

            //Creates automatic --------------------
            //Time errand created
            errands.ErrandTimeCreated = DateTime.Now;

            //The status of the errand
            //Console.Write("Beskrivning av status: ");
            //errands.Status = Console.ReadLine() ?? "";
            //var textstatus = "Ej påbörjad";
            //errands.Status = "Ej påbörjad";


            //Console.Write("Beskrivning av status: ");
            errands.Status = "Ej påbörjad.";


            //Save errand to database
            await CustomerService.SaveAsync(errands);
        }

        public async Task ListAllErrandsAsync()
        {
            //get all errands from database
            var errands = await CustomerService.GetAllAsync();

            Console.WriteLine("Visar alla ärenden. \n");

            if (errands.Any())
            {
                foreach (Errands _errand in errands)
                {
                    Console.WriteLine($"Ärendenummer: {_errand.Id}");
                    Console.WriteLine($"Namn: {_errand.FirstName} {_errand.LastName}");
                    Console.WriteLine($"E-postadress: {_errand.Email}");

                    if (_errand.CustomerPhoneNr == null)
                    {
                        Console.WriteLine("Telefonnummer hittades inte");
                    }
                    else
                        Console.WriteLine($"Telefonnummer: {_errand.CustomerPhoneNr}");

                    Console.WriteLine($"Ärende datum: {_errand.ErrandTimeCreated}");
                    Console.WriteLine($"Beskrivning av ärendet: : {_errand.CustomerDescription}");

                    if (_errand.Status == null)
                    {
                        Console.WriteLine("Ärende status hittades inte");
                    }
                    else
                        Console.WriteLine($"Ärende status: {_errand.Status}");
                        Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("Inga ärenden finns i databasen.");
                Console.WriteLine("");
            }
        }

        public async Task ListSpecificErrandAsync()
        {
            Console.Write("Visa en specifik ärende. Ange ärendets id: ");
            var tempId = Console.ReadLine();

            if (tempId != null)
            {
                Guid newGuid = Guid.Parse(input: tempId);

                if (!string.IsNullOrEmpty(newGuid.ToString()))
                {
                    //get specific customer+address from database
                    var _errand = await CustomerService.GetAsync(newGuid);

                    if (_errand != null)
                    {
                        Console.WriteLine($"Ärendenummer: {_errand.Id}");
                        Console.WriteLine($"Namn: {_errand.FirstName} {_errand.LastName}");
                        Console.WriteLine($"E-postadress: {_errand.Email}");
                        Console.WriteLine($"Telefonnummer: {_errand.CustomerPhoneNr}");
                        Console.WriteLine($"Ärende datum: {_errand.ErrandTimeCreated}");
                        Console.WriteLine($"Beskrivning av ärendet: : {_errand.CustomerDescription}");
                        Console.WriteLine($"Ärende status: {_errand.Status}");
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"Ingen ärende med den angivna id {tempId} hittades.");
                        Console.WriteLine("");
                    }
                }
                else
                {
                    Console.WriteLine($"Ingen ärende id angiven.");
                    Console.WriteLine("");
                }
            }
            else 
            { 
                Console.WriteLine("Inget"); 
            }

        }

        public async Task UpdateStatusAsync()
        {
            Console.Write("Uppdatera ett ärende status. Skriv ärendets id: ");
            var tempId = Console.ReadLine();

            if (tempId != null)
            {
                Guid newGuid = Guid.Parse(input: tempId);

                if (!string.IsNullOrEmpty(newGuid.ToString()))
                {
                    var _errands = await CustomerService.GetAsync(newGuid);
                    if (_errands != null)
                    {
                        Console.WriteLine($"Uppdaterar ärende: {_errands.Id}  \n");

                        Console.WriteLine("Skriv något av följande: Ej påbörjad, Pågående, Avslutad. Annars tryck enter. \n");
                        _errands.Status = Console.ReadLine() ?? null!;

                        //update specific errand to database
                        await CustomerService.UpdateAsync(_errands);
                    }
                    else
                    {
                        Console.WriteLine($"Hittade inte någon kund med angivna id.");
                        Console.WriteLine("");
                    }

                }
                else
                {
                    Console.WriteLine($"Ingen id angiven.");
                    Console.WriteLine("");
                }
            }

        }

    }
}
