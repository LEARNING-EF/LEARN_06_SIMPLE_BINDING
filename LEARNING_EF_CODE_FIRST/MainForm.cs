using System.Linq;

namespace LEARNING_EF_CODE_FIRST
{
	public partial class MainForm : System.Windows.Forms.Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, System.EventArgs e)
		{
			Models.DatabaseContext oDatabaseContext = null;

			try
			{
				oDatabaseContext =
					new Models.DatabaseContext();

				// Solution (1)
				//var varUsers =
				//	oDatabaseContext.Users
				//	.ToList()
				//	;

				//if (varUsers.Count != 0)
				//{
				//	generateTestDataButton.Enabled = false;
				//}
				// /Solution (1)

				// Solution (2)
				//int intUserCount =
				//	oDatabaseContext.Users
				//	.Count()
				//	;

				//if (intUserCount != 0)
				//{
				//	generateTestDataButton.Enabled = false;
				//}
				// /Solution (2)

				// Solution (3)
				bool blnHasAny =
					oDatabaseContext.Users
					.Any()
					;

				if (blnHasAny)
				{
					generateTestDataButton.Enabled = false;
				}
				// /Solution (3)
			}
			catch (System.Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}
			finally
			{
				if (oDatabaseContext != null)
				{
					oDatabaseContext.Dispose();
					oDatabaseContext = null;
				}
			}
		}

		private void generateTestDataButton_Click(object sender, System.EventArgs e)
		{
			Models.DatabaseContext databaseContext = null;

			try
			{
				databaseContext =
					new Models.DatabaseContext();

				// **************************************************
				for (int index = 1; index <= 100; index++)
				{
					Models.User newUser = new Models.User();

					newUser.Password = "1234512345";
					newUser.Username = $"Username_{ index }";
					newUser.FullName = $"Full Name { index }";
					newUser.EmailAddress = $"User_{ index }@GMail.com";

					databaseContext.Users.Add(newUser);
				}

				databaseContext.SaveChanges();
				// **************************************************

				// **************************************************
				//for (int index = 1; index <= 100; index++)
				//{
				//	Models.User newUser = new Models.User();

				//	newUser.Password = "1234512345";
				//	newUser.Username = $"Username_{ index }";
				//	newUser.FullName = $"Full Name { index }";
				//	newUser.EmailAddress = $"User_{ index }@GMail.com";

				//	databaseContext.Users.Add(newUser);

				//	databaseContext.SaveChanges();
				//}
				// **************************************************

				generateTestDataButton.Enabled = false;

				System.Windows.Forms.MessageBox.Show("Data has been generated!");
			}
			catch (System.Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}
			finally
			{
				if (databaseContext != null)
				{
					databaseContext.Dispose();
					databaseContext = null;
				}
			}
		}

		private void displayDataButton_Click(object sender, System.EventArgs e)
		{
			Models.DatabaseContext databaseContext = null;

			try
			{
				databaseContext =
					new Models.DatabaseContext();

				// Solution (1)
				//var users =
				//	databaseContext.Users
				//	.OrderBy(current => current.FullName)
				//	.ToList()
				//	;

				//usersListBox.ValueMember = "Id";
				//usersListBox.DisplayMember = "FullName";
				//usersListBox.DataSource = users;
				// /Solution (1)

				// Solution (2)
				//var users; // Compile Error!
				//var users = null; // Compile Error!
				System.Collections.Generic.List<Models.User> users = null;

				if (string.IsNullOrWhiteSpace(fullNameTextBox.Text))
				{
					users =
						databaseContext.Users
						.OrderBy(current => current.FullName)
						.ToList()
						;
				}
				else
				{
					users =
						databaseContext.Users
						.Where(current => current.FullName.Contains(fullNameTextBox.Text))
						.OrderBy(current => current.FullName)
						.ToList()
						;
				}

				usersListBox.ValueMember = "Id";
				usersListBox.DisplayMember = "FullName";
				usersListBox.DataSource = users;
				// /Solution (2)
			}
			catch (System.Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}
			finally
			{
				if (databaseContext != null)
				{
					databaseContext.Dispose();
					databaseContext = null;
				}
			}
		}

		private void usersListBox_DoubleClick(object sender, System.EventArgs e)
		{
			Models.User oSelectedUser =
				usersListBox.SelectedItem as Models.User;

			if (oSelectedUser != null)
			{
				string strUserInfo =
					"Full Name: " + oSelectedUser.FullName +
					System.Environment.NewLine +
					"Username: " + oSelectedUser.Username +
					System.Environment.NewLine +
					"Password: " + oSelectedUser.Password +
					System.Environment.NewLine +
					"Email Address: " + oSelectedUser.EmailAddress
					;

				System.Windows.Forms.MessageBox.Show(strUserInfo);
			}
		}
	}
}
