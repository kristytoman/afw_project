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
                return;
            }

            entry.BackgroundColor = invalidColor;
        }

        /// <summary>
        /// Validates the email entry after unfocusing.
        /// </summary>
        /// <param name="sender">Email entry.</param>
        /// <param name="e"></param>
        private void Email_Unfocused(object sender, FocusEventArgs e)
        {
            Entry entry = (Entry)sender;
            Email email = new Email(entry.Text);
            ChangeEntry(entry, viewModel.Validate(email));
        }

        /// <summary>
        /// Validates the password entry after unfocusing.
        /// </summary>
        /// <param name="sender">Password entry.</param>
        /// <param name="e"></param>
        private void Password_Unfocused(object sender, FocusEventArgs e)
        {
            Entry entry = (Entry)sender;
            Password password = new Password(entry.Text);
            ChangeEntry(entry, viewModel.Validate(password));
        }

        /// <summary>
        /// Validates the firstName entry after unfocusing.
        /// </summary>
        /// <param name="sender">FirstName entry.</param>
        /// <param name="e"></param>
        private void Name_Unfocused(object sender, FocusEventArgs e)
        {
            Entry entry = (Entry)sender;
            ChangeEntry(entry, viewModel.Validate(entry.Text, Name.type_firstName));
        }

        /// <summary>
        /// Validates the lastName entry after unfocusing.
        /// </summary>
        /// <param name="sender">LastName entry.</param>
        /// <param name="e"></param>
        private void LastName_Unfocused(object sender, FocusEventArgs e)
        {
            Entry entry = (Entry)sender;
            ChangeEntry(entry, viewModel.Validate(entry.Text, Name.type_lastName));
        }

        /// <summary>
        /// Validates the phone entry after unfocusing.
        /// </summary>
        /// <param name="sender">Phone entry.</param>
        /// <param name="e"></param>
        private void Phone_Unfocused(object sender, FocusEventArgs e)
        {
            Entry entry = (Entry)sender;
            PhoneNumber phone = new PhoneNumber(entry.Text);
            ChangeEntry(entry, viewModel.Validate(phone));
        }

        /// <summary>
        /// Validates the street entry after unfocusing.
        /// </summary>
        /// <param name="sender">Street entry.</param>
        /// <param name="e"></param>
        private void Street_Unfocused(object sender, FocusEventArgs e)
        {
            Entry entry = (Entry)sender;
            ChangeEntry(entry, viewModel.Validate(entry.Text,Name.type_street));
        }

        /// <summary>
        /// Validates the building entry after unfocusing.
        /// </summary>
        /// <param name="sender">Building entry.</param>
        /// <param name="e"></param>
        private void Building_Unfocused(object sender, FocusEventArgs e)
        {
            Entry entry = (Entry)sender;
            Building building = new Building(entry.Text);
            ChangeEntry(entry, viewModel.Validate(building));
        }

        /// <summary>
        /// Validates the city entry after unfocusing.
        /// </summary>
        /// <param name="sender">City entry.</param>
        /// <param name="e"></param>
        private void City_Unfocused(object sender, FocusEventArgs e)
        {
            Entry entry = (Entry)sender;
            ChangeEntry(entry, viewModel.Validate(entry.Text,Name.type_city));
        }

        /// <summary>
        /// Validates the postalCode entry after unfocusing.
        /// </summary>
        /// <param name="sender">PostalCode entry.</param>
        /// <param name="e"></param>
        private void Code_Unfocused(object sender, FocusEventArgs e)
        {
            Entry entry = (Entry)sender;
            Number number = new Number(entry.Text);
            ChangeEntry(entry, viewModel.Validate(number));
        }
    }
}