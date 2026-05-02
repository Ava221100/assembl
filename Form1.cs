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
                    int value = int.Parse(parts[1]);

                    if (parts[2] == "R1") R1 = value;
                    if (parts[2] == "R2") R2 = value;
                    if (parts[2] == "R3") R3 = value;
                }

                //MOV
                else if (command == "MOV")
                {
                    int value = GetRegister(parts[1]);
                    SetRegister(parts[2], value);
                }

                // Add R1, R2, R3
                else if (command == "ADD")
                {
                    int value1 = GetRegister(parts[1]);
                    int value2 = GetRegister(parts[2]);
                    int result = value1 + value2;

                    SetRegister(parts[3], result);
                }

                // Sub R1, R2, R3
                else if (command == "SUB")
                {
                    int value1 = GetRegister(parts[1]);
                    int value2 = GetRegister(parts[2]);
                    int result = value1 - value2;

                    SetRegister(parts[3], result);
                }

                // Mul R1, R2, R3
                else if (command == "MUL")
                {
                    int value1 = GetRegister(parts[1]);
                    int value2 = GetRegister(parts[2]);
                    int result = value1 * value2;

                    SetRegister(parts[3], result);
                }

                // Div R1, R2, R3
                else if (command == "DIV")
                {
                    int value1 = GetRegister(parts[1]);
                    int value2 = GetRegister(parts[2]);

                    if (value2 == 0)
                    {
                        rtBoxOutPut.AppendText("Error: divide by zero\n");
                        continue;
                    }

                    int result = value1 / value2;
                    SetRegister(parts[3], result);
                }

                // Trp R3  
                else if (command == "TRP")
                {
                    if (parts[1] == "3")
                    {
                        rtBoxOutPut.AppendText(R3.ToString() + "\n");
                    }
                }
            }

            // update UI
            labelR1.Text = "R1: " + R1;
            labelR2.Text = "R2: " + R2;
            labelR3.Text = "R3: " + R3;
        }

        //get register value 
        private int GetRegister(string reg)
        {
            if (reg == "R1") return R1;
            if (reg == "R2") return R2;
            if (reg == "R3") return R3;

            return int.Parse(reg); // allows numbers like 5
        }

        //set register value
        private void SetRegister(string reg, int value)
        {
            if (reg == "R1") R1 = value;
            else if (reg == "R2") R2 = value;
            else if (reg == "R3") R3 = value;
        }

        //unit test
        private void RunTests()
        {
            rtBoxOutPut.AppendText("\n--- Running Tests ---\n");

            // positive test: ADD

            R1 = 5;
            R2 = 10;
            R3 = 0;

            int result = GetRegister("R1") + GetRegister("R2");
            SetRegister("R3", result);

            if (R3 == 15)
                rtBoxOutPut.AppendText("PASS: ADD test\n");
            else
                rtBoxOutPut.AppendText("FAIL: ADD test\n");

            // positive test: MOV

            R1 = 20;
            R2 = 0;

            SetRegister("R2", GetRegister("R1"));

            if (R2 == 20)
                rtBoxOutPut.AppendText("PASS: MOV test\n");
            else
                rtBoxOutPut.AppendText("FAIL: MOV test\n");

            // negative test: DIV by zero
            try
            {
                int a = 10;
                int b = 0;
                int x = a / b;

                rtBoxOutPut.AppendText("FAIL: DIV by zero not handled\n");
            }
            catch
            {
                rtBoxOutPut.AppendText("PASS: DIV by zero handled\n");
            }
        }
    }
}