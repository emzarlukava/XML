using System.Collections.Generic;
using System.Xml.Serialization;
using NUnit.Framework;

namespace Xml.Tests.BookListGenres
{
    [TestFixture]
    public class BookListGenresTests : XmlTestFixtureBase
    {
        private const string SourceFileName = "book-list-genres.xml";
        private const string SchemaFileName = "BookListGenres.book-list-genres.xsd";
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
            Assert.AreEqual(2, book.Genres.Count);
            Assert.AreEqual("Classic Regency novel", book.Genres[0]);
            Assert.AreEqual("Romance novel", book.Genres[1]);
            Assert.AreEqual("1-861001-57-8", book.Isbn);
            Assert.AreEqual("1823-01-28", book.PublicationDate);

            book = bookList.Books[1];
            Assert.AreEqual("The Handmaid's Tale", book.Title);
            Assert.AreEqual(29.95, book.Price);
            Assert.AreEqual(3, book.Genres.Count);
            Assert.AreEqual("Dystopian novel", book.Genres[0]);
            Assert.AreEqual("Speculative fiction", book.Genres[1]);
            Assert.AreEqual("Tragedy", book.Genres[2]);
            Assert.AreEqual("1-861002-30-1", book.Isbn);
            Assert.AreEqual("1985-01-01", book.PublicationDate);

            book = bookList.Books[2];
            Assert.AreEqual("Sense and Sensibility", book.Title);
            Assert.AreEqual(19.95, book.Price);
            Assert.AreEqual(1, book.Genres.Count);
            Assert.AreEqual("Romance novel", book.Genres[0]);
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
            [XmlElement("title")]
            public string Title { get; set; }

            [XmlElement("price")]
            public decimal Price { get; set; }

            [XmlArray("genres")]
            [XmlArrayItem("genre")]
            public List<string> Genres { get; } = new ();

            [XmlElement("isbn")]
            public string Isbn { get; set; }

            [XmlElement("publicationDate")]
            public string PublicationDate { get; set; }
        }
    }
}
