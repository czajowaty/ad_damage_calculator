using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzureDreamsDamageCalculator
{
    public partial class IdentifySpellDialog : Form
    {
        public IdentifySpellDialog()
        {
            InitializeComponent();
            Shown += (sender, e) => okButton.Focus();
        }
        public uint Charges
        {
            get
            { return (uint)chargesNumericUpDown.Value; }
            set
            { chargesNumericUpDown.Value = value; }
        }
        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
