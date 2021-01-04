namespace NewsSystem.Domain.Common.Models
{
    using FluentAssertions;
    using Domain.ArticleCreation.Models.Journalists;
    using Xunit;

    public class ValueObjectSpecs
    {
        [Fact]
        public void ValueObjectsWithEqualPropertiesShouldBeEqual()
        {
            // Arrange
            var first = new PhoneNumber("0876465566");
            var second = new PhoneNumber("0876465561");

            // Act
            var result = first == second;

            // Arrange
            result.Should().BeTrue();
        }

        [Fact]
        public void ValueObjectsWithDifferentPropertiesShouldNotBeEqual()
        {
            // Arrange
            var first = new PhoneNumber("0876465566");
            var second = new PhoneNumber("0876461566");

            // Act
            var result = first == second;

            // Arrange
            result.Should().BeFalse();
        }
    }
}
