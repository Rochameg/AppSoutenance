using System.Collections.Generic;
using System.Windows.Forms;
using AppSoutenance.Models;

namespace AppSoutenance.Helpers
{
    /// <summary>
    /// Extensions pour les contrôles Windows Forms
    /// </summary>
    public static class ControlExtensions
    {
        /// <summary>
        /// Remplit un ComboBox avec une liste d'éléments
        /// </summary>
        public static void FillWith(this ComboBox comboBox, List<ListItem> items)
        {
            comboBox.DataSource = null;
            comboBox.Items.Clear();
            comboBox.DataSource = items;
            comboBox.DisplayMember = "Text";
            comboBox.ValueMember = "Value";
            comboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Récupère la valeur sélectionnée d'un ComboBox comme entier
        /// </summary>
        public static int? GetSelectedValueAsInt(this ComboBox comboBox)
        {
            if (comboBox.SelectedValue == null || string.IsNullOrEmpty(comboBox.SelectedValue.ToString()))
                return null;

            if (int.TryParse(comboBox.SelectedValue.ToString(), out int value))
                return value;

            return null;
        }

        /// <summary>
        /// Définit la valeur sélectionnée d'un ComboBox
        /// </summary>
        public static void SetSelectedValue(this ComboBox comboBox, int? value)
        {
            if (value.HasValue)
                comboBox.SelectedValue = value.ToString();
            else
                comboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Réinitialise un TextBox
        /// </summary>
        public static void Clear(this TextBox textBox)
        {
            textBox.Text = string.Empty;
        }

        /// <summary>
        /// Récupère le texte d'un TextBox sans espaces
        /// </summary>
        public static string GetTrimmedText(this TextBox textBox)
        {
            return textBox.Text?.Trim() ?? string.Empty;
        }

        /// <summary>
        /// Vérifie si un TextBox est vide
        /// </summary>
        public static bool IsEmpty(this TextBox textBox)
        {
            return string.IsNullOrWhiteSpace(textBox.Text);
        }

        /// <summary>
        /// Récupère la valeur entière d'un TextBox
        /// </summary>
        public static int? GetIntValue(this TextBox textBox)
        {
            if (int.TryParse(textBox.Text, out int value))
                return value;
            return null;
        }

        /// <summary>
        /// Récupère l'ID de la ligne sélectionnée dans un DataGridView
        /// </summary>
        public static int? GetSelectedId(this DataGridView dgv, string columnName = null)
        {
            if (dgv.CurrentRow == null)
                return null;

            var cell = string.IsNullOrEmpty(columnName) ?
                dgv.CurrentRow.Cells[0] :
                dgv.CurrentRow.Cells[columnName];

            if (cell.Value == null)
                return null;

            if (int.TryParse(cell.Value.ToString(), out int id))
                return id;

            return null;
        }

        /// <summary>
        /// Récupère la valeur d'une cellule de la ligne sélectionnée
        /// </summary>
        public static string GetSelectedCellValue(this DataGridView dgv, int columnIndex)
        {
            if (dgv.CurrentRow == null || columnIndex >= dgv.Columns.Count)
                return null;

            return dgv.CurrentRow.Cells[columnIndex].Value?.ToString();
        }

        /// <summary>
        /// Récupère la valeur d'une cellule de la ligne sélectionnée par nom de colonne
        /// </summary>
        public static string GetSelectedCellValue(this DataGridView dgv, string columnName)
        {
            if (dgv.CurrentRow == null || !dgv.Columns.Contains(columnName))
                return null;

            return dgv.CurrentRow.Cells[columnName].Value?.ToString();
        }

        /// <summary>
        /// Vérifie si une ligne est sélectionnée
        /// </summary>
        public static bool HasSelection(this DataGridView dgv)
        {
            return dgv.CurrentRow != null && dgv.SelectedRows.Count > 0;
        }

        /// <summary>
        /// Configure les colonnes d'un DataGridView
        /// </summary>
        public static void ConfigureColumns(this DataGridView dgv, params (string Name, string Header, int Width)[] columns)
        {
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.Visible = false;
            }

            foreach (var (name, header, width) in columns)
            {
                if (dgv.Columns.Contains(name))
                {
                    dgv.Columns[name].Visible = true;
                    dgv.Columns[name].HeaderText = header;
                    if (width > 0)
                    {
                        dgv.Columns[name].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        dgv.Columns[name].Width = width;
                    }
                    else
                    {
                        dgv.Columns[name].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
            }
        }

        /// <summary>
        /// Efface tous les champs d'un formulaire
        /// </summary>
        public static void ClearAllFields(this Control container)
        {
            foreach (Control control in container.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Text = string.Empty;
                }
                else if (control is ComboBox comboBox)
                {
                    comboBox.SelectedIndex = comboBox.Items.Count > 0 ? 0 : -1;
                }
                else if (control is CheckBox checkBox)
                {
                    checkBox.Checked = false;
                }
                else if (control is DateTimePicker datePicker)
                {
                    datePicker.Value = System.DateTime.Now;
                }
                else if (control is NumericUpDown numericUpDown)
                {
                    numericUpDown.Value = numericUpDown.Minimum;
                }
                else if (control.HasChildren)
                {
                    control.ClearAllFields();
                }
            }
        }
    }
}
