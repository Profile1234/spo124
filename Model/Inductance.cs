using System;

namespace Model
{
    /// <summary>
    /// Класс для реализации катушки
    /// </summary>
    /// 
    [Serializable]
    public class Inductance : Elements
    {
        /// <summary>
        /// Индуктивность катушки
        /// </summary>
        private float L;

        /// <summary>
        /// Конструктор класса Resistor 
        /// </summary>
        /// <param name="paramert1">Значение частоты тока</param>
        /// <param name="paramert2">Значение индуктивности</param>
        public Inductance(float paramert1, float paramert2) : base(paramert1, paramert2)
        {
            L = paramert2;
        }

        /// <summary>
        /// Подсчет комплексного сопративления
        /// </summary>
        /// <returns>Возвращение резельтата в виде строки</returns>
        public override string ComplexResistance()
        {
            return $"Z = { Omega * L}j Ом";
        }

        /// <summary>
        /// Вывод характеристик
        /// </summary>
        /// <returns>Строка с параметрами элемента</returns>
        public override string Characteristic()
        {
            return $"omega = {Omega} рад/с, L = {L} Гн";
        }

        /// <summary>
        /// Возврат комплексного сопративления в виде числа
        /// </summary>
        /// <returns>Комплексное сопративление</returns>
        public override float ComplexResistanceFloat()
        {
            return Omega * L;
        }
    }
}
