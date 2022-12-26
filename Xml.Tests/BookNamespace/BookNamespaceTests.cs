using System.Xml.Serialization;
using NUnit.Framework;

namespace Xml.Tests.BookNamespace
{
    [TestFixture]
    public class BookNamespaceTests : XmlTestFixtureBase
    {
        private const string SourceFileName = "book-namespace.xml";
        private const string SchemaFileName = "BookNamespace.book-namespace.xsd";

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
        }

        [Test]
        public void ValidateSchema()
        {
            ValidateSchema(this.content, this.schema, TargetNamespaces.BookNamespace);
        }

        [XmlRoot("book", Namespace = TargetNamespaces.BookNamespace)]
        public class Book
        {
            [XmlElement("title")]
            public string Title { get; set; }
        }
    }
}
