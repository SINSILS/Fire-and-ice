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
            Form currentForm = Form.ActiveForm;
            try
            {
                if (currentForm != null)
                {
                    Label? t = currentForm.Controls["updateLabel"] as Label;
                    if (t != null)
                    {
                        t.Visible = true;
                    }
                }
            }

            catch (NullReferenceException)
            {
                //?
            }
        }

        private async void HideLabel()
        {
            Form currentForm = Form.ActiveForm;
            if (currentForm != null)
            {
                try
                {
                    Label? t = currentForm.Controls["updateLabel"] as Label;
                    if (t != null)
                    {
                        await Task.Delay(3000);
                        t.Visible = false;
                    }

                }
                catch (NullReferenceException)
                {
                    //?
                }
            }
        }
    }
}


