namespace Futurez.XrmToolBox
{
    partial class PortalSiteSettingsControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PortalSiteSettingsControl));
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Create", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Update", System.Windows.Forms.HorizontalAlignment.Left);
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.toolButtonClose = new System.Windows.Forms.ToolStripButton();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolButtonLoadSites = new System.Windows.Forms.ToolStripButton();
            this.toolButtonReload = new System.Windows.Forms.ToolStripButton();
            this.dropDownChanges = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolButtonPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.toolButtonSave = new System.Windows.Forms.ToolStripMenuItem();
            this.labelActiveSites = new System.Windows.Forms.Label();
            this.comboActiveSites = new System.Windows.Forms.ComboBox();
            this.tableMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelMainLayout = new System.Windows.Forms.Panel();
            this.panelCurrentSettings = new System.Windows.Forms.Panel();
            this.crmGridSettings = new xrmtb.XrmToolBox.Controls.CRMGridView();
            this.panelCurrSettingTool = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelCurrentSiteSettings = new System.Windows.Forms.Label();
            this.labelFilter = new System.Windows.Forms.Label();
            this.textBoxFind = new System.Windows.Forms.TextBox();
            this.buttonReloadSettings = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.splitterHoriz = new System.Windows.Forms.Splitter();
            this.panelPreview = new System.Windows.Forms.Panel();
            this.listViewPreview = new System.Windows.Forms.ListView();
            this.colSettingName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOldValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.coNewVal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelPreviewTools = new System.Windows.Forms.Panel();
            this.buttonPreview = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelPreviewSettingUpdates = new System.Windows.Forms.Label();
            this.splitterVert = new System.Windows.Forms.Splitter();
            this.panelPropGrid = new System.Windows.Forms.Panel();
            this.propGridSettings = new System.Windows.Forms.PropertyGrid();
            this.panelSites = new System.Windows.Forms.Panel();
            this.linkLabelPortalRecordsMover = new System.Windows.Forms.LinkLabel();
            this.toolStripMenu.SuspendLayout();
            this.tableMain.SuspendLayout();
            this.panelMainLayout.SuspendLayout();
            this.panelCurrentSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.crmGridSettings)).BeginInit();
            this.panelCurrSettingTool.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panelPreview.SuspendLayout();
            this.panelPreviewTools.SuspendLayout();
            this.panelPropGrid.SuspendLayout();
            this.panelSites.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolButtonClose,
            this.tssSeparator1,
            this.toolButtonLoadSites,
            this.toolButtonReload,
            this.dropDownChanges});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(821, 25);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // toolButtonClose
            // 
            this.toolButtonClose.Image = ((System.Drawing.Image)(resources.GetObject("toolButtonClose.Image")));
            this.toolButtonClose.Name = "toolButtonClose";
            this.toolButtonClose.Size = new System.Drawing.Size(56, 22);
            this.toolButtonClose.Text = "Close";
            this.toolButtonClose.Click += new System.EventHandler(this.ToolButtonClose_Click);
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolButtonLoadSites
            // 
            this.toolButtonLoadSites.Image = global::Futurez.XrmToolBox.Properties.Resources.D365Logo;
            this.toolButtonLoadSites.Name = "toolButtonLoadSites";
            this.toolButtonLoadSites.Size = new System.Drawing.Size(114, 22);
            this.toolButtonLoadSites.Text = "Load Portal Sites";
            this.toolButtonLoadSites.Click += new System.EventHandler(this.ToolButtonLoadSites_Click);
            // 
            // toolButtonReload
            // 
            this.toolButtonReload.Enabled = false;
            this.toolButtonReload.Image = global::Futurez.XrmToolBox.Properties.Resources.reload16px;
            this.toolButtonReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolButtonReload.Name = "toolButtonReload";
            this.toolButtonReload.Size = new System.Drawing.Size(130, 22);
            this.toolButtonReload.Text = "Reload Site Settings";
            this.toolButtonReload.Click += new System.EventHandler(this.ToolButtonReload_Click);
            // 
            // dropDownChanges
            // 
            this.dropDownChanges.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolButtonPreview,
            this.toolButtonSave});
            this.dropDownChanges.Image = global::Futurez.XrmToolBox.Properties.Resources.floppy_80;
            this.dropDownChanges.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dropDownChanges.Name = "dropDownChanges";
            this.dropDownChanges.Size = new System.Drawing.Size(88, 22);
            this.dropDownChanges.Text = "Updates...";
            // 
            // toolButtonPreview
            // 
            this.toolButtonPreview.Enabled = false;
            this.toolButtonPreview.Name = "toolButtonPreview";
            this.toolButtonPreview.Size = new System.Drawing.Size(164, 22);
            this.toolButtonPreview.Text = "Preview Changes";
            this.toolButtonPreview.Click += new System.EventHandler(this.PreviewChangesButton_Click);
            // 
            // toolButtonSave
            // 
            this.toolButtonSave.Enabled = false;
            this.toolButtonSave.Name = "toolButtonSave";
            this.toolButtonSave.Size = new System.Drawing.Size(164, 22);
            this.toolButtonSave.Text = "Save Changes";
            this.toolButtonSave.Click += new System.EventHandler(this.SaveChangesButton_Click);
            // 
            // labelActiveSites
            // 
            this.labelActiveSites.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelActiveSites.Location = new System.Drawing.Point(3, 3);
            this.labelActiveSites.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelActiveSites.Name = "labelActiveSites";
            this.labelActiveSites.Size = new System.Drawing.Size(78, 17);
            this.labelActiveSites.TabIndex = 7;
            this.labelActiveSites.Text = "Active Sites:";
            this.labelActiveSites.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboActiveSites
            // 
            this.comboActiveSites.Dock = System.Windows.Forms.DockStyle.Left;
            this.comboActiveSites.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboActiveSites.FormattingEnabled = true;
            this.comboActiveSites.Location = new System.Drawing.Point(81, 3);
            this.comboActiveSites.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboActiveSites.Name = "comboActiveSites";
            this.comboActiveSites.Size = new System.Drawing.Size(264, 21);
            this.comboActiveSites.TabIndex = 8;
            this.comboActiveSites.SelectedIndexChanged += new System.EventHandler(this.ComboActiveSites_SelectedIndexChanged);
            // 
            // tableMain
            // 
            this.tableMain.ColumnCount = 1;
            this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableMain.Controls.Add(this.panelMainLayout, 0, 1);
            this.tableMain.Controls.Add(this.panelSites, 0, 0);
            this.tableMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableMain.Location = new System.Drawing.Point(0, 25);
            this.tableMain.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableMain.Name = "tableMain";
            this.tableMain.RowCount = 2;
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableMain.Size = new System.Drawing.Size(821, 604);
            this.tableMain.TabIndex = 16;
            // 
            // panelMainLayout
            // 
            this.panelMainLayout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMainLayout.Controls.Add(this.panelCurrentSettings);
            this.panelMainLayout.Controls.Add(this.splitterHoriz);
            this.panelMainLayout.Controls.Add(this.panelPreview);
            this.panelMainLayout.Controls.Add(this.splitterVert);
            this.panelMainLayout.Controls.Add(this.panelPropGrid);
            this.panelMainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainLayout.Location = new System.Drawing.Point(2, 29);
            this.panelMainLayout.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelMainLayout.Name = "panelMainLayout";
            this.panelMainLayout.Size = new System.Drawing.Size(817, 573);
            this.panelMainLayout.TabIndex = 0;
            // 
            // panelCurrentSettings
            // 
            this.panelCurrentSettings.Controls.Add(this.crmGridSettings);
            this.panelCurrentSettings.Controls.Add(this.panelCurrSettingTool);
            this.panelCurrentSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCurrentSettings.Location = new System.Drawing.Point(190, 318);
            this.panelCurrentSettings.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelCurrentSettings.Name = "panelCurrentSettings";
            this.panelCurrentSettings.Size = new System.Drawing.Size(625, 253);
            this.panelCurrentSettings.TabIndex = 17;
            // 
            // crmGridSettings
            // 
            this.crmGridSettings.AllowUserToAddRows = false;
            this.crmGridSettings.AllowUserToDeleteRows = false;
            this.crmGridSettings.AllowUserToOrderColumns = true;
            this.crmGridSettings.AllowUserToResizeRows = false;
            this.crmGridSettings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.crmGridSettings.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.crmGridSettings.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.crmGridSettings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.crmGridSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crmGridSettings.EntityReferenceClickable = true;
            this.crmGridSettings.FilterColumns = "";
            this.crmGridSettings.Location = new System.Drawing.Point(0, 30);
            this.crmGridSettings.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.crmGridSettings.Name = "crmGridSettings";
            this.crmGridSettings.ReadOnly = true;
            this.crmGridSettings.RowHeadersWidth = 20;
            this.crmGridSettings.RowTemplate.ReadOnly = true;
            this.crmGridSettings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.crmGridSettings.ShowFriendlyNames = true;
            this.crmGridSettings.ShowIdColumn = false;
            this.crmGridSettings.ShowIndexColumn = false;
            this.crmGridSettings.Size = new System.Drawing.Size(625, 223);
            this.crmGridSettings.TabIndex = 11;
            this.crmGridSettings.SelectionChanged += new System.EventHandler(this.CrmGridSettings_SelectionChanged);
            // 
            // panelCurrSettingTool
            // 
            this.panelCurrSettingTool.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCurrSettingTool.Controls.Add(this.flowLayoutPanel1);
            this.panelCurrSettingTool.Controls.Add(this.buttonReloadSettings);
            this.panelCurrSettingTool.Controls.Add(this.buttonDelete);
            this.panelCurrSettingTool.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCurrSettingTool.Location = new System.Drawing.Point(0, 0);
            this.panelCurrSettingTool.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelCurrSettingTool.Name = "panelCurrSettingTool";
            this.panelCurrSettingTool.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.panelCurrSettingTool.Size = new System.Drawing.Size(625, 30);
            this.panelCurrSettingTool.TabIndex = 14;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.labelCurrentSiteSettings);
            this.flowLayoutPanel1.Controls.Add(this.labelFilter);
            this.flowLayoutPanel1.Controls.Add(this.textBoxFind);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(5, 3);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(487, 22);
            this.flowLayoutPanel1.TabIndex = 16;
            // 
            // labelCurrentSiteSettings
            // 
            this.labelCurrentSiteSettings.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelCurrentSiteSettings.AutoSize = true;
            this.labelCurrentSiteSettings.Location = new System.Drawing.Point(2, 5);
            this.labelCurrentSiteSettings.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCurrentSiteSettings.Name = "labelCurrentSiteSettings";
            this.labelCurrentSiteSettings.Size = new System.Drawing.Size(146, 13);
            this.labelCurrentSiteSettings.TabIndex = 12;
            this.labelCurrentSiteSettings.Text = "Current Site Settings Records";
            this.labelCurrentSiteSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelFilter
            // 
            this.labelFilter.Location = new System.Drawing.Point(152, 0);
            this.labelFilter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFilter.Name = "labelFilter";
            this.labelFilter.Size = new System.Drawing.Size(65, 21);
            this.labelFilter.TabIndex = 16;
            this.labelFilter.Text = "Filter:";
            this.labelFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxFind
            // 
            this.textBoxFind.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxFind.Location = new System.Drawing.Point(221, 2);
            this.textBoxFind.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxFind.Name = "textBoxFind";
            this.textBoxFind.Size = new System.Drawing.Size(200, 20);
            this.textBoxFind.TabIndex = 15;
            this.textBoxFind.TextChanged += new System.EventHandler(this.TextBoxFind_TextChanged);
            // 
            // buttonReloadSettings
            // 
            this.buttonReloadSettings.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonReloadSettings.Enabled = false;
            this.buttonReloadSettings.Location = new System.Drawing.Point(492, 3);
            this.buttonReloadSettings.Margin = new System.Windows.Forms.Padding(2, 2, 5, 2);
            this.buttonReloadSettings.Name = "buttonReloadSettings";
            this.buttonReloadSettings.Size = new System.Drawing.Size(63, 22);
            this.buttonReloadSettings.TabIndex = 14;
            this.buttonReloadSettings.Text = "Reload";
            this.buttonReloadSettings.UseVisualStyleBackColor = true;
            this.buttonReloadSettings.Click += new System.EventHandler(this.ButtonReloadOnly_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonDelete.Enabled = false;
            this.buttonDelete.Location = new System.Drawing.Point(555, 3);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(5, 2, 2, 2);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(63, 22);
            this.buttonDelete.TabIndex = 13;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // splitterHoriz
            // 
            this.splitterHoriz.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.splitterHoriz.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterHoriz.Location = new System.Drawing.Point(190, 311);
            this.splitterHoriz.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitterHoriz.Name = "splitterHoriz";
            this.splitterHoriz.Size = new System.Drawing.Size(625, 7);
            this.splitterHoriz.TabIndex = 21;
            this.splitterHoriz.TabStop = false;
            // 
            // panelPreview
            // 
            this.panelPreview.Controls.Add(this.listViewPreview);
            this.panelPreview.Controls.Add(this.panelPreviewTools);
            this.panelPreview.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPreview.Location = new System.Drawing.Point(190, 0);
            this.panelPreview.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelPreview.Name = "panelPreview";
            this.panelPreview.Size = new System.Drawing.Size(625, 311);
            this.panelPreview.TabIndex = 18;
            // 
            // listViewPreview
            // 
            this.listViewPreview.CheckBoxes = true;
            this.listViewPreview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSettingName,
            this.colOldValue,
            this.coNewVal});
            this.listViewPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            listViewGroup1.Header = "Create";
            listViewGroup1.Name = "newItems";
            listViewGroup2.Header = "Update";
            listViewGroup2.Name = "updatedItems";
            this.listViewPreview.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.listViewPreview.Location = new System.Drawing.Point(0, 30);
            this.listViewPreview.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listViewPreview.Name = "listViewPreview";
            this.listViewPreview.Size = new System.Drawing.Size(625, 281);
            this.listViewPreview.TabIndex = 0;
            this.listViewPreview.UseCompatibleStateImageBehavior = false;
            this.listViewPreview.View = System.Windows.Forms.View.Details;
            this.listViewPreview.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ListViewPreview_ItemChecked);
            // 
            // colSettingName
            // 
            this.colSettingName.Text = "Setting Name";
            this.colSettingName.Width = 300;
            // 
            // colOldValue
            // 
            this.colOldValue.DisplayIndex = 2;
            this.colOldValue.Text = "Previous Value";
            this.colOldValue.Width = 300;
            // 
            // coNewVal
            // 
            this.coNewVal.DisplayIndex = 1;
            this.coNewVal.Text = "New Value";
            this.coNewVal.Width = 300;
            // 
            // panelPreviewTools
            // 
            this.panelPreviewTools.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPreviewTools.Controls.Add(this.buttonPreview);
            this.panelPreviewTools.Controls.Add(this.buttonSave);
            this.panelPreviewTools.Controls.Add(this.labelPreviewSettingUpdates);
            this.panelPreviewTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPreviewTools.Location = new System.Drawing.Point(0, 0);
            this.panelPreviewTools.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelPreviewTools.Name = "panelPreviewTools";
            this.panelPreviewTools.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.panelPreviewTools.Size = new System.Drawing.Size(625, 30);
            this.panelPreviewTools.TabIndex = 20;
            // 
            // buttonPreview
            // 
            this.buttonPreview.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonPreview.Enabled = false;
            this.buttonPreview.Location = new System.Drawing.Point(492, 3);
            this.buttonPreview.Margin = new System.Windows.Forms.Padding(2, 2, 5, 2);
            this.buttonPreview.Name = "buttonPreview";
            this.buttonPreview.Size = new System.Drawing.Size(63, 22);
            this.buttonPreview.TabIndex = 16;
            this.buttonPreview.Text = "Preview";
            this.buttonPreview.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonSave.Enabled = false;
            this.buttonSave.Location = new System.Drawing.Point(555, 3);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(5, 2, 2, 2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(63, 22);
            this.buttonSave.TabIndex = 15;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // labelPreviewSettingUpdates
            // 
            this.labelPreviewSettingUpdates.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelPreviewSettingUpdates.Location = new System.Drawing.Point(5, 3);
            this.labelPreviewSettingUpdates.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPreviewSettingUpdates.Name = "labelPreviewSettingUpdates";
            this.labelPreviewSettingUpdates.Size = new System.Drawing.Size(394, 22);
            this.labelPreviewSettingUpdates.TabIndex = 13;
            this.labelPreviewSettingUpdates.Text = "Site Settings Updates and Inserts - Check the items you wish to commit.";
            this.labelPreviewSettingUpdates.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitterVert
            // 
            this.splitterVert.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.splitterVert.Location = new System.Drawing.Point(183, 0);
            this.splitterVert.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitterVert.Name = "splitterVert";
            this.splitterVert.Size = new System.Drawing.Size(7, 571);
            this.splitterVert.TabIndex = 18;
            this.splitterVert.TabStop = false;
            // 
            // panelPropGrid
            // 
            this.panelPropGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPropGrid.Controls.Add(this.propGridSettings);
            this.panelPropGrid.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelPropGrid.Location = new System.Drawing.Point(0, 0);
            this.panelPropGrid.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelPropGrid.Name = "panelPropGrid";
            this.panelPropGrid.Size = new System.Drawing.Size(183, 571);
            this.panelPropGrid.TabIndex = 22;
            // 
            // propGridSettings
            // 
            this.propGridSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propGridSettings.Location = new System.Drawing.Point(0, 0);
            this.propGridSettings.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.propGridSettings.Name = "propGridSettings";
            this.propGridSettings.Size = new System.Drawing.Size(181, 569);
            this.propGridSettings.TabIndex = 18;
            this.propGridSettings.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.PropGridSettings_PropertyValueChanged);
            // 
            // panelSites
            // 
            this.panelSites.Controls.Add(this.linkLabelPortalRecordsMover);
            this.panelSites.Controls.Add(this.comboActiveSites);
            this.panelSites.Controls.Add(this.labelActiveSites);
            this.panelSites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSites.Location = new System.Drawing.Point(2, 2);
            this.panelSites.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelSites.Name = "panelSites";
            this.panelSites.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.panelSites.Size = new System.Drawing.Size(817, 23);
            this.panelSites.TabIndex = 16;
            // 
            // linkLabelPortalRecordsMover
            // 
            this.linkLabelPortalRecordsMover.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linkLabelPortalRecordsMover.LinkArea = new System.Windows.Forms.LinkArea(72, 100);
            this.linkLabelPortalRecordsMover.Location = new System.Drawing.Point(345, 3);
            this.linkLabelPortalRecordsMover.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabelPortalRecordsMover.Name = "linkLabelPortalRecordsMover";
            this.linkLabelPortalRecordsMover.Size = new System.Drawing.Size(469, 17);
            this.linkLabelPortalRecordsMover.TabIndex = 9;
            this.linkLabelPortalRecordsMover.TabStop = true;
            this.linkLabelPortalRecordsMover.Text = "Before committing changes, we suggest backing up your records using the Portal Re" +
    "cords Mover Tool!";
            this.linkLabelPortalRecordsMover.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.linkLabelPortalRecordsMover.UseCompatibleTextRendering = true;
            this.linkLabelPortalRecordsMover.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelPortalRecordsMover_LinkClicked);
            // 
            // PortalSiteSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableMain);
            this.Controls.Add(this.toolStripMenu);
            this.Name = "PortalSiteSettingsControl";
            this.Size = new System.Drawing.Size(821, 629);
            this.Load += new System.EventHandler(this.PortalSiteSettingsControl_Load);
            this.Resize += new System.EventHandler(this.PortalSiteSettingsControl_Resize);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.tableMain.ResumeLayout(false);
            this.panelMainLayout.ResumeLayout(false);
            this.panelCurrentSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.crmGridSettings)).EndInit();
            this.panelCurrSettingTool.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panelPreview.ResumeLayout(false);
            this.panelPreviewTools.ResumeLayout(false);
            this.panelPropGrid.ResumeLayout(false);
            this.panelSites.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton toolButtonClose;
        private System.Windows.Forms.ToolStripButton toolButtonLoadSites;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.Label labelActiveSites;
        private System.Windows.Forms.ComboBox comboActiveSites;
        private System.Windows.Forms.TableLayoutPanel tableMain;
        private System.Windows.Forms.Panel panelSites;
        private System.Windows.Forms.PropertyGrid propGridSettings;
        private System.Windows.Forms.Panel panelPreview;
        private System.Windows.Forms.Label labelPreviewSettingUpdates;
        private System.Windows.Forms.ListView listViewPreview;
        private System.Windows.Forms.ColumnHeader colSettingName;
        private System.Windows.Forms.ColumnHeader coNewVal;
        private System.Windows.Forms.ToolStripButton toolButtonReload;
        private System.Windows.Forms.Panel panelPreviewTools;
        private System.Windows.Forms.ToolStripDropDownButton dropDownChanges;
        private System.Windows.Forms.ToolStripMenuItem toolButtonPreview;
        private System.Windows.Forms.ToolStripMenuItem toolButtonSave; 
        private System.Windows.Forms.ColumnHeader colOldValue;
        private System.Windows.Forms.Panel panelMainLayout;
        private System.Windows.Forms.Button buttonPreview;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Panel panelCurrentSettings;
        private xrmtb.XrmToolBox.Controls.CRMGridView crmGridSettings;
        private System.Windows.Forms.Panel panelCurrSettingTool;
        private System.Windows.Forms.TextBox textBoxFind;
        private System.Windows.Forms.Button buttonReloadSettings;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label labelCurrentSiteSettings;
        private System.Windows.Forms.Splitter splitterVert;
        private System.Windows.Forms.Splitter splitterHoriz;
        private System.Windows.Forms.Panel panelPropGrid;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label labelFilter;
        private System.Windows.Forms.LinkLabel linkLabelPortalRecordsMover;
    }
}
