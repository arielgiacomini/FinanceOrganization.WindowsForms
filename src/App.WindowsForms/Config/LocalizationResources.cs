using System.Globalization;

namespace App.Forms.Config
{
    /// <summary>
    /// Centralized localization resource manager for all application messages.
    /// Supports multiple languages: pt-BR, es-ES, en-US, de-DE, fr-FR
    /// </summary>
    public static class LocalizationResources
    {
        public static string CurrentCulture { get; set; } = "pt-BR";

        /// <summary>
        /// Alert Messages
        /// </summary>
        public static class AlertMessages
        {
            public static string BillToPayPendingImport => GetMessage("BillToPayPendingImport");
            public static string NoItemsToFinalize => GetMessage("NoItemsToFinalize");
            public static string PendingRegistrationQuantity => GetMessage("PendingRegistrationQuantity");
            public static string QueryExecutedEvery => GetMessage("QueryExecutedEvery");
            public static string Seconds => GetMessage("Seconds");
            public static string EventRepeated => GetMessage("EventRepeated");
            public static string Times => GetMessage("Times");
            public static string UntilNow => GetMessage("UntilNow");
        }

        /// <summary>
        /// Common Messages
        /// </summary>
        public static class CommonMessages
        {
            public static string None => GetMessage("None");
            public static string Select => GetMessage("Select");
            public static string CreditCard => GetMessage("CreditCard");
            public static string DebitCard => GetMessage("DebitCard");
            public static string BankAccount => GetMessage("BankAccount");
            public static string Food => GetMessage("Food");
            public static string Transportation => GetMessage("Transportation");
            public static string Health => GetMessage("Health");
            public static string Entertainment => GetMessage("Entertainment");
            public static string Other => GetMessage("Other");
        }

        /// <summary>
        /// Error Messages
        /// </summary>
        public static class ErrorMessages
        {
            public static string InvalidCulture => GetMessage("InvalidCulture");
            public static string CultureNotFound => GetMessage("CultureNotFound");
            public static string ErrorSettingCulture => GetMessage("ErrorSettingCulture");
        }

        /// <summary>
        /// Button Labels
        /// </summary>
        public static class ButtonLabels
        {
            public static string Save => GetMessage("Save");
            public static string Cancel => GetMessage("Cancel");
            public static string Delete => GetMessage("Delete");
            public static string Edit => GetMessage("Edit");
            public static string Add => GetMessage("Add");
            public static string Search => GetMessage("Search");
            public static string Pay => GetMessage("Pay");
            public static string Receive => GetMessage("Receive");
            public static string Close => GetMessage("Close");
        }

        /// <summary>
        /// Table Headers
        /// </summary>
        public static class TableHeaders
        {
            public static string Description => GetMessage("Description");
            public static string Value => GetMessage("Value");
            public static string Date => GetMessage("Date");
            public static string DueDate => GetMessage("DueDate");
            public static string PurchaseDate => GetMessage("PurchaseDate");
            public static string PaymentDate => GetMessage("PaymentDate");
            public static string ReceivedDate => GetMessage("ReceivedDate");
            public static string Category => GetMessage("Category");
            public static string Account => GetMessage("Account");
            public static string Status => GetMessage("Status");
            public static string Actions => GetMessage("Actions");
        }

        /// <summary>
        /// Sets the global culture for localization
        /// </summary>
        public static void SetCulture(string cultureName)
        {
            try
            {
                // Validate culture exists
                var testCulture = new CultureInfo(cultureName);
                CurrentCulture = cultureName;
            }
            catch (CultureNotFoundException)
            {
                throw new ArgumentException($"Culture '{cultureName}' is not supported.", nameof(cultureName));
            }
        }

        /// <summary>
        /// Gets a localized message based on the current culture
        /// </summary>
        private static string GetMessage(string key)
        {
            var messages = GetMessagesForCulture(CurrentCulture);
            return messages.ContainsKey(key) ? messages[key] : $"[{key}]";
        }

        /// <summary>
        /// Returns all messages for a specific culture
        /// </summary>
        private static Dictionary<string, string> GetMessagesForCulture(string cultureName)
        {
            return cultureName switch
            {
                "es-ES" or "es" => GetSpanishMessages(),
                "en-US" or "en" => GetEnglishMessages(),
                "de-DE" or "de" => GetGermanMessages(),
                "fr-FR" or "fr" => GetFrenchMessages(),
                _ => GetPortugueseMessages() // Default to Portuguese
            };
        }

        private static Dictionary<string, string> GetPortugueseMessages()
        {
            return new Dictionary<string, string>
            {
                // Alert Messages
                { "BillToPayPendingImport", "Conta a Pagar pendente de importação: " },
                { "NoItemsToFinalize", "Nenhum item para finalizar cadastro." },
                { "PendingRegistrationQuantity", "Quantidade de Cadastro Pendentes: " },
                { "QueryExecutedEvery", "A cada " },
                { "Seconds", "segundo(s) é efetuado uma consulta. Evento Repetido: " },
                { "EventRepeated", "Evento Repetido: " },
                { "Times", "x" },
                { "UntilNow", "até o momento." },

                // Common Messages
                { "None", "Nenhum" },
                { "Select", "Selecione" },
                { "CreditCard", "Cartão de Crédito" },
                { "DebitCard", "Cartão de Débito" },
                { "BankAccount", "Conta Bancária" },
                { "Food", "Alimentação" },
                { "Transportation", "Transporte" },
                { "Health", "Saúde" },
                { "Entertainment", "Entretenimento" },
                { "Other", "Outro" },

                // Error Messages
                { "InvalidCulture", "Cultura inválida" },
                { "CultureNotFound", "Cultura '{0}' não encontrada." },
                { "ErrorSettingCulture", "Erro ao definir a cultura para '{0}'" },

                // Button Labels
                { "Save", "Salvar" },
                { "Cancel", "Cancelar" },
                { "Delete", "Excluir" },
                { "Edit", "Editar" },
                { "Add", "Adicionar" },
                { "Search", "Pesquisar" },
                { "Pay", "Pagar" },
                { "Receive", "Receber" },
                { "Close", "Fechar" },

                // Table Headers
                { "Description", "Descrição" },
                { "Value", "Valor" },
                { "Date", "Data" },
                { "DueDate", "Data de Vencimento" },
                { "PurchaseDate", "Data de Compra" },
                { "PaymentDate", "Data de Pagamento" },
                { "ReceivedDate", "Data de Recebimento" },
                { "Category", "Categoria" },
                { "Account", "Conta" },
                { "Status", "Status" },
                { "Actions", "Ações" }
            };
        }

        private static Dictionary<string, string> GetSpanishMessages()
        {
            return new Dictionary<string, string>
            {
                // Alert Messages
                { "BillToPayPendingImport", "Factura a pagar pendiente de importación: " },
                { "NoItemsToFinalize", "Ningún artículo para finalizar el registro." },
                { "PendingRegistrationQuantity", "Cantidad de registros pendientes: " },
                { "QueryExecutedEvery", "Cada " },
                { "Seconds", "segundo(s) se realiza una consulta. Evento repetido: " },
                { "EventRepeated", "Evento repetido: " },
                { "Times", "x" },
                { "UntilNow", "hasta el momento." },

                // Common Messages
                { "None", "Ninguno" },
                { "Select", "Seleccionar" },
                { "CreditCard", "Tarjeta de Crédito" },
                { "DebitCard", "Tarjeta de Débito" },
                { "BankAccount", "Cuenta Bancaria" },
                { "Food", "Alimentación" },
                { "Transportation", "Transporte" },
                { "Health", "Salud" },
                { "Entertainment", "Entretenimiento" },
                { "Other", "Otro" },

                // Error Messages
                { "InvalidCulture", "Cultura inválida" },
                { "CultureNotFound", "Cultura '{0}' no encontrada." },
                { "ErrorSettingCulture", "Error al establecer la cultura a '{0}'" },

                // Button Labels
                { "Save", "Guardar" },
                { "Cancel", "Cancelar" },
                { "Delete", "Eliminar" },
                { "Edit", "Editar" },
                { "Add", "Añadir" },
                { "Search", "Buscar" },
                { "Pay", "Pagar" },
                { "Receive", "Recibir" },
                { "Close", "Cerrar" },

                // Table Headers
                { "Description", "Descripción" },
                { "Value", "Valor" },
                { "Date", "Fecha" },
                { "DueDate", "Fecha de Vencimiento" },
                { "PurchaseDate", "Fecha de Compra" },
                { "PaymentDate", "Fecha de Pago" },
                { "ReceivedDate", "Fecha de Recepción" },
                { "Category", "Categoría" },
                { "Account", "Cuenta" },
                { "Status", "Estado" },
                { "Actions", "Acciones" }
            };
        }

        private static Dictionary<string, string> GetEnglishMessages()
        {
            return new Dictionary<string, string>
            {
                // Alert Messages
                { "BillToPayPendingImport", "Bill to pay pending import: " },
                { "NoItemsToFinalize", "No items to finalize registration." },
                { "PendingRegistrationQuantity", "Quantity of pending registrations: " },
                { "QueryExecutedEvery", "Every " },
                { "Seconds", "second(s) a query is executed. Event repeated: " },
                { "EventRepeated", "Event repeated: " },
                { "Times", "x" },
                { "UntilNow", "so far." },

                // Common Messages
                { "None", "None" },
                { "Select", "Select" },
                { "CreditCard", "Credit Card" },
                { "DebitCard", "Debit Card" },
                { "BankAccount", "Bank Account" },
                { "Food", "Food" },
                { "Transportation", "Transportation" },
                { "Health", "Health" },
                { "Entertainment", "Entertainment" },
                { "Other", "Other" },

                // Error Messages
                { "InvalidCulture", "Invalid culture" },
                { "CultureNotFound", "Culture '{0}' not found." },
                { "ErrorSettingCulture", "Error setting culture to '{0}'" },

                // Button Labels
                { "Save", "Save" },
                { "Cancel", "Cancel" },
                { "Delete", "Delete" },
                { "Edit", "Edit" },
                { "Add", "Add" },
                { "Search", "Search" },
                { "Pay", "Pay" },
                { "Receive", "Receive" },
                { "Close", "Close" },

                // Table Headers
                { "Description", "Description" },
                { "Value", "Value" },
                { "Date", "Date" },
                { "DueDate", "Due Date" },
                { "PurchaseDate", "Purchase Date" },
                { "PaymentDate", "Payment Date" },
                { "ReceivedDate", "Received Date" },
                { "Category", "Category" },
                { "Account", "Account" },
                { "Status", "Status" },
                { "Actions", "Actions" }
            };
        }

        private static Dictionary<string, string> GetGermanMessages()
        {
            return new Dictionary<string, string>
            {
                // Alert Messages
                { "BillToPayPendingImport", "Rechnung ausstehend zum Import: " },
                { "NoItemsToFinalize", "Keine Elemente zur Fertigstellung der Registrierung." },
                { "PendingRegistrationQuantity", "Anzahl ausstehender Registrierungen: " },
                { "QueryExecutedEvery", "Alle " },
                { "Seconds", "Sekunde(n) wird eine Abfrage ausgeführt. Ereignis wiederholt: " },
                { "EventRepeated", "Ereignis wiederholt: " },
                { "Times", "x" },
                { "UntilNow", "bisher." },

                // Common Messages
                { "None", "Keine" },
                { "Select", "Auswählen" },
                { "CreditCard", "Kreditkarte" },
                { "DebitCard", "Debitkarte" },
                { "BankAccount", "Bankkonto" },
                { "Food", "Lebensmittel" },
                { "Transportation", "Verkehr" },
                { "Health", "Gesundheit" },
                { "Entertainment", "Unterhaltung" },
                { "Other", "Sonstiges" },

                // Error Messages
                { "InvalidCulture", "Ungültige Kultur" },
                { "CultureNotFound", "Kultur '{0}' nicht gefunden." },
                { "ErrorSettingCulture", "Fehler beim Einstellen der Kultur auf '{0}'" },

                // Button Labels
                { "Save", "Speichern" },
                { "Cancel", "Abbrechen" },
                { "Delete", "Löschen" },
                { "Edit", "Bearbeiten" },
                { "Add", "Hinzufügen" },
                { "Search", "Suchen" },
                { "Pay", "Zahlen" },
                { "Receive", "Empfangen" },
                { "Close", "Schließen" },

                // Table Headers
                { "Description", "Beschreibung" },
                { "Value", "Wert" },
                { "Date", "Datum" },
                { "DueDate", "Fälligkeitsdatum" },
                { "PurchaseDate", "Kaufdatum" },
                { "PaymentDate", "Zahlungsdatum" },
                { "ReceivedDate", "Empfangsdatum" },
                { "Category", "Kategorie" },
                { "Account", "Konto" },
                { "Status", "Status" },
                { "Actions", "Aktionen" }
            };
        }

        private static Dictionary<string, string> GetFrenchMessages()
        {
            return new Dictionary<string, string>
            {
                // Alert Messages
                { "BillToPayPendingImport", "Facture à payer en attente d'importation: " },
                { "NoItemsToFinalize", "Aucun élément pour finaliser l'enregistrement." },
                { "PendingRegistrationQuantity", "Quantité d'enregistrements en attente: " },
                { "QueryExecutedEvery", "Tous les " },
                { "Seconds", "seconde(s) une requête est exécutée. Événement répété: " },
                { "EventRepeated", "Événement répété: " },
                { "Times", "x" },
                { "UntilNow", "jusqu'à présent." },

                // Common Messages
                { "None", "Aucun" },
                { "Select", "Sélectionner" },
                { "CreditCard", "Carte de Crédit" },
                { "DebitCard", "Carte de Débit" },
                { "BankAccount", "Compte Bancaire" },
                { "Food", "Nourriture" },
                { "Transportation", "Transport" },
                { "Health", "Santé" },
                { "Entertainment", "Divertissement" },
                { "Other", "Autre" },

                // Error Messages
                { "InvalidCulture", "Culture invalide" },
                { "CultureNotFound", "Culture '{0}' non trouvée." },
                { "ErrorSettingCulture", "Erreur lors de la définition de la culture à '{0}'" },

                // Button Labels
                { "Save", "Enregistrer" },
                { "Cancel", "Annuler" },
                { "Delete", "Supprimer" },
                { "Edit", "Modifier" },
                { "Add", "Ajouter" },
                { "Search", "Rechercher" },
                { "Pay", "Payer" },
                { "Receive", "Recevoir" },
                { "Close", "Fermer" },

                // Table Headers
                { "Description", "Description" },
                { "Value", "Valeur" },
                { "Date", "Date" },
                { "DueDate", "Date d'Échéance" },
                { "PurchaseDate", "Date d'Achat" },
                { "PaymentDate", "Date de Paiement" },
                { "ReceivedDate", "Date de Réception" },
                { "Category", "Catégorie" },
                { "Account", "Compte" },
                { "Status", "Statut" },
                { "Actions", "Actions" }
            };
        }
    }
}
