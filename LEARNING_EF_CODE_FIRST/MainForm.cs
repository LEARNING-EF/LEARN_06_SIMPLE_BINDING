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
					.Any();

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
					//databaseContext = null;
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
				// **************************************************

				// **************************************************
				//for (int index = 1; index <= 100; index++)
				//{
				//	Models.User newUser = new Models.User();

				//	newUser.Username = $"Username_{ index }";
				//	newUser.FullName = $"Full Name { index }";

				//	databaseContext.Users.Add(newUser);
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
					//databaseContext = null;
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

				////usersListBox.ValueMember = "Id";
				////usersListBox.DisplayMember = "FullName";

				//usersListBox.ValueMember = nameof(Models.User.Id);
				//usersListBox.DisplayMember = nameof(Models.User.FullName);

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
					//users =
					//	databaseContext.Users
					//	.Where(current => current.FullName.Contains(fullNameTextBox.Text))
					//	.OrderBy(current => current.FullName)
					//	.ToList()
					//	;

					users =
						databaseContext.Users
						.Where(current => current.FullName.ToLower().Contains(fullNameTextBox.Text.ToLower()))
						.OrderBy(current => current.FullName)
						.ToList()
						;
				}

				usersListBox.ValueMember = nameof(Models.User.Id);
				usersListBox.DisplayMember = nameof(Models.User.FullName);
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
					//databaseContext = null;
				}
			}
		}

		private void UsersListBox_DoubleClick(object sender, System.EventArgs e)
		{
			if (usersListBox.SelectedItem == null)
			{
				System.Windows.Forms.MessageBox.Show("You did not specify any item!");

				return;
			}

			// روش اول
			// روش ذیل احمقانه‌ترین روش می‌باشد
			//Models.User selectedUser =
			//	(Models.User)usersListBox.SelectedItem;

			// روش دوم
			//if (usersListBox.SelectedItem is Models.User)
			//{
			//	Models.User selectedUser =
			//		(Models.User)usersListBox.SelectedItem;
			//}

			// روش سوم
			// روش هوشمندانه
			//Models.User selectedUser =
			//	usersListBox.SelectedItem as Models.User;

			//if (selectedUser != null)
			//{
			//	string message =
			//		$"Full Name { selectedUser.FullName }\r\nUsername: { selectedUser.Username }";

			//	System.Windows.Forms.MessageBox.Show(message);
			//}

			// روش چهارم
			// روش هوشمندانه و مدرن
			if (usersListBox.SelectedItem is Models.User selectedUser)
			{
				//string message =
				//	$"Full Name { selectedUser.FullName }\r\nUsername: { selectedUser.Username }";

				string message =
					$"Full Name { selectedUser.FullName }{ System.Environment.NewLine }Username: { selectedUser.Username }";

				System.Windows.Forms.MessageBox.Show(message);
			}
		}
	}
}
