using System;

namespace Model
{
    /// <summary>
    /// Абстрактный класс для реализации элементов электричесикх схем
    /// </summary>
    [Serializable]
    abstract public class Elements
    {
        private float o;
        /// <summary>
        /// Циклическая частота
        /// </summary>
        protected float Omega 
        {
            get => o;
            set
            {
                if (value >= 0)
                    o = value;
                else throw new ArgumentException("Частота отрицательная");
            }
        }

        private float p;
        /// <summary>
        /// Параметр элемента
        /// </summary>
        protected float Parametr
        {
            set
            {
                if (value < 0)
                    throw new ArgumentException("Параметр элемента отрицательный");
                else if (value > 100)
                    throw new ArgumentException("Значение слишком большое");
                else
                    p = value;
            }
        }

        public Elements(float paramert1, float paramert2)
        {
            Omega = paramert1;
            Parametr = paramert2;
        }

        abstract public string ComplexResistance();
        abstract public string Characteristic();
        abstract public float ComplexResistanceFloat();
    }
}
