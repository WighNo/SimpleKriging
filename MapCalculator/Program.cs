using Core;
using Core.Extensions;
using Core.Interfaces;
using Core.Loaders;
using Core.Selectors;
using Core.Matrix;
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
            Point3D[][] content = Helpers.GenerateParam();
            List<Point3D> point3Ds = Helpers.GeneratePoints();

            List<KrigingPoint> krigingPoints = new List<KrigingPoint>();

            Console.WriteLine(content.Length);
            Console.WriteLine(content[0].Length);

            for (int j = 0; j < content[0].Length; j++)
            {
                KrigingPoint krigingPoint = new KrigingPoint(content[0][j]);
                krigingPoints.Add(krigingPoint);

                krigingPoint.Matrix = new Matrix(point3Ds.Count);
                krigingPoint.Matrix.Fill(point3Ds.GetDistance());

                Console.WriteLine($"{0}\t{j}");
            }

            Console.WriteLine(krigingPoints.Count);
            
            /*Action<StreamWriter> s = (writer) =>
            {
                for (int i = 0; i < content.Length; i++)
                {
                    for (int j = 0; j < content[i].Length; j++)
                    {
                        for (int k = 0; k < point3Ds.Count; k++)
                        {
                            writer.Write(content[i][j].CalculateDistance(point3Ds[k]));
                            writer.Write(";");
                        }
                    }

                    if (i < content.Length - 1)
                        writer.WriteLine();
                }
            };
            
            matrixStorage.WriteFile(s, true);
            Console.ReadLine();*/

            Console.ReadLine();
            
            var param = Helpers.GenerateParam();
            var pointss = Helpers.GeneratePoints();
            var interpolators = new KrigingInterpolator();
            interpolators.Interpolate(param, pointss, Helpers.AllNodes(param), new KrigingInterpolationOptions());
            
            return;
            
            ISelectorWithDialog fileSelector = new FileSelector();
            ISelectorWithDialog folderSelector = new FolderSelector();
         
            Console.WriteLine("Press Enter");
            Console.ReadKey();
            
            string filePoints = fileSelector.Select("Выберите файл с точками", "Text Document|*.txt");
            string fileGrid = fileSelector.Select("Выберите файл сетки", "Json File|*.json");
            //string fileMap = folderSelector.Select("Выберите место для сохранение результата");

            ILoader<List<Point3D>> pointsLoader = new PointsLoader(filePoints);
            ILoader<Point3D[][]> gridLoader = new JsonGridLoader(fileGrid);

            List<Point3D> points = pointsLoader.Load();
            Point3D[][] map = gridLoader.Load();

            Matrix matrix = new Matrix(points.Count);
            matrix.Fill(points.GetDistance());
            matrix.Inverse();
            
            Console.ReadKey();

            bool[][] mask = Helpers.AllNodes(map);

            IInterpolator interpolator = new KrigingInterpolator();

            if (interpolator.Interpolate(map, points, mask, new KrigingInterpolationOptions()) == false)
                return;

            //TODO реализовать сохранение
            /*ISaver<Point3D[][]> mapSaver = new DefaultMapSaver(fileMap);
            mapSaver.Save(map);*/
        }

        static void DisplayMatrix(Matrix matrix)
        {
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    Console.Write($"{matrix.GetElement(i, j), 5}");
                }
                Console.Write(Environment.NewLine);
            }
            
            Console.Write(Environment.NewLine);
        }
    }
}