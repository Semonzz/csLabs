using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab04
{
    public class Animal : IComparable
    { 
        protected int weight;
        protected string color;

        public int getWeight() { return weight; }
        public string getColor() { return color; }
        public void setColor(string otherColor) { color = otherColor; }
        public void setWeight(int otherWeight) { weight = otherWeight; }
        public Animal() { }

        public int CompareTo(object o)
        {
            Animal p = o as Animal;
            if (p != null)
                return this.weight.CompareTo(p.weight);
            else
                throw new Exception("Невозможно сравнить два объекта");
        }
    }

    public class Cat :  Animal {
        private int age;
        private string name;
        private string breed;

        public int getAge() { return age; }
        public string getName() { return name; }
        public string getBreed() { return breed; }

        public void setName(string otherName) { name = otherName; }
        public void setBreed(string otherBreed) { breed = otherBreed; }
        public void setAge(int otherWeight) { age = otherWeight; }

        public Cat() { }

        public Cat(int age, string name, string breed, int weight, string color)
        {
            this.age = age;
            this.name = name;
            this.breed = breed;
            this.color = color;
            this.weight = weight;
        }
    }
    public class Bird : Animal
    {
        private int wingspan;
        private string kind;

        public int getWingspan() { return wingspan; }
        public string getKind() { return kind; }
        public void setKind(string otherKind) { kind = otherKind; }
        public void setWingspan(int otherWingspan) { wingspan = otherWingspan; }

        public Bird() { }

        public Bird(int wingspan, string kind, int weight, string color)
        {
            this.wingspan = wingspan;
            this.kind = kind;
            this.color = color;
            this.weight = weight;
        }
    }
}
