using Core;
using Core.Matrix;
using IDW;
using System;
using System.Collections.Generic;
using System.Threading;
using Core.Extensions;
using Core.Interfaces;
using Core.Loaders;
using Core.Selectors;

namespace MapCalculator
{
    public static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            ISelectorWithDialog fileSelector = new FileSelector();
            ISelectorWithDialog folderSelector = new FolderSelector();
         
            Console.WriteLine("Press Enter");
            Console.ReadKey();
            
            string filePoints = fileSelector.Select("Выберите файл с точками", "Text Document|*.txt");
            string fileGrid = fileSelector.Select("Выберите файл сетки", "Json File|*.json");
            string fileMap = folderSelector.Select("Выберите место для сохранение результата");

            ILoader<List<Point3D>> pointsLoader = new PointsLoader(filePoints);
            ILoader<Point3D[][]> gridLoader = new JsonGridLoader(fileGrid);

            List<Point3D> points = Helpers.GeneratePoints();//pointsLoader.Load();
            Point3D[][] map = Helpers.GenerateParam();//gridLoader.Load();
            
            bool[][] mask = Helpers.AllNodes(map);

            IInterpolator interpolator = new KrigingInterpolator();

            if (interpolator.Interpolate(map, points, mask, new KrigingInterpolationOptions()) == false)
                return;

            //TODO реализовать сохранение
            ISaver<Point3D[][]> mapSaver = new DefaultMapSaver(fileMap);
            mapSaver.Save(map);
        }
    }
}