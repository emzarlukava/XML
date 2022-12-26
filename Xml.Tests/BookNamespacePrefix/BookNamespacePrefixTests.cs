using System.Xml.Serialization;
using NUnit.Framework;

namespace Xml.Tests.BookNamespacePrefix
{
    [TestFixture]
    public class BookNamespacePrefixTests : XmlTestFixtureBase
    {
        private const string SourceFileName = "book-namespace-prefix.xml";
        private const string SchemaFileName = "BookNamespacePrefix.book-namespace-prefix.xsd";
        private const string NamespacePrefix = "co";

        private string content;
        private string schema;

        [SetUp]
        public void SetUp()
        {
            this.content = ReadContent(SourceFileName);
            this.schema = ReadSchema(SchemaFileName);
        }

        [Test]
        public void DeserializeAndTestContent()
        {
            Book book = Deserialize<Book>(this.content);

            Assert.NotNull(book);
            Assert.AreEqual("Pride And Prejudice", book.Title);
            Assert.AreEqual(1, book.Id);
        }

        [Test]
        public void ValidateSchema()
        {
            ValidateSchema(this.content, this.schema, TargetNamespaces.BookNamespace);
        }

        [Test]
        public void LoadXmlAndTestElementPrefixes()
        {
            this.LoadXmlAndTestElementPrefixes(this.content, NamespacePrefix);
        }

        [XmlRoot("book", Namespace = TargetNamespaces.BookNamespace)]
        public class Book
        {
            [XmlAttribute("id")]
            public int Id { get; set; }

            [XmlElement("title")]
            public string Title { get; set; }
        }
    }
}
