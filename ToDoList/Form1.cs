using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddToDo_Click(object sender, EventArgs e)
        {
            string newItem = txtNewToDo.Text.Trim();

            if (!String.IsNullOrWhiteSpace(newItem))
            {
                if (containsTask(newItem, clsToDo.Items))
                {
                    MessageBox.Show("You already added that item", "Error");
                    txtNewToDo.SelectAll();
                }
                else
                {
                    DateTime dateCreated = DateTime.Now;
                    bool urgent = chkUrgent.Checked;

                    string todoText = $"{newItem} - Created at {dateCreated:g}";

                    if (urgent)
                    {
                        todoText += " URGENT!";
                    }
                    
                    clsToDo.Items.Add(todoText);

                    txtNewToDo.Clear();
                    chkUrgent.Checked = false;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<string> finishedItems = new List<string>();

            foreach (string item in clsToDo.CheckedItems)
            {
                finishedItems.Add(item);
            }

            foreach (string item in finishedItems)
            {
                clsToDo.Items.Remove(item);
                lstDone.Items.Add(item);
            }
        }

        private bool containsTask(string newTask, CheckedListBox.ObjectCollection currentTasks)
        {
            foreach (string task in currentTasks)
            {
                if (task.ToLower() == newTask.ToLower())
                {
                    return true;
                }
            }

            return false;
        }
    }
}
