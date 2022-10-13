using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core;
using Core.Extensions;
using Core.Interfaces;
using Core.Loaders;
using IDW;

namespace MapCalculator
{
    public static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            Console.WriteLine("Press Enter");
            Console.ReadKey();

            ISelectorWithDialog fileSelector = new FileSelector();
            ISelectorWithDialog folderSelector = new FolderSelector();

            /*
             * 
             * TODO для ковариационной функции взять расстояние до ближайшей точки
             * ki = C(Ui - U); узнать, что такое "Ui" и "U"  
             *
             */

            List<Point3D> points = Helpers.Get6Points();

            Matrix matrix6x6 = new Matrix(points.Count);
            Matrix matrix6x1 = new Matrix(6, 1);

            double[] distances = points.GetDistance();
            matrix6x6.Fill(distances);

            SpaceBetweenMatrix();
            DisplayMatrix(matrix6x6.ConvertToCovariance());

            void DisplayMatrix(Matrix matrix)
            {
                for (int i = 0; i < matrix.Lines; i++)
                {
                    for (int j = 0; j < matrix.Columns; j++)
                    {
                        Console.Write($"{matrix.GetElement(i, j),10}");
                    }

                    Console.WriteLine();
                }

            }

            void SpaceBetweenMatrix(int count = 1)
            {
                for (int i = 0; i < count; i++)
                    Console.WriteLine();
            }

            double CalculateCovariance(double h)
            {
                return 1 - 1.5 * (h / 4141) + 0.5 * Math.Pow(h / 4141, 3);
            }

            /// Здесь необходимо заполнить названия файлов используя параметры командной строки, либо диалоги
            string filePoints = fileSelector.Select("Выберите файл с точками", "Text Document|*.txt");
            string fileGrid = fileSelector.Select("Выберите файл сетки", "Text Document|*.txt");
            string fileMap = folderSelector.Select("Выберите место для сохранение результата");

            /// Там надо реализовать методы загрузки параметров в каком либо виде, например точки X,Y,Z, парамкетры сетки как минимум/максимум по X|Y и количество узлов по X|Y
            ILoader<List<Point3D>> pointsLoader = new PointsLoader(filePoints);
            ILoader<Point3D[][]> gridLoader = new GridLoader(fileGrid);

            //TODO Реализовать загрузку
            //List<Point3D> points = pointsLoader.Load();
            Point3D[][] map = gridLoader.Load();

            /// В каких узлах считаем
            bool[][] mask = Helpers.AllNodes(map);

            /// Метод интерполяции
            IInterpolator interpolator = new KrigingInterpolator();

            /// Сама интерполяция, сейчас параметры специфичные не определены
            if (interpolator.Interpolate(map, points, mask, new KrigingInterpolationOptions()) == false)
                return;

            //TODO реализовать сохранение
            ISaver<Point3D[][]> mapSaver = new DefaultMapSaver(fileMap);
            mapSaver.Save(map);

        }
    }
}