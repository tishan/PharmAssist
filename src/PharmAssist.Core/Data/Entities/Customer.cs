
	namespace PharmAssist.Core.Data.Entities
{
	/// <summary>
	/// The customer entity.
	/// </summary>
	public class Customer: EntityBase
	{
		/// <summary>
		/// Gets or sets the customer name.
		/// </summary>
		public string CustomerName
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the customer bussiness name.
		/// </summary>
		public string CutomerBussinessName
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets customer twon.
		/// </summary>
		public string  Town
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the address.
		/// </summary>
		public string Address
		{
			get;
			set;
		}

		public string Telephone
		{
			get;
			set;
		}

		public string Mobile
		{
			get;
			set;
		}

		public string Email
		{
			get;
			set;
		}

		public string Comments
		{
			get;
			set;
		}
	}
}
