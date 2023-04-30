namespace CollegeSoftApp.Models
{
	public partial class FeeDetailEdit
	{
		public int DetailId { get; set; }

		public int FeeId { get; set; }
		public int EntryUserId { get; set; }
		public DateTime EntryDate { get; set; }
		public string? EntryTime { get; set; }
		public decimal TotalAmt { get; set; }

		public decimal PaidAmt { get; set; }

		public decimal RemainingAmt { get; set; }

		public string? FeeStatus { get; set; }


		public DateTime PrintDate { get; set; }

		public string? PrintTime { get; set; }

		public int PrintUserId { get; set; }


	}
}
