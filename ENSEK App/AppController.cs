using System;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ENSEK_App
{
    public class AppController
    {
        private readonly AppView View;

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

        private void InternalBindLists()
        {
            if (this.response != null)
            {
                View.EnsekBindingSource.RaiseListChangedEvents = true;
                View.EnsekBindingSource.DataSource = response.GetKeyValuePairs();
                View.EnsekBindingSource.ResetBindings(false);

                View.EnsekOtherBindingSource.RaiseListChangedEvents = true;
                View.EnsekOtherBindingSource.DataSource = response;
                View.EnsekOtherBindingSource.ResetBindings(false);
            }
        }

        private void CreateModel()
        {
            Model = new AppModel();
            Model.SetupApi();
        }


        private void ViewInstance_UploadButtonClicked(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                FileName = "Select a csv file",
                Filter = @"Text files (*.csv)|*.csv",
                Title = @"Open csv file"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var result = Model.PostCsv(openFileDialog.FileName).Result;
                UpdatePreparedResponse(result);
                InternalBindLists();
            }
        }

        private void UpdatePreparedResponse(string result)
        {
            this.response = JsonConvert.DeserializeObject<ENSEKResponse>(result);
        }
    }
}
