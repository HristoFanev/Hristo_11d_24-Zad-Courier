using Hristo_11d__24.Business;
using Hristo_11d__24.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hristo_11d__24
{
    public partial class Form1 : Form
    {
        ParcelBusiness parcelBusiness = new ParcelBusiness();
        ParcelTypeBusiness parcelTypeBusiness = new ParcelTypeBusiness();
        public Form1()
        {
            InitializeComponent();
        }
        private void LoadRecord(Parcel parcel)
        {
            idTextBox.BackColor = Color.White;
            idTextBox.Text = parcel.Id.ToString();
            nameTextBox.Text = parcel.Name;
            descriptionTextBox.Text = parcel.Description;
            priceTextBox.Text = parcel.Price.ToString();
            weightTextBox.Text = parcel.Weight.ToString();
            parcelTypeComboBox.Text = parcel.ParcelType.Name;
        }
        private void ClearScreen()
        {
            idTextBox.BackColor = Color.White;
            idTextBox.Clear();
            nameTextBox.Clear();
            descriptionTextBox.Clear();
            priceTextBox.Clear();
            weightTextBox.Clear();
            parcelTypeComboBox.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<ParcelType> allTypes = parcelTypeBusiness.GetAllTypes();
            parcelTypeComboBox.DataSource = allTypes;
            parcelTypeComboBox.DisplayMember = "Name";
            parcelTypeComboBox.ValueMember = "Id";
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text == "" || string.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Въведете данни моля!");
                return;
            }
            Parcel parcel = new Parcel();
            parcel.Name = nameTextBox.Text;
            parcel.Description = descriptionTextBox.Text;
            parcel.Price = decimal.Parse(priceTextBox.Text);
            parcel.Weight = decimal.Parse(weightTextBox.Text);
            parcel.ParcelTypeId = (int)parcelTypeComboBox.SelectedValue;
            parcelBusiness.Add(parcel);
            ClearScreen();
        }

        private void getButton_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (string.IsNullOrEmpty(idTextBox.Text) || !idTextBox.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведете ид за търсене!");
                idTextBox.BackColor = Color.Red;
                return;
            }
            else
            {
                id = int.Parse(idTextBox.Text);
            }
            Parcel fndParcel = parcelBusiness.Get(id);
            if (fndParcel == null)
            {
                MessageBox.Show("Няма такъв запис!");
                idTextBox.BackColor = Color.Red;
                return;
            }
            LoadRecord(fndParcel);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (string.IsNullOrEmpty(idTextBox.Text) || !idTextBox.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведете ид за търсене!");
                idTextBox.BackColor = Color.Red;
                return;
            }
            else
            {
                id = int.Parse(idTextBox.Text);
            }
            if (string.IsNullOrEmpty(nameTextBox.Text))
            {
                Parcel updParcel = parcelBusiness.Get(id);
                if (updParcel == null)
                {
                    MessageBox.Show("Няма такъв запис!");
                    idTextBox.BackColor = Color.Red;
                    return;
                }
                LoadRecord(updParcel);
            }
            else
            {
                Parcel parcel = new Parcel();
                parcel.Name = nameTextBox.Text;
                parcel.Description = descriptionTextBox.Text;
                parcel.Price = decimal.Parse(priceTextBox.Text);
                parcel.Weight = decimal.Parse(weightTextBox.Text);
                parcel.ParcelTypeId = (int)parcelTypeComboBox.SelectedValue;
                parcelBusiness.Update(id, parcel);
            }
        }

        private void getAllButton_Click(object sender, EventArgs e)
        {
            List<Parcel> parcels = parcelBusiness.GetAll();
            parcelListBox.Items.Clear();

            foreach (var item in parcels)
            {
                parcelListBox.Items.Add($"{item.Id} {item.Name} {item.Description} {item.Price}лв. {item.Weight}кг. Вид пратка: {item.ParcelType.Name}");
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (string.IsNullOrEmpty(idTextBox.Text) || !idTextBox.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведете ид за търсене!");
                idTextBox.BackColor = Color.Red;
                return;
            }
            else
            {
                id = int.Parse(idTextBox.Text);
            }
            Parcel delParcel = parcelBusiness.Get(id);
            if (delParcel == null)
            {
                MessageBox.Show("Няма такъв запис!");
                idTextBox.BackColor = Color.Red;
                return;
            }
            LoadRecord(delParcel);

            DialogResult question = MessageBox.Show("Искате ли да изтриете записа?", "Изтриване", MessageBoxButtons.YesNo);
            if (question == DialogResult.Yes)
            {
                parcelBusiness.Delete(id);
            }
        }
    }
}
