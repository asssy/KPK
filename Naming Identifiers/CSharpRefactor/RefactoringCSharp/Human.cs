using System;

class Human
{
    enum Sex { Male, Female };

    class Person
    {
        public Sex Sex { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public void CreatPerson(int age)
    {
        Person person = new Person();
        person.Age = age;

        if (age % 2 == 0)
        {
            person.Name = "Батката";
            person.Sex = Sex.Female;
        }
        else
        {
            person.Name = "Мацето";
            person.Sex = Sex.Female;
        }
    }

    static void Main()
    { 
    }
}

