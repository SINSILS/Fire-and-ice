namespace Client._Patterns_Designs._Template_Pattern
{
    public abstract class LabelUpdater
    {
        public abstract void LabelText();

        public void Update()
        {
            ShowLabel();
            LabelText();
            HideLabel();
        }

        private void ShowLabel()
        {
            try
            {
                Form currentForm = Form.ActiveForm;

                if (currentForm != null)
                {
                    Label? t = currentForm.Controls["updateLabel"] as Label;
                    if (t != null)
                    {
                        t.Visible = true;
                    }
                }
            }
            catch(NullReferenceException)
            {
                throw;
            }
        }

        private async void HideLabel()
        {
            try
            {
                Form currentForm = Form.ActiveForm;
                if (currentForm != null)
                {
                    Label? t = currentForm.Controls["updateLabel"] as Label;
                    if (t != null)
                    {
                        await Task.Delay(3000);
                        t.Visible = false;
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


