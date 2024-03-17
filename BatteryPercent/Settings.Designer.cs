namespace BatteryPercent
{
    partial class Settings
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
            buttonApply = new Button();
            label1 = new Label();
            checkBoxAutoBackgroundColor = new CheckBox();
            textBoxBackgroundColor = new TextBox();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            checkBoxAutoTextColor = new CheckBox();
            label2 = new Label();
            textBoxTextColor = new TextBox();
            groupBox3 = new GroupBox();
            trackBarTextOpacity = new TrackBar();
            label5 = new Label();
            trackBarBackgroundOpacity = new TrackBar();
            label4 = new Label();
            checkBoxMatchOpacity = new CheckBox();
            trackBarOverallOpacity = new TrackBar();
            label3 = new Label();
            buttonCancel = new Button();
            groupBox4 = new GroupBox();
            checkBoxClockFormat = new CheckBox();
            checkBoxShowClock = new CheckBox();
            groupBox5 = new GroupBox();
            checkBoxBatteryTime = new CheckBox();
            checkBoxBatteryPercentage = new CheckBox();
            groupBox6 = new GroupBox();
            trackBar3 = new TrackBar();
            label8 = new Label();
            checkBoxStartAuto = new CheckBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarTextOpacity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarBackgroundOpacity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarOverallOpacity).BeginInit();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar3).BeginInit();
            SuspendLayout();
            // 
            // buttonApply
            // 
            buttonApply.Location = new Point(457, 414);
            buttonApply.Name = "buttonApply";
            buttonApply.Size = new Size(109, 41);
            buttonApply.TabIndex = 0;
            buttonApply.Text = "Apply";
            buttonApply.UseVisualStyleBackColor = true;
            buttonApply.Click += buttonApply_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 50);
            label1.Name = "label1";
            label1.Size = new Size(106, 15);
            label1.TabIndex = 1;
            label1.Text = "Background Color:";
            // 
            // checkBoxAutoBackgroundColor
            // 
            checkBoxAutoBackgroundColor.AutoSize = true;
            checkBoxAutoBackgroundColor.Location = new Point(6, 22);
            checkBoxAutoBackgroundColor.Name = "checkBoxAutoBackgroundColor";
            checkBoxAutoBackgroundColor.Size = new Size(181, 19);
            checkBoxAutoBackgroundColor.TabIndex = 2;
            checkBoxAutoBackgroundColor.Text = "Automatic Background Color";
            checkBoxAutoBackgroundColor.UseVisualStyleBackColor = true;
            // 
            // textBoxBackgroundColor
            // 
            textBoxBackgroundColor.Location = new Point(118, 47);
            textBoxBackgroundColor.Name = "textBoxBackgroundColor";
            textBoxBackgroundColor.Size = new Size(100, 23);
            textBoxBackgroundColor.TabIndex = 3;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkBoxAutoBackgroundColor);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBoxBackgroundColor);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(292, 100);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Background";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(checkBoxAutoTextColor);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(textBoxTextColor);
            groupBox2.Location = new Point(12, 118);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(292, 100);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Text and Font";
            // 
            // checkBoxAutoTextColor
            // 
            checkBoxAutoTextColor.AutoSize = true;
            checkBoxAutoTextColor.Location = new Point(6, 22);
            checkBoxAutoTextColor.Name = "checkBoxAutoTextColor";
            checkBoxAutoTextColor.Size = new Size(138, 19);
            checkBoxAutoTextColor.TabIndex = 2;
            checkBoxAutoTextColor.Text = "Automatic Text Color";
            checkBoxAutoTextColor.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 50);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 1;
            label2.Text = "Text Color:";
            // 
            // textBoxTextColor
            // 
            textBoxTextColor.Location = new Point(75, 47);
            textBoxTextColor.Name = "textBoxTextColor";
            textBoxTextColor.Size = new Size(100, 23);
            textBoxTextColor.TabIndex = 3;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(trackBarTextOpacity);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(trackBarBackgroundOpacity);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(checkBoxMatchOpacity);
            groupBox3.Controls.Add(trackBarOverallOpacity);
            groupBox3.Controls.Add(label3);
            groupBox3.Location = new Point(310, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(292, 260);
            groupBox3.TabIndex = 9;
            groupBox3.TabStop = false;
            groupBox3.Text = "Opacity";
            // 
            // trackBarTextOpacity
            // 
            trackBarTextOpacity.LargeChange = 25;
            trackBarTextOpacity.Location = new Point(6, 204);
            trackBarTextOpacity.Name = "trackBarTextOpacity";
            trackBarTextOpacity.Size = new Size(104, 45);
            trackBarTextOpacity.TabIndex = 15;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 186);
            label5.Name = "label5";
            label5.Size = new Size(72, 15);
            label5.TabIndex = 14;
            label5.Text = "Text Opacity";
            // 
            // trackBarBackgroundOpacity
            // 
            trackBarBackgroundOpacity.LargeChange = 25;
            trackBarBackgroundOpacity.Location = new Point(6, 138);
            trackBarBackgroundOpacity.Name = "trackBarBackgroundOpacity";
            trackBarBackgroundOpacity.Size = new Size(104, 45);
            trackBarBackgroundOpacity.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 120);
            label4.Name = "label4";
            label4.Size = new Size(115, 15);
            label4.TabIndex = 12;
            label4.Text = "Background Opacity";
            // 
            // checkBoxMatchOpacity
            // 
            checkBoxMatchOpacity.AutoSize = true;
            checkBoxMatchOpacity.Location = new Point(6, 98);
            checkBoxMatchOpacity.Name = "checkBoxMatchOpacity";
            checkBoxMatchOpacity.Size = new Size(174, 19);
            checkBoxMatchOpacity.TabIndex = 11;
            checkBoxMatchOpacity.Text = "Text and Background Match";
            checkBoxMatchOpacity.UseVisualStyleBackColor = true;
            // 
            // trackBarOverallOpacity
            // 
            trackBarOverallOpacity.LargeChange = 25;
            trackBarOverallOpacity.Location = new Point(6, 47);
            trackBarOverallOpacity.Name = "trackBarOverallOpacity";
            trackBarOverallOpacity.Size = new Size(104, 45);
            trackBarOverallOpacity.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 29);
            label3.Name = "label3";
            label3.Size = new Size(88, 15);
            label3.TabIndex = 0;
            label3.Text = "Overall Opacity";
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(342, 414);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(109, 41);
            buttonCancel.TabIndex = 10;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(checkBoxClockFormat);
            groupBox4.Controls.Add(checkBoxShowClock);
            groupBox4.Location = new Point(12, 224);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(292, 100);
            groupBox4.TabIndex = 11;
            groupBox4.TabStop = false;
            groupBox4.Text = "Clock Settings";
            // 
            // checkBoxClockFormat
            // 
            checkBoxClockFormat.AutoSize = true;
            checkBoxClockFormat.Location = new Point(6, 47);
            checkBoxClockFormat.Name = "checkBoxClockFormat";
            checkBoxClockFormat.Size = new Size(164, 19);
            checkBoxClockFormat.TabIndex = 3;
            checkBoxClockFormat.Text = "Show Time in 24hr Format";
            checkBoxClockFormat.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowClock
            // 
            checkBoxShowClock.AutoSize = true;
            checkBoxShowClock.Location = new Point(6, 22);
            checkBoxShowClock.Name = "checkBoxShowClock";
            checkBoxShowClock.Size = new Size(144, 19);
            checkBoxShowClock.TabIndex = 2;
            checkBoxShowClock.Text = "Show Clock in Overlay";
            checkBoxShowClock.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(checkBoxBatteryTime);
            groupBox5.Controls.Add(checkBoxBatteryPercentage);
            groupBox5.Location = new Point(12, 330);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(292, 100);
            groupBox5.TabIndex = 12;
            groupBox5.TabStop = false;
            groupBox5.Text = "Battery Settings";
            // 
            // checkBoxBatteryTime
            // 
            checkBoxBatteryTime.AutoSize = true;
            checkBoxBatteryTime.Location = new Point(6, 47);
            checkBoxBatteryTime.Name = "checkBoxBatteryTime";
            checkBoxBatteryTime.Size = new Size(184, 19);
            checkBoxBatteryTime.TabIndex = 3;
            checkBoxBatteryTime.Text = "Show Battery Time Remaining";
            checkBoxBatteryTime.UseVisualStyleBackColor = true;
            // 
            // checkBoxBatteryPercentage
            // 
            checkBoxBatteryPercentage.AutoSize = true;
            checkBoxBatteryPercentage.Location = new Point(6, 22);
            checkBoxBatteryPercentage.Name = "checkBoxBatteryPercentage";
            checkBoxBatteryPercentage.Size = new Size(157, 19);
            checkBoxBatteryPercentage.TabIndex = 2;
            checkBoxBatteryPercentage.Text = "Show Battery Percentage";
            checkBoxBatteryPercentage.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(trackBar3);
            groupBox6.Controls.Add(label8);
            groupBox6.Location = new Point(316, 278);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(286, 105);
            groupBox6.TabIndex = 13;
            groupBox6.TabStop = false;
            groupBox6.Text = "General";
            // 
            // trackBar3
            // 
            trackBar3.Location = new Point(6, 47);
            trackBar3.Name = "trackBar3";
            trackBar3.Size = new Size(274, 45);
            trackBar3.TabIndex = 10;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 29);
            label8.Name = "label8";
            label8.Size = new Size(70, 15);
            label8.TabIndex = 0;
            label8.Text = "Overlay Size";
            // 
            // checkBoxStartAuto
            // 
            checkBoxStartAuto.AutoSize = true;
            checkBoxStartAuto.Location = new Point(316, 389);
            checkBoxStartAuto.Name = "checkBoxStartAuto";
            checkBoxStartAuto.Size = new Size(173, 19);
            checkBoxStartAuto.TabIndex = 14;
            checkBoxStartAuto.Text = "Start Automatically at Login";
            checkBoxStartAuto.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(616, 468);
            Controls.Add(checkBoxStartAuto);
            Controls.Add(groupBox6);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(buttonCancel);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(buttonApply);
            Name = "Settings";
            ShowIcon = false;
            Text = "Settings";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarTextOpacity).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarBackgroundOpacity).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarOverallOpacity).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonApply;
        private Label label1;
        private CheckBox checkBoxAutoBackgroundColor;
        private TextBox textBoxBackgroundColor;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private CheckBox checkBoxAutoTextColor;
        private Label label2;
        private TextBox textBoxTextColor;
        private GroupBox groupBox3;
        private TrackBar trackBarTextOpacity;
        private Label label5;
        private TrackBar trackBarBackgroundOpacity;
        private Label label4;
        private CheckBox checkBoxMatchOpacity;
        private TrackBar trackBarOverallOpacity;
        private Label label3;
        private Button buttonCancel;
        private GroupBox groupBox4;
        private CheckBox checkBoxClockFormat;
        private CheckBox checkBoxShowClock;
        private GroupBox groupBox5;
        private CheckBox checkBoxBatteryTime;
        private CheckBox checkBoxBatteryPercentage;
        private GroupBox groupBox6;
        private TrackBar trackBar3;
        private Label label8;
        private CheckBox checkBoxStartAuto;
    }
}
