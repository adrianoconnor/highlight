using Highlight.Configuration;
using Highlight.Engines;
using Highlight.Tests.Engines.Resources;
using NUnit.Framework;

namespace Highlight.Tests.Engines
{
    [TestFixture]
    public class HtmlEngineTests
    {
        private IEngine htmlEngine, xmlEngine;
        private IConfiguration configuration;

        [SetUp]
        public void FixtureSetUp()
        {
            htmlEngine = new HtmlEngine();
            xmlEngine = new XmlEngine();

            configuration = new DefaultConfiguration();
        }

        [Test]
        public void Highlight_CsharpDefinitionAndCsharpInput_ReturnsExpectedOutput()
        {
            // Arrange
            var definition = configuration.Definitions["C#"];
            var input = InputOutput.CSharp_Sample1;
            var expectedOutout = InputOutput.CSharp_Sample1_HtmlOutput;

            // Act
            var output = htmlEngine.Highlight(definition, input);

            // Assert
            Assert.That(output, Is.EqualTo(expectedOutout));
        }

        [Test]
        public void Highlight_HtmlDefinitionAndXhtmlInput_ReturnsExpectedOutput()
        {
            // Arrange
            var definition = configuration.Definitions["HTML"];
            var input = InputOutput.Html_Sample1;
            var expectedOutput = InputOutput.Html_Sample1_HtmlOutput;

            // Act
            var output = htmlEngine.Highlight(definition, input);

            // Assert
            Assert.That(output, Is.EqualTo(expectedOutput));
        }

        [Test]
        public void Highlight_HtmlDefinitionAndHtmlInput_ReturnsExpectedOutput()
        {
            // Arrange
            var definition = configuration.Definitions["HTML"];
            var input = InputOutput.Html_Sample2;
            var expectedOutput = InputOutput.Html_Sample2_HtmlOutput;

            // Act
            var output = htmlEngine.Highlight(definition, input);

            // Assert
            Assert.That(output, Is.EqualTo(expectedOutput));
        }

        [Test]
        public void Highlight_EnsureSqlIsCaseInsensitive()
        {
            // Arrange
            var definition = configuration.Definitions["SQL"];
            var input = "select * from my_table;";
            var expectedOutout = "<highlightedInput><ReservedKeyword>select</ReservedKeyword> * <ReservedKeyword>from</ReservedKeyword> my_table;</highlightedInput>";

            // Act
            var output = xmlEngine.Highlight(definition, input);

            // Assert
            Assert.That(output, Is.EqualTo(expectedOutout));
        }

        [Test]
        public void Highlight_EnsureCsIsCaseSensitive()
        {
            // Arrange
            var definition = configuration.Definitions["C#"];
            var input = "VOID test;";
            var expectedOutout = "<highlightedInput>VOID test;</highlightedInput>";

            // Act
            var output = xmlEngine.Highlight(definition, input);

            // Assert
            Assert.That(output, Is.EqualTo(expectedOutout));
        }
    }
}