using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AppSoutenance.Helpers
{
    /// <summary>
    /// Classe de validation des formulaires
    /// </summary>
    public class FormValidator  // <-- DÉCLARATION DE CLASS MANQUANTE
    {
        private readonly List<ValidationError> _errors;
        private readonly ErrorProvider _errorProvider;

        public FormValidator(Form form)  // <-- CONSTRUCTEUR
        {
            _errors = new List<ValidationError>();
            _errorProvider = new ErrorProvider
            {
                BlinkStyle = ErrorBlinkStyle.NeverBlink,
                Icon = SystemIcons.Error,
                ContainerControl = form  // Associe l'ErrorProvider au formulaire
            };
        }

        /// <summary>
        /// Liste des erreurs de validation
        /// </summary>
        public List<ValidationError> Errors => _errors;

        /// <summary>
        /// Indique si la validation est réussie
        /// </summary>
        public bool IsValid => _errors.Count == 0;

        /// <summary>
        /// Efface toutes les erreurs
        /// </summary>
        public void ClearErrors()
        {
            _errors.Clear();
            _errorProvider.Clear();
        }

        /// <summary>
        /// Valide qu'un champ n'est pas vide
        /// </summary>
        public bool RequiredField(TextBox textBox, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                AddError(textBox, $"Le champ {fieldName} est requis.");
                return false;
            }
            ClearError(textBox);
            return true;
        }

        /// <summary>
        /// Valide qu'un ComboBox a une sélection
        /// </summary>
        public bool RequiredSelection(ComboBox comboBox, string fieldName)
        {
            if (comboBox.SelectedIndex <= 0 || comboBox.SelectedValue == null ||
                string.IsNullOrEmpty(comboBox.SelectedValue.ToString()))
            {
                AddError(comboBox, $"Veuillez sélectionner {fieldName}.");
                return false;
            }
            ClearError(comboBox);
            return true;
        }

        /// <summary>
        /// Valide la longueur maximale d'un champ
        /// </summary>
        public bool MaxLength(TextBox textBox, int maxLength, string fieldName)
        {
            if (textBox.Text.Length > maxLength)
            {
                AddError(textBox, $"Le champ {fieldName} ne doit pas dépasser {maxLength} caractères.");
                return false;
            }
            ClearError(textBox);
            return true;
        }

        /// <summary>
        /// Valide la longueur minimale d'un champ
        /// </summary>
        public bool MinLength(TextBox textBox, int minLength, string fieldName)
        {
            if (textBox.Text.Length < minLength)
            {
                AddError(textBox, $"Le champ {fieldName} doit contenir au moins {minLength} caractères.");
                return false;
            }
            ClearError(textBox);
            return true;
        }

        /// <summary>
        /// Valide qu'un champ est un email valide
        /// </summary>
        public bool ValidEmail(TextBox textBox, string fieldName = "Email")
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (!Regex.IsMatch(textBox.Text, pattern))
            {
                AddError(textBox, $"Le champ {fieldName} n'est pas un email valide.");
                return false;
            }
            ClearError(textBox);
            return true;
        }

        /// <summary>
        /// Valide qu'un champ est un numéro de téléphone valide
        /// </summary>
        public bool ValidPhone(TextBox textBox, string fieldName = "Téléphone")
        {
            string pattern = @"^[\d\s\+\-\(\)]{8,15}$";
            if (!Regex.IsMatch(textBox.Text, pattern))
            {
                AddError(textBox, $"Le champ {fieldName} n'est pas un numéro de téléphone valide.");
                return false;
            }
            ClearError(textBox);
            return true;
        }

        /// <summary>
        /// Valide qu'un champ est un entier
        /// </summary>
        public bool ValidInteger(TextBox textBox, string fieldName)
        {
            if (!int.TryParse(textBox.Text, out _))
            {
                AddError(textBox, $"Le champ {fieldName} doit être un nombre entier.");
                return false;
            }
            ClearError(textBox);
            return true;
        }

        /// <summary>
        /// Valide qu'un champ est un entier dans une plage
        /// </summary>
        public bool ValidIntegerRange(TextBox textBox, int min, int max, string fieldName)
        {
            if (!int.TryParse(textBox.Text, out int value))
            {
                AddError(textBox, $"Le champ {fieldName} doit être un nombre entier.");
                return false;
            }

            if (value < min || value > max)
            {
                AddError(textBox, $"Le champ {fieldName} doit être compris entre {min} et {max}.");
                return false;
            }

            ClearError(textBox);
            return true;
        }

        /// <summary>
        /// Valide qu'un champ est un nombre décimal
        /// </summary>
        public bool ValidDecimal(TextBox textBox, string fieldName)
        {
            if (!decimal.TryParse(textBox.Text, out _))
            {
                AddError(textBox, $"Le champ {fieldName} doit être un nombre décimal.");
                return false;
            }
            ClearError(textBox);
            return true;
        }

        /// <summary>
        /// Valide qu'une date est sélectionnée
        /// </summary>
        public bool ValidDate(DateTimePicker datePicker, string fieldName)
        {
            if (datePicker.Value == DateTime.MinValue)
            {
                AddError(datePicker, $"Veuillez sélectionner une date pour {fieldName}.");
                return false;
            }
            ClearError(datePicker);
            return true;
        }

        /// <summary>
        /// Valide qu'une date est dans le futur
        /// </summary>
        public bool FutureDate(DateTimePicker datePicker, string fieldName)
        {
            if (datePicker.Value <= DateTime.Now)
            {
                AddError(datePicker, $"Le champ {fieldName} doit être une date future.");
                return false;
            }
            ClearError(datePicker);
            return true;
        }

        /// <summary>
        /// Valide qu'une date est dans le passé
        /// </summary>
        public bool PastDate(DateTimePicker datePicker, string fieldName)
        {
            if (datePicker.Value >= DateTime.Now)
            {
                AddError(datePicker, $"Le champ {fieldName} doit être une date passée.");
                return false;
            }
            ClearError(datePicker);
            return true;
        }

        /// <summary>
        /// Valide que deux mots de passe correspondent
        /// </summary>
        public bool PasswordMatch(TextBox password, TextBox confirmPassword)
        {
            if (password.Text != confirmPassword.Text)
            {
                AddError(confirmPassword, "Les mots de passe ne correspondent pas.");
                return false;
            }
            ClearError(confirmPassword);
            return true;
        }

        /// <summary>
        /// Valide la complexité d'un mot de passe
        /// </summary>
        public bool PasswordStrength(TextBox textBox, int minLength = 6)
        {
            if (textBox.Text.Length < minLength)
            {
                AddError(textBox, $"Le mot de passe doit contenir au moins {minLength} caractères.");
                return false;
            }
            ClearError(textBox);
            return true;
        }

        /// <summary>
        /// Ajoute une erreur personnalisée
        /// </summary>
        public void AddError(Control control, string message)
        {
            _errors.Add(new ValidationError(control, message));
            _errorProvider.SetError(control, message);
            HighlightError(control);
        }

        /// <summary>
        /// Efface l'erreur d'un contrôle
        /// </summary>
        public void ClearError(Control control)
        {
            _errorProvider.SetError(control, string.Empty);
            ClearHighlight(control);
        }

        /// <summary>
        /// Met en surbrillance un contrôle en erreur
        /// </summary>
        private void HighlightError(Control control)
        {
            if (control is TextBox textBox)
            {
                textBox.BackColor = Color.FromArgb(255, 230, 230);
            }
            else if (control is ComboBox comboBox)
            {
                comboBox.BackColor = Color.FromArgb(255, 230, 230);
            }
        }

        /// <summary>
        /// Efface la surbrillance d'un contrôle
        /// </summary>
        private void ClearHighlight(Control control)
        {
            if (control is TextBox textBox)
            {
                textBox.BackColor = Color.White;
            }
            else if (control is ComboBox comboBox)
            {
                comboBox.BackColor = Color.White;
            }
        }

        /// <summary>
        /// Affiche un message avec toutes les erreurs
        /// </summary>
        public void ShowErrors()
        {
            if (_errors.Count > 0)
            {
                var messages = new List<string>();
                foreach (var error in _errors)
                {
                    messages.Add($"• {error.Message}");
                }
                MessageBox.Show(
                    string.Join(Environment.NewLine, messages),
                    "Erreurs de validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Retourne le premier message d'erreur
        /// </summary>
        public string GetFirstError()
        {
            return _errors.Count > 0 ? _errors[0].Message : string.Empty;
        }
    }

    /// <summary>
    /// Classe représentant une erreur de validation
    /// </summary>
    public class ValidationError
    {
        public Control Control { get; }
        public string Message { get; }

        public ValidationError(Control control, string message)
        {
            Control = control;
            Message = message;
        }
    }
}