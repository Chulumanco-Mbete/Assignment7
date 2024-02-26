using Newtonsoft.Json;

namespace MauiAssignment7
{
    public partial class MainPage : ContentPage
    {
        public string fullFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "myFile.txt");

        private User _user;
        public User CurrentUser
        {
            get { return _user; }
            set { _user = value;
            OnPropertyChanged();}           
        }

        public MainPage()
        {
            InitializeComponent();
            CurrentUser = LoadData();
            BindingContext = this;
        }

        public void SaveData(User user)
        {
            //string filePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            //string fullFileName = Path.Combine(filePath, "myFile.txt");
            if (File.Exists(fullFileName))
            {
                string userJson = JsonConvert.SerializeObject(user);
                File.WriteAllText(fullFileName, userJson);
            }
            else new User();
        }

        public User LoadData()
        {
            //string filePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            //string fullFileName = Path.Combine(filePath, "myFile.txt");
            if (File.Exists(fullFileName))
            {
                string fileContent = File.ReadAllText(fullFileName);
                User savedUser = JsonConvert.DeserializeObject<User>(fileContent);
                return savedUser;
            }
            else return new User();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //string filePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            //string fullFileName = Path.Combine(filePath, "myFile.txt");
            SaveData(CurrentUser);
            if (File.Exists(fullFileName))
            {
                DisplayAlert("Alert", "User account saved.", "OK");
            }
            else 
            {
                DisplayAlert("Alert", "User account not saved.", "OK");
            }
        }
    }
}

