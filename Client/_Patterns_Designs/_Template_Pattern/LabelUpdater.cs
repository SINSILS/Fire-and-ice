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
            Label? t = currentForm.Controls["updateLabel"] as Label;
            if (t != null)
            {
                t.Visible = true;
            }
        }

        private async void HideLabel()
        {
            Form currentForm = Form.ActiveForm;
            Label? t = currentForm.Controls["updateLabel"] as Label;
            if (t != null)
            {
                await Task.Delay(3000);
                t.Visible = false;
            }
        }
    }
}


