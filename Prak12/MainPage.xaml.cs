using Newtonsoft.Json;

namespace Prak12
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }


        bool isEdit = false;
        private int indexNoteBook = -1;

        private void OnSaveClicked(object sender, EventArgs e)
        {
            if (isEdit)
            {
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "noteBooks.json");
                string updatejson = File.ReadAllText(filePath);
                List<NoteBook> existingNoteBook = new List<NoteBook>();
                existingNoteBook = JsonConvert.DeserializeObject<List<NoteBook>>(updatejson);
                NoteBook editedNoteBook = existingNoteBook[indexNoteBook];

                editedNoteBook.Name = entrName.Text;
                editedNoteBook.PhoneNumber = int.Parse(entrNumber.Text);
                editedNoteBook.Address = entrAddress.Text;
                editedNoteBook.Gender = entrGender.Text;  
                editedNoteBook.Nationality = entrNationality.Text;



                string updatedJson = JsonConvert.SerializeObject(existingNoteBook);
                File.WriteAllText(filePath, updatedJson);
                isEdit = false;
            }
            else
            {
                NoteBook newCountry = new NoteBook
                {
                    Address = entrAddress.Text,
                    Name = entrName.Text,
                    PhoneNumber = int.Parse(entrNumber.Text),
                    Gender = entrGender.Text,
                    Nationality = entrNationality.Text,
                };

                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "noteBooks.json");
                List<NoteBook> existingNoteBook = new List<NoteBook>();

                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    existingNoteBook = JsonConvert.DeserializeObject<List<NoteBook>>(json);
                }

                existingNoteBook.Add(newCountry);

                string updatedJson = JsonConvert.SerializeObject(existingNoteBook);
                File.WriteAllText(filePath, updatedJson);

                entrAddress.Text = string.Empty;
                entrName.Text = string.Empty;
                entrNumber.Text = string.Empty; 
                entrGender.Text = string.Empty;
                entrNationality.Text = entrNationality.Text;
            }
        }

        private void goToListViewClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListView());
        }

        public void Edit(NoteBook noteBook, int index)
        {
            entrName.Text = noteBook.Name;
            entrNumber.Text = Convert.ToString(noteBook.PhoneNumber);
            entrAddress.Text = Convert.ToString(noteBook.Address);
            entrGender.Text= noteBook.Gender;
            entrNationality.Text= noteBook.Nationality;
            isEdit = true;
            indexNoteBook = index;

        }

    }
    public class NoteBook
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public string Gender { get;set; }
        public string Nationality { get; set; }
    }
}
