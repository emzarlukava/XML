using System.Collections.Generic;
using System.Xml.Serialization;
using NUnit.Framework;

namespace Xml.Tests.BookListPublicationDate
{
    [TestFixture]
    public class BookListPublicationDateTests : XmlTestFixtureBase
    {
        private const string SourceFileName = "book-list-publication-date.xml";
        private const string SchemaFileName = "BookListPublicationDate.book-list-publication-date.xsd";
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
            Assert.NotNull(book.PublicationDate);
            Assert.AreEqual(1823, book.PublicationDate.Year);
            Assert.AreEqual(01, book.PublicationDate.Month);
            Assert.AreEqual(28, book.PublicationDate.Day);

            book = bookList.Books[1];
            Assert.AreEqual("The Handmaid's Tale", book.Title);
            Assert.AreEqual(29.95, book.Price);
            Assert.AreEqual("novel", book.Genre);
            Assert.AreEqual("1-861002-30-1", book.Isbn);
            Assert.NotNull(book.PublicationDate);
            Assert.AreEqual(1985, book.PublicationDate.Year);
            Assert.AreEqual(01, book.PublicationDate.Month);
            Assert.AreEqual(01, book.PublicationDate.Day);

            book = bookList.Books[2];
            Assert.AreEqual("Sense and Sensibility", book.Title);
            Assert.AreEqual(19.95, book.Price);
            Assert.AreEqual("novel", book.Genre);
            Assert.AreEqual("1-861001-45-3", book.Isbn);
            Assert.NotNull(book.PublicationDate);
            Assert.AreEqual(1811, book.PublicationDate.Year);
            Assert.AreEqual(01, book.PublicationDate.Month);
            Assert.AreEqual(01, book.PublicationDate.Day);
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
            [XmlElement("title")]
            public string Title { get; set; }

            [XmlElement("price")]
            public decimal Price { get; set; }

            [XmlElement("genre")]
            public string Genre { get; set; }

            [XmlElement("isbn")]
            public string Isbn { get; set; }

            [XmlElement("publicationDate")]
            public PublicationDate PublicationDate { get; set; }
        }

        public class PublicationDate
        {
            [XmlElement("publicationYear")]
            public int Year { get; set; }

            [XmlElement("publicationMonth")]
            public int Month { get; set; }

            [XmlElement("publicationDay")]
            public int Day { get; set; }
        }
    }
}
