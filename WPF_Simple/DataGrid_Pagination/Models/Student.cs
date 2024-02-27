using Bogus;
using DataGrid_Pagination.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGrid_Pagination.Models
{
    public class Student : FakerIService<Student>
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public int Grade { get; set; }

        public DateOnly BirthDay { get; set; }
        public string PhoneNo { get; set; }


        private Faker<Student> faker = new Faker<Student>("zh_CN")
            .RuleFor(t => t.Id, f => f.IndexFaker)
            .RuleFor(t => t.Name, f => f.Name.FullName())
            .RuleFor(t => t.Grade, f => f.Random.Int(30, 100))
            .RuleFor(t => t.BirthDay, f => f.Date.BetweenDateOnly(new DateOnly(1990, 1, 1), new DateOnly(2010, 1, 1)))
            .RuleFor(t => t.PhoneNo, f => f.Phone.PhoneNumberFormat());

        public IEnumerable<Student> FakeMany(int count)
        {
            return faker.Generate(count);
        }

        public Student FakeOne()
        {
            return faker.Generate();
        }
    }
}
