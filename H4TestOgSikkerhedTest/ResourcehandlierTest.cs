using H4TestOgSikkerhed.Data;

namespace H4TestOgSikkerhedTest
{
    public class ResourceHandlerTest
    {
        [Fact]
        public void CreateTestFile()
        {
            // Arrange
            string filename = "unittest.txt";
            string path = "UnitTest";
            string error = "";
            bool success = false;
            MyResourceHandler myResourceHandler = new();

            // Act
            success = myResourceHandler.TryCreateFile(path, filename, out error);

            // Assert
            Assert.True(success);
            Assert.Empty(error);
        }
    }
}