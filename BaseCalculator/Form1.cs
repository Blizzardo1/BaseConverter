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
        // ReSharper disable once MemberInitializerValueIgnored
        private readonly Base[] _menu = {
            new( "bin", "Binary",       new RadioButton{Name = "binRbtn", AutoSize = true}, b => new(b, 2)),
            new( "oct", "Octal",        new RadioButton{Name = "octRbtn", AutoSize = true}, o =>  new(o, 8)),
            new( "dec", "Decimal",      new RadioButton{Name = "decRbtn", AutoSize = true}, d=> new(d, 10)),
            new( "hex", "Hexadecimal",  new RadioButton{Name = "hexRbtn", AutoSize = true}, h => new(h, 16)),
            new( "ebin", "Floating Binary",       new RadioButton{Name = "ebinRbtn", AutoSize = true }, b => new(b, 2  , true)),
            new( "eoct", "Floating Octal",        new RadioButton{Name = "eoctRbtn", AutoSize = true }, o =>  new(o, 8 , true)),
            new( "edec", "Floating Decimal",      new RadioButton{Name = "edecRbtn", AutoSize = true }, d=> new(d, 10  , true)),
            new( "ehex", "Floating Hexadecimal",  new RadioButton{Name = "ehexRbtn", AutoSize = true }, h => new(h, 16 , true))
        };

        private readonly RadioButton[] _signs = {
            new() { Name = "signRbtn", Text = @"Signed", Tag = false},
            new() { Name = "unsignRbtn", Text = @"Unsigned", Tag = true}
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


        private void DoConversion()
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
