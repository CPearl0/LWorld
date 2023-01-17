namespace LWorld
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.GameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RestartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.QuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelMap = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GameToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1184, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // GameToolStripMenuItem
            // 
            this.GameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewGameToolStripMenuItem,
            this.RestartToolStripMenuItem,
            this.toolStripSeparator1,
            this.QuitToolStripMenuItem});
            this.GameToolStripMenuItem.Name = "GameToolStripMenuItem";
            this.GameToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.GameToolStripMenuItem.Text = "游戏(&G)";
            // 
            // NewGameToolStripMenuItem
            // 
            this.NewGameToolStripMenuItem.Name = "NewGameToolStripMenuItem";
            this.NewGameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.NewGameToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.NewGameToolStripMenuItem.Text = "新游戏(&N)";
            this.NewGameToolStripMenuItem.Click += new System.EventHandler(this.NewGameToolStripMenuItem_Click);
            // 
            // RestartToolStripMenuItem
            // 
            this.RestartToolStripMenuItem.Name = "RestartToolStripMenuItem";
            this.RestartToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.RestartToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.RestartToolStripMenuItem.Text = "重新开始此游戏(&R)";
            this.RestartToolStripMenuItem.Click += new System.EventHandler(this.RestartToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(218, 6);
            // 
            // QuitToolStripMenuItem
            // 
            this.QuitToolStripMenuItem.Name = "QuitToolStripMenuItem";
            this.QuitToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.QuitToolStripMenuItem.Text = "退出(&Q)";
            this.QuitToolStripMenuItem.Click += new System.EventHandler(this.QuitToolStripMenuItem_Click);
            // 
            // labelMap
            // 
            this.labelMap.AutoSize = true;
            this.labelMap.Location = new System.Drawing.Point(0, 25);
            this.labelMap.Name = "labelMap";
            this.labelMap.Size = new System.Drawing.Size(89, 17);
            this.labelMap.TabIndex = 1;
            this.labelMap.Text = "MazeLocation";
            this.labelMap.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 781);
            this.Controls.Add(this.labelMap);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "迷宫";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem GameToolStripMenuItem;
        private ToolStripMenuItem NewGameToolStripMenuItem;
        private Label labelMap;
        private ToolStripMenuItem RestartToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem QuitToolStripMenuItem;
    }
}