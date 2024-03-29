﻿namespace MaxMind.GeoIP.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using System.Text;

    using MaxMind.GeoIP;

    using NUnit.Framework;

    [TestFixture(Description = "Tests top level functionality of the MaxMind.GeoIP Assembly")]
    public class GeoIPTests
    {
        private LookupService service;

        [TestFixtureSetUp]
        public void Setup()
        {
            string dbPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            dbPath = dbPath.Remove(0, 6);
            dbPath = Path.Combine(dbPath, @"..\..\..\Test Data\GeoIP.dat");
            DirectoryInfo dirInfo = new DirectoryInfo(dbPath);
            service = new LookupService(dirInfo.FullName);
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            service.Dispose();
        }

        #region Tests

        [Test]
        public void GetLeedsCity()
        {
            // twentysix public IP
            IPAddress input = IPAddress.Parse("80.229.91.10");
            string expected = "GB";
            Country result = service.GetCountry(input);
            string code = result.Code;
            Assert.That(code, Is.EqualTo(expected));
        }

        [Test]
        public void GetGoogle()
        {
            // IP Address obtained by pinging google.com
            IPAddress input = IPAddress.Parse("66.102.9.147");
            string expected = "US";
            Country result = service.GetCountry(input);
            string code = result.Code;
            Assert.That(code, Is.EqualTo(expected));
        }

        #endregion

    }
}
