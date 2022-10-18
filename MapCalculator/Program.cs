using Core;
using Core.Extensions;
using Core.Interfaces;
using Core.Loaders;
using Core.Selectors;
using IDW;
using System;
using System.Collections.Generic;

namespace MapCalculator
{
    public static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            ISelectorWithDialog fileSelector = new FileSelector();
            ISelectorWithDialog folderSelector = new FolderSelector();
            
            Console.ReadKey();
            
            string filePoints = fileSelector.Select("Выберите файл с точками", "Text Document|*.txt");
            string fileGrid = fileSelector.Select("Выберите файл сетки", "Json File|*.json");
            //string fileMap = folderSelector.Select("Выберите место для сохранение результата");

            /// Там надо реализовать методы загрузки параметров в каком либо виде, например точки X,Y,Z,
            /// параметры сетки как минимум/максимум по X|Y и количество узлов по X|Y
            ILoader<List<Point3D>> pointsLoader = new PointsLoader(filePoints);
            ILoader<Point3D[][]> gridLoader = new JsonGridLoader(fileGrid);

            List<Point3D> points = pointsLoader.Load();
            Point3D[][] map = gridLoader.Load();

            /*Matrix matrix = new Matrix(points.Count);
            matrix.Fill(points.GetDistance());
            matrix.ConvertToCovariance(new SphericalVariogram());*/

            Console.ReadKey();

            /// В каких узлах считаем
            bool[][] mask = Helpers.AllNodes(map);

            /// Метод интерполяции
            IInterpolator interpolator = new KrigingInterpolator();

            /// Сама интерполяция, сейчас параметры специфичные не определены
            if (interpolator.Interpolate(map, points, mask, new KrigingInterpolationOptions()) == false)
                return;

            //TODO реализовать сохранение
            /*ISaver<Point3D[][]> mapSaver = new DefaultMapSaver(fileMap);
            mapSaver.Save(map);*/
        }
    }
}