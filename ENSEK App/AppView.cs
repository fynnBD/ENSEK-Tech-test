using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ENSEK_App
{
    public partial class AppView : Form
    {
        public Button UploadButton => uploadButton;

        public event EventHandler UploadClicked;

        protected AppController controller;
        public AppView()
        {
            InitializeComponent();
            uploadButton.Click += (sender, e) => RaiseEvent(UploadClicked, sender, e);


            SetController();
        }

        private void SetController()
        {
            controller = new AppController(this);
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
