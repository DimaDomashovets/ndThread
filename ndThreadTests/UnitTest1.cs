using NUnit.Framework;
using RestClientD;
using RestSharp;

namespace ndThreadTests
{
    public class Tests
    {
        Class1 class1;
        
        [SetUp]
        public void Setup()
        {
           class1 = new Class1("https://qa01.threadkm.com");
        }

        [Test]
        public void CreateStichD()
        {
            class1.CreateStich("14199");

        }

        [Test]
        public void CreateThreadByAdmin()
        {
            class1.CreateThreadByAdm();


        }

        [Test]
        public void CreateThreadByInternalUser()
        {
            class1.CreateThreadByInternUser("354");
        }

        [Test]
        public void CreateThreadByExternalUser()
        {
           JsonNet ad=class1.CreateThreadByExternUser("354");
           Assert.IsTrue(ad.error.Contains("403"));
        }

    }
}