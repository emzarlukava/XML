using System.Xml.Serialization;
using NUnit.Framework;

namespace Xml.Tests.BookTitleElement
{
    [TestFixture]
    public class BookTitleElementTests : XmlTestFixtureBase
    {
        private const string SourceFileName = "book-title-element.xml";

        private string content;

        [SetUp]
        public void SetUp()
        {
            this.content = ReadContent(SourceFileName);
        }

        [Test]
        public void DeserializeAndTestContent()
        {
            Book book = Deserialize<Book>(this.content);

            Assert.NotNull(book);
            Assert.AreEqual("Pride And Prejudice", book.Title);
        }

        [XmlRoot("book", Namespace = "")]
        public class Book
        {
            [XmlElement("title")]
            public string Title { get; set; }
        }
    }
}
