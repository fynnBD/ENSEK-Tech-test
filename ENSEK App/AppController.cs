
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ENSEK_App
{
    public class AppController
    {
        private AppView View;

        private AppModel Model;

        private ENSEKResponse response;

        public AppController(AppView view)
        {
            this.View = view;
            InternalWireUpEvents();
            CreateModel();
        }

        private void InternalWireUpEvents()
        {
            View.UploadClicked += ViewInstance_UploadButtonClicked;
        }

        private void CreateModel()
        {
            Model = new AppModel();
            Model.SetupAPI();
        }


        private void ViewInstance_UploadButtonClicked(object sender, System.EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                FileName = "Select a csv file",
                Filter = "Text files (*.csv)|*.csv",
                Title = "Open csv file"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var response = Model.PostCSV(openFileDialog.FileName);
            }
        }

    }
}
