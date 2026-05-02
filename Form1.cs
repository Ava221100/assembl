using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Assembly_Code
{
    public partial class Form1 : Form
    {
        // registers
        int R1 = 0;
        int R2 = 0;
        int R3 = 0;

        //command storage list
        List<string[]> program = new List<string[]>();
        public Form1()
        {
            InitializeComponent();
        }
        private void buttonGo_Click_1(object sender, EventArgs e)
        {
            rtBoxOutPut.Clear();    // Clear output 

            program.Clear();       // Clear previous program

            string[] lines = rtBoxInPut.Text.Split('\n');
            foreach (string inputline in lines)
            {
                string line = inputline.Trim();
                if (line == "") continue;
                string[] parts = line.Split(' ');

                program.Add(parts);
            }
            
            foreach (string[] parts in program)
            {
                 string command = parts[0];

                // LD 
                if (command == "LD")
                {
                    int number = int.Parse(parts[1]);

                    if (parts[2] == "R1") R1 = number;
                    if (parts[2] == "R2") R2 = number;
                    if (parts[2] == "R3") R3 = number;
                }

                // Add R1, R2, R3
                else if (parts[0] == "ADD")
                {
                    int value1 = 0;
                    int value2 = 0;

                    if (parts[1] == "R1") value1 = R1;
                    if (parts[1] == "R2") value1 = R2;
                    if (parts[1] == "R3") value1 = R3;

                    if (parts[2] == "R1") value2 = R1;
                    if (parts[2] == "R2") value2 = R2;
                    if (parts[2] == "R3") value2 = R3;

                    int result = value1 + value2;

                    if (parts[3] == "R1") R1 = result;
                    if (parts[3] == "R2") R2 = result;
                    if (parts[3] == "R3") R3 = result;
                }

                // Sub R1, R2, R3
                else if (parts[0] == "SUB")
                {
                    int value1 = 0;
                    int value2 = 0;

                    if (parts[1] == "R1") value1 = R1;
                    if (parts[1] == "R2") value1 = R2;
                    if (parts[1] == "R3") value1 = R3;

                    if (parts[2] == "R1") value2 = R1;
                    if (parts[2] == "R2") value2 = R2;
                    if (parts[2] == "R3") value2 = R3;

                    int result = value1 - value2;

                    if (parts[3] == "R1") R1 = result;
                    if (parts[3] == "R2") R2 = result;
                    if (parts[3] == "R3") R3 = result;
                }

                // Mul R1, R2, R3
                else if (parts[0] == "MUL")
                {
                    int value1 = 0;
                    int value2 = 0;

                    if (parts[1] == "R1") value1 = R1;
                    if (parts[1] == "R2") value1 = R2;
                    if (parts[1] == "R3") value1 = R3;

                    if (parts[2] == "R1") value2 = R1;
                    if (parts[2] == "R2") value2 = R2;
                    if (parts[2] == "R3") value2 = R3;

                    int result = value1 * value2;

                    if (parts[3] == "R1") R1 = result;
                    if (parts[3] == "R2") R2 = result;
                    if (parts[3] == "R3") R3 = result;
                }

                // Div R1, R2, R3
                else if (parts[0] == "DIV")
                {
                    int value1 = 0;
                    int value2 = 0;

                    if (parts[1] == "R1") value1 = R1;
                    if (parts[1] == "R2") value1 = R2;
                    if (parts[1] == "R3") value1 = R3;

                    if (parts[2] == "R1") value2 = R1;
                    if (parts[2] == "R2") value2 = R2;
                    if (parts[2] == "R3") value2 = R3;

                    int result = value1 / value2;

                    if (parts[3] == "R1") R1 = result;
                    if (parts[3] == "R2") R2 = result;
                    if (parts[3] == "R3") R3 = result;
                }

                // Trp R3  
                else if (parts[0] == "TRP")
                {
                    if (parts[1] == "3")
                    {
                        rtBoxOutPut.AppendText(R3.ToString() + "\n");
                    }
                }
            }

            // Update labels
            labelR1.Text = "R1: " + R1;
            labelR2.Text = "R2: " + R2;
            labelR3.Text = "R3: " + R3;
        }
    }
}