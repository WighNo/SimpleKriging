using Core;
using Core.Generators;
using Core.Interfaces;
using Core.Loaders;
using Core.Savers;
using Core.Selectors;
using IDW;
using System;
using System.Collections.Generic;

namespace MapCalculator
{
    /*
     * Предполагаю, что алгоритм работает не совсем корректно
     * т.к при подстановки значений в файл "testmap.html" вывод сильно отличается от примера.
     * Возможно это из-за того, что матрица неправильно инвертируется (признаю, инверсию своровал. Простите :с)
     *
     * 
     *---------------------------------------------------------------------------------------------------------
     *                                                                                                        |
     *------------------------------------------- СТРУКТУРА ПРОЕКТА -------------------------------------------
     *                                                                                                        |
     *---------------------------------------------------------------------------------------------------------
     * 
     * "Extensions" набор методо-расширений для инверсии матриц и расчёта матриц расстояний
     * "Generators" часть функционала класса "Helpers"
     * "Interfaces" все используемые интерфейсы.
     * "Loaders"    загрузчики точек и карты
     * "Matrix"     класс матриц, а так же отдельный класс с математикой для матриц (только умножение)
     * "Savers"     класс, сохраняющий результат интерполяции
     * "Selectors"  диалоговые окна выбора файлов и пути сохранения
     * 
     */
    public static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            Console.WriteLine("Press Enter");
            Console.ReadKey();
            
            ISelectorWithDialog fileSelector = new FileSelector();
            ISelectorWithDialog saveMapDialog = new SaveFolderSelector();
            
            string filePoints = fileSelector.Select("Выберите файл с точками", "Text Document|*.txt");
            string fileGrid = fileSelector.Select("Выберите файл сетки", "Json File|*.json");
            string fileMap = saveMapDialog.Select("Выберите место сохранения", "xyz|*.xyz");

            ILoader<List<Point3D>> pointsLoader = new PointsLoader(filePoints);
            ILoader<Point3D[][]> gridLoader = new JsonGridLoader(fileGrid);

            List<Point3D> points = pointsLoader.Load();
            Point3D[][] map = gridLoader.Load();
            
            bool[][] mask = new AllNodesMaskMapGenerator(map).Generate();

            IInterpolator interpolator = new KrigingInterpolator();

            if (interpolator.Interpolate(map, points, mask, new KrigingInterpolationOptions()) == false)
                return;

            ISaver<Point3D[][]> mapSaver = new DefaultMapSaver(fileMap);
            mapSaver.Save(map);
        }
    }
}