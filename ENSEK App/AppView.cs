using System;
using System.Windows.Forms;

namespace ENSEK_App
{
    public partial class AppView : Form
    {
        public event EventHandler UploadClicked;

        public BindingSource EnsekBindingSource => this.eNSEKResponseBindingSource;
        public BindingSource EnsekOtherBindingSource => this.eNSEKOTHERResponseBindingSource;

        protected AppController Controller;
        public AppView()
        {
            InitializeComponent();
            uploadButton.Click += (sender, e) => RaiseEvent(UploadClicked, sender, e);

            SetController();
        }

        private void SetController()
        {
            Controller = new AppController(this);
        }

        protected void RaiseEvent(EventHandler methodDelegate, object sender, EventArgs e)
        {
            if (methodDelegate != null)
            {
                methodDelegate.Invoke(sender, e);
            }
        }
    }
}
