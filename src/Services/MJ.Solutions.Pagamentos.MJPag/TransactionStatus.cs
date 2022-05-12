namespace MJ.Solutions.Pagamentos.MJPag
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
