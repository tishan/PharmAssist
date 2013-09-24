
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
		
	}
}
