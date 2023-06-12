using System;

// Структура Food (продукт питания)
struct Food
{
    // Поле Weight (вес продукта питания в граммах) — положительное целое число
    private int weight;
    public int Weight
    {
        get { return weight; }
        set
        {
            if (value > 0)
                weight = value;
            else
                throw new ArgumentException("Вес продукта должен быть положительным");
        }
    }

    // Поле Calorie (калорийность —количество килокалорий в 100 г продукта) — положительное число с плавающей точкой, округленное до одного знака после запятой
    private double calorie;
    public double Calorie
    {
        get { return calorie; }
        set
        {
            if (value > 0)
                calorie = Math.Round(value, 1);
            else
                throw new ArgumentException("Калорийность продукта должна быть положительной");
        }
    }

    // Свойство Value— количество килокалорий в данном продукте; только для чтения
    public double Value
    {
        get { return Weight * Calorie / 100.0; }
    }

    // Конструктор с параметрами веса и калорийности
    public Food(int weight, double calorie)
    {
        this.weight = 0;
        this.calorie = 0;
        Weight = weight;
        Calorie = calorie;
    }

    // Переопределение метода ToString()
    public override string ToString()
    {
        return $"{Weight} г калорийности {Calorie} Ккал/100 г";
    }

    // Переопределение метода Equals()
    public override bool Equals(object obj)
    {
        if (obj == null || !(obj is Food))
            return false;
        Food other = (Food)obj;
        return Weight == other.Weight && Calorie == other.Calorie;
    }

    // Переопределение метода GetHashCode()
    public override int GetHashCode()
    {
        return Weight.GetHashCode() ^ Calorie.GetHashCode();
    }

    // Переопределение операции сложения (+)
    public static Food operator +(Food f1, Food f2)
    {
        if (f1.Calorie != f2.Calorie)
            throw new InvalidOperationException("Нельзя складывать продукты разной калорийности");
        return new Food(f1.Weight + f2.Weight, f1.Calorie);
    }

    // Переопределение операции вычитания (-)
    public static Food operator -(Food f1, Food f2)
    {
        if (f1.Calorie != f2.Calorie)
            throw new InvalidOperationException("Нельзя вычитать продукты разной калорийности");
        if (f1.Weight < f2.Weight)
            throw new InvalidOperationException("Нельзя вычитать продукт с большим весом");
        return new Food(f1.Weight - f2.Weight, f1.Calorie);
    }
}

