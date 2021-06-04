﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            lab1.Student Stl1 = new Student("John", 2, "321234");
            InitializeComponent();
            label10.Text = Stl1.Name;
            label12.Text = Stl1.Course.ToString();
            label14.Text = Stl1.GradeBook;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            lab1.Student Stl1 = new Student(textBox4.Text, Decimal.ToInt32(numericUpDown2.Value), textBox5.Text);
            label10.Text = Stl1.Name;
            label12.Text = Stl1.Course.ToString();
            label14.Text = Stl1.GradeBook;
        }
    }

    public class Student
    {
        // 1. Поля класса - объявленные как protected - видимы в производных классах,
        // и невидимы из экземпляра класса
        protected string name; // Фамилия и имя студента
        protected int course; // Курс обучения
        protected string gradeBook; // Номер зачетной книги

        // 2. Конструктор класса с 3 параметрами
        public Student(string Name, int course, string gradeBook)
        {
            this.Name = Name;
            this.course = course;
            this.gradeBook = gradeBook;
        }

        // 3. Свойства доступа к полям класса
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Course
        {
            get { return course; }
            set { course = value; }
        }

        public string GradeBook
        {
            get { return gradeBook; }
            set { gradeBook = value; }
        }

        // 4. Метод Print() - вывести значения полей на экран
        public void Print(string el1, string el2, string el3)
        {
            el1 = Name;
            el2 = course.ToString();
            el3 = gradeBook;
        }
    }

    // Класс Aspirant - наследует возможности класса Student
    public class Aspirant : Student
    {
        // 1. Внутреннее поле класса
        protected string topic; // Тема кандидатской диссертации

        // 2. Конструктор класса Aspirant - с помощью ключевого слова base обращается
        // к конструктору базового класса Student
        public Aspirant(string name, int course, string gradeBook, string topic) :
            base(name, course, gradeBook)
        {
            // Можно изменять protected-члены базового класса
            base.name = name; // доступ к полю name класса Student с помощью base
            this.course = course; // доступ к полю course класса Student с помощью this
            this.gradeBook = gradeBook;

            this.topic = topic; // инициализация внутреннего поля класса Aspirant
        }

        // 3. Свойство для доступа к полю topic
        public string Topic
        {
            get { return topic; }
            set { topic = value; }
        }

        // 4. Метод Print() - печать полей класса Aspirant
        // Имя данного метода перекрывает имя метода Student.Print(),
        // поэтому перед именем метода указывается new
        public void Print(string el1, string el2, string el3, string el4) // new - переопределение метода базового класса
        {
            base.Print(el1,el2,el3); // вызвать метод Print() базового класса
            el4 = Topic;
        }
    }

    // Класс Зав. Кафедры
    public class ZavKafedry : Aspirant
    {
        protected string kafedra;

        public ZavKafedry(string name, int course, string gradeBook, string topic, string Kafedra) :
            base(name, course, gradeBook, topic)
        {
            // Можно изменять protected-члены базового класса
            base.name = name; // доступ к полю name класса Aspirant с помощью base
            this.course = course; // доступ к полю course класса Aspirant с помощью this
            this.gradeBook = gradeBook;
            this.topic = topic; // доступ к полю topic класса Aspirant с помощью base
            this.Kafedra = Kafedra; // инициализация внутреннего поля класса ZavKafedry
        }

        // 3. Свойство для доступа к полю Kafedra
        public string Kafedra
        {
            get { return kafedra; }
            set { kafedra = value; }
        }

        public void Print(string el1, string el2, string el3, string el4, string el5) // new - переопределение метода базового класса
        {
            base.Print(el1, el2, el3, el4); // вызвать метод Print() базового класса
            el5 = kafedra;
        }

    }

}
