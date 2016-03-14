using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using MiniForms.Interfaces;
using MiniForms.Login;
using MiniForms.ModuleLoader;
using MiniForms.Process;

namespace MiniForms
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            DiaLogin dia = new DiaLogin();
            dia.ShowDialog();
            InitializeComponent();
            new SettingsLoader().CheckSettings();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Fill cbModule
            var loader = new HardCodeLoader();
            lstbModule.DataSource = loader.GetModuleDetails().ToList();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            // Move selected item in lbSteps one place up
            if (lbSteps.SelectedItem == null || lbSteps.SelectedIndex == 0) 
                return;
            lbSteps.Items.Insert(lbSteps.SelectedIndex - 1, lbSteps.SelectedItem);
            lbSteps.SelectedIndex -= 2;
            lbSteps.Items.RemoveAt(lbSteps.SelectedIndex + 2);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            // Move selected item in lbSteps one place down
            if (lbSteps.SelectedItem == null || lbSteps.SelectedIndex >= lbSteps.Items.Count - 1) 
                return;
            lbSteps.Items.Insert(lbSteps.SelectedIndex + 2, lbSteps.SelectedItem);
            lbSteps.SelectedIndex += 2;
            lbSteps.Items.RemoveAt(lbSteps.SelectedIndex - 2);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            plSteps.Controls.RemoveAt(lbSteps.SelectedIndex);
            lbSteps.Items.Remove(lbSteps.SelectedItem);
            RefreshGraphics();
        }

        private void lbSteps_DoubleClick(object sender, EventArgs e)
        {
            var module = (IModule) lbSteps.SelectedItem;
            module.EditModule();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            new ProcessRunner(lbSteps.Items.Cast<IModule>().ToList()).Start();
        }

        private void plSteps_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void plSteps_DragDrop(object sender, DragEventArgs e)
        {
            //Add selected item in cbModule to lbSteps
            if (lstbModule.SelectedItem != null)
            {
                var moduleDetail = (IModuleDetail)lstbModule.SelectedItem;

                // Create instanse of selected module
                var module = (IModule)Activator.CreateInstance(moduleDetail.ModuleType);
                module.EditModule();
                lbSteps.Items.Add(module); // Add instance to listbox
                var steps = plSteps.Controls;
                var lb = new Label()
                {
                    Text = e.Data.GetData(DataFormats.Text).ToString(),
                    Location = plSteps.PointToClient(new Point(e.X, e.Y)), // Point relative to control
                    AutoSize = true,
                    BackColor = Color.Transparent
                };
                steps.Add(lb); // Add label to panel


#region event handlers
                lb.Click += lb_Click;
                lb.DoubleClick += lb_DoubleClick;
                lb.MouseHover += lb_MouseHover;
                lb.MouseDown += (o, args) =>
                {
                    IsDragging = true;
                    DraggingLabel = (Label) o;
                };

                lb.MouseMove += (o, args) =>
                {
                    var relativeCoords = plSteps.PointToClient(MousePosition);
                    if (IsDragging && DraggingLabel != null)
                    {
                        DraggingLabel.Location = relativeCoords;
                        RefreshGraphics();
                    }
                };
                lb.MouseUp += (o, args) =>
                {
                    IsDragging = false;
                    DraggingLabel = null;
                };
#endregion
                if (plSteps.Controls.Count != 1)
                {
                    var p1 =
                        new Point(steps[steps.Count - 1].Location.X,
                                  steps[steps.Count - 1].Location.Y);
                    var p2 =
                        new Point(steps[steps.Count - 2].Location.X,
                                  steps[steps.Count - 2].Location.Y);
                    DrawLine(p1, p2);
                }
            }
        }

        void lb_MouseHover(object sender, EventArgs e)
        {
            new ToolTip().SetToolTip((Label)sender, ReturnModuleDescription((Label)sender));
        }
        protected bool IsDragging = false;
        protected Label DraggingLabel = null;

        string ReturnModuleDescription(Label item)
        {
            var index = plSteps.Controls.GetChildIndex(item);
            IModule module = (IModule) lbSteps.Items[index];
            return module.Description;
        }

        void lb_DoubleClick(object sender, EventArgs e)
        {
            var index = plSteps.Controls.GetChildIndex((Label)sender);
            IModule module = (IModule)lbSteps.Items[index];
            module.EditModule();
        }

        void lb_Click(object sender, EventArgs e)
        {
            var lb = (Label)sender;
            foreach (Label item in plSteps.Controls)
            {
                if(item != lb)
                    item.ForeColor = Color.Black;
            }
            lb.ForeColor = Color.Red;
            lbSteps.SelectedIndex = plSteps.Controls.GetChildIndex(lb);
        }

        private void lstbModule_MouseDown(object sender, MouseEventArgs e)
        {
            lstbModule.DoDragDrop(lstbModule.SelectedItem.ToString(), DragDropEffects.Copy | DragDropEffects.All);
        }

        private void RefreshGraphics()
        {
            plSteps.CreateGraphics().Clear(Color.FromArgb(154, 159, 161));
            var step = plSteps.Controls;
            for (var i = 0; i < step.Count; i++)
            {
                if (i >= step.Count - 1 || step.Count <= 1) continue;
                var p1 =
                    new Point(step[i + 1].Location.X,
                        step[i + 1].Location.Y);
                        
                var p2 =
                    new Point(step[i].Location.X,
                        step[i].Location.Y);
                        
                DrawLine(p1, p2);
            }
        }

        private void DrawLine(Point p1, Point p2)
        {
            using (var g = plSteps.CreateGraphics())
            {
                var p = new Pen(Color.Black, 4) { StartCap = LineCap.ArrowAnchor };
                g.DrawLine(p, p1, p2);
            }
        }

        private void lbSteps_SelectedIndexChanged(object sender, EventArgs e)
        {
            FocusItemInPanel();
        }

        private void FocusItemInPanel()
        {
            foreach (Label item in plSteps.Controls)
            {
                item.ForeColor = 
                    plSteps.Controls.GetChildIndex(item) == lbSteps.SelectedIndex ? Color.Red : Color.Black;
            }
        }
    }
}
