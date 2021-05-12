using GestorPasswordsDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordsManagerUserInterface
{
    public partial class ModifyUserPasswordPairExposedInDataBreaches : UserControl
    {
        public PasswordManager PasswordManager { get; private set; }
        public Panel PnlMainWindow { get; private set; }
        public UserPasswordPairForm Form { get; private set; }
        public UserPasswordPair PasswordToModified { get; private set; }
        public IDataBreachesFormatter DataBreaches { get; private set; }
        public ModifyUserPasswordPairExposedInDataBreaches(PasswordManager aPasswordManager, Panel panel, UserPasswordPair password, IDataBreachesFormatter dataBreaches)
        {
            InitializeComponent();
            PasswordManager = aPasswordManager;
            PnlMainWindow = panel;
            PasswordToModified = password;
            DataBreaches = dataBreaches;
            LoadUserPasswordPairForm(password);
        }

        private void LoadUserPasswordPairForm(UserPasswordPair passwordToModified)
        {
            pnlModifyUserPasswordPair.Controls.Clear();
            Form = new UserPasswordPairForm(PasswordManager, passwordToModified);
            pnlModifyUserPasswordPair.Controls.Add(Form);
        }

        public void ModifyPassword()
        {
            UserPasswordPair newPassword = CreatePassword();
            PasswordToModified.Category.ModifyUserPasswordPair(PasswordToModified, newPassword);
            GoBack();
        }

        private UserPasswordPair CreatePassword()
        {
            NormalCategory category = Form.GetCategory();
            string site = Form.GetSite();
            string username = Form.GetUsername();
            string password = Form.GetPassword();
            string notes = Form.GetNotes();

            UserPasswordPair userPasswordPair = new UserPasswordPair()
            {
                Category = category,
                Site = site,
                Username = username,
                Password = password,
                Notes = notes
            };

            return userPasswordPair;
        }
        private void GoBack()
        {
            PnlMainWindow.Controls.Clear();
            UserControl dataBreaches = new DataBreachesResult(PasswordManager, PnlMainWindow, DataBreaches);
            PnlMainWindow.Controls.Add(dataBreaches);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            GoBack();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            PnlMainWindow.Controls.Clear();
            UserControl menu = new Menu(PasswordManager, PnlMainWindow);
            PnlMainWindow.Controls.Add(menu);
        }

        private void btnAccept_Click_1(object sender, EventArgs e)
        {
            try
            {
                ModifyPassword();
            }
            catch (ExceptionExistingUserPasswordPair exception)
            {
                MessageBox.Show(exception.Message, "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExceptionUserPasswordPairHasInvalidUsernameLength exception)
            {
                MessageBox.Show(exception.Message, "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExceptionUserPasswordPairHasInvalidPasswordLength exception)
            {
                MessageBox.Show(exception.Message, "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExceptionUserPasswordPairHasInvalidSiteLength exception)
            {
                MessageBox.Show(exception.Message, "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExceptionUserPasswordPairHasInvalidNotesLength exception)
            {
                MessageBox.Show(exception.Message, "An error has occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
