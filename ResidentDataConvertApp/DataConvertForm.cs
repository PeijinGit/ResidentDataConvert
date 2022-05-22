using Abstraction;
using Domain;
using Domain.Static;
using System.ComponentModel;

namespace ResidentDataConvertApp
{
    public partial class DataConvertForm : Form
    {
        private readonly IFileProcessor _fileProcessor;
        private readonly IFileCheck _fileCheck;
        private string _filePath;
        private string _destination;

        public DataConvertForm(IFileProcessor fileProcessor, IFileCheck fileCheck)
        {
            InitializeComponent();
            _fileProcessor = fileProcessor;
            _fileCheck = fileCheck;
        }

        private void targetFileButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = CommonValue.InitialDirectory;
                openFileDialog.Filter = CommonValue.Filter;
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    _filePath = openFileDialog.FileName;
                    SelectFiletextBox.Text = _filePath;
                }
            }
        }

        private void destinationButton_Click(object sender, EventArgs e)
        {
            if (desFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                _destination = desFolderBrowserDialog.SelectedPath;
                DestinationTextBox.Text = _destination;
            }
        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            DisableButton();
            try
            {
                if (string.IsNullOrEmpty(_filePath) || string.IsNullOrEmpty(_destination))
                {
                    MessageBox.Show(ErrorMessage.PathInvalid, ErrorMessage.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    EnableButton();
                    return;
                }

                CommonResponse commonResponse = _fileCheck.CheckFileExisting(_filePath);
                if (commonResponse.ErrorCode)
                {
                    MessageBox.Show(commonResponse.Message, ErrorMessage.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    EnableButton();
                    return;
                }

                progressWorker.RunWorkerAsync();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, ErrorMessage.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                EnableButton();
            }    
        }

        private void DataConvertForm_Load(object sender, EventArgs e)
        {

        }

        private void progressWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            _fileProcessor.ProcessFile(_filePath, _destination, worker);
            
        }

        private void progressWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) 
        {
            ProgressLabel.Text = e.ProgressPercentage.ToString()+"%";
        }

        private void progressWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message, ErrorMessage.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
              var resultBox =  MessageBox.Show(CommonValue.ConvertingComplete, CommonValue.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (resultBox == DialogResult.OK) 
                {
                    EnableButton();
                    ProgressLabel.Text = String.Empty;
                }
            }
        }

        private void DisableButton()
        {
            convertButton.Enabled = false;
            targetFileButton.Enabled = false;
            destinationButton.Enabled = false;
        }

        private void EnableButton()
        {
            convertButton.Enabled = true;
            targetFileButton.Enabled = true;
            destinationButton.Enabled = true;
        }
    }
}