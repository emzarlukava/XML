using System.Xml.Serialization;
using NUnit.Framework;

namespace Xml.Tests.BookTitleAttribute
{
    [TestFixture]
    public class BookTitleAttributeTests : XmlTestFixtureBase
    {
        private const string SourceFileName = "book-title-attribute.xml";

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
            [XmlAttribute("title")]
            public string Title { get; set; }
        }
    }
}
