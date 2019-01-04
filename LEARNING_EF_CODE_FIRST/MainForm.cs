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
			Models.DatabaseContext databaseContext = null;

			try
			{
				databaseContext =
					new Models.DatabaseContext();

				// Solution (1)
				//var users =
				//	databaseContext.Users
				//	.ToList()
				//	;

				//if (users.Count != 0)
				//{
				//	generateTestDataButton.Enabled = false;
				//}
				// /Solution (1)

				// Solution (2)
				//int userCount =
				//	databaseContext.Users
				//	.Count()
				//	;

				//if (userCount != 0)
				//{
				//	generateTestDataButton.Enabled = false;
				//}
				// /Solution (2)

				// Solution (3)
				bool hasAny =
					databaseContext.Users
					.Any()
					;

				if (hasAny)
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
				if (databaseContext != null)
				{
					databaseContext.Dispose();
					databaseContext = null;
				}
			}
		}

		private void GenerateTestDataButton_Click(object sender, System.EventArgs e)
		{
			Models.DatabaseContext databaseContext = null;

			try
			{
				databaseContext =
					new Models.DatabaseContext();

				// **************************************************
				//for (int index = 1; index <= 100; index++)
				//{
				//	Models.User newUser = new Models.User();

				//	newUser.Username = $"Username_{ index }";
				//	newUser.FullName = $"Full Name { index }";

				//	databaseContext.Users.Add(newUser);

				//	// Note: Not Transactional!
				//	//databaseContext.SaveChanges();
				//}

				// Note: Transactional!
				//databaseContext.SaveChanges();
				// **************************************************

				// **************************************************
				for (int index = 1; index <= 100; index++)
				{
					Models.User newUser = new Models.User
					{
						Username = $"Username_{ index }",
						FullName = $"Full Name { index }",
					};

					databaseContext.Users.Add(newUser);
				}

				databaseContext.SaveChanges();
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

		private void DisplayDataButton_Click(object sender, System.EventArgs e)
		{
			Models.DatabaseContext databaseContext = null;

			try
			{
				databaseContext =
					new Models.DatabaseContext();

				// Solution (1) - Unbind
				//var users =
				//	databaseContext.Users
				//	.OrderBy(current => current.FullName)
				//	.ToList()
				//	;

				//foreach (var user in users)
				//{
				//	string text = user.FullName;

				//	usersListBox.Items.Add(text);
				//}
				// /Solution (1) - Unbind

				// Solution (2) - Bind
				//var users =
				//	databaseContext.Users
				//	.OrderBy(current => current.FullName)
				//	.ToList()
				//	;

				//usersListBox.ValueMember = "Id";
				//usersListBox.DisplayMember = "FullName";
				//usersListBox.DataSource = users;
				// /Solution (2) - Bind

				// Solution (3) - Bind
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
				// /Solution (3) - Bind
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

		private void UsersListBox_DoubleClick(object sender, System.EventArgs e)
		{
			Models.User selectedUser =
				usersListBox.SelectedItem as Models.User;

			if (selectedUser != null)
			{
				string strUserInfo =
					"Full Name: " + selectedUser.FullName +
					System.Environment.NewLine +
					"Username: " + selectedUser.Username
					//System.Environment.NewLine +
					//"Password: " + oSelectedUser.Password +
					//System.Environment.NewLine +
					//"Email Address: " + oSelectedUser.EmailAddress
					;

				System.Windows.Forms.MessageBox.Show(strUserInfo);
			}
		}
	}
}
