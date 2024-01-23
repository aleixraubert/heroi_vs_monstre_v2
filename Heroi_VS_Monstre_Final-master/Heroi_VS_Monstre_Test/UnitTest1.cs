using PR1_Metodos_Batalla;

namespace Heroi_VS_Monstre_Test
{
    [TestClass]
    public class IsNotLimitsTests
    {
        [TestMethod]
        public void IsNotLimits_NumberWithinLimits_ReturnsFalse()
        {
            //Arrange
            int value = 5;
            int max = 10;
            int min = 1;

            //Act
            bool actual = Batalla.IsNotLimits(value, min, max);

            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsNotLimits_NumberOutsideLimits_ReturnsTrue()
        {
            //Arrange
            int value = 15;
            int max = 10;
            int min = 1;

            //Act
            bool actual = Batalla.IsNotLimits(value, min, max);

            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsNotLimits_NumberNegative_ReturnsTrue()
        {
            //Arrange
            int value = -5;
            int max = 10;
            int min = 0;

            //Act
            bool actual = Batalla.IsNotLimits(value, min, max);

            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsNotLimits_NumberEqualMin_ReturnsFalse()
        {
            //Arrange
            int value = 5;
            int max = 10;
            int min = 5;

            //Act
            bool actual = Batalla.IsNotLimits(value, min, max);

            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsNotLimits_NumberEqualMax_ReturnsFalse()
        {
            //Arrange
            int value = 10;
            int max = 10;
            int min = 1;

            //Act
            bool actual = Batalla.IsNotLimits(value, min, max);

            //Assert
            Assert.IsFalse(actual);
        }
    }

    [TestClass]
    public class RandomAttacker
    {
        [TestMethod]
        public void RandomAttacker_ReturnsArray()
        {
            //Arrange
            int[] array = new int[4];

            //Act
            array = Batalla.RandomAttacker();

            //Assert
            Assert.IsNotNull(array);
        }
    }

    [TestClass]
    public class Sort_Desc
    {
        [TestMethod]
        public void Sort_Desc_NormalArray()
        {
            //Arrange
            int[] array = { 3, 5, 8, 10 };

            int[] expected = { 10, 8, 5, 3 };

            //Act
            array = Batalla.Sort_Desc(array);

            //Assert
            Assert.AreEqual(expected, array);
        }

        [TestMethod]
        public void Sort_Desc_EmptyArray()
        {
            //Arrange
            int[] array = { };

            int[] expected = { };

            //Act
            array = Batalla.Sort_Desc(array);

            //Assert
            Assert.AreEqual(expected, array);
        }

        [TestMethod]
        public void Sort_Desc_ArrayWithNegativeNumbers()
        {
            //Arrange
            int[] array = { -3, -5, 1, 0 };

            int[] expected = { 1, 0, -3, -5 };

            //Act
            array = Batalla.Sort_Desc(array);

            //Assert
            Assert.AreEqual(expected, array);
        }


        [TestMethod]
        public void Sort_Desc_ArrayWithZeros()
        {
            //Arrange
            int[] array = { 10, 8, 0, 1 };

            int[] expected = { 10, 8, 1, 0};

            //Act
            array = Batalla.Sort_Desc(array);

            //Assert
            Assert.AreEqual(expected, array);
        }

        [TestMethod]
        public void Sort_Desc_ArrayWithSameNumbers()
        {
            //Arrange
            int[] array = { 3, 2, 5, 2 };

            int[] expected = { 5, 3, 2, 2 };

            //Act
            array = Batalla.Sort_Desc(array);

            //Assert
            Assert.AreEqual(expected, array);
        }
    }
}
