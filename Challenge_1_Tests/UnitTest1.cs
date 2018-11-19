using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_1_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MenuRepository_AddMenuItemToList_ShouldReturnCorrectCount()
        {
            //--Arrange
              = new StreamingContentRepository();
            var list = contentRepo.GetContentList();
            StreamingContent content = new StreamingContent();
            StreamingContent contentTwo = new StreamingContent();


            //--Act
            contentRepo.AddContentToList(content);
            list.Add(contentTwo);
            var actual = contentRepo.GetContentList().Count;
            var expected = 2;

            //--Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
