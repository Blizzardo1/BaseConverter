using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseCalculator
{

    public record Base(string BaseName, string BaseFullName, RadioButton Button, Func<string, NumberRecord> func);

}
