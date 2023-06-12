using System;

namespace Homework_1
{
    public struct ComplexTr
    {
        private float _abs;
        public float Abs
        {
            get => _abs;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Модуль должен быть неотрицательным");
                _abs = value;
            }
        }

        private float _arg;
        public float Arg
        {
            get => _arg;
            set => _arg = value;
        }

        public float Re => _abs * (float)Math.Cos(_arg);
        public float Im => _abs * (float)Math.Sin(_arg);

        public ComplexTr(float abs, float arg)
        {
            if (abs < 0)
                throw new ArgumentException("Модуль должен быть неотрицательным");
            _abs = abs;
            _arg = arg;
        }

        public override string ToString()
        {
            if (FloatEquals(_abs, 0))
                return "0";
            if (FloatEquals(_abs, 1))
                return $"cos({_arg}) + i sin({_arg})";
            return $"{_abs}(cos({_arg}) + i sin({_arg}))";
        }

        public override bool Equals(object? obj)
        {
            if (obj is not ComplexTr)
                throw new ArgumentException("Сравнивать можно только комплексные числа");
            var complex = (ComplexTr)obj;
            return FloatEquals(Abs, complex.Abs)
                && FloatEquals(0, (float)((Arg - complex.Arg) % (2 * Math.PI)));
        }

        private static bool FloatEquals(float a, float b)
        {
            var difference = Math.Pow(10, -13);
            return Math.Abs(a - b) <= difference;
        }
        
        public static ComplexTr operator *(ComplexTr a, ComplexTr b)
        {
            return new ComplexTr(a.Abs * b.Abs, a.Arg + b.Arg);
        }
        
        public static ComplexTr operator /(ComplexTr a, ComplexTr b)
        {
            if (FloatEquals(b.Abs, 0))
                throw new ArgumentException("Деление на 0 запрещено");
            return new ComplexTr(a.Abs / b.Abs, a.Arg - b.Arg);
        }
    }
}