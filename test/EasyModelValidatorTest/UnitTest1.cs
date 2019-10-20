using System.ComponentModel.DataAnnotations;
using EasyModelValidator;
using NUnit.Framework;

namespace EasyModelValidatorTest
{
    [TestFixture]
    public class Tests
    {
        class Contact
        {
            [Required, RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                         @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                         @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                 ErrorMessage = "Email Format Error")]
            public string Email { get; set; }

            [Required] public string Name { get; set; }
        }

        [Test]
        public void Test1()
        {
            var myInstance = new Contact()
            {
                Email = "ali.asdasd",
                Name = "Ali"
            };

            var validationResult = myInstance.IsValid();
            if (!validationResult) Assert.Pass();
        }


        [Test]
        public void Test2()
        {
            var myInstance = new Contact()
            {
                Email = "alialp3.141@gmail.com"
            };

            var validationResult = myInstance.IsValid();
            Assert.IsFalse(validationResult);
        }

        [Test]
        public void Test3()
        {
            var myInstance = new Contact()
            {
                Email = "alialp3.141@gmail.com",
                Name = "Ali"
            };

            var validationResult = myInstance.IsValid();
            Assert.IsTrue(validationResult);
        }
    }
}