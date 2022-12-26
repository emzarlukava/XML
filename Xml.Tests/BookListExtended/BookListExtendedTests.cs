using System.Collections.Generic;
using System.Xml.Serialization;
using NUnit.Framework;

namespace Xml.Tests.BookListExtended
{
    [TestFixture]
    public class BookListExtendedTests : XmlTestFixtureBase
    {
        private const string SourceFileName = "book-list-extended.xml";
        private const string SchemaFileName = "BookListExtended.book-list-extended.xsd";
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
            Assert.AreEqual(1, book.Id);
            Assert.AreEqual("Jane Austen", book.Author);
            Assert.AreEqual("United Kingdom", book.Country);
            Assert.AreEqual("Pride And Prejudice", book.Title);
            Assert.AreEqual("English", book.Language);
            Assert.AreEqual(24.95, book.Price);
            Assert.AreEqual("novel", book.Genre);
            Assert.AreEqual("1-861001-57-8", book.Isbn);
            Assert.AreEqual("1823-01-28", book.PublicationDate);

            book = bookList.Books[1];
            Assert.AreEqual(2, book.Id);
            Assert.AreEqual("Margaret Atwood", book.Author);
            Assert.AreEqual("Canada", book.Country);
            Assert.AreEqual("The Handmaid's Tale", book.Title);
            Assert.AreEqual("English", book.Language);
            Assert.AreEqual(29.95, book.Price);
            Assert.AreEqual("novel", book.Genre);
            Assert.AreEqual("1-861002-30-1", book.Isbn);
            Assert.AreEqual("1985-01-01", book.PublicationDate);

            book = bookList.Books[2];
            Assert.AreEqual(3, book.Id);
            Assert.AreEqual("Jane Austen", book.Author);
            Assert.AreEqual("United Kingdom", book.Country);
            Assert.AreEqual("Sense and Sensibility", book.Title);
            Assert.AreEqual("English", book.Language);
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
            [XmlAttribute("id")]
            public int Id { get; set; }

            [XmlElement("author")]
            public string Author { get; set; }

            [XmlElement("country")]
            public string Country { get; set; }

            [XmlElement("title")]
            public string Title { get; set; }

            [XmlElement("language")]
            public string Language { get; set; }

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
