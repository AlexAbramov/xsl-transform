using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using System.Xml.Xsl;

namespace XslTransform
{
	/// <summary>
	/// Summary description for MainForm.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		const string xslFilter="XSL Files|*.xsl|XSLT Files|*.xslt";
		const string xmlFilter="XML Files|*.xml";
		const string textFilter="Text Files|*.txt";
		Options options;
	
		System.Xml.Xsl.XslCompiledTransform xslt =new System.Xml.Xsl.XslCompiledTransform();
		bool inputChanged=false;
		bool xslChanged=false;
		string inputFilePath="";
		string xslFilePath="";
		string outputFilePath="";

		private System.Windows.Forms.OpenFileDialog dlgOpenFile;
		private System.Windows.Forms.TextBox tbXsl;
		private System.Windows.Forms.TextBox tbOutput;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.TabControl tcFiles;
		private System.Windows.Forms.TabPage tpInput;
		private System.Windows.Forms.TabPage tpXsl;
		private System.Windows.Forms.TabPage tpOutput;
		private System.Windows.Forms.TextBox tbInput;
		private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.MenuItem miFile;
		private System.Windows.Forms.MenuItem miOpen;
		private System.Windows.Forms.MenuItem miSave;
		private System.Windows.Forms.MenuItem miSaveAll;
		private System.Windows.Forms.MenuItem miExit;
		private System.Windows.Forms.MenuItem miTools;
		private System.Windows.Forms.MenuItem miTransform;
		private System.Windows.Forms.MenuItem miHelp;
		private System.Windows.Forms.MenuItem miAbout;
		private System.Windows.Forms.ToolBar toolBar;
		private System.Windows.Forms.ImageList ilToolbar;
		private System.Windows.Forms.ToolBarButton tbbOpen;
		private System.Windows.Forms.ToolBarButton tbbTransform;
		private System.Windows.Forms.ToolBarButton tbbSave;
		private System.Windows.Forms.ToolBarButton tbbSaveAll;
		private System.Windows.Forms.ToolBarButton tbbSep;
		private System.Windows.Forms.ToolBarButton tbbSep2;
		private System.Windows.Forms.SaveFileDialog dlgSaveFile;
		private System.Windows.Forms.MenuItem miOptions;

		private System.Windows.Forms.StatusBar statusBar;

		public MainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.tbXsl = new System.Windows.Forms.TextBox();
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.tcFiles = new System.Windows.Forms.TabControl();
            this.tpInput = new System.Windows.Forms.TabPage();
            this.tbInput = new System.Windows.Forms.TextBox();
            this.tpXsl = new System.Windows.Forms.TabPage();
            this.tpOutput = new System.Windows.Forms.TabPage();
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.miFile = new System.Windows.Forms.MenuItem();
            this.miOpen = new System.Windows.Forms.MenuItem();
            this.miSave = new System.Windows.Forms.MenuItem();
            this.miSaveAll = new System.Windows.Forms.MenuItem();
            this.miExit = new System.Windows.Forms.MenuItem();
            this.miTools = new System.Windows.Forms.MenuItem();
            this.miTransform = new System.Windows.Forms.MenuItem();
            this.miOptions = new System.Windows.Forms.MenuItem();
            this.miHelp = new System.Windows.Forms.MenuItem();
            this.miAbout = new System.Windows.Forms.MenuItem();
            this.toolBar = new System.Windows.Forms.ToolBar();
            this.tbbOpen = new System.Windows.Forms.ToolBarButton();
            this.tbbSep = new System.Windows.Forms.ToolBarButton();
            this.tbbTransform = new System.Windows.Forms.ToolBarButton();
            this.tbbSep2 = new System.Windows.Forms.ToolBarButton();
            this.tbbSave = new System.Windows.Forms.ToolBarButton();
            this.tbbSaveAll = new System.Windows.Forms.ToolBarButton();
            this.ilToolbar = new System.Windows.Forms.ImageList(this.components);
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.dlgSaveFile = new System.Windows.Forms.SaveFileDialog();
            this.tcFiles.SuspendLayout();
            this.tpInput.SuspendLayout();
            this.tpXsl.SuspendLayout();
            this.tpOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbXsl
            // 
            this.tbXsl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbXsl.Location = new System.Drawing.Point(0, 0);
            this.tbXsl.Multiline = true;
            this.tbXsl.Name = "tbXsl";
            this.tbXsl.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbXsl.Size = new System.Drawing.Size(680, 526);
            this.tbXsl.TabIndex = 3;
            this.tbXsl.TextChanged += new System.EventHandler(this.tbXsl_TextChanged);
            // 
            // tbOutput
            // 
            this.tbOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbOutput.Location = new System.Drawing.Point(0, 0);
            this.tbOutput.Multiline = true;
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.ReadOnly = true;
            this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbOutput.Size = new System.Drawing.Size(680, 526);
            this.tbOutput.TabIndex = 4;
            // 
            // tcFiles
            // 
            this.tcFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcFiles.Controls.Add(this.tpInput);
            this.tcFiles.Controls.Add(this.tpXsl);
            this.tcFiles.Controls.Add(this.tpOutput);
            this.tcFiles.Location = new System.Drawing.Point(0, 32);
            this.tcFiles.Name = "tcFiles";
            this.tcFiles.SelectedIndex = 0;
            this.tcFiles.Size = new System.Drawing.Size(688, 552);
            this.tcFiles.TabIndex = 6;
            this.tcFiles.SelectedIndexChanged += new System.EventHandler(this.tcFiles_SelectedIndexChanged);
            // 
            // tpInput
            // 
            this.tpInput.Controls.Add(this.tbInput);
            this.tpInput.Location = new System.Drawing.Point(4, 22);
            this.tpInput.Name = "tpInput";
            this.tpInput.Size = new System.Drawing.Size(680, 526);
            this.tpInput.TabIndex = 0;
            this.tpInput.Text = "Input";
            // 
            // tbInput
            // 
            this.tbInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbInput.Location = new System.Drawing.Point(0, 0);
            this.tbInput.Multiline = true;
            this.tbInput.Name = "tbInput";
            this.tbInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbInput.Size = new System.Drawing.Size(680, 526);
            this.tbInput.TabIndex = 4;
            this.tbInput.TextChanged += new System.EventHandler(this.tbInput_TextChanged);
            // 
            // tpXsl
            // 
            this.tpXsl.Controls.Add(this.tbXsl);
            this.tpXsl.Location = new System.Drawing.Point(4, 22);
            this.tpXsl.Name = "tpXsl";
            this.tpXsl.Size = new System.Drawing.Size(680, 526);
            this.tpXsl.TabIndex = 1;
            this.tpXsl.Text = "XSL";
            // 
            // tpOutput
            // 
            this.tpOutput.Controls.Add(this.tbOutput);
            this.tpOutput.Location = new System.Drawing.Point(4, 22);
            this.tpOutput.Name = "tpOutput";
            this.tpOutput.Size = new System.Drawing.Size(680, 526);
            this.tpOutput.TabIndex = 2;
            this.tpOutput.Text = "Output";
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miFile,
            this.miTools,
            this.miHelp});
            // 
            // miFile
            // 
            this.miFile.Index = 0;
            this.miFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miOpen,
            this.miSave,
            this.miSaveAll,
            this.miExit});
            this.miFile.Text = "&File";
            // 
            // miOpen
            // 
            this.miOpen.Index = 0;
            this.miOpen.Text = "&Open";
            this.miOpen.Click += new System.EventHandler(this.miOpen_Click);
            // 
            // miSave
            // 
            this.miSave.Index = 1;
            this.miSave.Text = "&Save";
            this.miSave.Click += new System.EventHandler(this.miSave_Click);
            // 
            // miSaveAll
            // 
            this.miSaveAll.Index = 2;
            this.miSaveAll.Text = "Save &All";
            this.miSaveAll.Click += new System.EventHandler(this.miSaveAll_Click);
            // 
            // miExit
            // 
            this.miExit.Index = 3;
            this.miExit.Text = "E&xit";
            this.miExit.Click += new System.EventHandler(this.miExit_Click);
            // 
            // miTools
            // 
            this.miTools.Index = 1;
            this.miTools.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miTransform,
            this.miOptions});
            this.miTools.Text = "&Tools";
            // 
            // miTransform
            // 
            this.miTransform.Index = 0;
            this.miTransform.Text = "&Transform";
            this.miTransform.Click += new System.EventHandler(this.miTransform_Click);
            // 
            // miOptions
            // 
            this.miOptions.Index = 1;
            this.miOptions.Text = "&Options";
            this.miOptions.Click += new System.EventHandler(this.miOptions_Click);
            // 
            // miHelp
            // 
            this.miHelp.Index = 2;
            this.miHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miAbout});
            this.miHelp.Text = "&Help";
            // 
            // miAbout
            // 
            this.miAbout.Index = 0;
            this.miAbout.Text = "&About";
            this.miAbout.Click += new System.EventHandler(this.miAbout_Click);
            // 
            // toolBar
            // 
            this.toolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.tbbOpen,
            this.tbbSep,
            this.tbbTransform,
            this.tbbSep2,
            this.tbbSave,
            this.tbbSaveAll});
            this.toolBar.DropDownArrows = true;
            this.toolBar.ImageList = this.ilToolbar;
            this.toolBar.Location = new System.Drawing.Point(0, 0);
            this.toolBar.Name = "toolBar";
            this.toolBar.ShowToolTips = true;
            this.toolBar.Size = new System.Drawing.Size(688, 32);
            this.toolBar.TabIndex = 7;
            this.toolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar_ButtonClick);
            // 
            // tbbOpen
            // 
            this.tbbOpen.ImageIndex = 1;
            this.tbbOpen.Name = "tbbOpen";
            // 
            // tbbSep
            // 
            this.tbbSep.Name = "tbbSep";
            this.tbbSep.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbbTransform
            // 
            this.tbbTransform.ImageIndex = 2;
            this.tbbTransform.Name = "tbbTransform";
            // 
            // tbbSep2
            // 
            this.tbbSep2.Name = "tbbSep2";
            this.tbbSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbbSave
            // 
            this.tbbSave.ImageIndex = 3;
            this.tbbSave.Name = "tbbSave";
            // 
            // tbbSaveAll
            // 
            this.tbbSaveAll.ImageIndex = 4;
            this.tbbSaveAll.Name = "tbbSaveAll";
            // 
            // ilToolbar
            // 
            this.ilToolbar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilToolbar.ImageStream")));
            this.ilToolbar.TransparentColor = System.Drawing.Color.Transparent;
            this.ilToolbar.Images.SetKeyName(0, "");
            this.ilToolbar.Images.SetKeyName(1, "");
            this.ilToolbar.Images.SetKeyName(2, "");
            this.ilToolbar.Images.SetKeyName(3, "");
            this.ilToolbar.Images.SetKeyName(4, "");
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 584);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(688, 22);
            this.statusBar.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(688, 606);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.toolBar);
            this.Controls.Add(this.tcFiles);
            this.Menu = this.mainMenu;
            this.MinimumSize = new System.Drawing.Size(552, 640);
            this.Name = "MainForm";
            this.Text = "XSL Transform";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tcFiles.ResumeLayout(false);
            this.tpInput.ResumeLayout(false);
            this.tpInput.PerformLayout();
            this.tpXsl.ResumeLayout(false);
            this.tpXsl.PerformLayout();
            this.tpOutput.ResumeLayout(false);
            this.tpOutput.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

		void OnException(Exception ex)
	  {
			MessageBox.Show(this,ex.ToString(),base.Text);
		}

		private void MainForm_Load(object sender, System.EventArgs e)
		{
			try
			{
				string samplesDir=Application.StartupPath+"\\Samples";
				dlgOpenFile.InitialDirectory=samplesDir;
				dlgSaveFile.InitialDirectory=samplesDir;
				
				inputFilePath=samplesDir+"\\default\\default.xml";
				xslFilePath=samplesDir+ "\\default\\default.xslt";
				outputFilePath=samplesDir+ "\\default\\output.txt";	

				ReadInput();
				ReadXsl();

				options=Options.Load();
				UpdateFont();
			}
			catch(Exception ex)
			{
				OnException(ex);
			}
			finally
			{
				UpdateControls();
			}
		}

		void ReadInput()
		{
			tbInput.Text=Utils.ReadFile(inputFilePath);
			inputChanged=false;
		}

		void ReadXsl()
		{
			tbXsl.Text=Utils.ReadFile(xslFilePath);
			xslChanged=false;
		}

		private void tbXsl_TextChanged(object sender, System.EventArgs e)
		{
			xslChanged=true;
			UpdateControls();
		}

		private void miAbout_Click(object sender, System.EventArgs e)
		{
			About();
		}

		private void miOpen_Click(object sender, System.EventArgs e)
		{
			Open();
		}

		private void miSave_Click(object sender, System.EventArgs e)
		{
			Save();
		}

		private void miSaveAll_Click(object sender, System.EventArgs e)
		{
			SaveAll();
		}

		private void miExit_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void miTransform_Click(object sender, System.EventArgs e)
		{
			Transform();
		}

		private void toolBar_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			ToolBarButton tbb=e.Button;
			if(tbb==tbbOpen)
			{
				Open();
			}
			else if(tbb==tbbSave)
			{
				Save();
			}
			else if(tbb==tbbSaveAll)
			{
				SaveAll();
			}
			else if(tbb==tbbTransform)
			{
				Transform();
			}
		}

		void New()
		{
			try
			{
				if(this.tcFiles.SelectedTab==tpInput)
				{
					tbInput.Text="";
				}
				else if(this.tcFiles.SelectedTab==tpXsl)
				{
					tbXsl.Text="";
				}
				else tbOutput.Text="";
			}
			catch(Exception ex)
			{
				OnException(ex);
			}
			finally
			{
				UpdateControls();
			}
		}

		void Open()
		{
			try
			{
				if(this.tcFiles.SelectedTab==tpInput)
				{
					dlgOpenFile.Filter=xmlFilter;
				}
				else if(this.tcFiles.SelectedTab==tpXsl)
				{
					dlgOpenFile.Filter=xslFilter;
				}
				else dlgOpenFile.Filter=textFilter;

				if(dlgOpenFile.ShowDialog()==DialogResult.OK)
				{
					if(this.tcFiles.SelectedTab==tpInput)
					{
						inputFilePath=dlgOpenFile.FileName;
						ReadInput();
					}
					else if(this.tcFiles.SelectedTab==tpXsl)
					{
						xslFilePath=dlgOpenFile.FileName;
						ReadXsl();
					}
					else
					{
						outputFilePath=dlgOpenFile.FileName;
						tbOutput.Text=Utils.ReadFile(outputFilePath);
					}
				}
			}
			catch(Exception ex)
			{
				OnException(ex);
			}
			finally
			{
				UpdateControls();
			}
		}

		void Save()
		{
			try
			{
				if(this.tcFiles.SelectedTab==tpInput)
				{
					dlgSaveFile.Filter=xmlFilter;
				}
				else if(this.tcFiles.SelectedTab==tpXsl)
				{
					dlgSaveFile.Filter=xslFilter;
				}
				else
				{
					dlgSaveFile.Filter=textFilter;
				}

				if(dlgSaveFile.ShowDialog()==DialogResult.OK)
				{
					string text="";
					if(this.tcFiles.SelectedTab==tpInput)
					{
						inputFilePath=dlgSaveFile.FileName;
						text=tbInput.Text;
						inputChanged=false;
					}
					else if(this.tcFiles.SelectedTab==tpXsl)
					{
						xslFilePath=dlgSaveFile.FileName;
						text=tbXsl.Text;
						xslChanged=false;
					}
					else text=tbOutput.Text;
					Utils.WriteFile(dlgSaveFile.FileName,text);
				}
			}
			catch(Exception ex)
			{
				OnException(ex);
			}
			finally
			{
				UpdateControls();
			}
		}

		void SaveAll()
		{
			try
			{
				Utils.WriteFile(inputFilePath,tbInput.Text);
				inputChanged=false;
				Utils.WriteFile(xslFilePath,tbXsl.Text);
				xslChanged=false;
			}
			catch(Exception ex)
			{
				OnException(ex);
			}
			finally
			{
				UpdateControls();
			}
		}

		void About()
		{
		}

		void Transform()
		{
			try
			{
				if(inputChanged)
				{
					Utils.WriteFile(inputFilePath,tbInput.Text);
					inputChanged=false;
				}
				if(xslChanged)
				{
					Utils.WriteFile(xslFilePath,tbXsl.Text);
					xslChanged=false;
				}

				using(WaitCursor wc=new WaitCursor())
				{
					xslt.Load(xslFilePath);
					xslt.Transform(inputFilePath,outputFilePath);
				}

				using(StreamReader sr=new StreamReader(outputFilePath))
				{
					tbOutput.Text=sr.ReadToEnd();
				}

				this.tcFiles.SelectedTab=tpOutput;

			}
			catch(Exception ex)
			{
				OnException(ex);
			}
			finally
			{
				UpdateControls();
			}
		}

		private void tcFiles_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		  UpdateControls();
		}

		private void tbInput_TextChanged(object sender, System.EventArgs e)
		{
			this.inputChanged=true;
			UpdateControls();
		}

		void UpdateControls()
		{
			bool transformEnabled=inputFilePath.Length>0 && xslFilePath.Length>0;
			this.miTransform.Enabled=transformEnabled;
			this.tbbTransform.Enabled=transformEnabled;
		}

		private void miOptions_Click(object sender, System.EventArgs e)
		{
			OptionsForm form=new OptionsForm(options);
			if(form.ShowDialog()==DialogResult.OK)
			{
				UpdateFont();
			}
		}

		void UpdateFont()
		{
			this.tbInput.Font=options.Font;
			this.tbXsl.Font=options.Font;
			this.tbOutput.Font=options.Font;
		}
	}
}
