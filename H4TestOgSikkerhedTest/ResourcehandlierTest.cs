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
            Assert.True(success, error);
            Assert.Empty(error);
        }

        [Fact] public void DeleteFile() 
        {
            string filename = "unittest.txt";
            string path = "UnitTest";
            string error = "";
            bool success = false;
            MyResourceHandler myResourceHandler = new();

            success = myResourceHandler.TryDeleteFile(path,filename, out error);

            Assert.True(success, error);
            Assert.Empty(error);


        }


    }
}