using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client._Patterns_Designs._Visitor_Pattern;

namespace Client._Patterns_Designs._Template_Pattern
{
    public sealed class ThreeCoinUpdate : LabelUpdater
    {
        public override void LabelText(string text)
        {
            try
            {
                Form currentForm = Form.ActiveForm;
                if (currentForm != null)
                {
                    Label? t = currentForm.Controls["updateLabel"] as Label;
                    if (t != null)
                    {
                        t.Text = text;
                    }
                }
            }
            catch (NullReferenceException)
            {
                throw;
            }
        }

        public override string Accept(Visitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
