using System.Collections.Generic;
using Core;
using Core.Generators;
using Core.Interfaces;
using IDW;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IDWTests
{
    [TestClass]
    public class KrigingTests
    {
        [TestMethod]
        public void BaseTest()
        {
            IInterpolator interpolator = new KrigingInterpolator();

            Point3D[][] param = new DefaultParamGenerator().Generate();
            List<Point3D> points = new DefaultPointsGenerator().Generate();
            bool[][] mask = new AllNodesMaskMapGenerator(param).Generate();
            
            bool result = interpolator.Interpolate(param, points, mask, new KrigingInterpolationOptions());
            Assert.AreEqual(true, result, "Метод построения Kriging не выдает результат.");
        }
    }
}