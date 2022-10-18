using Core;
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
            var param = Helpers.GenerateParam();
            var points = Helpers.GeneratePoints();
            var interpolator = new KrigingInterpolator();
            var result = interpolator.Interpolate(param, points, Helpers.AllNodes(param), new KrigingInterpolationOptions());
            Assert.AreEqual(true, result, "Метод построения Kriging не выдает результат.");
        }
    }
}