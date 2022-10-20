namespace Kanban_Duc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        /* Variables */

        // Used to Store the Mouse Location on the Screen when Button is Clicked
        private Point mouseDownLocation;

        // Used to know if the Button can be Moved.
        private bool isMoveable = false;

        // Used to prevent clicking the button when being dragged
        private bool clickEnabled = true;



        /// <summary> Occurrs when the visible button on the Form is clicked. </summary>


        /* Custom Button : Create & Configure the Button */
        private void CreateButton(string btnText)
        {
            // Create the Button instance:
            Button btn = new Button();
            btn.AutoSize = true;
            // Custom Button Style Configuration Code.
            // i.e: FlatStyle; FlatAppearance; BackColor; ForeColor; Text; Size; Location; etc...
            btn.FlatStyle = FlatStyle.Standard;
            btn.FlatAppearance.BorderColor = Color.White;
            btn.BackColor = Color.Purple;
            btn.ForeColor = Color.White;
            btn.Text = btnText;
            btn.Location = new Point(100, 100);

            // Custom Button Event.
            btn.Click += new EventHandler(CustomButton_Click);
            btn.MouseDown += new MouseEventHandler(CustomButton_MouseDown);
            btn.MouseMove += new MouseEventHandler(CustomButton_MouseMove);
            btn.MouseUp += new MouseEventHandler(CustomButton_MouseUp);

            // Add Button to Control Collection.
            Controls.Add(btn);

            // Show Button.
            btn.Show();
        }


        /* Custom Button Events */

        /// <summary> Occurrs whenever the Custom Button is Clicked </summary>
        private void CustomButton_Click(object sender, EventArgs e)
        {
            if (clickEnabled)
            {
                // Note: The "for" loop bellow lets you get the current button; so you can drag it.

                Button btn = (Button)sender;

                // Iterate over the Form Controls
                for (int i = 0; i < Controls.Count; i++)
                {
                    // If the Button Clicked Corresponds to a Found Index in Control Collection...
                    if (i == Controls.IndexOf(btn))
                    {
                        // Perform Corresponding Button Action.
                        MessageBox.Show(btn.Name + " Clicked!");
                    }
                }
            }
        }

        /// <summary> Occurrs whenever Left Mouse Button Clicks the Button and is Kept Down. </summary>
        private void CustomButton_MouseDown(object sender, MouseEventArgs e)
        {
            // Check if Left Mouse Button is Clicked.
            if (e.Button == MouseButtons.Left)
            {
                // Set mouseDownLocation (Point) variable, according to the current mouse location (X and Y).
                mouseDownLocation = e.Location;

                // Enable the hability to move the Button.
                isMoveable = true;
            }
        }

        /// <summary> Occurrs whenever Left Mouse Button is Down and Mouse is Moving the Button. </summary>
        private void CustomButton_MouseMove(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;

            // If the hability to move the button is "true" and the mouse button used to drag the button is the left mouse button:
            if (isMoveable)
            {
                if (e.Button == MouseButtons.Left)
                {
                    // Set the Button location X and Y...
                    btn.Left = e.X + btn.Left - mouseDownLocation.X;
                    btn.Top = e.Y + btn.Top - mouseDownLocation.Y;
                }
            }

            // Disable Click hability (See: Note at the end of this post).
            clickEnabled = false;
        }

        /// <summary> Occurrs whenever Left Mouse Button is not longer being hold down (Left Mouse Button is Up). </summary>
        private void CustomButton_MouseUp(object sender, MouseEventArgs e)
        {
            // Disables the hability to move the button
            isMoveable = false;
            clickEnabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Size size = new Size(200,30);
            String box_text = textBox1.Text;
            // Create the Button. Specifying the Button Text and its Size.
            CreateButton(box_text);
            textBox1.Text = "";
        }

        
    }
}