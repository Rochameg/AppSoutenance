using System.Windows.Forms;

namespace AppSoutenance.Helpers
{
    /// <summary>
    /// Classe utilitaire pour les messages de l'application
    /// </summary>
    public static class MessageHelper
    {
        private const string APP_TITLE = "Sen Soutenance";

        /// <summary>
        /// Affiche un message de succès
        /// </summary>
        public static void ShowSuccess(string message, string title = "Succès")
        {
            MessageBox.Show(message, $"{APP_TITLE} - {title}",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Affiche un message d'erreur
        /// </summary>
        public static void ShowError(string message, string title = "Erreur")
        {
            MessageBox.Show(message, $"{APP_TITLE} - {title}",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Affiche un message d'avertissement
        /// </summary>
        public static void ShowWarning(string message, string title = "Attention")
        {
            MessageBox.Show(message, $"{APP_TITLE} - {title}",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Affiche un message d'information
        /// </summary>
        public static void ShowInfo(string message, string title = "Information")
        {
            MessageBox.Show(message, $"{APP_TITLE} - {title}",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Affiche une confirmation Oui/Non
        /// </summary>
        public static bool Confirm(string message, string title = "Confirmation")
        {
            return MessageBox.Show(message, $"{APP_TITLE} - {title}",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        /// <summary>
        /// Affiche une confirmation de suppression
        /// </summary>
        public static bool ConfirmDelete(string itemName = "cet élément")
        {
            return Confirm($"Êtes-vous sûr de vouloir supprimer {itemName} ?\n\nCette action est irréversible.",
                "Confirmer la suppression");
        }

        /// <summary>
        /// Affiche une confirmation de fermeture avec modifications non sauvegardées
        /// </summary>
        public static DialogResult ConfirmUnsavedChanges()
        {
            return MessageBox.Show(
                "Vous avez des modifications non sauvegardées.\n\nVoulez-vous les enregistrer avant de fermer ?",
                $"{APP_TITLE} - Modifications non sauvegardées",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Affiche une confirmation de déconnexion
        /// </summary>
        public static bool ConfirmLogout()
        {
            return Confirm("Êtes-vous sûr de vouloir vous déconnecter ?", "Déconnexion");
        }

        /// <summary>
        /// Affiche une confirmation de fermeture de l'application
        /// </summary>
        public static bool ConfirmExit()
        {
            return Confirm("Êtes-vous sûr de vouloir quitter l'application ?", "Quitter");
        }

        /// <summary>
        /// Affiche un message d'opération en cours (non bloquant)
        /// </summary>
        public static void ShowLoading(string message = "Chargement en cours...")
        {
            // TODO: Implémenter un indicateur de chargement personnalisé
        }

        /// <summary>
        /// Message de champ requis
        /// </summary>
        public static string RequiredField(string fieldName)
        {
            return $"Le champ {fieldName} est requis.";
        }

        /// <summary>
        /// Message d'enregistrement réussi
        /// </summary>
        public static string SaveSuccess(string itemName = "L'enregistrement")
        {
            return $"{itemName} a été enregistré avec succès.";
        }

        /// <summary>
        /// Message de modification réussie
        /// </summary>
        public static string UpdateSuccess(string itemName = "L'enregistrement")
        {
            return $"{itemName} a été modifié avec succès.";
        }

        /// <summary>
        /// Message de suppression réussie
        /// </summary>
        public static string DeleteSuccess(string itemName = "L'enregistrement")
        {
            return $"{itemName} a été supprimé avec succès.";
        }

        /// <summary>
        /// Message d'élément non trouvé
        /// </summary>
        public static string NotFound(string itemName = "L'enregistrement")
        {
            return $"{itemName} n'a pas été trouvé.";
        }

        /// <summary>
        /// Message d'élément déjà existant
        /// </summary>
        public static string AlreadyExists(string itemName = "Cet enregistrement")
        {
            return $"{itemName} existe déjà.";
        }

        /// <summary>
        /// Message de sélection requise
        /// </summary>
        public static string SelectionRequired(string itemName = "un élément")
        {
            return $"Veuillez sélectionner {itemName} dans la liste.";
        }
    }
}
