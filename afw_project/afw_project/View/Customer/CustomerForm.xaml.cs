using afw_project.View_Model;
using afw_project.Model.Validation.Objects;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace afw_project.View.Customer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomerForm : ContentPage
    {
        /// <summary>
        /// Color for valid entry.
        /// </summary>
        readonly Color validColor = Color.Green;

        /// <summary>
        /// Color for invalid entry.
        /// </summary>
        readonly Color invalidColor = Color.Red;

        /// <summary>
        /// View-model for the sign up page.
        /// </summary>
        readonly VM_CustomerForm viewModel;

       


        /// <summary>
        /// Initializing new Sign Up page.
        /// </summary>
        public CustomerForm(bool isSignUp)
        {
            InitializeComponent();

            /// Creates and binds the view-model.
            viewModel = new VM_CustomerForm(isSignUp);
            BindingContext = viewModel;
        }

        /// <summary>
        /// Changes the style of an entry.
        /// </summary>
        /// <param name="entry">Entry to change style.</param>
        /// <param name="valid">State of input value.</param>
        private void ChangeEntry(Entry entry, bool valid)
        {
            if (valid)
            {
                entry.BackgroundColor = validColor;
            }
            else
            {
                entry.BackgroundColor = invalidColor;
            }
        }



        /// <summary>
        /// Validates the email entry after unfocusing.
        /// </summary>
        /// <param name="sender">Email entry.</param>
        /// <param name="e"></param>
        private void Email_Unfocused(object sender, FocusEventArgs e)
        {
            Entry entry = (Entry)sender;
            ChangeEntry(entry, viewModel.Validate(new Email(entry.Text)));
        }



        /// <summary>
        /// Validates the password entry after unfocusing.
        /// </summary>
        /// <param name="sender">Password entry.</param>
        /// <param name="e"></param>
        private void Password_Unfocused(object sender, FocusEventArgs e)
        {
            Entry entry = (Entry)sender;
            if (viewModel.isSignUp || (entry.Text != string.Empty && entry.Text!=null)) 
            {
                ChangeEntry(entry, viewModel.Validate(new Password(entry.Text, viewModel.isSignUp)));
            }
        }



        /// <summary>
        /// Validates the firstName entry after unfocusing.
        /// </summary>
        /// <param name="sender">FirstName entry.</param>
        /// <param name="e"></param>
        private void Name_Unfocused(object sender, FocusEventArgs e)
        {
            Entry entry = (Entry)sender;
            ChangeEntry(entry, viewModel.Validate(new Name(entry.Text)));
        }



        /// <summary>
        /// Validates the lastName entry after unfocusing.
        /// </summary>
        /// <param name="sender">LastName entry.</param>
        /// <param name="e"></param>
        private void LastName_Unfocused(object sender, FocusEventArgs e)
        {
            Entry entry = (Entry)sender;
            ChangeEntry(entry, viewModel.Validate(new Surname(entry.Text)));
        }



        /// <summary>
        /// Validates the phone entry after unfocusing.
        /// </summary>
        /// <param name="sender">Phone entry.</param>
        /// <param name="e"></param>
        private void Phone_Unfocused(object sender, FocusEventArgs e)
        {
            Entry entry = (Entry)sender;
            ChangeEntry(entry, viewModel.Validate(new PhoneNumber(entry.Text)));
        }



        /// <summary>
        /// Validates the street entry after unfocusing.
        /// </summary>
        /// <param name="sender">Street entry.</param>
        /// <param name="e"></param>
        private void Street_Unfocused(object sender, FocusEventArgs e)
        {
            Entry entry = (Entry)sender;
            ChangeEntry(entry, viewModel.Validate(new StreetName(entry.Text)));
        }



        /// <summary>
        /// Validates the building entry after unfocusing.
        /// </summary>
        /// <param name="sender">Building entry.</param>
        /// <param name="e"></param>
        private void Building_Unfocused(object sender, FocusEventArgs e)
        {
            Entry entry = (Entry)sender;
            ChangeEntry(entry, viewModel.Validate(new Building(entry.Text)));
        }



        /// <summary>
        /// Validates the city entry after unfocusing.
        /// </summary>
        /// <param name="sender">City entry.</param>
        /// <param name="e"></param>
        private void City_Unfocused(object sender, FocusEventArgs e)
        {
            Entry entry = (Entry)sender;
            ChangeEntry(entry, viewModel.Validate(new CityName(entry.Text)));
        }



        /// <summary>
        /// Validates the postalCode entry after unfocusing.
        /// </summary>
        /// <param name="sender">PostalCode entry.</param>
        /// <param name="e"></param>
        private void Code_Unfocused(object sender, FocusEventArgs e)
        {
            Entry entry = (Entry)sender;
            ChangeEntry(entry, viewModel.Validate(new PostalCode(entry.Text)));
        }



        /// <summary>
        /// Validates the country input after changing the selected index.
        /// </summary>
        /// <param name="sender">Picker of the country.</param>
        /// <param name="e"></param>
        private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Picker picker = sender as Picker;
            viewModel.Validate(new Country(picker.SelectedItem.ToString()));
        }
    }
}