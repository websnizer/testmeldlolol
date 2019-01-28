using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.AccountManagement;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationCAI
{
	public partial class Connection : Form
	{
		//Colors
		Color mainColor = Color.FromArgb(255, 97, 0);
		Color offColor = Color.FromArgb(255, 133, 59);
		Color darkColor = Color.FromArgb(25, 25, 25);

		//Constructeur
		public Connection()
		{
			InitializeComponent();
		}







		// Interface Design //
		private System.Drawing.Point newpoint;
		private int x, y;
		private void CharForm_Load(object sender, EventArgs e)
		{
			this.BackColor = darkColor;
			pct_Bigger.BackColor = mainColor;
			pct_Close.BackColor = mainColor;
			pct_Icon.BackColor = mainColor;
			pct_Minimize.BackColor = mainColor;
			top.BackColor = mainColor;
			//Positionnement des icones de la barre de navigation
			pct_Close.Left = this.Width - 30;
			pct_Minimize.Left = this.Width - 60;
			PositionningLines();
		}//Form Load
		private void CharForm_Resize(object sender, EventArgs e)
		{
			//Repositionner les icones de la barre de navigation lors d'un resize de la form
			pct_Close.Left = this.Width - 30;
			pct_Minimize.Left = this.Width - 60;
			PositionningLines();
		}//Resize
		 //Lignes
		private void PositionningLines()
		{
			//Positionner les lignes qui délimitent la fenêtre
			LeftLine.BackColor = mainColor;
			LeftLine.Left = 0;
			LeftLine.Top = 0;
			LeftLine.Height = this.Height;
			LeftLine.Width = 1;

			RightLine.BackColor = mainColor;
			RightLine.Left = this.Width - 1;
			RightLine.Top = 0;
			RightLine.Height = this.Height;
			RightLine.Width = 1;

			TopLine.BackColor = mainColor;
			TopLine.Left = 0;
			TopLine.Top = 0;
			TopLine.Width = this.Width;
			TopLine.Height = 1;

			BottomLine.BackColor = mainColor;
			BottomLine.Left = 0;
			BottomLine.Top = this.Height - 1;
			BottomLine.Width = this.Width;
			TopLine.Height = 1;

		}
		//Barre TOP
		private void top_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				newpoint = Control.MousePosition;
				newpoint.X -= (x);
				newpoint.Y -= (y);
				this.Location = newpoint;
			}
		}//MouseMove TOP
		private void pct_Close_Click(object sender, EventArgs e)
		{
			Close();
		}//Close
		private void pct_Bigger_Click(object sender, EventArgs e)
		{
			this.WindowState = (this.WindowState == FormWindowState.Normal) ? FormWindowState.Maximized : FormWindowState.Normal;
		}//Bigger
		private void pct_Minimize_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}//Minimize
		private void pct_Icon_Click(object sender, EventArgs e)
		{
			mnu_main.Show(this, pct_Icon.Location.X, pct_Icon.Location.Y + 25);
		}//Menu Icone
		private void top_MouseDown(object sender, MouseEventArgs e)
		{
			x = Control.MousePosition.X - this.Location.X;
			y = Control.MousePosition.Y - this.Location.Y;
		}//Déplacement de la fenêtre
		private void title_MouseDown(object sender, MouseEventArgs e)
		{
			x = Control.MousePosition.X - this.Location.X;
			y = Control.MousePosition.Y - this.Location.Y;
		}//Déplacement de la fenêtre
		private void top_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			this.WindowState = (this.WindowState == FormWindowState.Normal) ? FormWindowState.Maximized : FormWindowState.Normal;
		}//Bigger lors d'un double click
		private void pct_Minimize_MouseLeave(object sender, EventArgs e)
		{
			pct_Minimize.Image = global::ApplicationCAI.Properties.Resources.underscore;
			pct_Minimize.BackColor = mainColor;
		}//Minimize Hover
		private void pct_Minimize_MouseMove(object sender, MouseEventArgs e)
		{
			pct_Minimize.Image = global::ApplicationCAI.Properties.Resources.underscore2;
			pct_Minimize.BackColor = offColor;
		}//Minimize Hover
		private void pct_Bigger_MouseLeave(object sender, EventArgs e)
		{
			pct_Bigger.Image = global::ApplicationCAI.Properties.Resources.ss;
			pct_Bigger.BackColor = mainColor;
		}//Bigger Hover
		private void pct_Bigger_MouseMove(object sender, MouseEventArgs e)
		{
			pct_Bigger.Image = global::ApplicationCAI.Properties.Resources.ss2;
			pct_Bigger.BackColor = offColor;
		}//Bigger Hover
		private void pct_Close_MouseLeave(object sender, EventArgs e)
		{
			pct_Close.Image = global::ApplicationCAI.Properties.Resources.xx;
			pct_Close.BackColor = mainColor;
		}//Close Hover
		private void pct_Close_MouseMove(object sender, MouseEventArgs e)
		{
			pct_Close.Image = global::ApplicationCAI.Properties.Resources.xx2;
			pct_Close.BackColor = Color.Red;
		}//Close Hover
		private void pct_Icon_MouseMove(object sender, MouseEventArgs e)
		{
			pct_Icon.Image = global::ApplicationCAI.Properties.Resources.Icon2;
			pct_Icon.BackColor = offColor;
		}//Menu Icone Hover
		private void pct_Icon_MouseLeave(object sender, EventArgs e)
		{
			pct_Icon.Image = global::ApplicationCAI.Properties.Resources.Icon;
			pct_Icon.BackColor = mainColor;
		}//Menu Icone Hover
		 //Menu buttons
		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}//Bouton Close
		//Menu déroulant
		private class MyRenderer : ToolStripProfessionalRenderer
		{
			public MyRenderer() : base(new MyColors()) { }
		}//Override des menus par défaut

		private void pct_Connexion_MouseMove(object sender, MouseEventArgs e)
		{
			pct_Connexion.Image = global::ApplicationCAI.Properties.Resources.bouton_connexion_light;
		}

		private void pct_Connexion_MouseLeave(object sender, EventArgs e)
		{
			pct_Connexion.Image = global::ApplicationCAI.Properties.Resources.bouton_connexion;
		}

		private void pct_Connexion_Click(object sender, EventArgs e)
		{
			//Create your domain context
			//using (PrincipalContext domain = new PrincipalContext(ContextType.Domain))
			{
				//If connection is correct
				//bool connected = domain.ValidateCredentials(txt_Login.Text, txt_Password.Text);
				//if (connected){
					MessageBox.Show("Connecté");
					Connected frm_Connected = new Connected();
					frm_Connected.ShowDialog();
				//}
				//else{
				//	MessageBox.Show("Impossible de se connecter");
				//}
			}
		}

		private class MyColors : ProfessionalColorTable
		{
			public override Color MenuItemSelected
			{
				get { return Color.FromArgb(25, 25, 25); }
			}
			public override Color MenuItemBorder
			{
				get { return Color.Black; }
			}
		}//Override des couleurs par défaut
	}
}
