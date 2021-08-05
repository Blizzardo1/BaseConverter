using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseCalculator
{
    public partial class Form1 : Form
    {
        private readonly Base[] _menu = {
            new( "bin", "Binary",       new RadioButton{Name = "binRbtn", AutoSize = true}, (b) => new(b, 2)),
            new( "oct", "Octal",        new RadioButton{Name = "octRbtn", AutoSize = true}, (o) =>  new(o, 8)),
            new( "dec", "Decimal",      new RadioButton{Name = "decRbtn", AutoSize = true}, (d)=> new(d, 10)),
            new( "hex", "Hexadecimal",  new RadioButton{Name = "hexRbtn", AutoSize = true}, (h) => new(h, 16)),
            new( "ubin", "Unsigned Binary",       new RadioButton{Name = "ubinRbtn", AutoSize = true }, (b) => new(b, 2  , true)),
            new( "uoct", "Unsigned Octal",        new RadioButton{Name = "uoctRbtn", AutoSize = true }, (o) =>  new(o, 8 , true)),
            new( "udec", "Unsigned Decimal",      new RadioButton{Name = "udecRbtn", AutoSize = true }, (d)=> new(d, 10  , true)),
            new( "uhex", "Unsigned Hexadecimal",  new RadioButton{Name = "uhexRbtn", AutoSize = true }, (h) => new(h, 16 , true))
        };

        private readonly RadioButton[] _signs = {
            new RadioButton{ Name = "signRbtn", Text = "Signed", Tag = false},
            new RadioButton{ Name = "unsignRbtn", Text = "Unsigned", Tag = true}
        };
        public Form1()
        {
            InitializeComponent();
            foreach (Base b in _menu)
            {
                b.Button.Text = b.BaseFullName;
                flpy1.Controls.Add(b.Button);
            }
            _menu.First().Button.Checked = true;
        }



        public void DoConversion()
        {
            try
            {
                if (inputTxt.Text.IsEmpty()) throw new ArgumentException("Input cannot be null");
                foreach (Base b in _menu)
                {
                    if (!b.Button.Checked)
                    {
                        continue;
                    }

                    NumberRecord n = b.func(inputTxt.Text);
                    outputTxt.Text = n.ToString();

                }
            }
            catch (Exception ex)
            {
                NativeMethods.ErrorMessage(this, ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DoConversion();
            inputTxt.Clear();
        }
    }
}
