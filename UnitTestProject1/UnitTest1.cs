using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        public struct Vector2
        {
            public float X { get; set; }
            public float Y { get; set; }  

            public Vector2(float x, float y)
            {
                X = x;
                Y = y;
            }
            public override string ToString()
            {
                return $"X : {X} / Y : {Y}";
            }
   
        }
        [TestMethod]

     
            
           
       protected void VectorToString()
        {
            int x = 2;
            int y = 5;

            var vector = new Vector2(x, y);
            var resultado = vector.ToString();

            var resultadoEsperado = $"X : {x} / Y : {y}";

            Assert.AreEqual(resultado, resultadoEsperado);
        }
    }
    
}
