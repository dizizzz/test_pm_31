using AnalaizerClassLibrary;
using System.Collections;

namespace AnalaizerClassLibraryTest
{
    [TestClass]
    public class AnalaizerClassTests
    {
        //[TestMethod]
        //public void CreateStack_WithOperators_ReturnsCorrectRPN()
        //{
        //    // Arrange
        //    AnalaizerClass.expression = "1+2";

        //    // Act
        //    ArrayList result = AnalaizerClass.CreateStack();

        //    // Assert
        //    CollectionAssert.AreEqual(new ArrayList() { "1", "2", "+" }, result);
        //}

        //[TestMethod]
        //public void CreateStack_WithMultipleOperators_ReturnsCorrectRPN()
        //{
        //    // Arrange
        //    AnalaizerClass.expression = "3+2*4";

        //    // Act
        //    ArrayList result = AnalaizerClass.CreateStack();

        //    // Assert
        //    CollectionAssert.AreEqual(new ArrayList() { "3", "2", "4", "*", "+" }, result);
        //}

        //[TestMethod]
        //public void CreateStack_WithBrackets_ReturnsCorrectRPN()
        //{
        //    // Arrange
        //    AnalaizerClass.expression = "(3+2)*4";

        //    // Act
        //    ArrayList result = AnalaizerClass.CreateStack();

        //    // Assert
        //    CollectionAssert.AreEqual(new ArrayList() { "3", "2", "+", "4", "*" }, result);
        //}

        //[TestMethod]
        //public void CreateStack_WithUnaryMinus_ReturnsCorrectRPN()
        //{
        //    // Arrange
        //    AnalaizerClass.expression = "m3+2";

        //    // Act
        //    ArrayList result = AnalaizerClass.CreateStack();

        //    // Assert
        //    CollectionAssert.AreEqual(new ArrayList() { "3", "m", "2", "+" }, result);
        //}

        //[TestMethod]
        //public void CreateStack_WithUnaryPlus_ReturnsCorrectRPN()
        //{
        //    // Arrange
        //    AnalaizerClass.expression = "p5*1";

        //    // Act
        //    ArrayList result = AnalaizerClass.CreateStack();

        //    // Assert
        //    CollectionAssert.AreEqual(new ArrayList() { "5", "p", "1", "*" }, result);
        //}

        //[TestMethod]
        //public void CreateStack_WithComplexExpression_ReturnsCorrectRPN()
        //{
        //    // Arrange
        //    AnalaizerClass.expression = "3+(4-2)*5";

        //    // Act
        //    ArrayList result = AnalaizerClass.CreateStack();

        //    // Assert
        //    CollectionAssert.AreEqual(new ArrayList() { "3", "4", "2", "-", "5", "*", "+" }, result);
        //}

        //[TestMethod]
        //public void CreateStack_WithModulus_ReturnsCorrectRPN()
        //{
        //    // Arrange
        //    AnalaizerClass.expression = "10%3+1";

        //    // Act
        //    ArrayList result = AnalaizerClass.CreateStack();

        //    // Assert
        //    CollectionAssert.AreEqual(new ArrayList() { "10", "3", "%", "1", "+" }, result);
        //}

        public TestContext TestContext { get; set; }

        [TestMethod]
        [DataSource("System.Data.SqlClient", @"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\StackTestDB.mdf;Integrated Security=True;Connect Timeout=30", "TestData", DataAccessMethod.Sequential)]
        public void CreateStack_ReturnsCorrectRPN()
        {

            // Arrange
            AnalaizerClass.expression = TestContext.DataRow["Expression"].ToString();
            ArrayList expectedResult = new ArrayList(TestContext.DataRow["ExpectedResult"].ToString().Split(','));

            // Act
            ArrayList result = AnalaizerClass.CreateStack();

            // Assert
            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void CreateStack_EmptyExpression_ReturnsEmptyArrayList()
        {
            // Arrange
            AnalaizerClass.expression = string.Empty;
            ArrayList expected = new ArrayList();

            // Act
            var result = AnalaizerClass.CreateStack();

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CreateStack_WithInvalidExpression_ThrowsInvalidOperationException()
        {
            // Arrange
            AnalaizerClass.expression = "3+2)";

            // Act
            AnalaizerClass.CreateStack();
        }
    }
}