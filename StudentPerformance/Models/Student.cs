using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformance.Models
{
    [Serializable]
    public class Student
    {
        private float average = 0;
        private ushort[] marks = { 0, 0, 0, 0, 0, 0, 0, 0 };
        private string name = "";

        public string Name
        {
            get => name;
            set => name = value;
        }

        public ushort Elec
        {
            get => marks[0];
            set => marks[0] = value;
        }


        public ushort Comp_Net
        {
            get => marks[1];
            set => marks[1] = value;
        }

        public ushort Comp_Arch
        {
            get => marks[2];
            set => marks[2] = value;
        }

        public ushort Prob_Theory
        {
            get => marks[3];
            set => marks[3] = value;
        }

        public ushort Calculus
        {
            get => marks[4];
            set => marks[4] = value;
        }
        public ushort Comp_Math
        {
            get => marks[5];
            set => marks[5] = value;
        }
        public ushort PI
        {
            get => marks[6];
            set => marks[6] = value;
        }
        public ushort Vis_Prog
        {
            get => marks[7];
            set => marks[7] = value;
        }

        public float Average
        {
            get
            {
                average = 0;
                foreach (ushort num in marks)
                {
                    average += num;
                }
                return average /= 8;
            }
        }
    }
}
