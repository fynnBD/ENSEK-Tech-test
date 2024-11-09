
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ENSEK_App
{
    public class AppController
    {
        private AppView View;

        private AppModel Model;

        public ENSEKResponse response = new ENSEKResponse();

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
                var response = Model.PostCSV(openFileDialog.FileName).Result;
                UpdatePreparedResponse(response);
            }
        }

        private void UpdatePreparedResponse(string response)
        {
            var outt = JsonConvert.DeserializeObject<ENSEKResponse>(response);

        }


    }
}
