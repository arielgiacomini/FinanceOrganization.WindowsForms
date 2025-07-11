﻿using App.Forms.Services.Output;

namespace App.WindowsForms.Services.Output
{
    public class SearchAccountOutput
    {
        public int Quantidade { get; set; } = 0;
        public IList<SearchAccountData> Data { get; set; } = new List<SearchAccountData>();
        public Dictionary<string, string> Validations { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> Errors { get; set; } = new Dictionary<string, string>();
        public OutputStatus Status { get; set; }
        public string? Message { get; set; }
    }

    public class SearchAccountData
    {
        /// <summary>
        /// Identificador único da conta
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Descrição da Conta
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Dia de Vencimento
        /// </summary>
        public int? DueDate { get; set; }
        /// <summary>
        /// Dia de Fechamento
        /// </summary>
        public int? ClosingDay { get; set; }
        /// <summary>
        /// Considera Pago?
        /// </summary>
        public bool? ConsiderPaid { get; set; }
        /// <summary>
        /// Identificador Número da Agência da Conta
        /// </summary>
        public string? AccountAgency { get; set; }
        /// <summary>
        /// Identificador Número da Conta
        /// </summary>
        public string? AccountNumber { get; set; }
        /// <summary>
        /// Identificador Digito da Conta
        /// </summary>
        public string? AccountDigit { get; set; }
        /// <summary>
        /// Por segurança contém apenas os últimos 4 digitos do cartão de crédito
        /// </summary>
        public string? CardNumber { get; set; }
        /// <summary>
        /// Caso o tipo de conta for de recebimento de comissão, aqui fica o % de comissão que será cálculado e recebido.
        /// </summary>
        public decimal? CommissionPercentage { get; set; }
        /// <summary>
        /// Indica se o registro ativo
        /// </summary>
        public bool Enable { get; set; }
        /// <summary>
        /// Data de criação do registro
        /// </summary>
        public DateTime CreationDate { get; set; }
        /// <summary>
        /// Data de alteração do registro
        /// </summary>
        public DateTime? LastChangeDate { get; set; }
        /// <summary>
        /// Indica se a conta é Cartão de Crédito
        /// </summary>
        public bool IsCreditCard { get; set; }
        /// <summary>
        /// Traduz as cores vinda do serviço de contas
        /// </summary>
        public CollorAccount? Colors { get; set; } = new CollorAccount();
    }

    public class CollorAccount
    {
        /// <summary>
        /// Id único da cor x conta
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Id da conta
        /// </summary>
        public int AccountId { get; set; }
        /// <summary>
        /// Cor predominante do fundo de tela
        /// </summary>
        public string BackgroundColorHexadecimal { get; set; } = "#FFFFFF";
        /// <summary>
        /// Cor predominante dos textos da tela
        /// </summary>
        public string FonteColorHexadecimal { get; set; } = "#000000";
        /// <summary>
        /// Indica se o registro ativo
        /// </summary>
        public bool Enable { get; set; }
        /// <summary>
        /// Data de criação do registro
        /// </summary>
        public DateTime CreationDate { get; set; }
        /// <summary>
        /// Data de alteração do registro
        /// </summary>
        public DateTime? LastChangeDate { get; set; }
    }
}