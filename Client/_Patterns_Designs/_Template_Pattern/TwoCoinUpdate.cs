using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client._Patterns_Designs._Template_Pattern
{
    public sealed class TwoCoinUpdate : LabelUpdater
    {
        public override void LabelText()
        {
            Form currentForm = Form.ActiveForm;
                Label? t = currentForm.Controls["updateLabel"] as Label;
                if (t != null)
                {
                    t.Text = "You got two coins!";
                }
        }
    }
}
