using UpdateDataWithDynamicLinq.Common;
using UpdateDataWithDynamicLinq.DB;

namespace TestUpdate
{
    public class Testv1
    {
        [Fact]
        public void Update()
        {

            // Act
            TestClass testClass = new TestClass();
            var dbContext = new MyContext();
            string value = "TEst414";
            string ColumnName = "Name";

            int Id = 2;
            // Assert
            testClass.UpdateRecord("Student", "UpdateDataWithDynamicLinq.Model", ColumnName, Id, value);
            var item = dbContext.Student.FirstOrDefault(d => d.Id == Id);
            //Assert

            Assert.NotNull(item);
            Assert.Equal(item.Name, value);

            ///act



        }
    }
}