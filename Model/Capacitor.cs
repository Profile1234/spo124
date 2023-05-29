using System;

namespace Model
{
    /// <summary>
    /// Класс для реализации конденсатора
    /// </summary>
    [Serializable]
    public class Capacitor : Elements
    {
        /// <summary>
        /// Емкость конденсатора
        /// </summary>
        private float C;
         
        /// <summary>
        /// Конструктор класса Resistor
        /// </summary>
        /// <param name="paramert1">Значение частоты тока</param>
        /// <param name="paramert2">Значение емкости</param>
        public Capacitor(float paramert1, float paramert2) : base(paramert1, paramert2)
        {
            C = paramert2;
        }

        /// <summary>
        /// Подсчет комплексного сопративления
        /// </summary>
        /// <returns>Возвращение резельтата в виде строки</returns>
        public override string ComplexResistance()
        {
            return $"Z = {-1 / Omega / C}j Ом";
        }

        /// <summary>
        /// Вывод характеристик
        /// </summary>
        /// <returns>Строка с параметрами элемента</returns>
        public override string Characteristic()
        {
            return $"omega = {Omega} рад/с, C = {C} Ф";
        }

        /// <summary>
        /// Возврат комплексного сопративления в виде числа
        /// </summary>
        /// <returns>Комплексное сопративление</returns>
        public override float ComplexResistanceFloat()
        {
            return -1 / Omega / C;
        }
    }
}
