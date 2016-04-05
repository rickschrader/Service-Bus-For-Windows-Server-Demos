#region Copyright
//=======================================================================================
// Microsoft Business Platform Division Customer Advisory Team  
//
// This sample is supplemental to the technical guidance published on the community
// blog at http://www.appfabriccat.com/. 
// 
// Author: Paolo Salvatori
//=======================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
// EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
// MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=======================================================================================
#endregion

#region Using Directives
using System;
using System.Windows.Forms;
using System.Drawing;
#endregion

namespace Microsoft.WindowsAzure.CAT.ServiceBusExplorer
{
    public partial class OptionForm : Form
    {
        #region Public Constructor
        public OptionForm(decimal logFontSize, 
                          decimal treeViewFontSize, 
                          int retryCount,
                          int retryTimeout,
                          int receiveTimeout,
                          int sessionTimeout,
                          int prefetchCount,
                          int top,
                          bool saveMessageToFile,
                          bool savePropertiesToFile)
        {
            InitializeComponent();
            
            LogFontSize = logFontSize;
            TreeViewFontSize = treeViewFontSize;
            RetryCount = retryCount;
            RetryTimeout = retryTimeout;
            ReceiveTimeout = receiveTimeout;
            SessionTimeout = sessionTimeout;
            PrefetchCount = prefetchCount;
            TopCount = top;

            logNumericUpDown.Value = logFontSize;
            treeViewNumericUpDown.Value = treeViewFontSize;
            retryCountNumericUpDown.Value = retryCount;
            retryTimeoutNumericUpDown.Value = retryTimeout;
            receiveTimeoutNumericUpDown.Value = receiveTimeout;
            sessionTimeoutNumericUpDown.Value = sessionTimeout;
            prefetchCountNumericUpDown.Value = prefetchCount;
            topNumericUpDown.Value = top;
            SaveMessageToFile = saveMessageToFile;
            SavePropertiesToFile = savePropertiesToFile;
        }
        #endregion

        #region Public Properties
        public decimal LogFontSize { get; set; }
        public decimal TreeViewFontSize { get; set; }
        public int RetryCount { get; set; }
        public int RetryTimeout { get; set; }
        public int ReceiveTimeout { get; set; }
        public int SessionTimeout { get; set; }
        public int PrefetchCount { get; set; }
        public int TopCount { get; set; }
        public bool SaveMessageToFile { get; set; }
        public bool SavePropertiesToFile { get; set; }
        #endregion

        #region Event Handlers
        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void logNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            LogFontSize = logNumericUpDown.Value;
        }

        private void treeViewNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            TreeViewFontSize = treeViewNumericUpDown.Value;
        }

        private void OptionForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == '\r';
            if (e.Handled)
            {
                btnOk_Click(sender, null);
            }
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            logNumericUpDown.Value = (decimal)8.25;
            treeViewNumericUpDown.Value = (decimal)8.25;
            LogFontSize = (decimal)8.25;
            TreeViewFontSize = (decimal)8.25;
            RetryCount = 10;
            RetryTimeout = 100;
            ReceiveTimeout = 1;
            SessionTimeout = 3;
            PrefetchCount = 0;
            Top = 10;
            SaveMessageToFile = true;
            SavePropertiesToFile = true;
        }

        private void retryCountNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            RetryCount = (int)retryCountNumericUpDown.Value;
        }

        private void retryTimeoutNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            RetryTimeout = (int)retryTimeoutNumericUpDown.Value;
        }

        private void receiveTimeoutNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            ReceiveTimeout = (int)receiveTimeoutNumericUpDown.Value;
        }
        private void sessionTimeoutNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SessionTimeout = (int)sessionTimeoutNumericUpDown.Value;
        }

        private void prefetchCountNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            PrefetchCount = (int)prefetchCountNumericUpDown.Value;
        }

        private void topNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            TopCount = (int)topNumericUpDown.Value;
        }

        private void saveMessageToFileCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SaveMessageToFile = saveMessageToFileCheckBox.Checked;
        }

        private void savePropertiesToFileCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SavePropertiesToFile = savePropertiesToFileCheckBox.Checked;
        }

        private void button_MouseEnter(object sender, EventArgs e)
        {
            if (sender != null && sender is Control)
            {
                ((Control)sender).ForeColor = Color.White;
            }
        }

        private void button_MouseLeave(object sender, EventArgs e)
        {
            if (sender != null && sender is Control)
            {
                ((Control)sender).ForeColor = SystemColors.ControlText;
            }
        }
        #endregion
    }
}