namespace MJ.Solutions.Pagamento.MJPag
{
	public enum TransactionStatus
	{
		Authorized = 1,
		Paid,
		Refused,
		Chargedback,
		Cancelled
	}
}
