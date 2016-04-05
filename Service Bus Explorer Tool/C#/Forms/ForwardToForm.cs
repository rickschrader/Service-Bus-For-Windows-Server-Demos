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
using Microsoft.ServiceBus.Messaging;

#endregion

namespace Microsoft.WindowsAzure.CAT.ServiceBusExplorer
{
    public partial class ForwardToForm : Form
    {
        #region Private Constants
        private const string QueueEntities = "Queues";
        private const string TopicEntities = "Topics";
        private const string RelayServiceEntities = "Relay Services";
        private const string Entity = "Entity";
        #endregion

        #region Private Fields
        private TreeNode queueListNode;
        private TreeNode topicListNode;
        #endregion

        #region Public Constructor
        public ForwardToForm()
        {
            InitializeComponent();
            if (MainForm.SingletonMainForm != null &&
                MainForm.SingletonMainForm.ServiceBusTreeView != null)
            {
                CloneNode(MainForm.SingletonMainForm.ServiceBusTreeView.TopNode, null);
            }
            if (serviceBusTreeView.Nodes.Count > 0 &&
                serviceBusTreeView.Nodes[0] != null)
            {
                serviceBusTreeView.Nodes[0].Expand();
            }
            if (queueListNode != null)
            {
                queueListNode.Expand();
            }
            if (topicListNode != null)
            {
                topicListNode.Expand();
            }
        }
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
            ForwardTo = null;
            Close();
        }

        private void button_MouseEnter(object sender, EventArgs e)
        {
            var control = sender as Control;
            if (control != null)
            {
                control.ForeColor = Color.White;
            }
        }

        private void button_MouseLeave(object sender, EventArgs e)
        {
            var control = sender as Control;
            if (control != null)
            {
                control.ForeColor = SystemColors.ControlText;
            }
        }
        #endregion

        #region Public Properties
        public string ForwardTo { get; private set; }
        #endregion

        #region Private Methods
        private void txtForwardTo_TextChanged(object sender, EventArgs e)
        {
            ForwardTo = txtForwardTo.Text;
        }

        private void TextForm_Activated(object sender, EventArgs e)
        {
            txtForwardTo.Focus();
        }

        private void CloneNode(TreeNode node, TreeNode parent)
        {
            if (node == null || node.Text == RelayServiceEntities)
            {
                return;
            }
            
            var newNode = parent == null ?
                              serviceBusTreeView.Nodes.Add(node.Text, node.Text, node.ImageIndex, node.StateImageIndex) :
                              parent.Nodes.Add(node.Text, node.Text, node.ImageIndex, node.SelectedImageIndex);
            if (node.Tag != null)
            {
                if (node.Tag is QueueDescription ||
                    node.Tag is TopicDescription)
                {
                    newNode.Tag = Entity;
                }
            }
            if (newNode.Text == QueueEntities)
            {
                queueListNode = newNode;
            }
            if (newNode.Text == TopicEntities)
            {
                topicListNode = newNode;
            }
            if (node.Tag is TopicDescription)
            {
                return;
            }
            for (var i = 0; i < node.Nodes.Count; i++)
            {
                CloneNode(node.Nodes[i], newNode);
            }
        }

        private void serviceBusTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if ((string)e.Node.Tag == Entity)
            {
                txtForwardTo.Text = e.Node.Text;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtForwardTo.Text = null;
        }
        #endregion
    }
}
