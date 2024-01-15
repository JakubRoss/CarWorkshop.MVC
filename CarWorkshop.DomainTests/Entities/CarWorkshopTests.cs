using Xunit;

namespace CarWorkshop.Domain.Entities.Tests
{
    public class CarWorkshopTests
    {
        [Fact]
        public void EncodeNameShouldEncodeNameCorrectly()
        {
            //Arrange
            var carWorkshop = new CarWorkshop()
            {
                Name = "FSO Polonez",
            };

             //Act
            carWorkshop.EncodeName();

            // Assert
            carWorkshop.EncodedName.Equals("fso-polonez");
        }

        [Fact]
        public void EncodeNameShouldThrowNullReferenceException()
        {
            // Arrange
            CarWorkshop carWorkshop = new CarWorkshop(); 
            carWorkshop.Name = null!; 

            // Act & Assert
            Assert.Throws<NullReferenceException>(carWorkshop.EncodeName);
        }
    }
}