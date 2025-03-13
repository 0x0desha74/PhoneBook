using PhoneBook.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace  PhoneBook.Repository.Data
{
    public static class  ApplicationDbContextSeed
    {
        public async static Task SeedData(ApplicationDbContext context)
        {
            if (!context.Contacts.Any())
            {
                var contactData = File.ReadAllText("../PhoneBook.Repository/Data/DataSeed/contacts.json");
                var contacts = JsonSerializer.Deserialize<List<Contact>>(contactData);
                if(contacts.Count() >0 && contacts is not null)
                {
                    foreach (var contact in contacts)
                        await context.Contacts.AddAsync(contact);
                }
                await context.SaveChangesAsync();
            }

            if (!context.Addresses.Any())
            {
                var addressData = File.ReadAllText("../PhoneBook.Repository/Data/DataSeed/address.json");
                var addresses = JsonSerializer.Deserialize<List<Address>>(addressData);
                if (addresses.Count() > 0 && addresses is not null)
                {
                    foreach (var address in addresses)
                        await context.Addresses.AddAsync(address);
                }
                await context.SaveChangesAsync();
            }
        }
    }
}
