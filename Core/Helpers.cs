using System;
using System.Collections.Generic;

namespace Core
{
    /// <summary>
    /// Вспомогательный класс, по хорошему было бы создать базовые классы для списка точек и карт, тогда эти методы уйдут в типы
    /// </summary>
    //TODO Distribute functionality into classes
    public static class Helpers
    {
        public static List<Point3D> GeneratePoints()
        {
            return new List<Point3D>
            {
                new Point3D(317845.2, 861486, 0.2),
                new Point3D(319055.2, 861414.8, 0.27),
                new Point3D(320327, 862052.9, 0.28),
                new Point3D(319037.6, 860832.8, 0.29),
                new Point3D(320673.2, 860675.6, 0.29),
                new Point3D(320242.1, 860271.5, 0.29),
                new Point3D(322358.9, 859888.9, 0.29),
                new Point3D(323994.8, 862455, 0.29),
                new Point3D(322444.3, 863255, 0.29),
                new Point3D(323582.4, 861493.7, 0.29),
                new Point3D(319628.8, 861376.6, 0.29),
                new Point3D(323187, 860733.3, 0.29),
                new Point3D(323202.8, 862361.6, 0.29),
                new Point3D(324401.4, 862872.5, 0.29),
                new Point3D(324528.6, 863629, 0.29),
                new Point3D(324332.2, 862397.2, 0.29),
                new Point3D(324645.1, 862124.3, 0.29),
                new Point3D(323220.2, 859901.5, 0.29),
                new Point3D(324857.3, 861625.6, 0.29),
                new Point3D(323679.2, 859517.5, 0.29),
                new Point3D(324902.2, 860816.5, 0.29),
                new Point3D(325335.4, 861225.7, 0.29),
                new Point3D(324528.2, 859532.9, 0.29),
                new Point3D(324925.7, 859968.5, 0.29),
                new Point3D(325318.5, 860400.2, 0.29),
                new Point3D(325488.7, 859866.8, 0.29),
                new Point3D(324915.4, 859125.2, 0.29),
                new Point3D(323836.5, 863936.6, 0.29),
                new Point3D(324321.9, 861766.7, 0.29),
                new Point3D(324468.5, 861137.3, 0.29),
                new Point3D(325844.2, 859539.1, 0.29),
                new Point3D(324449.4, 859099.9, 0.29),
                new Point3D(324156.3, 858669.6, 0.29),
                new Point3D(324699.5, 858669.3, 0.29),
                new Point3D(325194.1, 858695.9, 0.29),
                new Point3D(319773.7, 848505.4, 0.29),
                new Point3D(320364.5, 847965.6, 0.29),
                new Point3D(320923.9, 847459, 0.29),
                new Point3D(319330.6, 847383.8, 0.29),
                new Point3D(320211.4, 847225.7, 0.29),
                new Point3D(318982.9, 847081.2, 0.29),
                new Point3D(319480.8, 846968.6, 0.29),
                new Point3D(320322.5, 846760.5, 0.29),
                new Point3D(319675.7, 846604.3, 0.29),
                new Point3D(316118.5, 850598, 0.29),
                new Point3D(315779.5, 850178.9, 0.29),
                new Point3D(318577.1, 848401.9, 0.29),
                new Point3D(318941.5, 847582.4, 0.29),
                new Point3D(318517.8, 847865.9, 0.29),
                new Point3D(318985.2, 848038.9, 0.29),
                new Point3D(320681.8, 857355, 0.29),
                new Point3D(321348.6, 857688.4, 0.29),
                new Point3D(320903.7, 856944.6, 0.29),
                new Point3D(320655.1, 856582.6, 0.29),
                new Point3D(317891.1, 854335.3, 0.29),
                new Point3D(318429.6, 854213.8, 0.29),
                new Point3D(318770.2, 854315.5, 0.29),
                new Point3D(318095.6, 853951.5, 0.29),
                new Point3D(319882.7, 853874.7, 0.29),
                new Point3D(320496, 853455.5, 0.29),
                new Point3D(320967.7, 853406.2, 0.29),
                new Point3D(320276.7, 853094.6, 0.29),
                new Point3D(321193.7, 853051, 0.29),
                new Point3D(319623.8, 852762.7, 0.29),
                new Point3D(320457.4, 852689.1, 0.29),
                new Point3D(320919.2, 852694.5, 0.29),
                new Point3D(320909.3, 851905, 0.29),
                new Point3D(319313, 851570.4, 0.3),
                new Point3D(319746, 851551.5, 0.3),
                new Point3D(320185.1, 851533.7, 0.32),
                new Point3D(319130.5, 851215.7, 0.32),
                new Point3D(319530.7, 851185.1, 0.33),
                new Point3D(319977.5, 851167.9, 0.33),
                new Point3D(319747.2, 850724.6, 0.34),
                new Point3D(319911, 850342.5, 0.34),
                new Point3D(317885.9, 850088, 0.35),
                new Point3D(318794.9, 850031.4, 0.36),
                new Point3D(320598, 849920.9, 0.36),
                new Point3D(318540.5, 849655.3, 0.36),
                new Point3D(319000.2, 849633.1, 0.36),
                new Point3D(320348.7, 849526.4, 0.36),
                new Point3D(321395.7, 849141.4, 0.37),
                new Point3D(319202.9, 849238, 0.37),
                new Point3D(319636.2, 849195.7, 0.37),
                new Point3D(320084.3, 849187.8, 0.37),
                new Point3D(318936, 848841.3, 0.38),
                new Point3D(319171.3, 848471.5, 0.38),
                new Point3D(320273.8, 848814.3, 0.39),
                new Point3D(319438.9, 848858.5, 0.39),
                new Point3D(320527.5, 848382.5, 0.39),
                new Point3D(320704.8, 848006.9, 0.39),
                new Point3D(321167.9, 847980.9, 0.4),
                new Point3D(314609.5, 847906.4, 0.4),
                new Point3D(321370.4, 847354.5, 0.4),
                new Point3D(318627.5, 861426.2, 0.41),
                new Point3D(319102, 859679.6, 0.41),
                new Point3D(321467.5, 857453.9, 0.41),
                new Point3D(314207.8, 847580.6, 0.41),
                new Point3D(321887.6, 862860.8, 0.41),
                new Point3D(320440.9, 861382.8, 0.42),
                new Point3D(318354.3, 854584.2, 0.42),
                new Point3D(318670.8, 850019, 0.43),
                new Point3D(321300.2, 862024.2, 0.43),
                new Point3D(322864.8, 861945.9, 0.43),
                new Point3D(321021, 860384.7, 0.43),
                new Point3D(321725.6, 860888.5, 0.43),
                new Point3D(323103.8, 863277, 0.44),
                new Point3D(323579.9, 862847, 0.44),
                new Point3D(322727.5, 862817.1, 0.44),
                new Point3D(324040.9, 860757.3, 0.44),
                new Point3D(324492.3, 860412.5, 0.44),
                new Point3D(320278.75, 856967, 0.44),
                new Point3D(321495.1, 860646.9, 0.44),
                new Point3D(321641.9, 847909, 0.44),
                new Point3D(319565.4, 847522.7, 0.45),
                new Point3D(319191.5, 854293.3, 0.45),
                new Point3D(319158, 853531, 0.45),
                new Point3D(319577.8, 853550.9, 0.45),
                new Point3D(320011.2, 852618.3, 0.45),
                new Point3D(320474.7, 851952.1, 0.45),
                new Point3D(320252.3, 850826.4, 0.45),
                new Point3D(317926, 850846.2, 0.45),
                new Point3D(318399, 850844.7, 0.46),
                new Point3D(319230.8, 850004.4, 0.47),
                new Point3D(319448.1, 849622.6, 0.52),
                new Point3D(319897.4, 849585.2, 0.54),
                new Point3D(320554.2, 849163.1, 0.55),
                new Point3D(320759.6, 848807.5, 0.57),
                new Point3D(320926.3, 848351.6, 0.58),
                new Point3D(315776.2, 847515.7, 0.58)
            };
        }

        public static bool[][] AllNodes(Point3D[][] map)
        {
            var mask = new bool[map.Length][];
            for (var i = 0; i < map.Length; i++)
            {
                mask[i] = new bool[map[i].Length];
                for (var j = 0; j < map[i].Length; j++)
                {
                    mask[i][j] = true;
                }
            }

            return mask;
        }

        public static Point3D[][] GenerateParam()
        {
            var nx = 460;
            var ny = 800;
            var xStep = 50.0;
            var yStep = 50.0;
            var xMin = 309000.0;
            var yMin = 827000.0;
            var xMax = xMin + (nx - 1) * xStep;
            var yMax = yMin + (ny - 1) * yStep;

            var map = new Point3D[nx][];         
            for (var i = 0; i < nx; i++)
            {
                map[i] = new Point3D[ny];
                for (var j = 0; j < ny; j++)
                {
                    map[i][j] = new Point3D(xMin + xStep * i, yMin + yStep * j, double.NaN);
                }
            }

            return map;
        }
    }
}