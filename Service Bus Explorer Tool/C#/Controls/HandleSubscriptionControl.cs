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
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.ServiceBus.Messaging;
#endregion

namespace Microsoft.WindowsAzure.CAT.ServiceBusExplorer
{
    public partial class HandleSubscriptionControl : UserControl
    {
        #region DllImports
        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);
        #endregion

        #region Private Constants
        //***************************
        // Formats
        //***************************
        private const string ExceptionFormat = "Exception: {0}";
        private const string InnerExceptionFormat = "InnerException: {0}";

        //***************************
        // Indexes
        //***************************
        private const int EnableBatchedOperationsIndex = 0;
        private const int EnableDeadLetteringOnFilterEvaluationExceptionsIndex = 1;
        private const int EnableDeadLetteringOnMessageExpirationIndex = 2;
        private const int RequiresSessionIndex = 3;

        //***************************
        // Texts
        //***************************
        private const string DeleteText = "Delete";
        private const string CreateText = "Create";
        private const string UpdateText = "Update";
        private const string CancelText = "Cancel";
        private const string EnableText = "Enable";
        private const string DisableText = "Disable";
        private const string SubscriptionEntity = "SubscriptionDescription";
        private const string FilterExpression = "Filter Expression";
        private const string ActionExpression = "Action Expression";
        private const string UserMetadata = "User Metadata";

        //***************************
        // Messages
        //***************************
        private const string NameCannotBeNull = "The Name field cannot be null.";
        private const string MaxDeliveryCountMustBeANumber = "The MaxDeliveryCount field must be a number.";

        private const string DefaultMessageTimeToLiveDaysMustBeANumber = "The Days value of the DefaultMessageTimeToLive field must be a number.";
        private const string DefaultMessageTimeToLiveHoursMustBeANumber = "The Hours value of the DefaultMessageTimeToLive field must be a number.";
        private const string DefaultMessageTimeToLiveMinutesMustBeANumber = "The Minutes value of the DefaultMessageTimeToLive field must be a number.";
        private const string DefaultMessageTimeToLiveSecondsMustBeANumber = "The Seconds value of the DefaultMessageTimeToLive field must be a number.";
        private const string DefaultMessageTimeToLiveMillisecondsMustBeANumber = "The Milliseconds value of the DefaultMessageTimeToLive field must be a number.";

        private const string LockDurationDaysMustBeANumber = "The Days value of the LockDuration field must be a number.";
        private const string LockDurationHoursMustBeANumber = "The Hours value of the LockDuration field must be a number.";
        private const string LockDurationMinutesMustBeANumber = "The Minutes value of the LockDuration field must be a number.";
        private const string LockDurationSecondsMustBeANumber = "The Seconds value of the LockDuration field must be a number.";
        private const string LockDurationMillisecondsMustBeANumber = "The Milliseconds value of the LockDuration field must be a number.";

        //***************************
        // Tooltips
        //***************************
        private const string NameTooltip = "Gets or sets the subscription name.";
        private const string DefaultMessageTimeToLiveTooltip = "Gets or sets the default message time to live of a queue.";
        private const string FilterExpressionTooltip = "Gets or sets the filter expression of the default rule.";
        private const string FilterActionTooltip = "Gets or sets the filter action of the default rule.";
        private const string LockDurationTooltip = "Gets or sets the lock duration timespan associated with this queue.";
        private const string MaxDeliveryCountTooltip = "Gets or sets the maximum delivery count. A message is automatically deadlettered after this number of deliveries.";
        private const string UserMetadataTooltip = "Gets or sets the user metadata.";
        private const string ForwardToTooltip = "Gets or sets the path to the recipient to which the message is forwarded.";

        //***************************
        // Property Labels
        //***************************
        private const string Status = "Status";
        private const string CreatedAt = "Created At";
        private const string AccessedAt = "Accessed At";
        private const string UpdatedAt = "Updated At";
        private const string MessageCount = "Message Count";
        private const string ActiveMessageCount = "Active Message Count";
        private const string DeadletterMessageCount = "DeadLetter Message Count";
        private const string ScheduledMessageCount = "Scheduled Message Count";
        private const string TransferMessageCount = "Transfer Message Count";
        private const string TransferDeadLetterMessageCount = "Transfer DL Message Count";
        private const string IsReadOnly = "IsReadOnly";
        #endregion

        #region Private Fields
        private readonly SubscriptionWrapper wrapper;
        private readonly ServiceBusHelper serviceBusHelper;
        private readonly WriteToLogDelegate writeToLog;
        #endregion

        #region Public Constructors
        public HandleSubscriptionControl(WriteToLogDelegate writeToLog, ServiceBusHelper serviceBusHelper, SubscriptionWrapper wrapper)
        {
            this.writeToLog = writeToLog;
            this.serviceBusHelper = serviceBusHelper;
            this.wrapper = wrapper;
            InitializeComponent();
            InitializeData();
        } 
        #endregion

        #region Public Events
        public event Action OnCancel;
        public event Action OnRefresh;
        public event Action OnChangeStatus;
        #endregion

        #region Private Methods
        private void InitializeData()
        {
            if (wrapper != null &&
                wrapper.TopicDescription != null &&
                wrapper.SubscriptionDescription != null)
            {
                // Initialize buttons
                btnCreateDelete.Text = DeleteText;
                btnCancelUpdate.Text = UpdateText;
                btnChangeStatus.Text = wrapper.SubscriptionDescription.Status == EntityStatus.Active ? DisableText : EnableText;
                btnRefresh.Visible = true;
                btnChangeStatus.Visible = true;
                btnOpenFilterForm.Enabled = false;
                btnOpenActionForm.Enabled = false;

                // Initialize textboxes
                txtName.ReadOnly = true;
                txtName.BackColor = SystemColors.Window;
                txtName.GotFocus += textBox_GotFocus;

                txtFilter.ReadOnly = true;
                txtFilter.BackColor = SystemColors.Window;
                txtFilter.GotFocus += textBox_GotFocus;

                txtAction.ReadOnly = true;
                txtAction.BackColor = SystemColors.Window;
                txtAction.GotFocus += textBox_GotFocus;

                // Initialize groupers
                grouperDefaultRule.Visible = false;
                grouperSubscriptionSettings.Location = grouperDefaultRule.Location;
                grouperSubscriptionSettings.Size = new Size(grouperSubscriptionSettings.Size.Width, Height - 144);

                // Initialize property grid
                var propertyList = new List<string[]>();
                if (serviceBusHelper.IsCloudNamespace)
                {
                    propertyList.AddRange(new[]{new[]{Status, wrapper.SubscriptionDescription.Status.ToString()},
                                                new[]{IsReadOnly, wrapper.SubscriptionDescription.IsReadOnly.ToString()},
                                                new[]{CreatedAt, wrapper.SubscriptionDescription.CreatedAt.ToString(CultureInfo.CurrentCulture)},
                                                new[]{AccessedAt, wrapper.SubscriptionDescription.AccessedAt.ToString(CultureInfo.CurrentCulture)},
                                                new[]{UpdatedAt, wrapper.SubscriptionDescription.UpdatedAt.ToString(CultureInfo.CurrentCulture)},
                                                new[]{ActiveMessageCount, wrapper.SubscriptionDescription.MessageCountDetails.ActiveMessageCount.ToString(CultureInfo.CurrentCulture)},
                                                new[]{DeadletterMessageCount, wrapper.SubscriptionDescription.MessageCountDetails.DeadLetterMessageCount.ToString(CultureInfo.CurrentCulture)},
                                                new[]{ScheduledMessageCount, wrapper.SubscriptionDescription.MessageCountDetails.ScheduledMessageCount.ToString(CultureInfo.CurrentCulture)},
                                                new[]{TransferMessageCount, wrapper.SubscriptionDescription.MessageCountDetails.TransferMessageCount.ToString(CultureInfo.CurrentCulture)},
                                                new[]{TransferDeadLetterMessageCount, wrapper.SubscriptionDescription.MessageCountDetails.TransferDeadLetterMessageCount.ToString(CultureInfo.CurrentCulture)},
                                                new[]{MessageCount, wrapper.SubscriptionDescription.MessageCount.ToString(CultureInfo.CurrentCulture)}});
                }
                else
                {
                    propertyList.AddRange(new[]{new[]{Status, wrapper.SubscriptionDescription.Status.ToString()},
                                                new[]{IsReadOnly, wrapper.SubscriptionDescription.IsReadOnly.ToString()},
                                                new[]{CreatedAt, wrapper.SubscriptionDescription.CreatedAt.ToString(CultureInfo.CurrentCulture)},
                                                new[]{AccessedAt, wrapper.SubscriptionDescription.AccessedAt.ToString(CultureInfo.CurrentCulture)},
                                                new[]{UpdatedAt, wrapper.SubscriptionDescription.UpdatedAt.ToString(CultureInfo.CurrentCulture)},
                                                new[]{MessageCount, wrapper.SubscriptionDescription.MessageCount.ToString(CultureInfo.CurrentCulture)}});
                }
                propertyListView.Items.Clear();
                foreach (var array in propertyList)
                {
                    propertyListView.Items.Add(new ListViewItem(array));
                }

                // Name
                if (!string.IsNullOrEmpty(wrapper.SubscriptionDescription.Name))
                {
                    txtName.Text = wrapper.SubscriptionDescription.Name;
                }

                // UserMetadata
                if (!string.IsNullOrEmpty(wrapper.SubscriptionDescription.UserMetadata))
                {
                    txtUserMetadata.Text = wrapper.SubscriptionDescription.UserMetadata;
                }

                // ForwardTo
                if (!string.IsNullOrEmpty(wrapper.SubscriptionDescription.ForwardTo))
                {
                    int i;
                    txtForwardTo.Text = !string.IsNullOrEmpty(wrapper.SubscriptionDescription.ForwardTo) &&
                                        (i = wrapper.SubscriptionDescription.ForwardTo.IndexOf('/')) > 0 &&
                                        i < wrapper.SubscriptionDescription.ForwardTo.Length - 1 ?
                                        wrapper.SubscriptionDescription.ForwardTo.Substring(wrapper.SubscriptionDescription.ForwardTo.LastIndexOf('/') + 1) :
                                        wrapper.SubscriptionDescription.ForwardTo;
                }

                // MaxDeliveryCount
                txtMaxDeliveryCount.Text = wrapper.SubscriptionDescription.MaxDeliveryCount.ToString(CultureInfo.InvariantCulture);

                // DefaultMessageTimeToLive
                txtDefaultMessageTimeToLiveDays.Text = wrapper.SubscriptionDescription.DefaultMessageTimeToLive.Days.ToString(CultureInfo.InvariantCulture);
                txtDefaultMessageTimeToLiveHours.Text = wrapper.SubscriptionDescription.DefaultMessageTimeToLive.Hours.ToString(CultureInfo.InvariantCulture);
                txtDefaultMessageTimeToLiveMinutes.Text = wrapper.SubscriptionDescription.DefaultMessageTimeToLive.Minutes.ToString(CultureInfo.InvariantCulture);
                txtDefaultMessageTimeToLiveSeconds.Text = wrapper.SubscriptionDescription.DefaultMessageTimeToLive.Seconds.ToString(CultureInfo.InvariantCulture);
                txtDefaultMessageTimeToLiveMilliseconds.Text = wrapper.SubscriptionDescription.DefaultMessageTimeToLive.Milliseconds.ToString(CultureInfo.InvariantCulture);

                // LockDuration
                txtLockDurationDays.Text = wrapper.SubscriptionDescription.LockDuration.Days.ToString(CultureInfo.InvariantCulture);
                txtLockDurationHours.Text = wrapper.SubscriptionDescription.LockDuration.Hours.ToString(CultureInfo.InvariantCulture);
                txtLockDurationMinutes.Text = wrapper.SubscriptionDescription.LockDuration.Minutes.ToString(CultureInfo.InvariantCulture);
                txtLockDurationSeconds.Text = wrapper.SubscriptionDescription.LockDuration.Seconds.ToString(CultureInfo.InvariantCulture);
                txtLockDurationMilliseconds.Text = wrapper.SubscriptionDescription.LockDuration.Milliseconds.ToString(CultureInfo.InvariantCulture);

                // EnableDeadLetteringOnFilterEvaluationExceptions
                checkedListBox.SetItemChecked(EnableBatchedOperationsIndex,
                                              wrapper.SubscriptionDescription.EnableBatchedOperations);

                // EnableDeadLetteringOnFilterEvaluationExceptions
                checkedListBox.SetItemChecked(EnableDeadLetteringOnFilterEvaluationExceptionsIndex,
                                              wrapper.SubscriptionDescription.EnableDeadLetteringOnFilterEvaluationExceptions);

                // EnableDeadLetteringOnMessageExpiration
                checkedListBox.SetItemChecked(EnableDeadLetteringOnMessageExpirationIndex,
                                              wrapper.SubscriptionDescription.EnableDeadLetteringOnMessageExpiration);

                // RequiresSession
                checkedListBox.SetItemChecked(RequiresSessionIndex,
                                              wrapper.SubscriptionDescription.RequiresSession);
                
                checkedListBox.ItemCheck += checkedListBox_ItemCheck;

                toolTip.SetToolTip(txtName, NameTooltip);
                toolTip.SetToolTip(txtUserMetadata, UserMetadataTooltip);
                toolTip.SetToolTip(txtForwardTo, ForwardToTooltip);
                toolTip.SetToolTip(txtDefaultMessageTimeToLiveDays, DefaultMessageTimeToLiveTooltip);
                toolTip.SetToolTip(txtDefaultMessageTimeToLiveHours, DefaultMessageTimeToLiveTooltip);
                toolTip.SetToolTip(txtDefaultMessageTimeToLiveMinutes, DefaultMessageTimeToLiveTooltip);
                toolTip.SetToolTip(txtDefaultMessageTimeToLiveSeconds, DefaultMessageTimeToLiveTooltip);
                toolTip.SetToolTip(txtDefaultMessageTimeToLiveMilliseconds, DefaultMessageTimeToLiveTooltip);
                toolTip.SetToolTip(txtFilter, FilterExpressionTooltip);
                toolTip.SetToolTip(txtAction, FilterActionTooltip);
                toolTip.SetToolTip(txtLockDurationDays, LockDurationTooltip);
                toolTip.SetToolTip(txtLockDurationHours, LockDurationTooltip);
                toolTip.SetToolTip(txtLockDurationMinutes, LockDurationTooltip);
                toolTip.SetToolTip(txtLockDurationSeconds, LockDurationTooltip);
                toolTip.SetToolTip(txtLockDurationMilliseconds, LockDurationTooltip);
                toolTip.SetToolTip(txtMaxDeliveryCount, MaxDeliveryCountTooltip);
            }
            else
            {
                // Initialize buttons
                btnCreateDelete.Text = CreateText;
                btnCancelUpdate.Text = CancelText;
                btnRefresh.Visible = false;
                btnChangeStatus.Visible = false;
                txtName.Focus();
            }
        }

        private void btnCreateDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (serviceBusHelper == null ||
                    wrapper == null ||
                    wrapper.TopicDescription == null)
                {
                    return;
                }
                if (btnCreateDelete.Text == DeleteText &&
                    wrapper.SubscriptionDescription != null &&
                    !string.IsNullOrEmpty(wrapper.SubscriptionDescription.Name))
                {
                    var deleteForm = new DeleteForm(wrapper.SubscriptionDescription.Name, SubscriptionEntity.ToLower());
                    if (deleteForm.ShowDialog() == DialogResult.OK)
                    {
                        serviceBusHelper.DeleteSubscription(wrapper.SubscriptionDescription);
                    }
                    return;
                }
                if (btnCreateDelete.Text == CreateText)
                {
                    if (string.IsNullOrEmpty(txtName.Text))
                    {
                        writeToLog(NameCannotBeNull);
                        return;
                    }

                    var subscriptionDescription = new SubscriptionDescription(wrapper.TopicDescription.Path,
                                                                              txtName.Text)
                        {
                            UserMetadata = txtUserMetadata.Text,
                            ForwardTo = txtForwardTo.Text
                        };

                    if (!string.IsNullOrEmpty(txtMaxDeliveryCount.Text))
                    {
                        int value;
                        if (int.TryParse(txtMaxDeliveryCount.Text, out value))
                        {
                            subscriptionDescription.MaxDeliveryCount = value;
                        }
                        else
                        {
                            writeToLog(MaxDeliveryCountMustBeANumber);
                            return;
                        }
                    }

                    var days = 0;
                    var hours = 0;
                    var minutes = 0;
                    var seconds = 0;
                    var milliseconds = 0;

                    if (!string.IsNullOrEmpty(txtDefaultMessageTimeToLiveDays.Text) ||
                        !string.IsNullOrEmpty(txtDefaultMessageTimeToLiveHours.Text) ||
                        !string.IsNullOrEmpty(txtDefaultMessageTimeToLiveMinutes.Text) ||
                        !string.IsNullOrEmpty(txtDefaultMessageTimeToLiveSeconds.Text) ||
                        !string.IsNullOrEmpty(txtDefaultMessageTimeToLiveMilliseconds.Text))
                    {
                        if (!string.IsNullOrEmpty(txtDefaultMessageTimeToLiveDays.Text))
                        {
                            if (!int.TryParse(txtDefaultMessageTimeToLiveDays.Text, out days))
                            {
                                writeToLog(DefaultMessageTimeToLiveDaysMustBeANumber);
                                return;
                            }
                        }
                        if (!string.IsNullOrEmpty(txtDefaultMessageTimeToLiveHours.Text))
                        {
                            if (!int.TryParse(txtDefaultMessageTimeToLiveHours.Text, out hours))
                            {
                                writeToLog(DefaultMessageTimeToLiveHoursMustBeANumber);
                                return;
                            }
                        }
                        if (!string.IsNullOrEmpty(txtDefaultMessageTimeToLiveMinutes.Text))
                        {
                            if (!int.TryParse(txtDefaultMessageTimeToLiveMinutes.Text, out minutes))
                            {
                                writeToLog(DefaultMessageTimeToLiveMinutesMustBeANumber);
                                return;
                            }
                        }
                        if (!string.IsNullOrEmpty(txtDefaultMessageTimeToLiveSeconds.Text))
                        {
                            if (!int.TryParse(txtDefaultMessageTimeToLiveSeconds.Text, out seconds))
                            {
                                writeToLog(DefaultMessageTimeToLiveSecondsMustBeANumber);
                                return;
                            }
                        }
                        if (!string.IsNullOrEmpty(txtDefaultMessageTimeToLiveMilliseconds.Text))
                        {
                            if (!int.TryParse(txtDefaultMessageTimeToLiveMilliseconds.Text, out milliseconds))
                            {
                                writeToLog(DefaultMessageTimeToLiveMillisecondsMustBeANumber);
                                return;
                            }
                        }
                        subscriptionDescription.DefaultMessageTimeToLive = new TimeSpan(days, hours, minutes, seconds, milliseconds);
                    }

                    days = 0;
                    hours = 0;
                    minutes = 0;
                    seconds = 0;
                    milliseconds = 0;

                    if (!string.IsNullOrEmpty(txtLockDurationDays.Text) ||
                        !string.IsNullOrEmpty(txtLockDurationHours.Text) ||
                        !string.IsNullOrEmpty(txtLockDurationMinutes.Text) ||
                        !string.IsNullOrEmpty(txtLockDurationSeconds.Text) ||
                        !string.IsNullOrEmpty(txtLockDurationMilliseconds.Text))
                    {
                        if (!string.IsNullOrEmpty(txtLockDurationDays.Text))
                        {
                            if (!int.TryParse(txtLockDurationDays.Text, out days))
                            {
                                writeToLog(LockDurationDaysMustBeANumber);
                                return;
                            }
                        }
                        if (!string.IsNullOrEmpty(txtLockDurationHours.Text))
                        {
                            if (!int.TryParse(txtLockDurationHours.Text, out hours))
                            {
                                writeToLog(LockDurationHoursMustBeANumber);
                                return;
                            }
                        }
                        if (!string.IsNullOrEmpty(txtLockDurationMinutes.Text))
                        {
                            if (!int.TryParse(txtLockDurationMinutes.Text, out minutes))
                            {
                                writeToLog(LockDurationMinutesMustBeANumber);
                                return;
                            }
                        }
                        if (!string.IsNullOrEmpty(txtLockDurationSeconds.Text))
                        {
                            if (!int.TryParse(txtLockDurationSeconds.Text, out seconds))
                            {
                                writeToLog(LockDurationSecondsMustBeANumber);
                                return;
                            }
                        }
                        if (!string.IsNullOrEmpty(txtLockDurationMilliseconds.Text))
                        {
                            if (!int.TryParse(txtLockDurationMilliseconds.Text, out milliseconds))
                            {
                                writeToLog(LockDurationMillisecondsMustBeANumber);
                                return;
                            }
                        }
                        subscriptionDescription.LockDuration = new TimeSpan(days, hours, minutes, seconds, milliseconds);
                    }

                    subscriptionDescription.EnableBatchedOperations = checkedListBox.GetItemChecked(EnableBatchedOperationsIndex);
                    subscriptionDescription.EnableDeadLetteringOnFilterEvaluationExceptions = checkedListBox.GetItemChecked(EnableDeadLetteringOnFilterEvaluationExceptionsIndex);
                    subscriptionDescription.EnableDeadLetteringOnMessageExpiration = checkedListBox.GetItemChecked(EnableDeadLetteringOnMessageExpirationIndex);
                    subscriptionDescription.RequiresSession = checkedListBox.GetItemChecked(RequiresSessionIndex);

                    var ruleDescription = new RuleDescription();

                    if (!string.IsNullOrEmpty(txtFilter.Text))
                    {
                        ruleDescription.Filter = new SqlFilter(txtFilter.Text);
                    }
                    if (!string.IsNullOrEmpty(txtAction.Text))
                    {
                        ruleDescription.Action = new SqlRuleAction(txtAction.Text);
                    }

                    wrapper.SubscriptionDescription = serviceBusHelper.CreateSubscription(wrapper.TopicDescription, 
                                                                                          subscriptionDescription, 
                                                                                          ruleDescription);
                    InitializeData();
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private static void textBox_GotFocus(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null)
            {
                HideCaret(textBox.Handle);
            }
        }

        private void HandleException(Exception ex)
        {
            if (ex == null || string.IsNullOrEmpty(ex.Message))
            {
                return;
            }
            writeToLog(string.Format(CultureInfo.CurrentCulture, ExceptionFormat, ex.Message));
            if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
            {
                writeToLog(string.Format(CultureInfo.CurrentCulture, InnerExceptionFormat, ex.InnerException.Message));
            }
        }

        private void checkedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (wrapper == null ||
                wrapper.SubscriptionDescription == null)
            {
                return;
            }
            if (e.Index == RequiresSessionIndex)
            {
                e.NewValue = wrapper.SubscriptionDescription.RequiresSession ? CheckState.Checked : CheckState.Unchecked;
            }
        }

        private void btnCancelUpdate_Click(object sender, EventArgs e)
        {
            if (btnCancelUpdate.Text == CancelText)
            {
                if (OnCancel != null)
                {
                    OnCancel();
                }
            }
            else
            {
                try
                {
                    wrapper.SubscriptionDescription.UserMetadata = txtUserMetadata.Text;
                    wrapper.SubscriptionDescription.ForwardTo = txtForwardTo.Text;

                    if (!string.IsNullOrEmpty(txtMaxDeliveryCount.Text))
                    {
                        int value;
                        if (int.TryParse(txtMaxDeliveryCount.Text, out value))
                        {
                            wrapper.SubscriptionDescription.MaxDeliveryCount = value;
                        }
                        else
                        {
                            writeToLog(MaxDeliveryCountMustBeANumber);
                            return;
                        }
                    }

                    var days = 0;
                    var hours = 0;
                    var minutes = 0;
                    var seconds = 0;
                    var milliseconds = 0;

                    if (!string.IsNullOrEmpty(txtDefaultMessageTimeToLiveDays.Text) ||
                        !string.IsNullOrEmpty(txtDefaultMessageTimeToLiveHours.Text) ||
                        !string.IsNullOrEmpty(txtDefaultMessageTimeToLiveMinutes.Text) ||
                        !string.IsNullOrEmpty(txtDefaultMessageTimeToLiveSeconds.Text) ||
                        !string.IsNullOrEmpty(txtDefaultMessageTimeToLiveMilliseconds.Text))
                    {
                        if (!string.IsNullOrEmpty(txtDefaultMessageTimeToLiveDays.Text))
                        {
                            if (!int.TryParse(txtDefaultMessageTimeToLiveDays.Text, out days))
                            {
                                writeToLog(DefaultMessageTimeToLiveDaysMustBeANumber);
                                return;
                            }
                        }
                        if (!string.IsNullOrEmpty(txtDefaultMessageTimeToLiveHours.Text))
                        {
                            if (!int.TryParse(txtDefaultMessageTimeToLiveHours.Text, out hours))
                            {
                                writeToLog(DefaultMessageTimeToLiveHoursMustBeANumber);
                                return;
                            }
                        }
                        if (!string.IsNullOrEmpty(txtDefaultMessageTimeToLiveMinutes.Text))
                        {
                            if (!int.TryParse(txtDefaultMessageTimeToLiveMinutes.Text, out minutes))
                            {
                                writeToLog(DefaultMessageTimeToLiveMinutesMustBeANumber);
                                return;
                            }
                        }
                        if (!string.IsNullOrEmpty(txtDefaultMessageTimeToLiveSeconds.Text))
                        {
                            if (!int.TryParse(txtDefaultMessageTimeToLiveSeconds.Text, out seconds))
                            {
                                writeToLog(DefaultMessageTimeToLiveSecondsMustBeANumber);
                                return;
                            }
                        }
                        if (!string.IsNullOrEmpty(txtDefaultMessageTimeToLiveMilliseconds.Text))
                        {
                            if (!int.TryParse(txtDefaultMessageTimeToLiveMilliseconds.Text, out milliseconds))
                            {
                                writeToLog(DefaultMessageTimeToLiveMillisecondsMustBeANumber);
                                return;
                            }
                        }
                        wrapper.SubscriptionDescription.DefaultMessageTimeToLive = new TimeSpan(days, hours, minutes, seconds,
                                                                                 milliseconds);
                    }

                    days = 0;
                    hours = 0;
                    minutes = 0;
                    seconds = 0;
                    milliseconds = 0;

                    if (!string.IsNullOrEmpty(txtLockDurationDays.Text) ||
                        !string.IsNullOrEmpty(txtLockDurationHours.Text) ||
                        !string.IsNullOrEmpty(txtLockDurationMinutes.Text) ||
                        !string.IsNullOrEmpty(txtLockDurationSeconds.Text) ||
                        !string.IsNullOrEmpty(txtLockDurationMilliseconds.Text))
                    {
                        if (!string.IsNullOrEmpty(txtLockDurationDays.Text))
                        {
                            if (!int.TryParse(txtLockDurationDays.Text, out days))
                            {
                                writeToLog(LockDurationDaysMustBeANumber);
                                return;
                            }
                        }
                        if (!string.IsNullOrEmpty(txtLockDurationHours.Text))
                        {
                            if (!int.TryParse(txtLockDurationHours.Text, out hours))
                            {
                                writeToLog(LockDurationHoursMustBeANumber);
                                return;
                            }
                        }
                        if (!string.IsNullOrEmpty(txtLockDurationMinutes.Text))
                        {
                            if (!int.TryParse(txtLockDurationMinutes.Text, out minutes))
                            {
                                writeToLog(LockDurationMinutesMustBeANumber);
                                return;
                            }
                        }
                        if (!string.IsNullOrEmpty(txtLockDurationSeconds.Text))
                        {
                            if (!int.TryParse(txtLockDurationSeconds.Text, out seconds))
                            {
                                writeToLog(LockDurationSecondsMustBeANumber);
                                return;
                            }
                        }
                        if (!string.IsNullOrEmpty(txtLockDurationMilliseconds.Text))
                        {
                            if (!int.TryParse(txtLockDurationMilliseconds.Text, out milliseconds))
                            {
                                writeToLog(LockDurationMillisecondsMustBeANumber);
                                return;
                            }
                        }
                        wrapper.SubscriptionDescription.LockDuration = new TimeSpan(days, hours, minutes, seconds, milliseconds);
                    }

                    wrapper.SubscriptionDescription.EnableBatchedOperations = checkedListBox.GetItemChecked(EnableBatchedOperationsIndex);
                    wrapper.SubscriptionDescription.EnableDeadLetteringOnFilterEvaluationExceptions = checkedListBox.GetItemChecked(EnableDeadLetteringOnFilterEvaluationExceptionsIndex);
                    wrapper.SubscriptionDescription.EnableDeadLetteringOnMessageExpiration = checkedListBox.GetItemChecked(EnableDeadLetteringOnMessageExpirationIndex);
                    wrapper.SubscriptionDescription.Status = EntityStatus.Disabled;
                    serviceBusHelper.UpdateSubscription(wrapper.TopicDescription, wrapper.SubscriptionDescription);
                }
                finally
                {
                    wrapper.SubscriptionDescription.Status = EntityStatus.Active;
                    wrapper.SubscriptionDescription = serviceBusHelper.NamespaceManager.UpdateSubscription(wrapper.SubscriptionDescription);
                    InitializeData();
                }
            }
        }

        private void openOpenFilterForm_Click(object sender, EventArgs e)
        {
            var form = new TextForm(FilterExpression, txtFilter.Text);
            if (form.ShowDialog() == DialogResult.OK)
            {
                txtFilter.Text = form.Content;
            }
        }

        private void btnOpenActionForm_Click(object sender, EventArgs e)
        {
            var form = new TextForm(ActionExpression, txtAction.Text);
            if (form.ShowDialog() == DialogResult.OK)
            {
                txtAction.Text = form.Content;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (OnRefresh != null)
            {
                OnRefresh();
            }
        }

        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            if (OnChangeStatus != null)
            {
                OnChangeStatus();
            }
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

        private void btnOpenUserMetadataForm_Click(object sender, EventArgs e)
        {
            var form = new TextForm(UserMetadata, txtUserMetadata.Text);
            if (form.ShowDialog() == DialogResult.OK)
            {
                txtUserMetadata.Text = form.Content;
            }
        }

        private void btnOpenForwardToForm_Click(object sender, EventArgs e)
        {
            var form = new ForwardToForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                txtForwardTo.Text = form.ForwardTo;
            }
        }

        private void propertyListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            var startX = e.ColumnIndex == 0 ? -1 : e.Bounds.X;
            var endX = e.Bounds.X + e.Bounds.Width - 1;
            // Background
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(215, 228, 242)), startX, -1, e.Bounds.Width + 1, e.Bounds.Height + 1);
            // Left vertical line
            e.Graphics.DrawLine(new Pen(SystemColors.ControlLightLight), startX, -1, startX, e.Bounds.Y + e.Bounds.Height + 1);
            // Top horizontal line
            e.Graphics.DrawLine(new Pen(SystemColors.ControlLightLight), startX, -1, endX, -1);
            // Bottom horizontal line
            e.Graphics.DrawLine(new Pen(SystemColors.ControlDark), startX, e.Bounds.Height - 1, endX, e.Bounds.Height - 1);
            // Right vertical line
            e.Graphics.DrawLine(new Pen(SystemColors.ControlDark), endX, -1, endX, e.Bounds.Height + 1);
            var roundedFontSize = (float)Math.Round(e.Font.SizeInPoints);
            var bounds = new RectangleF(e.Bounds.X + 4, (e.Bounds.Height - 6 - roundedFontSize) / 2, e.Bounds.Width, roundedFontSize + 4);
            e.Graphics.DrawString(e.Header.Text, e.Font, new SolidBrush(SystemColors.ControlText), bounds);
        }

        private void propertyListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawText();
        }

        private void propertyListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawText();
        }

        private void propertyListView_Resize(object sender, EventArgs e)
        {
            propertyListView.Columns[1].Width = propertyListView.Width - propertyListView.Columns[0].Width - 4;
        }
        #endregion
    }
}
