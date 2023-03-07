using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Media;
using DynamicData;
using ReactiveUI;
using StudentPerformance.Models;
using StudentPerformance.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reactive;
using System.Security.Cryptography;
using System.Text;

namespace StudentPerformance.ViewModels
{

    public class MainWindowViewModel : ViewModelBase
    {
        Student[] students;
        float[] avMarks = { 0, 0, 0, 0, 0, 0, 0, 0, 0};
        string name;
        ushort[] marks = { 0, 0, 0, 0, 0, 0, 0, 0};
        int index = -1;
        public MainWindowViewModel()
        {
            Students = new Student[]
            {
            new Student { Name = "Иванов Иван Иванович", Elec = 0, Comp_Net = 1, Comp_Arch = 2, Prob_Theory = 1, Calculus = 0, Comp_Math = 2, PI = 1, Vis_Prog = 0 },
            new Student { Name = "Петров Петр Петрович", Elec = 1, Comp_Net = 1, Comp_Arch = 1, Prob_Theory = 1, Calculus = 1, Comp_Math = 1, PI = 1, Vis_Prog = 1 },
            new Student { Name = "Алексеев Алексей Алексеевич", Elec = 2, Comp_Net = 1, Comp_Arch = 2, Prob_Theory = 1, Calculus = 2, Comp_Math = 1, PI = 2, Vis_Prog = 2 },
            };
            CalcAverage(students);
            AddStudent = ReactiveCommand.Create(() => {
                /*
                Array.Resize(ref students, students.Length+1);
                students[students.Length-1] = new Student { Name = Name, Elec = Elec, Comp_Net = CompNet, Comp_Arch = CompArch, Prob_Theory = ProbTheory, Calculus = Calculus, Comp_Math = CompMath, PI = PI, Vis_Prog = VisProg };
                Students = students;*/
                Student[] tmp = students;
                Array.Resize(ref tmp,tmp.Length + 1);
                tmp[tmp.Length - 1] = new Student { Name = Name, Elec = Elec, Comp_Net = CompNet, Comp_Arch = CompArch, Prob_Theory = ProbTheory, Calculus = Calculus, Comp_Math = CompMath, PI = PI, Vis_Prog = VisProg };
                Name = string.Empty;
                Students = tmp;
                CalcAverage(students);
            });
            DelStudent = ReactiveCommand.Create(() => {
                Student[] tmp = students;
                for(var i = index; i < tmp.Length-1; i++)
                {
                    tmp[i] = tmp[i + 1];
                }
                Index = -1;
                Array.Resize(ref tmp, tmp.Length - 1);
                Students = tmp;
                CalcAverage(students);
            });
            Save = ReactiveCommand.Create(() =>
            {
                Serializer<Student[]>.Save("data.xml", students);
            });
            Load = ReactiveCommand.Create(() =>
            {
                Students = Serializer<Student[]>.Load("data.xml");
                CalcAverage(students);
            });
        }
        public Student[] Students
        {
            get => students;
            set => this.RaiseAndSetIfChanged(ref students, value);
        }
        public int Index
        {
            get => index;
            set => this.RaiseAndSetIfChanged(ref index, value);
        }
        public float AvElec
        {
            get => avMarks[0];
            set => this.RaiseAndSetIfChanged(ref avMarks[0], value);
        }
        public float AvCompNet
        {
            get => avMarks[1];
            set => this.RaiseAndSetIfChanged(ref avMarks[1], value);
        }
        public float AvCompArch
        {
            get => avMarks[2];
            set => this.RaiseAndSetIfChanged(ref avMarks[2], value);
        }
        public float AvProbTheory
        {
            get => avMarks[3];
            set => this.RaiseAndSetIfChanged(ref avMarks[3], value);
        }
        public float AvCalculus
        {
            get => avMarks[4];
            set => this.RaiseAndSetIfChanged(ref avMarks[4], value);
        }
        public float AvCompMath
        {
            get => avMarks[5];
            set => this.RaiseAndSetIfChanged(ref avMarks[5], value);
        }
        public float AvPI
        {
            get => avMarks[6];
            set => this.RaiseAndSetIfChanged(ref avMarks[6], value);
        }
        public float AvVisProg
        {
            get => avMarks[7];
            set => this.RaiseAndSetIfChanged(ref avMarks[7], value);
        }
        public float AvAverage
        {
            get => avMarks[8];
            set => this.RaiseAndSetIfChanged(ref avMarks[8], value);
        }
        void CalcAverage(Student[] students)
        {
            for(var i=0;i<avMarks.Length;i++)
            {
                avMarks[i] = 0;
            }
            foreach(Student student in students)
            {
                AvElec += student.Elec;
                AvCompNet += student.Comp_Net;
                AvCompArch += student.Comp_Arch;
                AvProbTheory += student.Prob_Theory;
                AvCalculus += student.Calculus;
                AvCompMath += student.Comp_Math;
                AvPI += student.PI;
                AvVisProg += student.Vis_Prog;
                AvAverage += student.Average;
            }
            AvElec /= students.Length;
            AvCompNet /= students.Length;
            AvCompArch /= students.Length;
            AvProbTheory /= students.Length;
            AvCalculus /= students.Length;
            AvCompMath /= students.Length;
            AvPI /= students.Length;
            AvVisProg /= students.Length;
            AvAverage /= students.Length;
        }
        public string Name
        {
            get => name;
            set => this.RaiseAndSetIfChanged(ref name, value);
        }
        public ushort Elec
        {
            get => marks[0];
            set => this.RaiseAndSetIfChanged(ref marks[0], value);
        }
        public ushort CompNet
        {
            get => marks[1];
            set => this.RaiseAndSetIfChanged(ref marks[1], value);
        }
        public ushort CompArch
        {
            get => marks[2];
            set => this.RaiseAndSetIfChanged(ref marks[2], value);
        }
        public ushort ProbTheory
        {
            get => marks[3];
            set => this.RaiseAndSetIfChanged(ref marks[3], value);
        }
        public ushort Calculus
        {
            get => marks[4];
            set => this.RaiseAndSetIfChanged(ref marks[4], value);
        }
        public ushort CompMath
        {
            get => marks[5];
            set => this.RaiseAndSetIfChanged(ref marks[5], value);
        }
        public ushort PI
        {
            get => marks[6];
            set => this.RaiseAndSetIfChanged(ref marks[6], value);
        }
        public ushort VisProg
        {
            get => marks[7];
            set => this.RaiseAndSetIfChanged(ref marks[7], value);
        }
        
        ReactiveCommand<Unit, Unit> AddStudent { get; }
        ReactiveCommand<Unit, Unit> DelStudent { get; }
        ReactiveCommand<Unit, Unit> Save { get; }
        ReactiveCommand<Unit, Unit> Load { get; }
    }
}

