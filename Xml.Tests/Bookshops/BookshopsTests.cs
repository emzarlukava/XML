using System.Collections.Generic;
using System.Xml.Serialization;
using NUnit.Framework;

namespace Xml.Tests.Bookshops
{
    [TestFixture]
    public class BookshopsTests : XmlTestFixtureBase
    {
        private const string SourceFileName = "bookshops.xml";
        private const string SchemaFileName = "Bookshops.bookshops.xsd";
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
            BookshopList bookshopList = Deserialize<BookshopList>(this.content);

            Assert.NotNull(bookshopList);
            Assert.NotNull(bookshopList.Bookshops);
            Assert.AreEqual(3, bookshopList.Bookshops.Count);

            var bookshop = bookshopList.Bookshops[0];
            Assert.AreEqual(1, bookshop.Id);
            Assert.AreEqual("Amazon", bookshop.Name);
            Assert.AreEqual("https://amazon.com", bookshop.Website);
            Assert.NotNull(bookshop.Books);
            Assert.AreEqual(2, bookshop.Books.Count);

            var book = bookshop.Books[0];
            Assert.AreEqual(1, book.Id);
            Assert.NotNull(book.Authors);
            Assert.AreEqual(1, book.Authors.Count);
            Assert.AreEqual("Alexandre Dumas", book.Authors[0]);
            Assert.AreEqual("The Three Musketeers", book.Title);
            Assert.NotNull(book.Genres);
            Assert.AreEqual(3, book.Genres.Count);
            Assert.AreEqual("Historical novel", book.Genres[0]);
            Assert.AreEqual("Adventure novel", book.Genres[1]);
            Assert.AreEqual("Swashbuckler", book.Genres[2]);
            Assert.NotNull(book.Categories);
            Assert.AreEqual(2, book.Categories.Count);
            Assert.AreEqual("Action", book.Categories[0]);
            Assert.AreEqual("Adventure", book.Categories[1]);
            Assert.NotNull(book.Price);
            Assert.AreEqual(11.13M, book.Price.Value);
            Assert.AreEqual("USD", book.Price.Currency);
            Assert.AreEqual("English", book.Language);

            book = bookshop.Books[1];
            Assert.AreEqual(2, book.Id);
            Assert.NotNull(book.Authors);
            Assert.AreEqual(2, book.Authors.Count);
            Assert.AreEqual("Terry Pratchett", book.Authors[0]);
            Assert.AreEqual("Neil Gaiman", book.Authors[1]);
            Assert.AreEqual("The Illustrated Good Omens", book.Title);
            Assert.NotNull(book.Genres);
            Assert.AreEqual(2, book.Genres.Count);
            Assert.AreEqual("Fantasy novel", book.Genres[0]);
            Assert.AreEqual("Comedy novel", book.Genres[1]);
            Assert.NotNull(book.Categories);
            Assert.AreEqual(2, book.Categories.Count);
            Assert.AreEqual("Fantasy", book.Categories[0]);
            Assert.AreEqual("Science and Religion", book.Categories[1]);
            Assert.NotNull(book.Price);
            Assert.AreEqual(39.39M, book.Price.Value);
            Assert.NotNull("USD", book.Price.Currency);
            Assert.AreEqual("English", book.Language);

            bookshop = bookshopList.Bookshops[1];
            Assert.AreEqual(2, bookshop.Id);
            Assert.AreEqual("1000 livres et vous", bookshop.Name);
            Assert.AreEqual("https://1000livresetvous.com/", bookshop.Website);
            Assert.NotNull(bookshop.Books);
            Assert.AreEqual(2, bookshop.Books.Count);

            book = bookshop.Books[0];
            Assert.AreEqual(1, book.Id);
            Assert.NotNull(book.Authors);
            Assert.AreEqual(1, book.Authors.Count);
            Assert.AreEqual("Alexandre Dumas", book.Authors[0]);
            Assert.AreEqual("Les Trois Mousquetaires", book.Title);
            Assert.NotNull(book.Genres);
            Assert.AreEqual(3, book.Genres.Count);
            Assert.AreEqual("Historical novel", book.Genres[0]);
            Assert.AreEqual("Adventure novel", book.Genres[1]);
            Assert.AreEqual("Swashbuckler", book.Genres[2]);
            Assert.NotNull(book.Categories);
            Assert.AreEqual(2, book.Categories.Count);
            Assert.AreEqual("Fiction", book.Categories[0]);
            Assert.AreEqual("Littérature d'aventure", book.Categories[1]);
            Assert.NotNull(book.Price);
            Assert.AreEqual(16M, book.Price.Value);
            Assert.AreEqual("EUR", book.Price.Currency);
            Assert.AreEqual("French", book.Language);

            book = bookshop.Books[1];
            Assert.AreEqual(2, book.Id);
            Assert.NotNull(book.Authors);
            Assert.AreEqual(1, book.Authors.Count);
            Assert.AreEqual("Arthur Conan Doyle", book.Authors[0]);
            Assert.AreEqual("Une étude en rouge", book.Title);
            Assert.NotNull(book.Genres);
            Assert.AreEqual(2, book.Genres.Count);
            Assert.AreEqual("Detective fiction", book.Genres[0]);
            Assert.AreEqual("Short stories", book.Genres[1]);
            Assert.NotNull(book.Categories);
            Assert.AreEqual(3, book.Categories.Count);
            Assert.AreEqual("Fiction", book.Categories[0]);
            Assert.AreEqual("Littérature d'aventure", book.Categories[1]);
            Assert.AreEqual("Détective", book.Categories[2]);
            Assert.NotNull(book.Price);
            Assert.AreEqual(36M, book.Price.Value);
            Assert.AreEqual("EUR", book.Price.Currency);
            Assert.AreEqual("French", book.Language);

            bookshop = bookshopList.Bookshops[2];
            Assert.AreEqual(3, bookshop.Id);
            Assert.AreEqual("Oz", bookshop.Name);
            Assert.AreEqual("https://oz.by", bookshop.Website);
            Assert.NotNull(bookshop.Books);
            Assert.AreEqual(2, bookshop.Books.Count);

            book = bookshop.Books[0];
            Assert.AreEqual(2, book.Id);
            Assert.NotNull(book.Authors);
            Assert.AreEqual(1, book.Authors.Count);
            Assert.AreEqual("Александр Дюма", book.Authors[0]);
            Assert.AreEqual("Три мушкетера", book.Title);
            Assert.NotNull(book.Genres);
            Assert.AreEqual(3, book.Genres.Count);
            Assert.AreEqual("Historical novel", book.Genres[0]);
            Assert.AreEqual("Adventure novel", book.Genres[1]);
            Assert.AreEqual("Swashbuckler", book.Genres[2]);
            Assert.NotNull(book.Categories);
            Assert.AreEqual(3, book.Categories.Count);
            Assert.AreEqual("Художественная литература", book.Categories[0]);
            Assert.AreEqual("Классическая литература", book.Categories[1]);
            Assert.AreEqual("Зарубежная литература", book.Categories[2]);
            Assert.NotNull(book.Price);
            Assert.AreEqual(34.68M, book.Price.Value);
            Assert.AreEqual("BYN", book.Price.Currency);
            Assert.AreEqual("Русский", book.Language);

            book = bookshop.Books[1];
            Assert.AreEqual(1, book.Id);
            Assert.NotNull(book.Authors);
            Assert.AreEqual(1, book.Authors.Count);
            Assert.AreEqual("Arthur Conan Doyle", book.Authors[0]);
            Assert.AreEqual("The Adventures of Sherlock Holmes", book.Title);
            Assert.NotNull(book.Genres);
            Assert.AreEqual(2, book.Genres.Count);
            Assert.AreEqual("Detective fiction", book.Genres[0]);
            Assert.AreEqual("Short stories", book.Genres[1]);
            Assert.NotNull(book.Categories);
            Assert.AreEqual(3, book.Categories.Count);
            Assert.AreEqual("Нехудожественная литература", book.Categories[0]);
            Assert.AreEqual("Изучение иностранных языков", book.Categories[1]);
            Assert.AreEqual("Адаптированные книги", book.Categories[2]);
            Assert.NotNull(book.Price);
            Assert.AreEqual(11.22M, book.Price.Value);
            Assert.AreEqual("BYN", book.Price.Currency);
            Assert.AreEqual("English", book.Language);
        }

        [Test]
        public void ValidateSchema()
        {
            ValidateSchema(this.content, this.schema, TargetNamespaces.BookshopsNamespace);
        }

        [Test]
        public void LoadXmlAndTestElementPrefixes()
        {
            this.LoadXmlAndTestElementPrefixes(this.content, NamespacePrefix);
        }

        [XmlRoot("bookshops", Namespace = TargetNamespaces.BookshopsNamespace)]
        public class BookshopList
        {
            [XmlElement("bookshop")]
            public List<Bookshop> Bookshops { get; } = new List<Bookshop>();
        }

        public class Bookshop
        {
            [XmlAttribute("id")]
            public int Id { get; set; }

            [XmlElement("name")]
            public string Name { get; set; }

            [XmlElement("website")]
            public string Website { get; set; }

            [XmlArray("books")]
            [XmlArrayItem("book")]
            public List<Book> Books { get; } = new List<Book>();
        }

        public class Book
        {
            [XmlAttribute("id")]
            public int Id { get; set; }

            [XmlArray("authors")]
            [XmlArrayItem("author")]
            public List<string> Authors { get; } = new List<string>();

            [XmlElement("title")]
            public string Title { get; set; }

            [XmlArray("genres")]
            [XmlArrayItem("genre")]
            public List<string> Genres { get; } = new List<string>();

            [XmlArray("categories")]
            [XmlArrayItem("category")]
            public List<string> Categories { get; } = new List<string>();

            [XmlElement("price")]
            public BookPrice Price { get; set; }

            [XmlElement("language")]
            public string Language { get; set; }
        }

        public class BookPrice
        {
            [XmlAttribute("currency")]
            public string Currency { get; set; }

            [XmlText]
            public decimal Value { get; set; }
        }
    }
}
