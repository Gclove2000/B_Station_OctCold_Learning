using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;

namespace WpfMvvmDemo.Models
{
    
    public class Person
    {
        public int Id { get; set; }
    
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public DateOnly BirthDay { get; set; }

        public static Person FakerOne => faker.Generate();

        public static IEnumerable<Person> FakerMany(int count)=>faker.Generate(count);

        private static readonly Faker<Person> faker = new Faker<Person>()
            .RuleFor(t=>t.Id,f=>f.IndexFaker)
            .RuleFor(t=>t.FirstName,f=>f.Name.FirstName())
            .RuleFor(t=>t.LastName,f=>f.Name.LastName())
            .RuleFor(t=>t.FullName,f=>f.Name.FullName())
            .RuleFor(t=>t.BirthDay,f=>f.Date.BetweenDateOnly(new DateOnly(1990,1,1),new DateOnly(2010,1,1)));
    }
}
