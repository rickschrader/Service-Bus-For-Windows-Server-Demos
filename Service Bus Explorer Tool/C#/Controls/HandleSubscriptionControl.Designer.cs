namespace Microsoft.WindowsAzure.CAT.ServiceBusExplorer
{
    partial class HandleSubscriptionControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnChangeStatus = new System.Windows.Forms.Button();
            this.btnCancelUpdate = new System.Windows.Forms.Button();
            this.btnCreateDelete = new System.Windows.Forms.Button();
            this.grouperSubscriptionInformation = new Microsoft.WindowsAzure.CAT.ServiceBusExplorer.Grouper();
            this.propertyListView = new System.Windows.Forms.ListView();
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.valueColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grouperSubscriptionProperties = new Microsoft.WindowsAzure.CAT.ServiceBusExplorer.Grouper();
            this.btnOpenDescriptionForm = new System.Windows.Forms.Button();
            this.txtUserMetadata = new System.Windows.Forms.TextBox();
            this.btnOpenForwardToForm = new System.Windows.Forms.Button();
            this.lblForwardTo = new System.Windows.Forms.Label();
            this.txtForwardTo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaxDeliveryCount = new System.Windows.Forms.TextBox();
            this.grouperLockDuration = new Microsoft.WindowsAzure.CAT.ServiceBusExplorer.Grouper();
            this.lblLockDurationMilliseconds = new System.Windows.Forms.Label();
            this.txtLockDurationMilliseconds = new System.Windows.Forms.TextBox();
            this.lblLockDurationSeconds = new System.Windows.Forms.Label();
            this.txtLockDurationSeconds = new System.Windows.Forms.TextBox();
            this.lblLockDurationMinutes = new System.Windows.Forms.Label();
            this.txtLockDurationMinutes = new System.Windows.Forms.TextBox();
            this.lblLockDurationHours = new System.Windows.Forms.Label();
            this.lblLockDurationDays = new System.Windows.Forms.Label();
            this.txtLockDurationHours = new System.Windows.Forms.TextBox();
            this.txtLockDurationDays = new System.Windows.Forms.TextBox();
            this.groupergrouperDefaultMessageTimeToLive = new Microsoft.WindowsAzure.CAT.ServiceBusExplorer.Grouper();
            this.lblDefaultMessageTimeToLiveMilliseconds = new System.Windows.Forms.Label();
            this.txtDefaultMessageTimeToLiveMilliseconds = new System.Windows.Forms.TextBox();
            this.lblDefaultMessageTimeToLiveSeconds = new System.Windows.Forms.Label();
            this.txtDefaultMessageTimeToLiveSeconds = new System.Windows.Forms.TextBox();
            this.lblDefaultMessageTimeToLiveMinutes = new System.Windows.Forms.Label();
            this.txtDefaultMessageTimeToLiveMinutes = new System.Windows.Forms.TextBox();
            this.lbllblDefaultMessageTimeToLiveHours = new System.Windows.Forms.Label();
            this.lblDefaultMessageTimeToLiveDays = new System.Windows.Forms.Label();
            this.txtDefaultMessageTimeToLiveHours = new System.Windows.Forms.TextBox();
            this.txtDefaultMessageTimeToLiveDays = new System.Windows.Forms.TextBox();
            this.grouperName = new Microsoft.WindowsAzure.CAT.ServiceBusExplorer.Grouper();
            this.lblRelativeURI = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.grouperDefaultRule = new Microsoft.WindowsAzure.CAT.ServiceBusExplorer.Grouper();
            this.btnOpenActionForm = new System.Windows.Forms.Button();
            this.btnOpenFilterForm = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFilter = new System.Windows.Forms.Label();
            this.txtAction = new System.Windows.Forms.TextBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.grouperSubscriptionSettings = new Microsoft.WindowsAzure.CAT.ServiceBusExplorer.Grouper();
            this.checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.grouperSubscriptionInformation.SuspendLayout();
            this.grouperSubscriptionProperties.SuspendLayout();
            this.grouperLockDuration.SuspendLayout();
            this.groupergrouperDefaultMessageTimeToLive.SuspendLayout();
            this.grouperName.SuspendLayout();
            this.grouperDefaultRule.SuspendLayout();
            this.grouperSubscriptionSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRefresh.Location = new System.Drawing.Point(640, 360);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(72, 24);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            this.btnRefresh.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.btnRefresh.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // btnChangeStatus
            // 
            this.btnChangeStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangeStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.btnChangeStatus.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnChangeStatus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnChangeStatus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnChangeStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnChangeStatus.Location = new System.Drawing.Point(720, 360);
            this.btnChangeStatus.Name = "btnChangeStatus";
            this.btnChangeStatus.Size = new System.Drawing.Size(72, 24);
            this.btnChangeStatus.TabIndex = 8;
            this.btnChangeStatus.Text = "Disable";
            this.btnChangeStatus.UseVisualStyleBackColor = false;
            this.btnChangeStatus.Click += new System.EventHandler(this.btnChangeStatus_Click);
            this.btnChangeStatus.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.btnChangeStatus.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // btnCancelUpdate
            // 
            this.btnCancelUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.btnCancelUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnCancelUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnCancelUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnCancelUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancelUpdate.Location = new System.Drawing.Point(880, 360);
            this.btnCancelUpdate.Name = "btnCancelUpdate";
            this.btnCancelUpdate.Size = new System.Drawing.Size(72, 24);
            this.btnCancelUpdate.TabIndex = 10;
            this.btnCancelUpdate.Text = "Update";
            this.btnCancelUpdate.UseVisualStyleBackColor = false;
            this.btnCancelUpdate.Click += new System.EventHandler(this.btnCancelUpdate_Click);
            // 
            // btnCreateDelete
            // 
            this.btnCreateDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.btnCreateDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnCreateDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnCreateDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnCreateDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateDelete.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCreateDelete.Location = new System.Drawing.Point(800, 360);
            this.btnCreateDelete.Name = "btnCreateDelete";
            this.btnCreateDelete.Size = new System.Drawing.Size(72, 24);
            this.btnCreateDelete.TabIndex = 9;
            this.btnCreateDelete.Text = "Create";
            this.btnCreateDelete.UseVisualStyleBackColor = false;
            this.btnCreateDelete.Click += new System.EventHandler(this.btnCreateDelete_Click);
            this.btnCreateDelete.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.btnCreateDelete.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // grouperSubscriptionInformation
            // 
            this.grouperSubscriptionInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grouperSubscriptionInformation.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.grouperSubscriptionInformation.BackgroundGradientColor = System.Drawing.Color.White;
            this.grouperSubscriptionInformation.BackgroundGradientMode = Microsoft.WindowsAzure.CAT.ServiceBusExplorer.Grouper.GroupBoxGradientMode.None;
            this.grouperSubscriptionInformation.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.grouperSubscriptionInformation.BorderThickness = 1F;
            this.grouperSubscriptionInformation.Controls.Add(this.propertyListView);
            this.grouperSubscriptionInformation.CustomGroupBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.grouperSubscriptionInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grouperSubscriptionInformation.ForeColor = System.Drawing.Color.White;
            this.grouperSubscriptionInformation.GroupImage = null;
            this.grouperSubscriptionInformation.GroupTitle = "Subscription Information";
            this.grouperSubscriptionInformation.Location = new System.Drawing.Point(640, 8);
            this.grouperSubscriptionInformation.Name = "grouperSubscriptionInformation";
            this.grouperSubscriptionInformation.Padding = new System.Windows.Forms.Padding(20);
            this.grouperSubscriptionInformation.PaintGroupBox = true;
            this.grouperSubscriptionInformation.RoundCorners = 4;
            this.grouperSubscriptionInformation.ShadowColor = System.Drawing.Color.DarkGray;
            this.grouperSubscriptionInformation.ShadowControl = false;
            this.grouperSubscriptionInformation.ShadowThickness = 1;
            this.grouperSubscriptionInformation.Size = new System.Drawing.Size(312, 344);
            this.grouperSubscriptionInformation.TabIndex = 6;
            // 
            // propertyListView
            // 
            this.propertyListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader,
            this.valueColumnHeader});
            this.propertyListView.Location = new System.Drawing.Point(16, 32);
            this.propertyListView.Name = "propertyListView";
            this.propertyListView.OwnerDraw = true;
            this.propertyListView.Size = new System.Drawing.Size(279, 296);
            this.propertyListView.TabIndex = 0;
            this.propertyListView.UseCompatibleStateImageBehavior = false;
            this.propertyListView.View = System.Windows.Forms.View.Details;
            this.propertyListView.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.propertyListView_DrawColumnHeader);
            this.propertyListView.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.propertyListView_DrawItem);
            this.propertyListView.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.propertyListView_DrawSubItem);
            this.propertyListView.Resize += new System.EventHandler(this.propertyListView_Resize);
            // 
            // nameColumnHeader
            // 
            this.nameColumnHeader.Text = "Name";
            this.nameColumnHeader.Width = 160;
            // 
            // valueColumnHeader
            // 
            this.valueColumnHeader.Text = "Value";
            this.valueColumnHeader.Width = 115;
            // 
            // grouperSubscriptionProperties
            // 
            this.grouperSubscriptionProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grouperSubscriptionProperties.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.grouperSubscriptionProperties.BackgroundGradientColor = System.Drawing.Color.White;
            this.grouperSubscriptionProperties.BackgroundGradientMode = Microsoft.WindowsAzure.CAT.ServiceBusExplorer.Grouper.GroupBoxGradientMode.None;
            this.grouperSubscriptionProperties.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.grouperSubscriptionProperties.BorderThickness = 1F;
            this.grouperSubscriptionProperties.Controls.Add(this.btnOpenDescriptionForm);
            this.grouperSubscriptionProperties.Controls.Add(this.txtUserMetadata);
            this.grouperSubscriptionProperties.Controls.Add(this.btnOpenForwardToForm);
            this.grouperSubscriptionProperties.Controls.Add(this.lblForwardTo);
            this.grouperSubscriptionProperties.Controls.Add(this.txtForwardTo);
            this.grouperSubscriptionProperties.Controls.Add(this.label2);
            this.grouperSubscriptionProperties.Controls.Add(this.label3);
            this.grouperSubscriptionProperties.Controls.Add(this.txtMaxDeliveryCount);
            this.grouperSubscriptionProperties.CustomGroupBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.grouperSubscriptionProperties.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grouperSubscriptionProperties.ForeColor = System.Drawing.Color.White;
            this.grouperSubscriptionProperties.GroupImage = null;
            this.grouperSubscriptionProperties.GroupTitle = "Subscription Properties";
            this.grouperSubscriptionProperties.Location = new System.Drawing.Point(16, 184);
            this.grouperSubscriptionProperties.Name = "grouperSubscriptionProperties";
            this.grouperSubscriptionProperties.Padding = new System.Windows.Forms.Padding(20);
            this.grouperSubscriptionProperties.PaintGroupBox = true;
            this.grouperSubscriptionProperties.RoundCorners = 4;
            this.grouperSubscriptionProperties.ShadowColor = System.Drawing.Color.DarkGray;
            this.grouperSubscriptionProperties.ShadowControl = false;
            this.grouperSubscriptionProperties.ShadowThickness = 1;
            this.grouperSubscriptionProperties.Size = new System.Drawing.Size(296, 168);
            this.grouperSubscriptionProperties.TabIndex = 4;
            // 
            // btnOpenDescriptionForm
            // 
            this.btnOpenDescriptionForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenDescriptionForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.btnOpenDescriptionForm.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnOpenDescriptionForm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnOpenDescriptionForm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnOpenDescriptionForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenDescriptionForm.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOpenDescriptionForm.Location = new System.Drawing.Point(256, 88);
            this.btnOpenDescriptionForm.Name = "btnOpenDescriptionForm";
            this.btnOpenDescriptionForm.Size = new System.Drawing.Size(24, 21);
            this.btnOpenDescriptionForm.TabIndex = 3;
            this.btnOpenDescriptionForm.Text = "...";
            this.btnOpenDescriptionForm.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOpenDescriptionForm.UseVisualStyleBackColor = false;
            this.btnOpenDescriptionForm.Click += new System.EventHandler(this.btnOpenUserMetadataForm_Click);
            this.btnOpenDescriptionForm.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.btnOpenDescriptionForm.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // txtUserMetadata
            // 
            this.txtUserMetadata.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserMetadata.BackColor = System.Drawing.SystemColors.Window;
            this.txtUserMetadata.Location = new System.Drawing.Point(16, 88);
            this.txtUserMetadata.Name = "txtUserMetadata";
            this.txtUserMetadata.Size = new System.Drawing.Size(232, 20);
            this.txtUserMetadata.TabIndex = 2;
            // 
            // btnOpenForwardToForm
            // 
            this.btnOpenForwardToForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenForwardToForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.btnOpenForwardToForm.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnOpenForwardToForm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnOpenForwardToForm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnOpenForwardToForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenForwardToForm.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOpenForwardToForm.Location = new System.Drawing.Point(256, 132);
            this.btnOpenForwardToForm.Name = "btnOpenForwardToForm";
            this.btnOpenForwardToForm.Size = new System.Drawing.Size(24, 21);
            this.btnOpenForwardToForm.TabIndex = 5;
            this.btnOpenForwardToForm.Text = "...";
            this.btnOpenForwardToForm.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOpenForwardToForm.UseVisualStyleBackColor = false;
            this.btnOpenForwardToForm.Click += new System.EventHandler(this.btnOpenForwardToForm_Click);
            this.btnOpenForwardToForm.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.btnOpenForwardToForm.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // lblForwardTo
            // 
            this.lblForwardTo.AutoSize = true;
            this.lblForwardTo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblForwardTo.Location = new System.Drawing.Point(16, 116);
            this.lblForwardTo.Name = "lblForwardTo";
            this.lblForwardTo.Size = new System.Drawing.Size(64, 13);
            this.lblForwardTo.TabIndex = 31;
            this.lblForwardTo.Text = "Forward To:";
            // 
            // txtForwardTo
            // 
            this.txtForwardTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtForwardTo.BackColor = System.Drawing.SystemColors.Window;
            this.txtForwardTo.Location = new System.Drawing.Point(16, 132);
            this.txtForwardTo.Name = "txtForwardTo";
            this.txtForwardTo.Size = new System.Drawing.Size(232, 20);
            this.txtForwardTo.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(16, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Max Delivery Count:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(16, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "User Description:";
            // 
            // txtMaxDeliveryCount
            // 
            this.txtMaxDeliveryCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaxDeliveryCount.BackColor = System.Drawing.SystemColors.Window;
            this.txtMaxDeliveryCount.Location = new System.Drawing.Point(16, 44);
            this.txtMaxDeliveryCount.Name = "txtMaxDeliveryCount";
            this.txtMaxDeliveryCount.Size = new System.Drawing.Size(232, 20);
            this.txtMaxDeliveryCount.TabIndex = 0;
            // 
            // grouperLockDuration
            // 
            this.grouperLockDuration.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.grouperLockDuration.BackgroundGradientColor = System.Drawing.Color.White;
            this.grouperLockDuration.BackgroundGradientMode = Microsoft.WindowsAzure.CAT.ServiceBusExplorer.Grouper.GroupBoxGradientMode.None;
            this.grouperLockDuration.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.grouperLockDuration.BorderThickness = 1F;
            this.grouperLockDuration.Controls.Add(this.lblLockDurationMilliseconds);
            this.grouperLockDuration.Controls.Add(this.txtLockDurationMilliseconds);
            this.grouperLockDuration.Controls.Add(this.lblLockDurationSeconds);
            this.grouperLockDuration.Controls.Add(this.txtLockDurationSeconds);
            this.grouperLockDuration.Controls.Add(this.lblLockDurationMinutes);
            this.grouperLockDuration.Controls.Add(this.txtLockDurationMinutes);
            this.grouperLockDuration.Controls.Add(this.lblLockDurationHours);
            this.grouperLockDuration.Controls.Add(this.lblLockDurationDays);
            this.grouperLockDuration.Controls.Add(this.txtLockDurationHours);
            this.grouperLockDuration.Controls.Add(this.txtLockDurationDays);
            this.grouperLockDuration.CustomGroupBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.grouperLockDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grouperLockDuration.ForeColor = System.Drawing.Color.White;
            this.grouperLockDuration.GroupImage = null;
            this.grouperLockDuration.GroupTitle = "Lock Duration";
            this.grouperLockDuration.Location = new System.Drawing.Point(328, 8);
            this.grouperLockDuration.Name = "grouperLockDuration";
            this.grouperLockDuration.Padding = new System.Windows.Forms.Padding(20);
            this.grouperLockDuration.PaintGroupBox = true;
            this.grouperLockDuration.RoundCorners = 4;
            this.grouperLockDuration.ShadowColor = System.Drawing.Color.DarkGray;
            this.grouperLockDuration.ShadowControl = false;
            this.grouperLockDuration.ShadowThickness = 1;
            this.grouperLockDuration.Size = new System.Drawing.Size(296, 80);
            this.grouperLockDuration.TabIndex = 1;
            // 
            // lblLockDurationMilliseconds
            // 
            this.lblLockDurationMilliseconds.AutoSize = true;
            this.lblLockDurationMilliseconds.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLockDurationMilliseconds.Location = new System.Drawing.Point(240, 28);
            this.lblLockDurationMilliseconds.Name = "lblLockDurationMilliseconds";
            this.lblLockDurationMilliseconds.Size = new System.Drawing.Size(49, 13);
            this.lblLockDurationMilliseconds.TabIndex = 25;
            this.lblLockDurationMilliseconds.Text = "Millisecs:";
            // 
            // txtLockDurationMilliseconds
            // 
            this.txtLockDurationMilliseconds.BackColor = System.Drawing.SystemColors.Window;
            this.txtLockDurationMilliseconds.Location = new System.Drawing.Point(240, 44);
            this.txtLockDurationMilliseconds.Name = "txtLockDurationMilliseconds";
            this.txtLockDurationMilliseconds.Size = new System.Drawing.Size(40, 20);
            this.txtLockDurationMilliseconds.TabIndex = 4;
            // 
            // lblLockDurationSeconds
            // 
            this.lblLockDurationSeconds.AutoSize = true;
            this.lblLockDurationSeconds.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLockDurationSeconds.Location = new System.Drawing.Point(184, 28);
            this.lblLockDurationSeconds.Name = "lblLockDurationSeconds";
            this.lblLockDurationSeconds.Size = new System.Drawing.Size(52, 13);
            this.lblLockDurationSeconds.TabIndex = 24;
            this.lblLockDurationSeconds.Text = "Seconds:";
            // 
            // txtLockDurationSeconds
            // 
            this.txtLockDurationSeconds.BackColor = System.Drawing.SystemColors.Window;
            this.txtLockDurationSeconds.Location = new System.Drawing.Point(184, 44);
            this.txtLockDurationSeconds.Name = "txtLockDurationSeconds";
            this.txtLockDurationSeconds.Size = new System.Drawing.Size(40, 20);
            this.txtLockDurationSeconds.TabIndex = 3;
            // 
            // lblLockDurationMinutes
            // 
            this.lblLockDurationMinutes.AutoSize = true;
            this.lblLockDurationMinutes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLockDurationMinutes.Location = new System.Drawing.Point(128, 28);
            this.lblLockDurationMinutes.Name = "lblLockDurationMinutes";
            this.lblLockDurationMinutes.Size = new System.Drawing.Size(47, 13);
            this.lblLockDurationMinutes.TabIndex = 23;
            this.lblLockDurationMinutes.Text = "Minutes:";
            // 
            // txtLockDurationMinutes
            // 
            this.txtLockDurationMinutes.BackColor = System.Drawing.SystemColors.Window;
            this.txtLockDurationMinutes.Location = new System.Drawing.Point(128, 44);
            this.txtLockDurationMinutes.Name = "txtLockDurationMinutes";
            this.txtLockDurationMinutes.Size = new System.Drawing.Size(40, 20);
            this.txtLockDurationMinutes.TabIndex = 2;
            // 
            // lblLockDurationHours
            // 
            this.lblLockDurationHours.AutoSize = true;
            this.lblLockDurationHours.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLockDurationHours.Location = new System.Drawing.Point(72, 28);
            this.lblLockDurationHours.Name = "lblLockDurationHours";
            this.lblLockDurationHours.Size = new System.Drawing.Size(38, 13);
            this.lblLockDurationHours.TabIndex = 22;
            this.lblLockDurationHours.Text = "Hours:";
            // 
            // lblLockDurationDays
            // 
            this.lblLockDurationDays.AutoSize = true;
            this.lblLockDurationDays.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLockDurationDays.Location = new System.Drawing.Point(16, 28);
            this.lblLockDurationDays.Name = "lblLockDurationDays";
            this.lblLockDurationDays.Size = new System.Drawing.Size(34, 13);
            this.lblLockDurationDays.TabIndex = 21;
            this.lblLockDurationDays.Text = "Days:";
            // 
            // txtLockDurationHours
            // 
            this.txtLockDurationHours.BackColor = System.Drawing.SystemColors.Window;
            this.txtLockDurationHours.Location = new System.Drawing.Point(72, 44);
            this.txtLockDurationHours.Name = "txtLockDurationHours";
            this.txtLockDurationHours.Size = new System.Drawing.Size(40, 20);
            this.txtLockDurationHours.TabIndex = 1;
            // 
            // txtLockDurationDays
            // 
            this.txtLockDurationDays.BackColor = System.Drawing.SystemColors.Window;
            this.txtLockDurationDays.Location = new System.Drawing.Point(16, 44);
            this.txtLockDurationDays.Name = "txtLockDurationDays";
            this.txtLockDurationDays.Size = new System.Drawing.Size(40, 20);
            this.txtLockDurationDays.TabIndex = 0;
            // 
            // groupergrouperDefaultMessageTimeToLive
            // 
            this.groupergrouperDefaultMessageTimeToLive.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.groupergrouperDefaultMessageTimeToLive.BackgroundGradientColor = System.Drawing.Color.White;
            this.groupergrouperDefaultMessageTimeToLive.BackgroundGradientMode = Microsoft.WindowsAzure.CAT.ServiceBusExplorer.Grouper.GroupBoxGradientMode.None;
            this.groupergrouperDefaultMessageTimeToLive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.groupergrouperDefaultMessageTimeToLive.BorderThickness = 1F;
            this.groupergrouperDefaultMessageTimeToLive.Controls.Add(this.lblDefaultMessageTimeToLiveMilliseconds);
            this.groupergrouperDefaultMessageTimeToLive.Controls.Add(this.txtDefaultMessageTimeToLiveMilliseconds);
            this.groupergrouperDefaultMessageTimeToLive.Controls.Add(this.lblDefaultMessageTimeToLiveSeconds);
            this.groupergrouperDefaultMessageTimeToLive.Controls.Add(this.txtDefaultMessageTimeToLiveSeconds);
            this.groupergrouperDefaultMessageTimeToLive.Controls.Add(this.lblDefaultMessageTimeToLiveMinutes);
            this.groupergrouperDefaultMessageTimeToLive.Controls.Add(this.txtDefaultMessageTimeToLiveMinutes);
            this.groupergrouperDefaultMessageTimeToLive.Controls.Add(this.lbllblDefaultMessageTimeToLiveHours);
            this.groupergrouperDefaultMessageTimeToLive.Controls.Add(this.lblDefaultMessageTimeToLiveDays);
            this.groupergrouperDefaultMessageTimeToLive.Controls.Add(this.txtDefaultMessageTimeToLiveHours);
            this.groupergrouperDefaultMessageTimeToLive.Controls.Add(this.txtDefaultMessageTimeToLiveDays);
            this.groupergrouperDefaultMessageTimeToLive.CustomGroupBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.groupergrouperDefaultMessageTimeToLive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.groupergrouperDefaultMessageTimeToLive.ForeColor = System.Drawing.Color.White;
            this.groupergrouperDefaultMessageTimeToLive.GroupImage = null;
            this.groupergrouperDefaultMessageTimeToLive.GroupTitle = "Default Message Time To Live";
            this.groupergrouperDefaultMessageTimeToLive.Location = new System.Drawing.Point(16, 96);
            this.groupergrouperDefaultMessageTimeToLive.Name = "groupergrouperDefaultMessageTimeToLive";
            this.groupergrouperDefaultMessageTimeToLive.Padding = new System.Windows.Forms.Padding(20);
            this.groupergrouperDefaultMessageTimeToLive.PaintGroupBox = true;
            this.groupergrouperDefaultMessageTimeToLive.RoundCorners = 4;
            this.groupergrouperDefaultMessageTimeToLive.ShadowColor = System.Drawing.Color.DarkGray;
            this.groupergrouperDefaultMessageTimeToLive.ShadowControl = false;
            this.groupergrouperDefaultMessageTimeToLive.ShadowThickness = 1;
            this.groupergrouperDefaultMessageTimeToLive.Size = new System.Drawing.Size(296, 80);
            this.groupergrouperDefaultMessageTimeToLive.TabIndex = 2;
            // 
            // lblDefaultMessageTimeToLiveMilliseconds
            // 
            this.lblDefaultMessageTimeToLiveMilliseconds.AutoSize = true;
            this.lblDefaultMessageTimeToLiveMilliseconds.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDefaultMessageTimeToLiveMilliseconds.Location = new System.Drawing.Point(240, 28);
            this.lblDefaultMessageTimeToLiveMilliseconds.Name = "lblDefaultMessageTimeToLiveMilliseconds";
            this.lblDefaultMessageTimeToLiveMilliseconds.Size = new System.Drawing.Size(49, 13);
            this.lblDefaultMessageTimeToLiveMilliseconds.TabIndex = 25;
            this.lblDefaultMessageTimeToLiveMilliseconds.Text = "Millisecs:";
            // 
            // txtDefaultMessageTimeToLiveMilliseconds
            // 
            this.txtDefaultMessageTimeToLiveMilliseconds.BackColor = System.Drawing.SystemColors.Window;
            this.txtDefaultMessageTimeToLiveMilliseconds.Location = new System.Drawing.Point(240, 44);
            this.txtDefaultMessageTimeToLiveMilliseconds.Name = "txtDefaultMessageTimeToLiveMilliseconds";
            this.txtDefaultMessageTimeToLiveMilliseconds.Size = new System.Drawing.Size(40, 20);
            this.txtDefaultMessageTimeToLiveMilliseconds.TabIndex = 4;
            // 
            // lblDefaultMessageTimeToLiveSeconds
            // 
            this.lblDefaultMessageTimeToLiveSeconds.AutoSize = true;
            this.lblDefaultMessageTimeToLiveSeconds.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDefaultMessageTimeToLiveSeconds.Location = new System.Drawing.Point(184, 28);
            this.lblDefaultMessageTimeToLiveSeconds.Name = "lblDefaultMessageTimeToLiveSeconds";
            this.lblDefaultMessageTimeToLiveSeconds.Size = new System.Drawing.Size(52, 13);
            this.lblDefaultMessageTimeToLiveSeconds.TabIndex = 24;
            this.lblDefaultMessageTimeToLiveSeconds.Text = "Seconds:";
            // 
            // txtDefaultMessageTimeToLiveSeconds
            // 
            this.txtDefaultMessageTimeToLiveSeconds.BackColor = System.Drawing.SystemColors.Window;
            this.txtDefaultMessageTimeToLiveSeconds.Location = new System.Drawing.Point(184, 44);
            this.txtDefaultMessageTimeToLiveSeconds.Name = "txtDefaultMessageTimeToLiveSeconds";
            this.txtDefaultMessageTimeToLiveSeconds.Size = new System.Drawing.Size(40, 20);
            this.txtDefaultMessageTimeToLiveSeconds.TabIndex = 3;
            // 
            // lblDefaultMessageTimeToLiveMinutes
            // 
            this.lblDefaultMessageTimeToLiveMinutes.AutoSize = true;
            this.lblDefaultMessageTimeToLiveMinutes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDefaultMessageTimeToLiveMinutes.Location = new System.Drawing.Point(128, 28);
            this.lblDefaultMessageTimeToLiveMinutes.Name = "lblDefaultMessageTimeToLiveMinutes";
            this.lblDefaultMessageTimeToLiveMinutes.Size = new System.Drawing.Size(47, 13);
            this.lblDefaultMessageTimeToLiveMinutes.TabIndex = 23;
            this.lblDefaultMessageTimeToLiveMinutes.Text = "Minutes:";
            // 
            // txtDefaultMessageTimeToLiveMinutes
            // 
            this.txtDefaultMessageTimeToLiveMinutes.BackColor = System.Drawing.SystemColors.Window;
            this.txtDefaultMessageTimeToLiveMinutes.Location = new System.Drawing.Point(128, 44);
            this.txtDefaultMessageTimeToLiveMinutes.Name = "txtDefaultMessageTimeToLiveMinutes";
            this.txtDefaultMessageTimeToLiveMinutes.Size = new System.Drawing.Size(40, 20);
            this.txtDefaultMessageTimeToLiveMinutes.TabIndex = 2;
            // 
            // lbllblDefaultMessageTimeToLiveHours
            // 
            this.lbllblDefaultMessageTimeToLiveHours.AutoSize = true;
            this.lbllblDefaultMessageTimeToLiveHours.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbllblDefaultMessageTimeToLiveHours.Location = new System.Drawing.Point(72, 28);
            this.lbllblDefaultMessageTimeToLiveHours.Name = "lbllblDefaultMessageTimeToLiveHours";
            this.lbllblDefaultMessageTimeToLiveHours.Size = new System.Drawing.Size(38, 13);
            this.lbllblDefaultMessageTimeToLiveHours.TabIndex = 22;
            this.lbllblDefaultMessageTimeToLiveHours.Text = "Hours:";
            // 
            // lblDefaultMessageTimeToLiveDays
            // 
            this.lblDefaultMessageTimeToLiveDays.AutoSize = true;
            this.lblDefaultMessageTimeToLiveDays.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDefaultMessageTimeToLiveDays.Location = new System.Drawing.Point(16, 28);
            this.lblDefaultMessageTimeToLiveDays.Name = "lblDefaultMessageTimeToLiveDays";
            this.lblDefaultMessageTimeToLiveDays.Size = new System.Drawing.Size(34, 13);
            this.lblDefaultMessageTimeToLiveDays.TabIndex = 21;
            this.lblDefaultMessageTimeToLiveDays.Text = "Days:";
            // 
            // txtDefaultMessageTimeToLiveHours
            // 
            this.txtDefaultMessageTimeToLiveHours.BackColor = System.Drawing.SystemColors.Window;
            this.txtDefaultMessageTimeToLiveHours.Location = new System.Drawing.Point(72, 44);
            this.txtDefaultMessageTimeToLiveHours.Name = "txtDefaultMessageTimeToLiveHours";
            this.txtDefaultMessageTimeToLiveHours.Size = new System.Drawing.Size(40, 20);
            this.txtDefaultMessageTimeToLiveHours.TabIndex = 1;
            // 
            // txtDefaultMessageTimeToLiveDays
            // 
            this.txtDefaultMessageTimeToLiveDays.BackColor = System.Drawing.SystemColors.Window;
            this.txtDefaultMessageTimeToLiveDays.Location = new System.Drawing.Point(16, 44);
            this.txtDefaultMessageTimeToLiveDays.Name = "txtDefaultMessageTimeToLiveDays";
            this.txtDefaultMessageTimeToLiveDays.Size = new System.Drawing.Size(40, 20);
            this.txtDefaultMessageTimeToLiveDays.TabIndex = 0;
            // 
            // grouperName
            // 
            this.grouperName.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.grouperName.BackgroundGradientColor = System.Drawing.Color.White;
            this.grouperName.BackgroundGradientMode = Microsoft.WindowsAzure.CAT.ServiceBusExplorer.Grouper.GroupBoxGradientMode.None;
            this.grouperName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.grouperName.BorderThickness = 1F;
            this.grouperName.Controls.Add(this.lblRelativeURI);
            this.grouperName.Controls.Add(this.txtName);
            this.grouperName.CustomGroupBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.grouperName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grouperName.ForeColor = System.Drawing.Color.White;
            this.grouperName.GroupImage = null;
            this.grouperName.GroupTitle = "Name";
            this.grouperName.Location = new System.Drawing.Point(16, 8);
            this.grouperName.Name = "grouperName";
            this.grouperName.Padding = new System.Windows.Forms.Padding(20);
            this.grouperName.PaintGroupBox = true;
            this.grouperName.RoundCorners = 4;
            this.grouperName.ShadowColor = System.Drawing.Color.DarkGray;
            this.grouperName.ShadowControl = false;
            this.grouperName.ShadowThickness = 1;
            this.grouperName.Size = new System.Drawing.Size(296, 80);
            this.grouperName.TabIndex = 0;
            // 
            // lblRelativeURI
            // 
            this.lblRelativeURI.AutoSize = true;
            this.lblRelativeURI.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRelativeURI.Location = new System.Drawing.Point(16, 28);
            this.lblRelativeURI.Name = "lblRelativeURI";
            this.lblRelativeURI.Size = new System.Drawing.Size(99, 13);
            this.lblRelativeURI.TabIndex = 22;
            this.lblRelativeURI.Text = "Subscription Name:";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.BackColor = System.Drawing.SystemColors.Window;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtName.Location = new System.Drawing.Point(16, 44);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(264, 20);
            this.txtName.TabIndex = 0;
            // 
            // grouperDefaultRule
            // 
            this.grouperDefaultRule.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.grouperDefaultRule.BackgroundGradientColor = System.Drawing.Color.White;
            this.grouperDefaultRule.BackgroundGradientMode = Microsoft.WindowsAzure.CAT.ServiceBusExplorer.Grouper.GroupBoxGradientMode.None;
            this.grouperDefaultRule.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.grouperDefaultRule.BorderThickness = 1F;
            this.grouperDefaultRule.Controls.Add(this.btnOpenActionForm);
            this.grouperDefaultRule.Controls.Add(this.btnOpenFilterForm);
            this.grouperDefaultRule.Controls.Add(this.label1);
            this.grouperDefaultRule.Controls.Add(this.lblFilter);
            this.grouperDefaultRule.Controls.Add(this.txtAction);
            this.grouperDefaultRule.Controls.Add(this.txtFilter);
            this.grouperDefaultRule.CustomGroupBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.grouperDefaultRule.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grouperDefaultRule.ForeColor = System.Drawing.Color.White;
            this.grouperDefaultRule.GroupImage = null;
            this.grouperDefaultRule.GroupTitle = "Default Rule";
            this.grouperDefaultRule.Location = new System.Drawing.Point(328, 96);
            this.grouperDefaultRule.Name = "grouperDefaultRule";
            this.grouperDefaultRule.Padding = new System.Windows.Forms.Padding(20);
            this.grouperDefaultRule.PaintGroupBox = true;
            this.grouperDefaultRule.RoundCorners = 4;
            this.grouperDefaultRule.ShadowColor = System.Drawing.Color.DarkGray;
            this.grouperDefaultRule.ShadowControl = false;
            this.grouperDefaultRule.ShadowThickness = 1;
            this.grouperDefaultRule.Size = new System.Drawing.Size(296, 120);
            this.grouperDefaultRule.TabIndex = 3;
            // 
            // btnOpenActionForm
            // 
            this.btnOpenActionForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenActionForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.btnOpenActionForm.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnOpenActionForm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnOpenActionForm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnOpenActionForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenActionForm.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOpenActionForm.Location = new System.Drawing.Point(256, 88);
            this.btnOpenActionForm.Name = "btnOpenActionForm";
            this.btnOpenActionForm.Size = new System.Drawing.Size(24, 21);
            this.btnOpenActionForm.TabIndex = 3;
            this.btnOpenActionForm.Text = "...";
            this.btnOpenActionForm.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOpenActionForm.UseVisualStyleBackColor = false;
            this.btnOpenActionForm.Click += new System.EventHandler(this.btnOpenActionForm_Click);
            this.btnOpenActionForm.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.btnOpenActionForm.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // btnOpenFilterForm
            // 
            this.btnOpenFilterForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFilterForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.btnOpenFilterForm.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnOpenFilterForm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnOpenFilterForm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnOpenFilterForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenFilterForm.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOpenFilterForm.Location = new System.Drawing.Point(256, 44);
            this.btnOpenFilterForm.Name = "btnOpenFilterForm";
            this.btnOpenFilterForm.Size = new System.Drawing.Size(24, 21);
            this.btnOpenFilterForm.TabIndex = 1;
            this.btnOpenFilterForm.Text = "...";
            this.btnOpenFilterForm.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOpenFilterForm.UseVisualStyleBackColor = false;
            this.btnOpenFilterForm.Click += new System.EventHandler(this.openOpenFilterForm_Click);
            this.btnOpenFilterForm.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.btnOpenFilterForm.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(16, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Action:";
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblFilter.Location = new System.Drawing.Point(16, 28);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(32, 13);
            this.lblFilter.TabIndex = 27;
            this.lblFilter.Text = "Filter:";
            // 
            // txtAction
            // 
            this.txtAction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAction.BackColor = System.Drawing.SystemColors.Window;
            this.txtAction.Location = new System.Drawing.Point(16, 88);
            this.txtAction.Name = "txtAction";
            this.txtAction.Size = new System.Drawing.Size(232, 20);
            this.txtAction.TabIndex = 2;
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.BackColor = System.Drawing.SystemColors.Window;
            this.txtFilter.Location = new System.Drawing.Point(16, 44);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(232, 20);
            this.txtFilter.TabIndex = 0;
            this.txtFilter.Text = "1=1";
            // 
            // grouperSubscriptionSettings
            // 
            this.grouperSubscriptionSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grouperSubscriptionSettings.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.grouperSubscriptionSettings.BackgroundGradientColor = System.Drawing.Color.White;
            this.grouperSubscriptionSettings.BackgroundGradientMode = Microsoft.WindowsAzure.CAT.ServiceBusExplorer.Grouper.GroupBoxGradientMode.None;
            this.grouperSubscriptionSettings.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.grouperSubscriptionSettings.BorderThickness = 1F;
            this.grouperSubscriptionSettings.Controls.Add(this.checkedListBox);
            this.grouperSubscriptionSettings.CustomGroupBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.grouperSubscriptionSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grouperSubscriptionSettings.ForeColor = System.Drawing.Color.White;
            this.grouperSubscriptionSettings.GroupImage = null;
            this.grouperSubscriptionSettings.GroupTitle = "Subscription Settings";
            this.grouperSubscriptionSettings.Location = new System.Drawing.Point(328, 224);
            this.grouperSubscriptionSettings.Name = "grouperSubscriptionSettings";
            this.grouperSubscriptionSettings.Padding = new System.Windows.Forms.Padding(20);
            this.grouperSubscriptionSettings.PaintGroupBox = true;
            this.grouperSubscriptionSettings.RoundCorners = 4;
            this.grouperSubscriptionSettings.ShadowColor = System.Drawing.Color.DarkGray;
            this.grouperSubscriptionSettings.ShadowControl = false;
            this.grouperSubscriptionSettings.ShadowThickness = 1;
            this.grouperSubscriptionSettings.Size = new System.Drawing.Size(296, 128);
            this.grouperSubscriptionSettings.TabIndex = 5;
            // 
            // checkedListBox
            // 
            this.checkedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBox.CheckOnClick = true;
            this.checkedListBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.checkedListBox.FormattingEnabled = true;
            this.checkedListBox.Items.AddRange(new object[] {
            "Enable Batched Operations ",
            "Enable Dead Lettering On Filter Evaluation Error",
            "Enable Dead Lettering On Message Expiration",
            "Requires Session"});
            this.checkedListBox.Location = new System.Drawing.Point(16, 32);
            this.checkedListBox.Margin = new System.Windows.Forms.Padding(8);
            this.checkedListBox.Name = "checkedListBox";
            this.checkedListBox.Size = new System.Drawing.Size(264, 79);
            this.checkedListBox.TabIndex = 0;
            this.checkedListBox.ThreeDCheckBoxes = true;
            // 
            // HandleSubscriptionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.grouperSubscriptionInformation);
            this.Controls.Add(this.btnChangeStatus);
            this.Controls.Add(this.btnCancelUpdate);
            this.Controls.Add(this.grouperSubscriptionProperties);
            this.Controls.Add(this.btnCreateDelete);
            this.Controls.Add(this.grouperLockDuration);
            this.Controls.Add(this.groupergrouperDefaultMessageTimeToLive);
            this.Controls.Add(this.grouperName);
            this.Controls.Add(this.grouperDefaultRule);
            this.Controls.Add(this.grouperSubscriptionSettings);
            this.Name = "HandleSubscriptionControl";
            this.Size = new System.Drawing.Size(968, 400);
            this.grouperSubscriptionInformation.ResumeLayout(false);
            this.grouperSubscriptionProperties.ResumeLayout(false);
            this.grouperSubscriptionProperties.PerformLayout();
            this.grouperLockDuration.ResumeLayout(false);
            this.grouperLockDuration.PerformLayout();
            this.groupergrouperDefaultMessageTimeToLive.ResumeLayout(false);
            this.groupergrouperDefaultMessageTimeToLive.PerformLayout();
            this.grouperName.ResumeLayout(false);
            this.grouperName.PerformLayout();
            this.grouperDefaultRule.ResumeLayout(false);
            this.grouperDefaultRule.PerformLayout();
            this.grouperSubscriptionSettings.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip;
        private Grouper grouperSubscriptionSettings;
        private System.Windows.Forms.CheckedListBox checkedListBox;
        private Grouper grouperDefaultRule;
        private System.Windows.Forms.Button btnOpenActionForm;
        private System.Windows.Forms.Button btnOpenFilterForm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.TextBox txtAction;
        private System.Windows.Forms.TextBox txtFilter;
        private Grouper groupergrouperDefaultMessageTimeToLive;
        private System.Windows.Forms.Label lblDefaultMessageTimeToLiveMilliseconds;
        private System.Windows.Forms.TextBox txtDefaultMessageTimeToLiveMilliseconds;
        private System.Windows.Forms.Label lblDefaultMessageTimeToLiveSeconds;
        private System.Windows.Forms.TextBox txtDefaultMessageTimeToLiveSeconds;
        private System.Windows.Forms.Label lblDefaultMessageTimeToLiveMinutes;
        private System.Windows.Forms.TextBox txtDefaultMessageTimeToLiveMinutes;
        private System.Windows.Forms.Label lbllblDefaultMessageTimeToLiveHours;
        private System.Windows.Forms.Label lblDefaultMessageTimeToLiveDays;
        private System.Windows.Forms.TextBox txtDefaultMessageTimeToLiveHours;
        private System.Windows.Forms.TextBox txtDefaultMessageTimeToLiveDays;
        private Grouper grouperName;
        private System.Windows.Forms.TextBox txtName;
        private Grouper grouperLockDuration;
        private System.Windows.Forms.Label lblLockDurationMilliseconds;
        private System.Windows.Forms.TextBox txtLockDurationMilliseconds;
        private System.Windows.Forms.Label lblLockDurationSeconds;
        private System.Windows.Forms.TextBox txtLockDurationSeconds;
        private System.Windows.Forms.Label lblLockDurationMinutes;
        private System.Windows.Forms.TextBox txtLockDurationMinutes;
        private System.Windows.Forms.Label lblLockDurationHours;
        private System.Windows.Forms.Label lblLockDurationDays;
        private System.Windows.Forms.TextBox txtLockDurationHours;
        private System.Windows.Forms.TextBox txtLockDurationDays;
        private Grouper grouperSubscriptionProperties;
        private System.Windows.Forms.Button btnOpenDescriptionForm;
        private System.Windows.Forms.TextBox txtUserMetadata;
        private System.Windows.Forms.Button btnOpenForwardToForm;
        private System.Windows.Forms.Label lblForwardTo;
        private System.Windows.Forms.TextBox txtForwardTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaxDeliveryCount;
        private Grouper grouperSubscriptionInformation;
        private System.Windows.Forms.ListView propertyListView;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.ColumnHeader valueColumnHeader;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnChangeStatus;
        private System.Windows.Forms.Button btnCancelUpdate;
        private System.Windows.Forms.Button btnCreateDelete;
        private System.Windows.Forms.Label lblRelativeURI;
    }
}
