using CapestoneProject.Models;

public enum CardType
{
    Visa,
    MasterCard,
    LocalWallet
}

public class PaymentCard
{
    public int PaymentCardId { get; set; }
    public int UserId { get; set; }
    public string CardNumber { get; set; }
    public string CardHolderName { get; set; }
    public string ExpirationMonth { get; set; }
    public string ExpirationYear { get; set; }
    public string LastFourDigits { get; set; }
    public string CVC { get; set; }
    public bool IsDefault { get; set; }
    public CardType CardType { get; set; } 
    public bool IsActive { get; set; }
    public string? CreatedBy { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }




    public virtual User User { get; set; }
}
