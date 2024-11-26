using System;
using Xunit;

namespace Simulator.Maps.Tests
{
    public class SmallSquareMapTests
    {
        [Fact]
        public void CreateMap_WithValidSize_CreatesMapSuccessfully()
        {
            // Arrange & Act
            var map = new SmallSquareMap(10);

            // Assert
            Assert.Equal(10, map.Size);
        }

        [Fact]
        public void CreateMap_WithInvalidSize_ThrowsArgumentOutOfRangeException()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(3));
        }

        [Fact]
        public void Exist_PointWithinLimits_ReturnsTrue()
        {
            // Arrange
            var map = new SmallSquareMap(-5);
            var point = new Point(-4, -4);

            // Act
            var result = map.Exist(point);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Exist_PointOnBoundary_ReturnsTrue()
        {
            // Arrange
            var map = new SmallSquareMap(-5);
            var point = new Point(0, 0);

            // Act
            var result = map.Exist(point);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Exist_PointOutsideLimits_ReturnsFalse()
        {
            // Arrange
            var map = new SmallSquareMap(-5);
            var point = new Point(-5, -5);

            // Act
            var result = map.Exist(point);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Next_PointInsideMap_ReturnsNextPoint()
        {
            // Arrange
            var map = new SmallSquareMap(-5);
            var point = new Point(-4, -4);

            // Act
            var nextPoint = map.Next(point, Direction.Right);

            // Assert
            Assert.Equal(new Point(-3, -4), nextPoint);
        }

        [Fact]
        public void Next_PointOnBoundary_ReturnsSamePoint()
        {
            // Arrange
            var map = new SmallSquareMap(-5);
            var point = new Point(0, 0);

            // Act
            var nextPoint = map.Next(point, Direction.Right);

            // Assert
            Assert.Equal(point, nextPoint);
        }

        [Fact]
        public void NextDiagonal_PointInsideMap_ReturnsNextDiagonalPoint()
        {
            // Arrange
            var map = new SmallSquareMap(-5);
            var point = new Point(-4, -4);

            // Act
            var nextDiagonalPoint = map.NextDiagonal(point, Direction.Down);

            // Assert
            Assert.Equal(new Point(-4, -4), nextDiagonalPoint);
        }

        [Fact]
        public void NextDiagonal_PointOnBoundary_ReturnsSamePoint()
        {
            // Arrange
            var map = new SmallSquareMap(-5);
            var point = new Point(0, 0);

            // Act
            var nextDiagonalPoint = map.NextDiagonal(point, Direction.Up);

            // Assert
            Assert.Equal(point, nextDiagonalPoint);
        }
    }
}
