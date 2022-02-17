using HCAChallenge.Models;
using System;
using System.Linq;


namespace HCAChallenge.Data
{ 
    public class DbInitializer
    {
        public static void Initialize(SportContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.SportsFans.Any())
            {
                return;   // DB has been seeded
            }

            var sportsFans = new SportFan[]
            {
                new SportFan{FirstMidName="Chris",LastName="Klimkiewicz",Birthdate=DateTime.Parse("1978-12-12"),Sport="Basketball"},

            };
            foreach (SportFan s in sportsFans)
            {
                context.SportsFans.Add(s);
            }
            context.SaveChanges();


        
        }
    }
}