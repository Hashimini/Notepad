namespace Notepad
{
    partial class Program
    {
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileMenu;
        private System.Windows.Forms.ToolStripMenuItem NewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpMenu;
        private System.Windows.Forms.ToolStripMenuItem AboutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HowToUseMenuItem;

        private void InitializeComponent()
        {
            TextBox = new System.Windows.Forms.TextBox();
            MenuStrip = new System.Windows.Forms.MenuStrip();
            FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            NewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            OpenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            SaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            HelpMenu = new System.Windows.Forms.ToolStripMenuItem();
            AboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            HowToUseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            TabControl = new System.Windows.Forms.TabControl();
            tabPage1 = new System.Windows.Forms.TabPage();
            MenuStrip.SuspendLayout();
            TabControl.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // TextBox
            // 
            TextBox.AcceptsReturn = true;
            TextBox.AcceptsTab = true;
            TextBox.AccessibleDescription = "a";
            TextBox.AccessibleName = "a";
            TextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            TextBox.Location = new System.Drawing.Point(3, 3);
            TextBox.Margin = new System.Windows.Forms.Padding(0);
            TextBox.Multiline = true;
            TextBox.Name = "TextBox";
            TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            TextBox.Size = new System.Drawing.Size(570, 203);
            TextBox.TabIndex = 0;
            // 
            // MenuStrip
            // 
            MenuStrip.AccessibleDescription = "a";
            MenuStrip.AccessibleName = "a";
            MenuStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { FileMenu, HelpMenu });
            MenuStrip.Location = new System.Drawing.Point(0, 0);
            MenuStrip.Name = "MenuStrip";
            MenuStrip.Size = new System.Drawing.Size(584, 24);
            MenuStrip.TabIndex = 1;
            // 
            // FileMenu
            // 
            FileMenu.AccessibleDescription = "a";
            FileMenu.AccessibleName = "a";
            FileMenu.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            FileMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { NewMenuItem, OpenMenuItem, SaveMenuItem, ExitMenuItem });
            FileMenu.Name = "FileMenu";
            FileMenu.Size = new System.Drawing.Size(37, 20);
            FileMenu.Text = "File";
            // 
            // NewMenuItem
            // 
            NewMenuItem.AccessibleDescription = "a";
            NewMenuItem.AccessibleName = "a";
            NewMenuItem.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            NewMenuItem.Name = "NewMenuItem";
            NewMenuItem.Size = new System.Drawing.Size(103, 22);
            NewMenuItem.Text = "New";
            NewMenuItem.Click += NewMenuItem_Click;
            // 
            // OpenMenuItem
            // 
            OpenMenuItem.AccessibleDescription = "a";
            OpenMenuItem.AccessibleName = "a";
            OpenMenuItem.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            OpenMenuItem.Name = "OpenMenuItem";
            OpenMenuItem.Size = new System.Drawing.Size(103, 22);
            OpenMenuItem.Text = "Open";
            OpenMenuItem.Click += OpenFile;
            // 
            // SaveMenuItem
            // 
            SaveMenuItem.AccessibleDescription = "a";
            SaveMenuItem.AccessibleName = "a";
            SaveMenuItem.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            SaveMenuItem.Name = "SaveMenuItem";
            SaveMenuItem.Size = new System.Drawing.Size(103, 22);
            SaveMenuItem.Text = "Save";
            SaveMenuItem.Click += SaveFile;
            // 
            // ExitMenuItem
            // 
            ExitMenuItem.AccessibleDescription = "a";
            ExitMenuItem.AccessibleName = "a";
            ExitMenuItem.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            ExitMenuItem.Name = "ExitMenuItem";
            ExitMenuItem.Size = new System.Drawing.Size(103, 22);
            ExitMenuItem.Text = "Close";
            ExitMenuItem.Click += ExitMenuItem_Click;
            // 
            // HelpMenu
            // 
            HelpMenu.AccessibleDescription = "a";
            HelpMenu.AccessibleName = "a";
            HelpMenu.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            HelpMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            HelpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { AboutMenuItem, HowToUseMenuItem });
            HelpMenu.Name = "HelpMenu";
            HelpMenu.Size = new System.Drawing.Size(44, 20);
            HelpMenu.Text = "Help";
            // 
            // AboutMenuItem
            // 
            AboutMenuItem.AccessibleDescription = "a";
            AboutMenuItem.AccessibleName = "a";
            AboutMenuItem.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            AboutMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            AboutMenuItem.Name = "AboutMenuItem";
            AboutMenuItem.Size = new System.Drawing.Size(135, 22);
            AboutMenuItem.Text = "About";
            AboutMenuItem.Click += AboutMenuItem_Click;
            // 
            // HowToUseMenuItem
            // 
            HowToUseMenuItem.AccessibleDescription = "a";
            HowToUseMenuItem.AccessibleName = "a";
            HowToUseMenuItem.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuItem;
            HowToUseMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            HowToUseMenuItem.Name = "HowToUseMenuItem";
            HowToUseMenuItem.Size = new System.Drawing.Size(135, 22);
            HowToUseMenuItem.Text = "How to Use";
            HowToUseMenuItem.Click += HowToUseMenuItem_Click;
            // 
            // TabControl
            // 
            TabControl.AccessibleDescription = "a";
            TabControl.AccessibleName = "a";
            TabControl.AccessibleRole = System.Windows.Forms.AccessibleRole.Table;
            TabControl.Controls.Add(tabPage1);
            TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            TabControl.Location = new System.Drawing.Point(0, 24);
            TabControl.Name = "TabControl";
            TabControl.SelectedIndex = 0;
            TabControl.Size = new System.Drawing.Size(584, 237);
            TabControl.TabIndex = 2;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(TextBox);
            tabPage1.Location = new System.Drawing.Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(3);
            tabPage1.Size = new System.Drawing.Size(576, 209);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // Program
            // 
            AccessibleDescription = Strings.MenuFile;
            AccessibleName = "abracadabra";
            ClientSize = new System.Drawing.Size(584, 261);
            Controls.Add(TabControl);
            Controls.Add(MenuStrip);
            MainMenuStrip = MenuStrip;
            Name = "Program";
            Text = "Notepad";
            MenuStrip.ResumeLayout(false);
            MenuStrip.PerformLayout();
            TabControl.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage tabPage1;
    }
}
