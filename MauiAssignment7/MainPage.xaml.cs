using Newtonsoft.Json;

namespace MauiAssignment7
{
    public partial class MainPage : ContentPage
    {
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
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string fullFileName = Path.Combine(filePath, "myFile.txt");
            string userJson = JsonConvert.SerializeObject(user);
            File.WriteAllText(fullFileName, userJson);
        }

        public User LoadData()
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string fullFileName = Path.Combine(filePath, "myFile.txt");
            string fileContent = File.ReadAllText(fullFileName);
            User savedUser = JsonConvert.DeserializeObject<User>(fileContent);
            return savedUser;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            SaveData(CurrentUser);
        }
    }
}

