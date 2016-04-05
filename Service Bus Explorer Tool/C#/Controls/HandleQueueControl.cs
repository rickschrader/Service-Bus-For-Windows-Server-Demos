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
using System.Drawing;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.ServiceBus.Messaging;
#endregion

namespace Microsoft.WindowsAzure.CAT.ServiceBusExplorer
{
    public partial class HandleQueueControl : UserControl
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
        private const string SizeInGigabytes = "{0} GB";

        //***************************
        // Indexes
        //***************************
        private const int EnableBatchedOperationsIndex = 0;
        private const int EnableDeadLetteringOnMessageExpirationIndex = 1;
        private const int RequiresDuplicateDetectionIndex = 2;
        private const int RequiresSessionIndex = 3;
        private const int SupportOrderingIndex = 4;
        private const int IsAnonymousAccessibleIndex = 5;

        //***************************
        // Texts
        //***************************
        private const string DeleteText = "Delete";
        private const string CreateText = "Create";
        private const string UpdateText = "Update";
        private const string CancelText = "Cancel";
        private const string EnableText = "Enable";
        private const string DisableText = "Disable";
        private const string QueueEntity = "QueueDescription";
        private const string UserMetadata = "User Metadata";
        private const string MaxGigabytes = "MAX";

        //***************************
        // Messages
        //***************************
        private const string PathCannotBeNull = "The Path field cannot be null.";
        private const string MaxDeliveryCountMustBeANumber = "The MaxDeliveryCount field must be a number.";
        private const string DefaultMessageTimeToLiveDaysMustBeANumber = "The Days value of the DefaultMessageTimeToLive field must be a number.";
        private const string DefaultMessageTimeToLiveHoursMustBeANumber = "The Hours value of the DefaultMessageTimeToLive field must be a number.";
        private const string DefaultMessageTimeToLiveMinutesMustBeANumber = "The Minutes value of the DefaultMessageTimeToLive field must be a number.";
        private const string DefaultMessageTimeToLiveSecondsMustBeANumber = "The Seconds value of the DefaultMessageTimeToLive field must be a number.";
        private const string DefaultMessageTimeToLiveMillisecondsMustBeANumber = "The Milliseconds value of the DefaultMessageTimeToLive field must be a number.";

        private const string DuplicateDetectionHistoryTimeWindowDaysMustBeANumber = "The Days value of the DuplicateDetectionHistoryTimeWindow field must be a number.";
        private const string DuplicateDetectionHistoryTimeWindowHoursMustBeANumber = "The Hours value of the DuplicateDetectionHistoryTimeWindow field must be a number.";
        private const string DuplicateDetectionHistoryTimeWindowMinutesMustBeANumber = "The Minutes value of the DuplicateDetectionHistoryTimeWindow field must be a number.";
        private const string DuplicateDetectionHistoryTimeWindowSecondsMustBeANumber = "The Seconds value of the DuplicateDetectionHistoryTimeWindow field must be a number.";
        private const string DuplicateDetectionHistoryTimeWindowMillisecondsMustBeANumber = "The Milliseconds value of the DuplicateDetectionHistoryTimeWindow field must be a number.";

        private const string LockDurationDaysMustBeANumber = "The Days value of the LockDuration field must be a number.";
        private const string LockDurationHoursMustBeANumber = "The Hours value of the LockDuration field must be a number.";
        private const string LockDurationMinutesMustBeANumber = "The Minutes value of the LockDuration field must be a number.";
        private const string LockDurationSecondsMustBeANumber = "The Seconds value of the LockDuration field must be a number.";
        private const string LockDurationMillisecondsMustBeANumber = "The Milliseconds value of the LockDuration field must be a number.";
        private const string CannotForwardToItself = "The value of the ForwardTo property of the current queue cannot be set to itself.";

        //***************************
        // Tooltips
        //***************************
        private const string PathTooltip = "Gets or sets the queue path.";
        private const string UserMetadataTooltip = "Gets or sets the user metadata.";
        private const string ForwardToTooltip = "Gets or sets the path to the recipient to which the message is forwarded.";
        private const string MaxQueueSizeTooltip = "Gets or sets the maximum queue size in gigabytes.";
        private const string DefaultMessageTimeToLiveTooltip = "Gets or sets the default message time to live of a queue.";
        private const string DuplicateDetectionHistoryTimeWindowTooltip = "Gets or sets the duration of the time window for duplicate detection history.";
        private const string LockDurationTooltip = "Gets or sets the lock duration timespan associated with this queue.";
        private const string MaxDeliveryCountTooltip = "Gets or sets the maximum delivery count. A message is automatically deadlettered after this number of deliveries.";

        //***************************
        // Property Labels
        //***************************
        private const string Status = "Status";
        private const string SizeInBytes = "Size In Bytes";
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

        //***************************
        // Constants
        //***************************
        private const long SeviceBusForWindowsServerMaxQueueSize = 8796093022207;
        #endregion

        #region Private Fields
        private QueueDescription queueDescription;
        private readonly ServiceBusHelper serviceBusHelper;
        private readonly WriteToLogDelegate writeToLog;
        private readonly string path;
        #endregion

        #region Public Constructors
        public HandleQueueControl(WriteToLogDelegate writeToLog, ServiceBusHelper serviceBusHelper, QueueDescription queueDescription, string path)
        {
            this.writeToLog = writeToLog;
            this.serviceBusHelper = serviceBusHelper;
            this.path = path;
            this.queueDescription = queueDescription;
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
            trackBarMaxQueueSize.Maximum = serviceBusHelper.IsCloudNamespace ? 5 : 11;

            // IsAnonymousAccessible
            if (serviceBusHelper.IsCloudNamespace)
            {
                if (checkedListBox.Items.Count > IsAnonymousAccessibleIndex)
                {
                    checkedListBox.Items.RemoveAt(IsAnonymousAccessibleIndex);
                }
            }

            if (queueDescription != null)
            {
                // Initialize buttons
                btnCreateDelete.Text = DeleteText;
                btnCancelUpdate.Text = UpdateText;
                btnChangeStatus.Text = queueDescription.Status == EntityStatus.Active ? DisableText : EnableText;
                btnRefresh.Visible = true;
                btnChangeStatus.Visible = true;

                // Initialize textboxes
                txtPath.ReadOnly = true;
                txtPath.BackColor = SystemColors.Window;
                txtPath.GotFocus += textBox_GotFocus;
                trackBarMaxQueueSize.Enabled = false;

                // Initialize property grid
                var propertyList = new List<string[]>();
                if (serviceBusHelper.IsCloudNamespace)
                {
                    
                    propertyList.AddRange(new[]
                        {
                            new[] {Status, queueDescription.Status.ToString()},
                            new[] {IsReadOnly, queueDescription.IsReadOnly.ToString()},
                            new[] {SizeInBytes, queueDescription.SizeInBytes.ToString(CultureInfo.CurrentCulture)},
                            new[] {CreatedAt, queueDescription.CreatedAt.ToString(CultureInfo.CurrentCulture)},
                            new[] {AccessedAt, queueDescription.AccessedAt.ToString(CultureInfo.CurrentCulture)},
                            new[] {UpdatedAt, queueDescription.UpdatedAt.ToString(CultureInfo.CurrentCulture)},
                            new[] {ActiveMessageCount, queueDescription.MessageCountDetails.ActiveMessageCount.ToString(CultureInfo.CurrentCulture)},
                            new[] {DeadletterMessageCount, queueDescription.MessageCountDetails.DeadLetterMessageCount.ToString(CultureInfo.CurrentCulture)},
                            new[] {ScheduledMessageCount, queueDescription.MessageCountDetails.ScheduledMessageCount.ToString(CultureInfo.CurrentCulture)},
                            new[] {TransferMessageCount, queueDescription.MessageCountDetails.TransferMessageCount.ToString(CultureInfo.CurrentCulture)},
                            new[] {TransferDeadLetterMessageCount, queueDescription.MessageCountDetails.TransferDeadLetterMessageCount.ToString(CultureInfo.CurrentCulture)},
                            new[] {MessageCount, queueDescription.MessageCount.ToString(CultureInfo.CurrentCulture)}
                        });
                    
                }
                else
                {
                    propertyList.AddRange(new[]
                        {
                            new[] {Status, queueDescription.Status.ToString()},
                            new[] {IsReadOnly, queueDescription.IsReadOnly.ToString()},
                            new[] {SizeInBytes, queueDescription.SizeInBytes.ToString(CultureInfo.CurrentCulture)},
                            new[] {CreatedAt, queueDescription.CreatedAt.ToString(CultureInfo.CurrentCulture)},
                            new[] {AccessedAt, queueDescription.AccessedAt.ToString(CultureInfo.CurrentCulture)},
                            new[] {UpdatedAt, queueDescription.UpdatedAt.ToString(CultureInfo.CurrentCulture)},
                            new[] {MessageCount, queueDescription.MessageCount.ToString(CultureInfo.CurrentCulture)}
                        });
                }
                propertyListView.Items.Clear();
                foreach (var array in propertyList)
                {
                    propertyListView.Items.Add(new ListViewItem(array));
                }

                // Path
                if (!string.IsNullOrEmpty(queueDescription.Path))
                {
                    txtPath.Text = queueDescription.Path;
                }

                // UserMetadata
                if (!string.IsNullOrEmpty(queueDescription.UserMetadata))
                {
                    txtUserMetadata.Text = queueDescription.UserMetadata;
                }

                // ForwardTo
                if (!string.IsNullOrEmpty(queueDescription.ForwardTo))
                {
                    int i;
                    txtForwardTo.Text = !string.IsNullOrEmpty(queueDescription.ForwardTo) &&
                                        (i = queueDescription.ForwardTo.IndexOf('/')) > 0 &&
                                        i < queueDescription.ForwardTo.Length - 1 ? 
                                        queueDescription.ForwardTo.Substring(queueDescription.ForwardTo.LastIndexOf('/') + 1): 
                                        queueDescription.ForwardTo;

                }

                // MaxQueueSizeInBytes
                trackBarMaxQueueSize.Value = serviceBusHelper.IsCloudNamespace
                                                 ? (int) queueDescription.MaxSizeInMegabytes/1024
                                                 : queueDescription.MaxSizeInMegabytes == SeviceBusForWindowsServerMaxQueueSize
                                                       ? 11
                                                       : (int) queueDescription.MaxSizeInMegabytes/1024;

                // MaxDeliveryCount
                txtMaxDeliveryCount.Text = queueDescription.MaxDeliveryCount.ToString(CultureInfo.InvariantCulture);

                // DefaultMessageTimeToLive
                txtDefaultMessageTimeToLiveDays.Text = queueDescription.DefaultMessageTimeToLive.Days.ToString(CultureInfo.InvariantCulture);
                txtDefaultMessageTimeToLiveHours.Text = queueDescription.DefaultMessageTimeToLive.Hours.ToString(CultureInfo.InvariantCulture);
                txtDefaultMessageTimeToLiveMinutes.Text = queueDescription.DefaultMessageTimeToLive.Minutes.ToString(CultureInfo.InvariantCulture);
                txtDefaultMessageTimeToLiveSeconds.Text = queueDescription.DefaultMessageTimeToLive.Seconds.ToString(CultureInfo.InvariantCulture);
                txtDefaultMessageTimeToLiveMilliseconds.Text = queueDescription.DefaultMessageTimeToLive.Milliseconds.ToString(CultureInfo.InvariantCulture);

                // DuplicateDetectionHistoryTimeWindow
                txtDuplicateDetectionHistoryTimeWindowDays.Text = queueDescription.DuplicateDetectionHistoryTimeWindow.Days.ToString(CultureInfo.InvariantCulture);
                txtDuplicateDetectionHistoryTimeWindowHours.Text = queueDescription.DuplicateDetectionHistoryTimeWindow.Hours.ToString(CultureInfo.InvariantCulture);
                txtDuplicateDetectionHistoryTimeWindowMinutes.Text = queueDescription.DuplicateDetectionHistoryTimeWindow.Minutes.ToString(CultureInfo.InvariantCulture);
                txtDuplicateDetectionHistoryTimeWindowSeconds.Text = queueDescription.DuplicateDetectionHistoryTimeWindow.Seconds.ToString(CultureInfo.InvariantCulture);
                txtDuplicateDetectionHistoryTimeWindowMilliseconds.Text = queueDescription.DuplicateDetectionHistoryTimeWindow.Milliseconds.ToString(CultureInfo.InvariantCulture);

                // LockDuration
                txtLockDurationDays.Text = queueDescription.LockDuration.Days.ToString(CultureInfo.InvariantCulture);
                txtLockDurationHours.Text = queueDescription.LockDuration.Hours.ToString(CultureInfo.InvariantCulture);
                txtLockDurationMinutes.Text = queueDescription.LockDuration.Minutes.ToString(CultureInfo.InvariantCulture);
                txtLockDurationSeconds.Text = queueDescription.LockDuration.Seconds.ToString(CultureInfo.InvariantCulture);
                txtLockDurationMilliseconds.Text = queueDescription.LockDuration.Milliseconds.ToString(CultureInfo.InvariantCulture);

                // EnableBatchedOperations
                checkedListBox.SetItemChecked(EnableBatchedOperationsIndex,
                                              queueDescription.EnableBatchedOperations);

                // EnableDeadLetteringOnMessageExpiration
                checkedListBox.SetItemChecked(EnableDeadLetteringOnMessageExpirationIndex,
                                              queueDescription.EnableDeadLetteringOnMessageExpiration);

                // RequiresDuplicateDetection
                checkedListBox.SetItemChecked(RequiresDuplicateDetectionIndex,
                                              queueDescription.RequiresDuplicateDetection);

                // RequiresSession
                checkedListBox.SetItemChecked(RequiresSessionIndex,
                                              queueDescription.RequiresSession);

                // SupportOrdering
                checkedListBox.SetItemChecked(SupportOrderingIndex,
                                              queueDescription.SupportOrdering);

                // IsAnonymousAccessible
                if (!serviceBusHelper.IsCloudNamespace &&
                    queueDescription != null)
                {
                    checkedListBox.SetItemChecked(IsAnonymousAccessibleIndex,
                                                  queueDescription.IsAnonymousAccessible);
                }

                checkedListBox.ItemCheck += checkedListBox_ItemCheck;

                toolTip.SetToolTip(txtPath, PathTooltip);
                toolTip.SetToolTip(txtUserMetadata, UserMetadataTooltip);
                toolTip.SetToolTip(txtForwardTo, ForwardToTooltip);
                toolTip.SetToolTip(trackBarMaxQueueSize, MaxQueueSizeTooltip);
                toolTip.SetToolTip(txtDefaultMessageTimeToLiveDays, DefaultMessageTimeToLiveTooltip);
                toolTip.SetToolTip(txtDefaultMessageTimeToLiveHours, DefaultMessageTimeToLiveTooltip);
                toolTip.SetToolTip(txtDefaultMessageTimeToLiveMinutes, DefaultMessageTimeToLiveTooltip);
                toolTip.SetToolTip(txtDefaultMessageTimeToLiveSeconds, DefaultMessageTimeToLiveTooltip);
                toolTip.SetToolTip(txtDefaultMessageTimeToLiveMilliseconds, DefaultMessageTimeToLiveTooltip);
                toolTip.SetToolTip(txtDuplicateDetectionHistoryTimeWindowDays, DuplicateDetectionHistoryTimeWindowTooltip);
                toolTip.SetToolTip(txtDuplicateDetectionHistoryTimeWindowHours, DuplicateDetectionHistoryTimeWindowTooltip);
                toolTip.SetToolTip(txtDuplicateDetectionHistoryTimeWindowMinutes, DuplicateDetectionHistoryTimeWindowTooltip);
                toolTip.SetToolTip(txtDuplicateDetectionHistoryTimeWindowSeconds, DuplicateDetectionHistoryTimeWindowTooltip);
                toolTip.SetToolTip(txtDuplicateDetectionHistoryTimeWindowMilliseconds, DuplicateDetectionHistoryTimeWindowTooltip);
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

                if (!string.IsNullOrEmpty(path))
                {
                    txtPath.Text = path;
                }
                txtPath.Focus();
            }
        }

        private void btnCreateDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (serviceBusHelper == null)
                {
                    return;
                }
                if (btnCreateDelete.Text == DeleteText)
                {
                    var deleteForm = new DeleteForm(queueDescription.Path, QueueEntity.ToLower());
                    if (deleteForm.ShowDialog() == DialogResult.OK)
                    {
                        serviceBusHelper.DeleteQueue(queueDescription);
                    }
                }
                else
                {
                    if (txtPath.Text.Trim().ToLower() == txtForwardTo.Text.Trim().ToLower())
                    {
                        writeToLog(CannotForwardToItself);
                        txtForwardTo.Focus();
                        return;
                    }
                    if (string.IsNullOrEmpty(txtPath.Text))
                    {
                        writeToLog(PathCannotBeNull);
                        return;
                    }

                    var description = new QueueDescription(txtPath.Text)
                        {
                            UserMetadata = txtUserMetadata.Text,
                            ForwardTo = txtForwardTo.Text,
                            MaxSizeInMegabytes = serviceBusHelper.IsCloudNamespace
                                                 ? trackBarMaxQueueSize.Value*1024
                                                 : trackBarMaxQueueSize.Value == trackBarMaxQueueSize.Maximum
                                                       ? SeviceBusForWindowsServerMaxQueueSize
                                                       : trackBarMaxQueueSize.Value*1024
                        };

                    if (!string.IsNullOrEmpty(txtMaxDeliveryCount.Text))
                    {
                        int value;
                        if (int.TryParse(txtMaxDeliveryCount.Text, out value))
                        {
                            description.MaxDeliveryCount = value;
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
                        description.DefaultMessageTimeToLive = new TimeSpan(days, hours, minutes, seconds, milliseconds);
                    }

                    days = 0;
                    hours = 0;
                    minutes = 0;
                    seconds = 0;
                    milliseconds = 0;

                    if (!string.IsNullOrEmpty(txtDuplicateDetectionHistoryTimeWindowDays.Text) ||
                        !string.IsNullOrEmpty(txtDuplicateDetectionHistoryTimeWindowHours.Text) ||
                        !string.IsNullOrEmpty(txtDuplicateDetectionHistoryTimeWindowMinutes.Text) ||
                        !string.IsNullOrEmpty(txtDuplicateDetectionHistoryTimeWindowSeconds.Text) ||
                        !string.IsNullOrEmpty(txtDuplicateDetectionHistoryTimeWindowMilliseconds.Text))
                    {
                        if (!string.IsNullOrEmpty(txtDuplicateDetectionHistoryTimeWindowDays.Text))
                        {
                            if (!int.TryParse(txtDuplicateDetectionHistoryTimeWindowDays.Text, out days))
                            {
                                writeToLog(DuplicateDetectionHistoryTimeWindowDaysMustBeANumber);
                                return;
                            }
                        }
                        if (!string.IsNullOrEmpty(txtDuplicateDetectionHistoryTimeWindowHours.Text))
                        {
                            if (!int.TryParse(txtDuplicateDetectionHistoryTimeWindowHours.Text, out hours))
                            {
                                writeToLog(DuplicateDetectionHistoryTimeWindowHoursMustBeANumber);
                                return;
                            }
                        }
                        if (!string.IsNullOrEmpty(txtDuplicateDetectionHistoryTimeWindowMinutes.Text))
                        {
                            if (!int.TryParse(txtDuplicateDetectionHistoryTimeWindowMinutes.Text, out minutes))
                            {
                                writeToLog(DuplicateDetectionHistoryTimeWindowMinutesMustBeANumber);
                                return;
                            }
                        }
                        if (!string.IsNullOrEmpty(txtDuplicateDetectionHistoryTimeWindowSeconds.Text))
                        {
                            if (!int.TryParse(txtDuplicateDetectionHistoryTimeWindowSeconds.Text, out seconds))
                            {
                                writeToLog(DuplicateDetectionHistoryTimeWindowSecondsMustBeANumber);
                                return;
                            }
                        }
                        if (!string.IsNullOrEmpty(txtDuplicateDetectionHistoryTimeWindowMilliseconds.Text))
                        {
                            if (!int.TryParse(txtDuplicateDetectionHistoryTimeWindowMilliseconds.Text, out milliseconds))
                            {
                                writeToLog(DuplicateDetectionHistoryTimeWindowMillisecondsMustBeANumber);
                                return;
                            }
                        }
                        description.DuplicateDetectionHistoryTimeWindow = new TimeSpan(days, hours, minutes, seconds, milliseconds);
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
                        description.LockDuration = new TimeSpan(days, hours, minutes, seconds, milliseconds);
                    }

                    description.EnableBatchedOperations = checkedListBox.GetItemChecked(EnableBatchedOperationsIndex);
                    description.EnableDeadLetteringOnMessageExpiration = checkedListBox.GetItemChecked(EnableDeadLetteringOnMessageExpirationIndex);
                    description.RequiresDuplicateDetection = checkedListBox.GetItemChecked(RequiresDuplicateDetectionIndex);
                    description.RequiresSession = checkedListBox.GetItemChecked(RequiresSessionIndex);
                    description.SupportOrdering = checkedListBox.GetItemChecked(SupportOrderingIndex);
                    if (!serviceBusHelper.IsCloudNamespace)
                    {
                        description.IsAnonymousAccessible = checkedListBox.GetItemChecked(IsAnonymousAccessibleIndex);
                    }
                    queueDescription = serviceBusHelper.CreateQueue(description);
                    InitializeData();
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
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
            if (queueDescription == null)
            {
                return;
            }
            if (e.Index == RequiresSessionIndex)
            {
                e.NewValue = queueDescription.RequiresSession ? CheckState.Checked : CheckState.Unchecked;
            }
            if (e.Index == RequiresDuplicateDetectionIndex)
            {
                e.NewValue = queueDescription.RequiresDuplicateDetection ? CheckState.Checked : CheckState.Unchecked;
            }
            if (e.Index == IsAnonymousAccessibleIndex)
            {
                e.NewValue = queueDescription.IsAnonymousAccessible ? CheckState.Checked : CheckState.Unchecked;
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
                    if (txtPath.Text.Trim().ToLower() == txtForwardTo.Text.Trim().ToLower())
                    {
                        writeToLog(CannotForwardToItself);
                        txtForwardTo.Focus();
                        return;
                    }

                    queueDescription.UserMetadata = txtUserMetadata.Text;
                    queueDescription.ForwardTo = txtForwardTo.Text;
                    
                    if (!string.IsNullOrEmpty(txtMaxDeliveryCount.Text))
                    {
                        int value;
                        if (int.TryParse(txtMaxDeliveryCount.Text, out value))
                        {
                            queueDescription.MaxDeliveryCount = value;
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
                        queueDescription.DefaultMessageTimeToLive = new TimeSpan(days, hours, minutes, seconds,
                                                                                 milliseconds);
                    }

                    days = 0;
                    hours = 0;
                    minutes = 0;
                    seconds = 0;
                    milliseconds = 0;

                    if (!string.IsNullOrEmpty(txtDuplicateDetectionHistoryTimeWindowDays.Text) ||
                        !string.IsNullOrEmpty(txtDuplicateDetectionHistoryTimeWindowHours.Text) ||
                        !string.IsNullOrEmpty(txtDuplicateDetectionHistoryTimeWindowMinutes.Text) ||
                        !string.IsNullOrEmpty(txtDuplicateDetectionHistoryTimeWindowSeconds.Text) ||
                        !string.IsNullOrEmpty(txtDuplicateDetectionHistoryTimeWindowMilliseconds.Text))
                    {
                        if (!string.IsNullOrEmpty(txtDuplicateDetectionHistoryTimeWindowDays.Text))
                        {
                            if (!int.TryParse(txtDuplicateDetectionHistoryTimeWindowDays.Text, out days))
                            {
                                writeToLog(DuplicateDetectionHistoryTimeWindowDaysMustBeANumber);
                                return;
                            }
                        }
                        if (!string.IsNullOrEmpty(txtDuplicateDetectionHistoryTimeWindowHours.Text))
                        {
                            if (!int.TryParse(txtDuplicateDetectionHistoryTimeWindowHours.Text, out hours))
                            {
                                writeToLog(DuplicateDetectionHistoryTimeWindowHoursMustBeANumber);
                                return;
                            }
                        }
                        if (!string.IsNullOrEmpty(txtDuplicateDetectionHistoryTimeWindowMinutes.Text))
                        {
                            if (!int.TryParse(txtDuplicateDetectionHistoryTimeWindowMinutes.Text, out minutes))
                            {
                                writeToLog(DuplicateDetectionHistoryTimeWindowMinutesMustBeANumber);
                                return;
                            }
                        }
                        if (!string.IsNullOrEmpty(txtDuplicateDetectionHistoryTimeWindowSeconds.Text))
                        {
                            if (!int.TryParse(txtDuplicateDetectionHistoryTimeWindowSeconds.Text, out seconds))
                            {
                                writeToLog(DuplicateDetectionHistoryTimeWindowSecondsMustBeANumber);
                                return;
                            }
                        }
                        if (!string.IsNullOrEmpty(txtDuplicateDetectionHistoryTimeWindowMilliseconds.Text))
                        {
                            if (!int.TryParse(txtDuplicateDetectionHistoryTimeWindowMilliseconds.Text, out milliseconds))
                            {
                                writeToLog(DuplicateDetectionHistoryTimeWindowMillisecondsMustBeANumber);
                                return;
                            }
                        }
                        queueDescription.DuplicateDetectionHistoryTimeWindow = new TimeSpan(days, hours, minutes,
                                                                                            seconds, milliseconds);
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
                        queueDescription.LockDuration = new TimeSpan(days, hours, minutes, seconds, milliseconds);
                    }

                    queueDescription.EnableBatchedOperations = checkedListBox.GetItemChecked(EnableBatchedOperationsIndex);
                    queueDescription.EnableDeadLetteringOnMessageExpiration = checkedListBox.GetItemChecked(EnableDeadLetteringOnMessageExpirationIndex);
                    queueDescription.SupportOrdering = checkedListBox.GetItemChecked(SupportOrderingIndex);
                    if (!serviceBusHelper.IsCloudNamespace)
                    {
                        queueDescription.IsAnonymousAccessible = checkedListBox.GetItemChecked(IsAnonymousAccessibleIndex);
                    }
                    queueDescription.Status = EntityStatus.Disabled;
                    serviceBusHelper.UpdateQueue(queueDescription);
                }
                finally
                {
                    queueDescription.Status = EntityStatus.Active;
                    queueDescription = serviceBusHelper.NamespaceManager.UpdateQueue(queueDescription);
                    InitializeData();
                }
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

        private void trackBarMaxQueueSize_ValueChanged(object sender, decimal value)
        {
            lblMaxQueueSizeInGB.Text = string.Format(SizeInGigabytes, trackBarMaxQueueSize.Value);
            if (!serviceBusHelper.IsCloudNamespace &&
                trackBarMaxQueueSize.Value == trackBarMaxQueueSize.Maximum)
            {
                lblMaxQueueSizeInGB.Text = MaxGigabytes;
            }
        }
        #endregion
    }
}
