using Microsoft.Win32;
using Timer = System.Windows.Forms.Timer;

namespace MementoMori
{
    public partial class DeadManSwitch : Form
    {
        private Timer timer;
        private Boolean unlocked = false;
        private String code;
        private DateTime formOpenedTime;

        public DeadManSwitch()
        {
            InitializeComponent();
            SetCode();
            this.TopMost = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            SetupTimer();
            this.FormClosing += OnFormClosing;
            formOpenedTime = DateTime.Now;
            UpdateTitleTimer();

            // Get the working area of the screen (excluding taskbars and other docked windows)
            Rectangle workingArea = Screen.GetWorkingArea(this);

            // Set the form's location to the bottom-right corner with a 100-pixel margin
            this.Location = new Point(workingArea.Right - this.Width - 100, workingArea.Bottom - this.Height - 100);
        }

        private void SetCode()
        {
            // Get the path to the user's home directory
            string homeDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            // Combine the home directory path and the filename to get the full path to the file
            string filePath = Path.Combine(homeDir, "mementomori.txt");

            // Check if the file exists
            if (File.Exists(filePath))
            {
                // Read the contents of the file
                string contents = File.ReadAllText(filePath);

                // Set the variable on the form class
                code = contents;
            }
            else
            {
                // File does not exist
                MessageBox.Show("File not found: " + filePath);
            }
        }

        private void UpdateTitleTimer()
        {
            timer = new Timer
            {
                Interval = 1000 // 1000 milliseconds = 1 second
            };

            timer.Tick += UpdateTitle;
            timer.Start();
        }

        private void UpdateTitle(object sender, EventArgs e)
        {
            TimeSpan elapsedTime = DateTime.Now - formOpenedTime;
            int roundedSeconds = (int)Math.Ceiling(elapsedTime.TotalSeconds);
            this.Text = $"Memento Mori Guard: {roundedSeconds}s";
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            // Your custom function to execute when the form is closing
            CarpeDiem();
        }

        private void OnTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Unlock();
            }
        }

        private void Unlock()
        {
            if (code == codeBox.Text)
            {
                unlocked = true;
                Application.Exit();
            }
        }

        private void CarpeDiem()
        {
            if (unlocked)
            {
                return;
            }

            string homeDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string mementoListPath = Path.Combine(homeDir, "mementolist.txt");
            string mementoCodePath = Path.Combine(homeDir, "mementomori.txt");

            if (!File.Exists(mementoListPath))
            {
                MessageBox.Show("Memento list file not found: " + mementoListPath);
                return;
            }

            string[] lines = File.ReadAllLines(mementoListPath);
            List<string> foldersToDelete = new List<string>(lines);

            foreach (string folderPath in foldersToDelete)
            {
                try
                {
                    if (Directory.Exists(folderPath))
                    {
                        Directory.Delete(folderPath, true);
                    }
                }
                catch (IOException ex)
                {
                    // do nothing
                }
            }

            // Delete the memento list file
            try
            {
                File.Delete(mementoListPath);
                File.Delete(mementoCodePath);
            }
            catch (IOException ex)
            {
                // Handle the exception, e.g. log it or display an error message
            }

            MessageBox.Show("Memento Mori, et carpe diem.");
        }

        private void SetupTimer()
        {
            timer = new Timer
            {
                Interval = 20000
            };
            timer.Tick += OnTimerTick;
            timer.Start();
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            timer.Stop();
            // Implement your desired action here, but avoid deleting data or causing harm.
            Application.Exit();
        }

        private void OnUnlockClick(object sender, EventArgs e)
        {
            Unlock();
        }
    }
}