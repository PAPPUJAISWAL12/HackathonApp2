namespace CollegeSoftApp.Models
{
	public partial class ReceptionEdit
	{
		public int Rid { get; set; }

		public string? PersonName { get; set; }

		public DateTime EntryDate { get; set; }

		public string? EntryTime { get; set; }

		public string? Purpose { get; set; }

		public string? PersonAddress { get; set; }

		public string? Phone { get; set; }

		public int UserId { get; set; }

		public DateTime CancelledDate { get; set; }

		public int CancelledById { get; set; }

		public string? FiscalYear { get; set; }

		public string? ReceptionStatus { get; set; }
	}
}
