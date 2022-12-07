using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client._Patterns_Designs._Template_Pattern
{
    public sealed class ThreeCoinUpdate : LabelUpdater
    {
        public override void LabelText()
        {
            try
            {
                Form currentForm = Form.ActiveForm;
                if (currentForm != null)
                {
                    Label? t = currentForm.Controls["updateLabel"] as Label;
                    if (t != null)
                    {
                        t.Text = "You got three coins!";
                    }
                }
            }
            catch (NullReferenceException)
            {
                throw;
            }
        }
    }
}
