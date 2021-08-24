using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Assets._Scripts.General;


namespace Assets._Scripts.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class GridTests
    {

        float gridSize;
        float gridShift;
        Vector3 position;
        Vector3 Nposition;

        [SetUp]
        public void BaseSetUp()
        {
            position = new Vector3(1.2f,1.8f);
            Nposition = new Vector3(-1.2f, -1.8f);
        }

        // A Test behaves as an ordinary method
        [Test]
        public void GridTestsSimplePasses()
        {
            // Use the Assert class to test conditions
        }


        [TestCase(0.5f, 15.25f, 14.8f)]
        [TestCase(0.75f, 15.25f, 14.8f)]
        [TestCase(1f, 15.25f, 14.8f)]
        [TestCase(1.25f, 15.25f, 14.8f)]
        [TestCase(1.5f, 15.25f, 14.8f)]
        public void RoundPositiveValue(float gridSize, float positionX, float positionY)
        {
            position.x = positionX;
            position.y = positionY;

            position = new Vector3(BaseMethods.RoundToGridSupreme(gridSize, position.x), BaseMethods.RoundToGridSupreme(gridSize, position.y), 0);

            Assert.AreEqual(new Vector3(15,15,0), position);
            //Assert.AreEqual(Nposition, new Vector3(-15, -15, 0));
        }

        [TestCase(0.5f, 15.22f, 14.83f)]
        [TestCase(0.75f, 15.33f, 14.73f)]
        [TestCase(1f, 15.45f, 14.83f)]
        [TestCase(1.25f, 15.45f, 14.83f)]
        [TestCase(1.5f, 15.73f, 14.53f)]
        public void RoundNegativeValue(float gridSize, float positionX, float positionY)
        {
            Nposition.x = -positionX;
            Nposition.y = -positionY;

            Nposition = new Vector3(BaseMethods.RoundToGridSupreme(gridSize, Nposition.x), BaseMethods.RoundToGridSupreme(gridSize, Nposition.y), 0);

            Assert.AreEqual(new Vector3(-15, -15, 0),Nposition);
        }


        [TestCase(0.5f, 0.12f, 0.33f)]
        [TestCase(0.75f, 0.24f, 0.66f)]
        [TestCase(1f, 0.36f, 0.99f)]
        [TestCase(1.25f, 0.48f, 1f)]
        [TestCase(1.5f, 0.66f, 0.98f)]
        public void RoundPositive0Value(float gridSize, float positionX, float positionY)
        {
            position.x = positionX;
            position.y = positionY;

            position = new Vector3(BaseMethods.RoundToGridSupreme(gridSize, position.x), BaseMethods.RoundToGridSupreme(gridSize, position.y), 0);

            Assert.AreEqual(new Vector3(0, gridSize, 0), position);
            //Assert.AreEqual(Nposition, new Vector3(-15, -15, 0));
        }

        [TestCase(0.5f, 0.12f, 0.33f)]
        [TestCase(0.75f, 0.24f, 0.66f)]
        [TestCase(1f, 0.36f, 0.99f)]
        [TestCase(1.25f, 0.48f, 1f)]
        [TestCase(1.5f, 0.66f, 0.98f)]
        public void RoundNegative0Value(float gridSize, float positionX, float positionY)
        {
            Nposition.x = -positionX;
            Nposition.y = -positionY;

            Nposition = new Vector3(BaseMethods.RoundToGridSupreme(gridSize, Nposition.x), BaseMethods.RoundToGridSupreme(gridSize, Nposition.y), 0);
            Assert.AreEqual(new Vector3(0, -gridSize, 0), Nposition);
        }






        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator GridTestsWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }



    }
}
