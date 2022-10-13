using System.Collections.Generic;

namespace Core.Interfaces
{
    /// <summary>
    /// Базовый интерфейс, его надо наследовать для интерполяторов карт
    /// </summary>
    public interface IInterpolator
    {
        /// <summary>
        /// Собственно процесс интерполяции
        /// </summary>
        /// <param name="map">Результат</param>
        /// <param name="points">Точки</param>
        /// <param name="calculatingMask">Маска расчета, можно неиспользовать</param>
        /// <param name="options">специфичные параметры метода</param>
        /// <returns>Есть ли результат</returns>
        
        bool Interpolate(Point3D[][] map, List<Point3D> points, bool[][] calculatingMask, IInterpolationOptions options);
    }
}