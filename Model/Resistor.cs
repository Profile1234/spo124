using System;

namespace Model
{
    /// <summary>
    /// Класс для реализации резистора
    /// </summary>
    [Serializable]
    public class Resistor : Elements
    {
        /// <summary>
        /// Сопротивление резистора
        /// </summary>
        private float R;

        /// <summary> 
        /// Конструктор класса Resistor
        /// </summary>
        /// <param name="paramert">Значение сопротивления</param>
        public Resistor(float paramert) : base(0, paramert)
        {
            R = paramert;
        }

        /// <summary>
        /// Подсчет комплексного сопративления
        /// </summary>
        /// <returns>Возвращение резельтата в виде строки</returns>
        public override string ComplexResistance()
        {
            return $"Z = {R} Ом";
        }

        /// <summary>
        /// Вывод характеристик
        /// </summary>
        /// <returns>Строка с параметрами элемента</returns>
        public override string Characteristic()
        {
            return $"R = {R} Ом";
        }

        /// <summary>
        /// Возврат комплексного сопративления в виде числа
        /// </summary>
        /// <returns>Комплексное сопративление</returns>
        public override float ComplexResistanceFloat()
        {
            return R;
        }
    }
}
