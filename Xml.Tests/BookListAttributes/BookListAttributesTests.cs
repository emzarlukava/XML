using System.Collections.Generic;
using System.Xml.Serialization;
using NUnit.Framework;

namespace Xml.Tests.BookListAttributes
{
    [TestFixture]
    public class BookListAttributesTests : XmlTestFixtureBase
    {
        private const string SourceFileName = "book-list-attributes.xml";
        private const string SchemaFileName = "BookListAttributes.book-list-attributes.xsd";
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
            BookList bookList = Deserialize<BookList>(this.content);

            Assert.NotNull(bookList);
            Assert.NotNull(bookList.Books);
            Assert.AreEqual(3, bookList.Books.Count);

            var book = bookList.Books[0];
            Assert.AreEqual("Pride And Prejudice", book.Title);
            Assert.AreEqual(24.95, book.Price);
            Assert.AreEqual("novel", book.Genre);
            Assert.AreEqual("1-861001-57-8", book.Isbn);
            Assert.AreEqual("1823-01-28", book.PublicationDate);

            book = bookList.Books[1];
            Assert.AreEqual("The Handmaid's Tale", book.Title);
            Assert.AreEqual(29.95, book.Price);
            Assert.AreEqual("novel", book.Genre);
            Assert.AreEqual("1-861002-30-1", book.Isbn);
            Assert.AreEqual("1985-01-01", book.PublicationDate);

            book = bookList.Books[2];
            Assert.AreEqual("Sense and Sensibility", book.Title);
            Assert.AreEqual(19.95, book.Price);
            Assert.AreEqual("novel", book.Genre);
            Assert.AreEqual("1-861001-45-3", book.Isbn);
            Assert.AreEqual("1811-01-01", book.PublicationDate);
        }

        [Test]
        public void ValidateSchema()
        {
            ValidateSchema(this.content, this.schema, TargetNamespaces.BooksNamespace);
        }

        [Test]
        public void LoadXmlAndTestElementPrefixes()
        {
            this.LoadXmlAndTestElementPrefixes(this.content, NamespacePrefix);
        }

        [XmlRoot("books", Namespace = TargetNamespaces.BooksNamespace)]
        public class BookList
        {
            [XmlElement("book")]
            public List<Book> Books { get; } = new List<Book>();
        }

        public class Book
        {
            [XmlAttribute("title")]
            public string Title { get; set; }

            [XmlAttribute("price")]
            public decimal Price { get; set; }

            [XmlAttribute("genre")]
            public string Genre { get; set; }

            [XmlAttribute("isbn")]
            public string Isbn { get; set; }

            [XmlAttribute("publicationDate")]
            public string PublicationDate { get; set; }
        }
    }
}
