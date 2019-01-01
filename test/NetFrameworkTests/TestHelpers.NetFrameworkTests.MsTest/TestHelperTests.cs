﻿using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestHelpers.Net;

namespace TestHelpers.Net.NetFx.MsTest
{
    [TestClass]
    public class NetFxMsTestLutTests
    {
        readonly TestHelper _testHelper = new TestHelper();

        public NetFxMsTestLutTests()
        {
            _testHelper.Configuration.LogWriter = new DefaultTestLogWriter();
        }

        [TestMethod]
        public void CanOpenFile()
        {
            const string ExpectedContents = "Hello .NET Framework MSTest";
            string contents;
            using (StreamReader reader = _testHelper.OpenFile("test.txt"))
            {
                contents = reader.ReadToEnd();
            }

            Assert.AreEqual(ExpectedContents, contents);
        }


        [TestMethod]
        public void DetectMsTestFramework()
        {
            Assert.AreEqual(TestFrameworks.MsTest, _testHelper.TestFramework);
        }
    }
}