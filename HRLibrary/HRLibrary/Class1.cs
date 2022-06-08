using System;


namespace HRLibrary
{
    public class Serviceman
    {
        public string Name;
        public string Surname;
        public string Ticketnumber;
        public string Title;
        public string Unitnumber;
        public DateTime Postuplenie;
        public DateTime Servicetime;
        public ServicemanServicetype Type;
    }
    public Serviceman(string name, string surname, string ticketnumber, string title,string unitnumber,string postuplenie,string servicetime, ServicemanServicetype Type);
    {
        Name=name;
        Surname=surname;
        Type=type;
        Ticketnumber=ticketnumber;
        Title= title;
        Unitnumber=unitnumber;
        Postuplenie= postuplenie;
        Servicetime=servicetime;
        }
}
      public override string ToString() 
{ return $" {Name} {Surname}"; }
public void PrintInfo() { Console.WriteLine(this); var gender = ""; switch (Gender) { case PersonGender.Male: gender = "мужской"; break; case PersonGender.Female: gender = "женский"; break; } Console.WriteLine($"Датарождения: {Birthday:d}. Пол: {gender}. Возраст: {Age}."); } } } 
}

