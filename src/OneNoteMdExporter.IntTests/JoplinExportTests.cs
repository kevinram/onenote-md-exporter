using a.onexport.IntTests.Helpers;
using NUnit.Framework;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace a.onexport.IntTests
{
    public class JoplinExportTests : ExportTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public override void Image_SimpleImage()
        {
            var res = TestHelper.RunExporter("2", "TestBloc", "Image", "Simple image");

            throw new NotImplementedException();
        }
    }
}