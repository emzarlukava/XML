using System.Xml.Serialization;
using NUnit.Framework;

namespace Xml.Tests.BookElements
{
    [TestFixture]
    public class BookElementsTests : XmlTestFixtureBase
    {
        private const string SourceFileName = "book-elements.xml";
        private const string SchemaFileName = "BookElements.book-elements.xsd";

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
            Assert.AreEqual(24.95, book.Price);
            Assert.AreEqual("novel", book.Genre);
            Assert.AreEqual("1-861001-57-8", book.Isbn);
            Assert.AreEqual("1823-01-28", book.PublicationDate);
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

            [XmlElement("price")]
            public decimal Price { get; set; }

            [XmlElement("genre")]
            public string Genre { get; set; }

            [XmlElement("isbn")]
            public string Isbn { get; set; }

            [XmlElement("publicationDate")]
            public string PublicationDate { get; set; }
        }
    }
}
