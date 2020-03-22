using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Windows.Forms;

using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;

using McTools.Xrm.Connection;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Args;
using XrmToolBox.Extensibility.Interfaces;
using Futurez.XrmToolBox.Helper;

namespace Futurez.XrmToolBox
{
    public partial class PortalSiteSettingsControl : PluginControlBase, IStatusBarMessenger, IGitHubPlugin, IHelpPlugin, IPayPalPlugin, IMessageBusHost
    {
        //private Settings mySettings;
        private EntityCollection _currSiteSettingsColl { get; set; }
        private WebSiteSettings _currWebSiteSettings { get; set; }
        private ToolSettings _toolSettings;

        public string RepositoryName => "Futurez.XrmToolbox.PortalSiteSettings";

        public string UserName => "jamesnovak";

        public string HelpUrl => "https://github.com/jamesnovak/Futurez.XrmToolbox.PortalSiteSettings/issues";

        public string DonationDescription => "Thanks for the Portal Site Settings Manager!";

        public string EmailAccount => "james@jamesnovak.com";

        public PortalSiteSettingsControl()
        {
            InitializeComponent();
        }

        public event EventHandler<StatusBarMessageEventArgs> SendMessageToStatusBar;
        public event EventHandler<MessageBusEventArgs> OnOutgoingMessage;

        #region Site and Site Settings methods 

        /// <summary>
        /// Load the list of portal sites to filter 
        /// </summary>
        private void LoadPortalSites()
        {
            WorkAsync(
                new WorkAsyncInfo()
                {
                    AsyncArgument = null,
                    Message = "Loading Active Portal Website Records",
                    MessageWidth = 340,
                    MessageHeight = 150,                    
                    Work = (w, e) =>
                    {
                        w.ReportProgress(0);

                        var query = new QueryExpression("adx_website") {
                            ColumnSet = new ColumnSet(
                                "adx_parentwebsiteid", 
                                "adx_websiteid", 
                                "adx_name", 
                                "adx_primarydomainname", 
                                "adx_partialurl")
                        };

                        try
                        {
                            var sites = Service.RetrieveMultiple(query);
                            e.Result = sites;
                        }
                        catch (FaultException ex)
                        {
                            e.Result = ex;
                        }
                        finally {
                            w.ReportProgress(100);
                        }

                    },
                    ProgressChanged = e =>
                    {
                        SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(e.ProgressPercentage, e.UserState?.ToString()));
                    },
                    PostWorkCallBack = e =>
                    {
                        comboActiveSites.DataSource = null;
                        comboActiveSites.Items.Clear();

                        ClearUI();

                        var err = e.Result as FaultException;
                        if (err != null) {
                            MessageBox.Show(this, $"An error occured attempting to load the list of Active Website Records. Has Portals been deployed to this tenant?\n\n{err.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        var sites = e.Result as EntityCollection;
                        var items = new List<ComboDisplayItem>();
                        
                        foreach (var ent in sites.Entities)
                        {
                            var name = ent["adx_name"].ToString();
                            var domain = (ent.Attributes.ContainsKey("adx_primarydomainname")) ? ent["adx_primarydomainname"].ToString() : "no domain";
                            items.Add(new ComboDisplayItem(name, $"{name} ({domain})", $"{name} ({domain})", ent));
                        }

                        comboActiveSites.DisplayMember = "DisplayName";
                        comboActiveSites.ValueMember = "Value";
                        comboActiveSites.DataSource = items;

                        ToggleEnabledState(); 
                    }
                });
        }

        /// <summary>
        /// Load the site settings for the currently selected Website 
        /// </summary>
        private void LoadCurrentWebsiteSettings(bool reloadObject = true)
        {
            Guid? siteId = GetSelectedSiteId();

            if (siteId != null)
            {
                ExecuteMethod(LoadSiteSettings, reloadObject);
            }
        }

        /// <summary>
        /// Helper method to get the selected website id from the list 
        /// </summary>
        /// <returns></returns>
        private Guid? GetSelectedSiteId()
        {
            var listItem = comboActiveSites.SelectedItem as ComboDisplayItem;
            Guid? siteId = null;

            if (listItem != null)
            {
                var entity = listItem.Object as Entity;
                siteId = entity.Id;
            }

            return siteId;
        }

        /// <summary>
        /// Load the current list of Site Settings for the selected Site
        /// </summary>
        /// <param name="siteId"></param>
        private void LoadSiteSettings(bool reloadObject = true) {

            Guid? siteId = GetSelectedSiteId();

            if (reloadObject) {
                ClearUI();
            }
            
            WorkAsync(
                new WorkAsyncInfo()
                {
                    AsyncArgument = null,
                    Message = "Loading Active Portal Site Settings Records",
                    MessageWidth = 340,
                    MessageHeight = 150,
                    Work = (w, e) =>
                    {
                        var query = new QueryExpression("adx_sitesetting")
                        { //"adx_websiteid", 
                            ColumnSet = new ColumnSet("adx_sitesettingid", "adx_name", "adx_value", "adx_description", "modifiedon", "createdon"),
                            Criteria = new FilterExpression()
                            {
                                Conditions = {
                                    new ConditionExpression("adx_websiteid", ConditionOperator.Equal, siteId.ToString())
                                }
                            }                            
                        };
                        query.AddOrder("adx_name", OrderType.Ascending);
                        var currSettings = Service.RetrieveMultiple(query);
                        e.Result = currSettings;
                    },
                    ProgressChanged = e =>
                    {
                        SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(e.ProgressPercentage, e.UserState.ToString()));
                    },
                    PostWorkCallBack = e =>
                    {
                        _currSiteSettingsColl = e.Result as EntityCollection;

                        crmGridSettings.OrganizationService = Service;
                        crmGridSettings.DataSource = _currSiteSettingsColl;

                        crmGridSettings.Columns["#id"].DisplayIndex = 0;
                        crmGridSettings.Columns["adx_name"].DisplayIndex = 1;
                        crmGridSettings.Columns["adx_value"].DisplayIndex = 2;
                        crmGridSettings.Columns["adx_description"].DisplayIndex = 3;
                        crmGridSettings.Columns["modifiedon"].DisplayIndex = 4;
                        crmGridSettings.Columns["createdon"].DisplayIndex = 5;

                        if (reloadObject)
                        {
                            // now parse out the site settings
                            LoadWebSiteSettingObject(siteId.Value);
                        }
                        PreviewChanges();
                        ToggleEnabledState();
                    }
                });
        }

        /// <summary>
        /// Helper method to collect controls that need to be enabled based on state
        /// </summary>
        private void ToggleEnabledState()
        {
            comboActiveSites.Enabled = (comboActiveSites.Items.Count > 0);
            toolButtonReload.Enabled =
                toolButtonPreview.Enabled = 
                buttonDelete.Enabled = (_currSiteSettingsColl?.Entities.Count > 0);

            toolButtonSave.Enabled = (listViewPreview.CheckedItems.Count > 0);
            textBoxFind.Enabled = (crmGridSettings.GetDataSource<EntityCollection>()?.Entities.Count > 0);

            var rows = crmGridSettings.SelectedRowRecords;

            buttonReloadSettings.Enabled = 
            buttonDelete.Enabled = (rows?.Entities.Count > 0);
            
        }
        /// <summary>
        /// Load the current list of settings into the object for edit
        /// </summary>
        private void LoadWebSiteSettingObject(Guid websiteId)
        {
            // load the site settings into the site settings object
            propGridSettings.SelectedObject = null;
            _currWebSiteSettings = new WebSiteSettings(websiteId);

            _currWebSiteSettings.LoadSettings(_currSiteSettingsColl);
            propGridSettings.SelectedObject = _currWebSiteSettings;
        }

        /// <summary>
        /// Helper method that will retrieve the current set of potential updates for review
        /// </summary>
        private void PreviewChanges()
        {
            // calculate the insert and updates
            listViewPreview.Items.Clear();

            var entities = _currWebSiteSettings?.GetUpdatedSettings(_currSiteSettingsColl);

            if (entities != null)
            {
                var items = new List<ListViewItem>();
                foreach (var ent in entities)
                {
                    var item = new ListViewItem()
                    {
                        Group = (ent.Entity.EntityState == EntityState.Created) ? listViewPreview.Groups["newItems"] :
                                        listViewPreview.Groups["updatedItems"],
                        Name = "adx_name",
                        Text = ent.Entity["adx_name"].ToString(),
                        Tag = ent,
                        Checked = (ent.ValidationMessage.Length == 0 && ent.IsRequired)
                    };

                    item.SubItems.Add(new ListViewItem.ListViewSubItem()
                    {
                        Name = "adx_value",
                        Text = ent.OldValue?.ToString()
                    });
                    item.SubItems.Add(new ListViewItem.ListViewSubItem()
                    {
                        Name = "adx_value",
                        Text = ent.NewValue?.ToString()
                    });
                    item.SubItems.Add(new ListViewItem.ListViewSubItem()
                    {
                        Name = "Validation Messages",
                        Text = ent.ValidationMessage
                    });

                    items.Add(item);
                }
                listViewPreview.Items.AddRange(items.ToArray());
            }
        }

        /// <summary>
        /// Commit the selected updates to the server
        /// </summary>
        public void SaveChanges()
        {
            var execMulti = new ExecuteMultipleRequest()
            {
                Settings = new ExecuteMultipleSettings() {
                    ContinueOnError = true,
                    ReturnResponses = true
                },
                Requests = new OrganizationRequestCollection()
            };

            // now make the inserts 
            foreach (ListViewItem item in listViewPreview.CheckedItems)
            {
                var ent = item.Tag as PendingChange;

                if (ent.Entity.EntityState == EntityState.Created)
                {
                    execMulti.Requests.Add(new CreateRequest()
                    {
                        Target = ent.Entity
                    });
                }
                else if (ent.Entity.EntityState == EntityState.Changed) {
                    execMulti.Requests.Add(new UpdateRequest() {
                        Target = ent.Entity
                    });
                }
            }

            WorkAsync(
                new WorkAsyncInfo()
                {
                    AsyncArgument = execMulti,
                    Message = "Updating Portal Site Settings Records",
                    MessageWidth = 340,
                    MessageHeight = 150,
                    Work = (w, e) =>
                    {
                        var req = e.Argument as ExecuteMultipleRequest;
                        var resp = Service.Execute(req) as ExecuteMultipleResponse;
                        e.Result = resp;
                    },
                    ProgressChanged = e =>
                    {
                        SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(e.ProgressPercentage, e.UserState.ToString()));
                    },
                    PostWorkCallBack = e =>
                    {
                        // _currSiteSettingsColl = e.Result as EntityCollection;
                        LoadCurrentWebsiteSettings();
                    }
                });
        }

        /// <summary>
        /// Delete items in the collection 
        /// </summary>
        /// <param name="rows"></param>
        private void DeleteSiteSettings(EntityCollection rows) {

            var execMulti = new ExecuteMultipleRequest() {
                Settings = new ExecuteMultipleSettings()
                {
                    ContinueOnError = true,
                    ReturnResponses = true
                },
                Requests = new OrganizationRequestCollection()
            };

            // now make the inserts 
            foreach (Entity item in rows.Entities)
            {
                execMulti.Requests.Add(new DeleteRequest()
                {
                    Target = item.ToEntityReference()
                });
            }
            // TODO handle any exec multiple issues
            WorkAsync(
                new WorkAsyncInfo()
                {
                    AsyncArgument = execMulti,
                    Message = "Deleting Portal Site Settings Records",
                    MessageWidth = 340,
                    MessageHeight = 150,
                    Work = (w, e) =>
                    {
                        var req = e.Argument as ExecuteMultipleRequest;
                        var resp = Service.Execute(req) as ExecuteMultipleResponse;
                        e.Result = resp;
                    },
                    ProgressChanged = e =>
                    {
                        SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(e.ProgressPercentage, e.UserState.ToString()));
                    },
                    PostWorkCallBack = e =>
                    {
                        LoadSiteSettings(false);
                    }
                }
            );
        }

        /// <summary>
        /// Helper for clearing out some controls 
        /// </summary>
        private void ClearUI()
        {
            _currSiteSettingsColl = null;
            _currWebSiteSettings = null;

            propGridSettings.SelectedObject = null;
            crmGridSettings.DataSource = null;
            listViewPreview.Items.Clear();
            textBoxFind.Clear();
        }
        #endregion

        #region UI Event Handlers

        /// <summary>
        /// Load the list of sites
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolButtonLoadSites_Click(object sender, EventArgs e)
        {
            // The ExecuteMethod method handles connecting to an
            // organization if XrmToolBox is not yet connected
            if (ConfrimReloadSettings())
            {
                ExecuteMethod(LoadPortalSites);
            }
        }

        /// <summary>
        /// Load the settings for the new UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboActiveSites_SelectedIndexChanged(object sender, EventArgs e)
        {
            var listItem = comboActiveSites.SelectedItem as ComboDisplayItem;
            if (listItem == null) {
                ClearUI();
            }
            else
            {
                if (ConfrimReloadSettings()) {
                    LoadCurrentWebsiteSettings();
                }
            }
        }

        /// <summary>
        /// Check to see if there are active settings and whether the user wants to reload them
        /// </summary>
        /// <returns></returns>
        private bool ConfrimReloadSettings()
        {
            bool loadMe = true;
            var listItem = comboActiveSites.SelectedItem as ComboDisplayItem;
            // sites are loaded... 
            if (listItem != null)
            {
                // site settings are loaded... 
                if (_currWebSiteSettings != null)
                {
                    // changes made?
                    var pendingChanges = _currWebSiteSettings.GetUpdatedSettings(_currSiteSettingsColl);

                    if (pendingChanges.Count > 0)
                    {
                        var prompt = $"Clear your current changes and load Site Settings for {listItem.DisplayName}?";
                        loadMe = (DialogResult.Yes == MessageBox.Show(this, prompt, "Confirm change", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
                    }
                }
            }

            return loadMe;
        }


        /// <summary>
        /// Delete the selected Site Settings records 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void ButtonDelete_Click(object sender, EventArgs arg)
        {
            var rows = crmGridSettings.SelectedRowRecords;

            // prompt for delete.
            var prompt = $"Are you sure you would like to delete the selected {rows.Entities.Count} item(s)?\nNOTE: This cannot be undone!";
            if (DialogResult.Yes == MessageBox.Show(this, prompt, "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                DeleteSiteSettings(rows);
            }
        }

        /// <summary>
        /// Preview the list of changes to be created
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewChangesButton_Click(object sender, EventArgs e)
        {
            PreviewChanges();
        }

        private void SaveChangesButton_Click(object sender, EventArgs e)
        {
            var prompt = "Are you sure you would like to continue with the selected updates?";
            if (DialogResult.Yes != MessageBox.Show(this, prompt, "Confirm commit",MessageBoxButtons.YesNo, MessageBoxIcon.Question)) {
                return;
            }

            ExecuteMethod(SaveChanges);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewPreview_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ToggleEnabledState();
        }
        /// <summary>
        /// Reload all settings and the web site settings object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolButtonReload_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show(this, "Clear your current edits and reload the current Website Settings?", "Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                LoadCurrentWebsiteSettings();
            }
        }

        /// <summary>
        /// Track selected rows so we can toggle buttons enabled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CrmGridSettings_SelectionChanged(object sender, EventArgs e)
        {
            ToggleEnabledState();
        }

        /// <summary>
        /// Reload only the site settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonReloadOnly_Click(object sender, EventArgs e)
        {
            LoadSiteSettings(false);
        }

        /// <summary>
        /// When a property value is udpated, preview the changes against the current settings 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void PropGridSettings_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            // ShowInfoNotification($"Property Changed: {e.ChangedItem.Label}", null);
            PreviewChanges();
        }

        /// <summary>
        /// Let the user filter against the grid 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxFind_TextChanged(object sender, EventArgs e)
        {
            crmGridSettings.FilterText = textBoxFind.Text;
            textBoxFind.Focus();
        }

        /// <summary>
        /// Resize the splitters 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PortalSiteSettingsControl_Resize(object sender, EventArgs e)
        {
            int width = (int)ClientSize.Width / 3;
            int height = (int)ClientSize.Height / 2;

            panelPropGrid.Width = width;
            panelPreview.Height = height;
        }

        /// <summary>
        /// Open the Portal Records Mover tool
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinkLabelPortalRecordsMover_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var messageBusEventArgs = new MessageBusEventArgs("Portal Records Mover")
            {
                SourcePlugin = "Portal Site Settings Manager"
            };
            OnOutgoingMessage(this, messageBusEventArgs);
        }
        #endregion

        #region Tool specific events

        /// <summary>
        /// Do some setup on load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PortalSiteSettingsControl_Load(object sender, EventArgs e)
        {
            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out _toolSettings))
            {
                _toolSettings = new ToolSettings();
            }
            if (!_toolSettings.LatestMessageDisplayed)
            {
                ShowInfoNotification("Site settings are being updated regularly, especially around the various Authentication settings. Check out the Learn More link for more detail on the latest updates.  If you see missing settings or inconsistencies, please submit an issue via Github!", new Uri("https://docs.microsoft.com/en-us/powerapps/maker/portals/configure/configure-site-settings"));
                _toolSettings.LatestMessageDisplayed = true;
            }

            ClearUI();
            ToggleEnabledState();
        }

        /// <summary>
        /// This event occurs when the plugin is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PortalSiteSettingsControl_OnCloseTool(object sender, EventArgs e)
        {
            // save settings!
            SettingsManager.Instance.Save(GetType(), _toolSettings);
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);
            crmGridSettings.OrganizationService = newService;
            LoadPortalSites();
        }

        /// <summary>
        /// Close up shop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolButtonClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        /// <summary>
        /// Nothing to see here!
        /// </summary>
        /// <param name="message"></param>
        public void OnIncomingMessage(MessageBusEventArgs message)
        {
            // throw new NotImplementedException();
        }
        #endregion

    }
}